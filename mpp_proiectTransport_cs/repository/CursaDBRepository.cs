using System.Data;
using Common.Logging;
using mpp_proiectTransport_cs.domain;

namespace mpp_proiectTransport_cs.repository;

public class CursaDBRepository : CursaRepository
{
    private static readonly ILog log = LogManager.GetLogger("CursaDbRepository");

    IDbConnection con;

    public CursaDBRepository(IDbConnection con)
    {
        this.con = con;
    }

    public Cursa GetById(long id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from Curse where id_cursa = @id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    String destinatie = dataR.GetString(1);

                    // Assuming the second column is the DATETIME column
                    long unixTimestamp = dataR.GetInt64(2);
                    // Convert Unix timestamp to DateTime
                    DateTime plecare = DateTimeOffset.FromUnixTimeMilliseconds(unixTimestamp).UtcDateTime;

                    Int32 nr_locuri = dataR.GetInt32(3);

                    Cursa cursa = new Cursa(destinatie, plecare, nr_locuri);
                    cursa.id = id;

                    log.InfoFormat("Exiting findOne with value {0}", cursa);
                    return cursa;
                }
            }
        }
        log.InfoFormat("Exiting getById");
        return null;
    }

    public List<Cursa> GetAll()
    {
        List<Cursa> curse = new List<Cursa>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from Curse";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id = dataR.GetInt32(0);
                    String destinatie = dataR.GetString(1);

                    // Assuming the second column is the DATETIME column
                    long unixTimestamp = dataR.GetInt64(2);
                    // Convert Unix timestamp to DateTime
                    DateTime plecare = DateTimeOffset.FromUnixTimeMilliseconds(unixTimestamp).UtcDateTime;

                    Int32 nr_locuri = dataR.GetInt32(3);

                    Cursa cursa = new Cursa(destinatie, plecare, nr_locuri);
                    cursa.id = id;
                    curse.Add(cursa);
                }
            }
        }
        return curse;
    }

    public bool Save(Cursa entity)
    {
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into Curse(destinatie, plecare, nr_locuri)  values (@destinatie, @plecare, @nr_locuri)";
            var paramDestinatie = comm.CreateParameter();
            paramDestinatie.ParameterName = "@destinatie";
            paramDestinatie.Value = entity.destinatie;
            comm.Parameters.Add(paramDestinatie);

            var paramPlecare = comm.CreateParameter();
            paramPlecare.ParameterName = "@plecare";
            paramPlecare.Value = entity.plecare;
            comm.Parameters.Add(paramPlecare);

            var paramLocuri = comm.CreateParameter();
            paramLocuri.ParameterName = "@nr_locuri";
            paramLocuri.Value = entity.nr_locuri;
            comm.Parameters.Add(paramLocuri);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new Exception("No cursa added!");
        }
        return true;
    }

    public bool Delete(long id)
    {
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "delete from Curse where id=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);
            var dataR = comm.ExecuteNonQuery();
            if (dataR == 0)
                throw new Exception("No cursa deleted!");
        }

        return true;
    }

    public bool Update(long id, Cursa entity)
    {
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "update Curse set destinatie = @destinatie, plecare = @plecare, nr_locuri = @nr_locuri where id_cursa=@id";
            var paramDestinatie = comm.CreateParameter();
            paramDestinatie.ParameterName = "@destinatie";
            paramDestinatie.Value = entity.destinatie;
            comm.Parameters.Add(paramDestinatie);

            var paramPlecare = comm.CreateParameter();
            paramPlecare.ParameterName = "@plecare";
            paramPlecare.Value = entity.plecare;
            comm.Parameters.Add(paramPlecare);

            var paramLocuri = comm.CreateParameter();
            paramLocuri.ParameterName = "@nr_locuri";
            paramLocuri.Value = entity.nr_locuri;
            comm.Parameters.Add(paramLocuri);

            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            var dataR = comm.ExecuteNonQuery();
            if (dataR == 0)
                throw new Exception("No cursa updated!");
        }
        return true;
    }
}
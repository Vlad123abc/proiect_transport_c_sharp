using System.Data;
using Common.Logging;
using mpp_proiectTransport_cs.domain;

namespace mpp_proiectTransport_cs.repository;

public class RezervareDBRepository : RezervareRepository
{
    private static readonly ILog log = LogManager.GetLogger("UserDbRepository");

    IDbConnection con;
    public RezervareDBRepository(IDbConnection con)
    {
        this.con = con;
    }

    public Rezervare GetById(long id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from Rezervari where id_rezervare = @id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    String client = dataR.GetString(1);
                    Int32 nr_locuri = dataR.GetInt32(2);
                    long id_cursa = dataR.GetInt32(3);

                    Rezervare rezervare = new Rezervare(client, nr_locuri, id_cursa);
                    rezervare.id = id;

                    log.InfoFormat("Exiting findOne with value {0}", rezervare);
                    return rezervare;
                }
            }
        }
        log.InfoFormat("Exiting getById");
        return null;
    }

    public List<Rezervare> GetAll()
    {
        List<Rezervare> rezervari = new List<Rezervare>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from Rezervari";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id = dataR.GetInt32(0);

                    String client = dataR.GetString(1);
                    Int32 nr_locuri = dataR.GetInt32(2);
                    long id_cursa = dataR.GetInt32(3);

                    Rezervare rezervare = new Rezervare(client, nr_locuri, id_cursa);
                    rezervare.id = id;

                    rezervari.Add(rezervare);
                }
            }
        }
        return rezervari;
    }

    public bool Save(Rezervare entity)
    {

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into Rezervari(client, nr_locuri, id_cursa)  values (@client, @nr_locuri, @id_cursa)";
            var paramClient = comm.CreateParameter();
            paramClient.ParameterName = "@client";
            paramClient.Value = entity.nume_client;
            comm.Parameters.Add(paramClient);

            var paramLocuri = comm.CreateParameter();
            paramLocuri.ParameterName = "@nr_locuri";
            paramLocuri.Value = entity.nr_locuri;
            comm.Parameters.Add(paramLocuri);

            var paramIdCursa = comm.CreateParameter();
            paramIdCursa.ParameterName = "@id_cursa";
            paramIdCursa.Value = entity.id_cursa;
            comm.Parameters.Add(paramIdCursa);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new Exception("No rezervare added!");
        }
        return true;
    }

    public bool Delete(long id)
    {
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "delete from Rezervari where id=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);
            var dataR = comm.ExecuteNonQuery();
            if (dataR == 0)
                throw new Exception("No rezervare deleted!");
        }

        return true;
    }

    public bool Update(long id, Rezervare entity)
    {
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "update Rezervari set client = @client, nr_locuri = @nr_locuri, id_cursa = @id_cursa where id_rezervare=@id";
            var paramClient = comm.CreateParameter();
            paramClient.ParameterName = "@client";
            paramClient.Value = entity.nume_client;
            comm.Parameters.Add(paramClient);

            var paramLocuri = comm.CreateParameter();
            paramLocuri.ParameterName = "@nr_locuri";
            paramLocuri.Value = entity.nr_locuri;
            comm.Parameters.Add(paramLocuri);

            var paramIdCursa = comm.CreateParameter();
            paramIdCursa.ParameterName = "@id_cursa";
            paramIdCursa.Value = entity.id_cursa;
            comm.Parameters.Add(paramIdCursa);

            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            var dataR = comm.ExecuteNonQuery();
            if (dataR == 0)
                throw new Exception("No rezervare updated!");
        }
        return true;
    }
}
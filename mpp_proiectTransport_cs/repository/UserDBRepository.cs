using System.Data;
using mpp_proiectTransport_cs.domain;

using log4net;

namespace mpp_proiectTransport_cs.repository;

public class UserDBRepository : UserRepository
{
    private static readonly ILog log = LogManager.GetLogger("UserDbRepository");

    IDbConnection con;

    public UserDBRepository(IDbConnection conn)
    {
        log.Info("Creating UserDbRepository ");
        this.con = conn;
    }

    public User GetById(long id)
    {
        log.InfoFormat("Entering findOne with value {0}", id);

        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from Users where id_user = @id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            using (var dataR = comm.ExecuteReader())
            {
                if (dataR.Read())
                {
                    String username = dataR.GetString(1);
                    String password = dataR.GetString(2);

                    User user = new User(username, password);
                    user.id = id;


                    log.InfoFormat("Exiting findOne with value {0}", user);
                    return user;
                }
            }
        }
        log.InfoFormat("Exiting findOne with value {0}", null);
        return null;
    }

    public List<User> GetAll()
    {
        List<User> users = new List<User>();
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "select * from Users";

            using (var dataR = comm.ExecuteReader())
            {
                while (dataR.Read())
                {
                    int id = dataR.GetInt32(0);
                    String username = dataR.GetString(1);
                    String password = dataR.GetString(2);
                    User user = new User(username, password);
                    user.id = id;
                    users.Add(user);
                }
            }
        }
        return users;
    }

    public bool Save(User entity)
    {
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "insert into Users(username, password)  values (@username, @password)";
            var paramUsername = comm.CreateParameter();
            paramUsername.ParameterName = "@username";
            paramUsername.Value = entity.username;
            comm.Parameters.Add(paramUsername);

            var paramPassword = comm.CreateParameter();
            paramPassword.ParameterName = "@password";
            paramPassword.Value = entity.password;
            comm.Parameters.Add(paramPassword);

            var result = comm.ExecuteNonQuery();
            if (result == 0)
                throw new Exception("No user added!");
        }
        return true;
    }

    public bool Delete(long id)
    {
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "delete from Users where id_user=@id";
            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);
            var dataR = comm.ExecuteNonQuery();
            if (dataR == 0)
                throw new Exception("No task deleted!");
        }

        return true;
    }

    public bool Update(long id, User entity)
    {
        using (var comm = con.CreateCommand())
        {
            comm.CommandText = "update Users set username = @username, password = @password where id_user=@id";

            var paramUsername = comm.CreateParameter();
            paramUsername.ParameterName = "@username";
            paramUsername.Value = entity.username;
            comm.Parameters.Add(paramUsername);

            var paramPassword = comm.CreateParameter();
            paramPassword.ParameterName = "@password";
            paramPassword.Value = entity.password;
            comm.Parameters.Add(paramPassword);

            IDbDataParameter paramId = comm.CreateParameter();
            paramId.ParameterName = "@id";
            paramId.Value = id;
            comm.Parameters.Add(paramId);

            var dataR = comm.ExecuteNonQuery();
            if (dataR == 0)
                throw new Exception("No user deleted!");
        }
        return true;
    }
}
using System.Data;
using SQLitePCL;

namespace mpp_proiectTransport_cs.repository
{
    public static class DBUtils
    {
        private static IDbConnection instance = null;

        public static IDbConnection getConnection(IDictionary<string, string> props)
        {
            Batteries.Init();
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection(props);
                instance.Open();
                InitializeDatabase(instance);
            }
            return instance;
        }

        private static IDbConnection getNewConnection(IDictionary<string, string> props)
        {
            return ConnectionUtils.ConnectionFactory.getInstance().createConnection(props);
        }

        public static void InitializeDatabase(IDbConnection connection)
        {
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    @"CREATE TABLE IF NOT EXISTS ""Users"" (
	                                    ""id_user""	INTEGER NOT NULL,
	                                    ""username""	TEXT NOT NULL,
	                                    ""password""	TEXT NOT NULL,
	                                    PRIMARY KEY(""id_user"" AUTOINCREMENT)
                                    )";

                comm.ExecuteNonQuery();
            }
            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Curse
                     (
    id_cursa   integer  not null
        constraint Curse_pk
            primary key autoincrement,
    destinatie TEXT     not null,
    plecare    datetime not null,
    nr_locuri  integer  not null
)";

                comm.ExecuteNonQuery();
            }

            using (var comm = connection.CreateCommand())
            {
                comm.CommandText =
                    @"CREATE TABLE IF NOT EXISTS Rezervari
(
    id_rezervare integer not null
        constraint Rezervari_pk
            primary key autoincrement,
    client       TEXT    not null,
    nr_locuri    integer not null,
    id_cursa     integer not null
        constraint Rezervari_Curse_id_cursa_fk
            references Curse
            on update cascade on delete cascade
)";

                comm.ExecuteNonQuery();
            }

        }
    }
}

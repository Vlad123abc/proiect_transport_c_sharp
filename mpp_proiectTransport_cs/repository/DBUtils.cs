using System.Data;
using SQLitePCL;

namespace mpp_proiectTransport_cs.repository
{
    public static class DBUtils
    {
        private static IDbConnection instance = null;
        
        public static IDbConnection getConnection(IDictionary<string,string> props)
        {
            Batteries.Init();
            if (instance == null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection(props);
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection(IDictionary<string,string> props)
        {
            return ConnectionUtils.ConnectionFactory.getInstance().createConnection(props);
        }
    }
}
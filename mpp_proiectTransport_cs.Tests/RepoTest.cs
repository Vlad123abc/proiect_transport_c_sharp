using System.Configuration;
using log4net.Config;
using mpp_proiectTransport_cs.repository;

namespace mpp_proiectTransport_cs.Tests;

public class RepoTest
{
    IDictionary<String, string> props;

    private void setup()
    {
        XmlConfigurator.Configure();
        Console.WriteLine("Configuration Settings for mpp_transport_db_2 {0}",GetConnectionStringByName("TransportDB"));
        IDictionary<String, string> props = new SortedList<String, String>();
        props.Add("ConnectionString", GetConnectionStringByName("TransportDB"));
    }
    
    static string GetConnectionStringByName(string name)
    {
        // Assume failure.
        string returnValue = null;

        // Look for the name in the connectionStrings section.
        ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

        // If found, return the connection string.
        if (settings != null)
            returnValue = settings.ConnectionString;

        return returnValue;
    }
    
    [Fact]
    public void UsersAddedWillShowUpInRepo()
    {
        setup();
        //UserDBRepository userDbRepository = new UserDBRepository(props);
        
        //Assert.Equal(userDbRepository.GetById(1).username.Equals("vlad"));
        //Assert.
    }
}
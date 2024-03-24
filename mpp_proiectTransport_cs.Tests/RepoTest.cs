using System.Configuration;
using log4net.Config;
using mpp_proiectTransport_cs.domain;
using mpp_proiectTransport_cs.repository;

namespace mpp_proiectTransport_cs.Tests;

public class RepoTest
{
    IDictionary<String, string> props  = new SortedList<String, String>();


    private void setup()
    {
        props.Add("ConnectionString", "Filename=:memory:");
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
        var conn = DBUtils.getConnection(props);
        UserDBRepository userDbRepository = new UserDBRepository(conn);
        User vlad = new User (username: "vlad", password: "secretpass");
        userDbRepository.Save(vlad);

        Assert.Equal("vlad", userDbRepository.GetById(1).username);
        //Assert.
    }
}
using System.Configuration;
using log4net.Config;
using mpp_proiectTransport_cs.domain;
using mpp_proiectTransport_cs.repository;

namespace mpp_proiectTransport_cs.Tests;

public class RepoTest
{
    IDictionary<String, string> props  = new SortedList<String, String>();
    
    [Fact]
    public void UsersAddedWillShowUpInRepo()
    {
        props.Add("ConnectionString", "Filename=:memory:");
        var conn = DBUtils.getConnection(props);
        
        UserDBRepository userDbRepository = new UserDBRepository(conn);
        
        User vlad = new User (username: "vlad", password: "secretpass");
        userDbRepository.Save(vlad);

        Assert.Equal("vlad", userDbRepository.GetById(1).username);
        Assert.Equal("secretpass", userDbRepository.GetById(1).password);

        userDbRepository.Update(1, new User("new", "new"));
        Assert.Equal("new", userDbRepository.GetById(1).username);
        
        Assert.Single(userDbRepository.GetAll());

        userDbRepository.Delete(1);
        Assert.Empty(userDbRepository.GetAll());
    }
}
using System.Configuration;
using log4net.Config;
using mpp_proiectTransport_cs.domain;
using mpp_proiectTransport_cs.repository;
using Xunit.Abstractions;

namespace mpp_proiectTransport_cs.Tests;

public class RepoTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    IDictionary<String, string> props  = new SortedList<String, String>();

    public RepoTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void UsersTest()
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
    
    [Fact]
    public void CursaTest()
    {
        props.Add("ConnectionString", "Filename=:memory:");
        var conn = DBUtils.getConnection(props);

        CursaDBRepository cursaDbRepository = new CursaDBRepository(conn);

        DateTime dateTime = DateTime.Now;
        dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, 0, dateTime.Kind);
        Cursa cursa = new Cursa("cluj", dateTime, 10);
        cursaDbRepository.Save(cursa);
        
        Assert.Equal("cluj", cursaDbRepository.GetById(1).destinatie);
        Assert.Equal(dateTime, cursaDbRepository.GetById(1).plecare);
        Assert.Equal(10, cursaDbRepository.GetById(1).nr_locuri);

        dateTime = DateTime.Now;
        dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, 0, dateTime.Kind);
        cursaDbRepository.Update(1, new Cursa("update", dateTime, 11));
        Assert.Equal("update", cursaDbRepository.GetById(1).destinatie);
        Assert.Equal(dateTime, cursaDbRepository.GetById(1).plecare);
        Assert.Equal(11, cursaDbRepository.GetById(1).nr_locuri);

        Assert.Single(cursaDbRepository.GetAll());

        cursaDbRepository.Delete(1);
        Assert.Empty(cursaDbRepository.GetAll());
    }
    
    [Fact]
    public void RezervareTest()
    {
        props.Add("ConnectionString", "Filename=:memory:");
        var conn = DBUtils.getConnection(props);
        
        CursaDBRepository cursaDbRepository = new CursaDBRepository(conn);
        DateTime dateTime = DateTime.Now;
        dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, 0, dateTime.Kind);
        cursaDbRepository.Save(new Cursa("cluj", dateTime, 20));
        RezervareDBRepository rezervareDbRepository = new RezervareDBRepository(conn);
        
        Rezervare rezervare = new Rezervare("vlad", 2, 1);
        rezervareDbRepository.Save(rezervare);
        
        Assert.Equal("vlad", rezervareDbRepository.GetById(1).nume_client);
        Assert.Equal(2, rezervareDbRepository.GetById(1).nr_locuri);
        Assert.Equal(1, rezervareDbRepository.GetById(1).id_cursa);

        rezervareDbRepository.Update(1, new Rezervare("update", 3, 1));
        Assert.Equal("update", rezervareDbRepository.GetById(1).nume_client);
        Assert.Equal(3, rezervareDbRepository.GetById(1).nr_locuri);
        Assert.Equal(1, rezervareDbRepository.GetById(1).id_cursa);

        Assert.Single(rezervareDbRepository.GetAll());
        rezervareDbRepository.Delete(1);
        Assert.Empty(rezervareDbRepository.GetAll());
    }
}
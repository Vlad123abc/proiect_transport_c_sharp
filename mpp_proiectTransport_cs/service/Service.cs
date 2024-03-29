using mpp_proiectTransport_cs.repository;

namespace mpp_proiectTransport_cs.service;

public class Service
{
    private UserDBRepository UserDbRepository;
    private CursaDBRepository CursaDbRepository;
    private RezervareDBRepository RezervareDbRepository;

    public Service(UserDBRepository userDbRepository, CursaDBRepository cursaDbRepository, RezervareDBRepository rezervareDbRepository)
    {
        UserDbRepository = userDbRepository;
        CursaDbRepository = cursaDbRepository;
        RezervareDbRepository = rezervareDbRepository;
    }

    public bool Login(string username, string password)
    {
        foreach (var user in this.UserDbRepository.GetAll())
        {
            if (user.username == username && user.password == password)
                return true;
        }
        return false;
    }
}
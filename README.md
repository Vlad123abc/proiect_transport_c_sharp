i need to implement the networking part of the c# client server app

i would prefer that the client worker and the server proxy communicate trough rpc (same as the java - for better understanding) or even better, trough jsons (it will be easyer to implement next lab - java server + c# client or the other way around)

IService:

public interface IService
{
    bool login(string username, string password, IObserver client);

    List<Cursa> getAllCurse();

    Cursa cauta_cursa(string destinatie, DateTime data);

    List<Tuple<int, string>> generareListaLocuriCursa(Cursa cursa);

    void rezerva(string client, int nr, string destinatie, DateTime plecare);
}

IObserver:

public interface IObserver
{
    void rezervare(Rezervare rezervare);
}


ClientWorker is an IObserver (Server side)
ServerProxy is an IService (Client Side)

they must communicate trough requests and responses.






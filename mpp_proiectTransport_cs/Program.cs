﻿using System.Configuration;
using log4net.Config;
using mpp_proiectTransport_cs.domain;
using mpp_proiectTransport_cs.repository;

class MainClass
{
    public static void Main(string[] args)
    {
        //configurare jurnalizare folosind log4net
        // XmlConfigurator.Configure(new System.IO.FileInfo("/ConnectionUtils/db.config"));
        XmlConfigurator.Configure();
        Console.WriteLine("Configuration Settings for mpp_transport_db_2 {0}",GetConnectionStringByName("TransportDB"));
        IDictionary<String, string> props = new SortedList<String, String>();
        props.Add("ConnectionString", GetConnectionStringByName("TransportDB"));
        
        Console.WriteLine("User Repository DB ...");
        UserDBRepository userDbRepository = new UserDBRepository(props);
        Console.WriteLine("Curse Repository DB ...");
        CursaDBRepository cursaDbRepository = new CursaDBRepository(props);
        Console.WriteLine("Rezervari Repository DB ...");
        RezervareDBRepository rezervareDbRepository = new RezervareDBRepository(props);
        
        Console.WriteLine(userDbRepository.GetById(1).username);
        Console.WriteLine(cursaDbRepository.GetById(1).destinatie);
        Console.WriteLine(rezervareDbRepository.GetById(1).nume_client);
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
}

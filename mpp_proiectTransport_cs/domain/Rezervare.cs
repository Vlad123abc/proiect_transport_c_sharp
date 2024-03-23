namespace mpp_proiectTransport_cs.domain;

public class Rezervare : Entity<long>
{
    private string nume_client;
    private int nr_locuri;
    private long id_cursa;

    public Rezervare(string numeClient, int nrLocuri, long idCursa)
    {
        nume_client = numeClient;
        nr_locuri = nrLocuri;
        id_cursa = idCursa;
    }

    public string Nume_client
    {
        get { return nume_client; }
        set { nume_client = value; }
    }

    public int Nr_locuri
    {
        get { return nr_locuri; }
        set { nr_locuri = value; }
    }

    public long Id_cursa
    {
        get { return id_cursa; }
        set { id_cursa = value; }
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;
        if (!base.Equals(obj)) return false;
        Rezervare rezervare = (Rezervare)obj;
        return nume_client == rezervare.nume_client && nr_locuri == rezervare.nr_locuri && id_cursa == rezervare.id_cursa;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), nume_client, nr_locuri, id_cursa);
    }

    public override string ToString()
    {
        return $"Rezervare{{nume_client='{nume_client}', nr_locuri={nr_locuri}, id_cursa={id_cursa}, id={id}}}";
    }
}
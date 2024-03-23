namespace mpp_proiectTransport_cs.domain;

public class Cursa : Entity<long>
{
    private string destinatie;
    private DateTime plecare;
    private int nr_locuri;

    public Cursa(string destinatie, DateTime plecare, int nrLocuri): base(1)
    {
        this.destinatie = destinatie;
        this.plecare = plecare;
        nr_locuri = nrLocuri;
    }

    public string Destinatie
    {
        get { return destinatie; }
        set { destinatie = value; }
    }

    public DateTime Plecare
    {
        get { return plecare; }
        set { plecare = value; }
    }

    public int Nr_locuri
    {
        get { return nr_locuri; }
        set { nr_locuri = value; }
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;
        if (!base.Equals(obj)) return false;
        Cursa cursa = (Cursa)obj;
        return destinatie == cursa.destinatie && plecare == cursa.plecare && nr_locuri == cursa.nr_locuri;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), destinatie, plecare, nr_locuri);
    }

    public override string ToString()
    {
        return $"Cursa{{destinatie='{destinatie}', plecare={plecare}, nr_locuri={nr_locuri}, id={id}}}";
    }
}
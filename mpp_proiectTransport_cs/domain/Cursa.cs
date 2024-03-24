namespace mpp_proiectTransport_cs.domain;

public class Cursa : Entity<long>
{
    public Cursa(string destinatie, DateTime plecare, int nrLocuri)
    {
        this.destinatie = destinatie;
        this.plecare = plecare;
        nr_locuri = nrLocuri;
    }
    
    public string destinatie
    {
        get;
        set;
    }

    public DateTime plecare
    {
        get;
        set;
    }

    public int nr_locuri
    {
        get;
        set;
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
        return "";
        //return $"Cursa{{destinatie='{destinatie}', plecare={plecare}, nr_locuri={nr_locuri}, id={id}}}";
    }
}
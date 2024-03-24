namespace mpp_proiectTransport_cs.domain;

public class Entity<ID>
{
    public ID? id
    {
        get;
        set;
    }
    
    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;
        Entity<ID> entity = (Entity<ID>)obj;
        return Equals(id, entity.id);
    }

    public override int GetHashCode()
    {
        return id != null ? id.GetHashCode() : 0;
    }

    public override string ToString()
    {
        return $"Entity{{id={id}}}";
    }
}
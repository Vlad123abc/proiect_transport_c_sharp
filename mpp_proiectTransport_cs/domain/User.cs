namespace mpp_proiectTransport_cs.domain;

public class User : Entity<long>
{
    public User(string username, string password)
    {
        this.username = username;
        this.password = password;
    }
    
    public string username
    {
        get;
        set;
    }

    public string password
    {
        get;
        set;
    }
    
    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;
        if (!base.Equals(obj)) return false;
        User user = (User)obj;
        return username == user.username && password == user.password;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), username, password);
    }

    public override string ToString()
    {
        return "";
        //return $"User{{username='{username}', password='{password}', id={id}}}";
    }
}
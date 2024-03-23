namespace mpp_proiectTransport_cs.domain;

public class User : Entity<long>
{
    private string username;
    private string password;

    public User(string username, string password): base(1)
    {
        this.username = username;
        this.password = password;
    }

    public string Username
    {
        get { return username; }
        set { username = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
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
        // return "pulamee";
        return $"User{{username='{username}', password='{password}', id={id}}}";
    }
}
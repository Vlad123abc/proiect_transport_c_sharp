using mpp_proiectTransport_cs.domain;

namespace mpp_proiectTransport_cs.validators;

public class Validator
{
    public static void ValideazaUser(User user)
    {
        string errors = "";

        if (user.username == "")
            errors += "Username vid!";

        if (user.password.Length < 5)
            errors += "Parola prea scurta (minim 5 caractere)!";

        if (!string.IsNullOrEmpty(errors))
            throw new InvalidOperationException(errors);
    }

    public static void ValideazaCursa(Cursa cursa)
    {
        string errors = "";

        if (cursa.destinatie == "")
            errors += "Destinatie nula!";

        if (!string.IsNullOrEmpty(errors))
            throw new InvalidOperationException(errors);
    }

    public static void ValideazaRezervare(Rezervare rezervare)
    {
        string errors = "";

        if (rezervare.nume_client == "")
            errors += "Nume client nul!";

        if (rezervare.nr_locuri == 0)
            errors += "Trebuie sa rezervati minim 1 loc!";

        if (!string.IsNullOrEmpty(errors))
            throw new InvalidOperationException(errors);
    }
}
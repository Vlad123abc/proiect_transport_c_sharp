using mpp_proiectTransport_cs.domain;

namespace mpp_proiectTransport_cs.validators;

public class Validator
{
    public static void ValideazaUser(User user)
    {
        string errors = "";

        if (user.Username == "")
            errors += "Username vid!";

        if (user.Password.Length < 5)
            errors += "Parola prea scurta (minim 5 caractere)!";

        if (!string.IsNullOrEmpty(errors))
            throw new InvalidOperationException(errors);
    }

    public static void ValideazaCursa(Cursa cursa)
    {
        string errors = "";

        if (cursa.Destinatie == "")
            errors += "Destinatie nula!";

        if (!string.IsNullOrEmpty(errors))
            throw new InvalidOperationException(errors);
    }

    public static void ValideazaRezervare(Rezervare rezervare)
    {
        string errors = "";

        if (rezervare.Nume_client == "")
            errors += "Nume client nul!";

        if (rezervare.Nr_locuri == 0)
            errors += "Trebuie sa rezervati minim 1 loc!";

        if (!string.IsNullOrEmpty(errors))
            throw new InvalidOperationException(errors);
    }
}
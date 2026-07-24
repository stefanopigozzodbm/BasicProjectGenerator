using System;
using System.Linq;

public class IpSubnet
{
    public string FullIp { get; }
    public int Octet1 { get; }
    public int Octet2 { get; }
    public int Octet3 { get; }
    public int Octet4 { get; }

    public IpSubnet(string ipAddress)
    {
        if (string.IsNullOrWhiteSpace(ipAddress))
            throw new ArgumentNullException(nameof(ipAddress), "L'indirizzo IP non può essere vuoto.");

        var parts = ipAddress.Split('.');
        if (parts.Length != 4)
            throw new ArgumentException("Formato IP non valido. Sono richiesti 4 ottetti separati da punti.", nameof(ipAddress));

        // Parsing e verifica dei singoli ottetti
        if (!int.TryParse(parts[0], out var o1) || o1 < 0 || o1 > 255 ||
            !int.TryParse(parts[1], out var o2) || o2 < 0 || o2 > 255 ||
            !int.TryParse(parts[2], out var o3) || o3 < 0 || o3 > 255 ||
            !int.TryParse(parts[3], out var o4) || o4 < 0 || o4 > 255)
        {
            throw new ArgumentException("Gli ottetti devono essere numeri compresi tra 0 e 255.", nameof(ipAddress));
        }

        FullIp = ipAddress;
        Octet1 = o1;
        Octet2 = o2;
        Octet3 = o3;
        Octet4 = o4;
    }

    /// <summary>
    /// Restituisce l'IP completo (es. "10.0.0.1")
    /// </summary>
    public string GetFullIp() => FullIp;

    /// <summary>
    /// Restituisce la stringa senza l'ultimo ottetto, ma lasciando il punto finale (es. "10.0.0.")
    /// </summary>
    public string GetSubnetPrefixWithDot()
    {
        return $"{Octet1}.{Octet2}.{Octet3}.";
    }

    /// <summary>
    /// Restituisce gli ottetti separati come tupla di interi (o1, o2, o3, o4)
    /// </summary>
    public (int First, int Second, int Third, int Fourth) GetOctets()
    {
        return (Octet1, Octet2, Octet3, Octet4);
    }
}

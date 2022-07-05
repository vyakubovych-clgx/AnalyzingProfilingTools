using System.Security.Cryptography;

Console.WriteLine(GeneratePasswordHashUsingSalt("password",
    new byte[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15}));
Console.ReadLine();

string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
{

    var iterate = 10000;
    using var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
    byte[] hash = pbkdf2.GetBytes(20);

    byte[] hashBytes = new byte[36];
    for (int i = 0; i < 16; i++)
        hashBytes[i] = salt[i];
    for (int i = 0; i < 20; i++)
        hashBytes[16 + i] = hash[i];

    var passwordHash = Convert.ToBase64String(hashBytes);

    return passwordHash;

}

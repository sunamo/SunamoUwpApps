namespace apps.Secure;

using System;
using System.Security.Cryptography;
using System.Text;

public static class StringSecurityHelper
{
    private static readonly byte[] entropy = Encoding.Unicode.GetBytes("5ID'&mc %sJo@lGtbi%n!G^ fiVn8 *tNh3eB %rDaVijn!.c b");

    public static CryptDelegates CreateCryptDelegates()
    {
        CryptDelegates cryptDelegates = new CryptDelegates();
        cryptDelegates.decryptString = DecryptString;
        cryptDelegates.encryptString = EncryptString;
        return cryptDelegates;
    }

    /// <summary>
    /// A1 can be null
    /// </summary>
    /// <param name="salt"></param>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string EncryptString(string salt,  string input)
    {
        if (input == null)
        {
            return null;
        }

        byte[] encryptedData = ProtectedData.Protect(Encoding.Unicode.GetBytes(input), entropy, DataProtectionScope.CurrentUser);

        return Convert.ToBase64String(encryptedData);
    }

    /// <summary>
    /// A1 can be null
    /// </summary>
    /// <param name="salt"></param>
    /// <param name="encryptedData"></param>
    /// <returns></returns>
    public static string DecryptString(string salt, string encryptedData)
    {
        if (encryptedData == null)
        {
            return null;
        }

        try
        {
            byte[] decryptedData = ProtectedData.Unprotect(Convert.FromBase64String(encryptedData), entropy, DataProtectionScope.CurrentUser);

            return Encoding.Unicode.GetString(decryptedData);
        }
        catch
        {
            return null;
        }
    }
}

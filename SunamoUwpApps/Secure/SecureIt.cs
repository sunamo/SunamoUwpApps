namespace apps.Secure;

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Represents the secure it type.
/// </summary>
public static class SecureIt
{
    private static readonly byte[] entropy = Encoding.Unicode.GetBytes("Salt Is Not A Password");

    /// <summary>
    /// Encrypt string.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>The encrypt string result.</returns>
    public static string EncryptString(this SecureString input)
    {
        if (input == null)
        {
            return null;
        }

        var encryptedData = ProtectedData.Protect(
            Encoding.Unicode.GetBytes(input.ToInsecureString()),
            entropy,
            DataProtectionScope.CurrentUser);

        return Convert.ToBase64String(encryptedData);
    }

    /// <summary>
    /// Decrypt string.
    /// </summary>
    /// <param name="encryptedData">The encrypted data.</param>
    /// <returns>The decrypt string result.</returns>
    public static SecureString DecryptString(this string encryptedData)
    {
        if (encryptedData == null)
        {
            return null;
        }

        try
        {
            var decryptedData = ProtectedData.Unprotect(
                Convert.FromBase64String(encryptedData),
                entropy,
                DataProtectionScope.CurrentUser);

            return Encoding.Unicode.GetString(decryptedData).ToSecureString();
        }
        catch
        {
            return new SecureString();
        }
    }

    /// <summary>
    /// To secure string.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>The to secure string result.</returns>
    public static SecureString ToSecureString(this IEnumerable<char> input)
    {
        if (input == null)
        {
            return null;
        }

        var secure = new SecureString();

        foreach (var character in input)
        {
            secure.AppendChar(character);
        }

        secure.MakeReadOnly();
        return secure;
    }

    /// <summary>
    /// To insecure string.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns>The to insecure string result.</returns>
    public static string ToInsecureString(this SecureString input)
    {
        if (input == null)
        {
            return null;
        }

        var ptr = Marshal.SecureStringToBSTR(input);

        try
        {
            return Marshal.PtrToStringBSTR(ptr);
        }
        finally
        {
            Marshal.ZeroFreeBSTR(ptr);
        }
    }
}

﻿using System.Security.Cryptography;
using System.Text;

namespace SGDP.PLUS.Comun.General;

public class SegMD5 : IDisposable
{
    readonly MD5 md5Hash;

    public SegMD5()
    {
        md5Hash = MD5.Create();
    }

    public void Dispose()
    {
        md5Hash.Dispose();
    }

    public string GetMd5Hash(string input)
    {
        // Convert the input string to a byte array and compute the hash.
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data 
        // and format each one as a hexadecimal string.
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string.
        return sBuilder.ToString();

    }

    // Verify a hash against a string.
    public bool VerifyMd5Hash(string input, string hash)
    {
        // Hash the input.
        string hashOfInput = GetMd5Hash(input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
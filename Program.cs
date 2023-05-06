/*

    Leeremos un fichero, el fichero será hasheado por sus campos
    y luego serializado a un json
    Author: Bac.

*/

using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Hash
{
    class HashString
    {
        static void Main(string[] args)
        {
            string sSourceData;
            byte[] tmpSource;
            byte[] tmpHash;

            sSourceData = "Hola esto es una prueba";

            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);

            // We calculate the MD5 hash for the input data.
            // Calling ComputeHash on an instance of Md5CryptoServiceProvider.
            // tmpHash now contains the calculated hash value, which is 16 bytes.
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            byte[] tmpNewHash;
            byte[] tmpNewSource;

            sSourceData = "Aqui cambiamos el valor";
            tmpNewSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
            tmpNewHash = new MD5CryptoServiceProvider().ComputeHash(tmpNewSource);

            // Here we will compare both byte arrays to see if they are equal or not.
            bool bEqual = false;
            if (tmpNewHash.Length == tmpHash.Length)
            {
                int i = 0;
                while ((i < tmpNewHash.Length) && (tmpNewHash[i] == tmpHash[i]))
                {
                    i += 1;
                }
                if (i == tmpNewHash.Length)
                {
                    bEqual = true;
                }
            }

            if (bEqual)
                Console.WriteLine("The two hash values are the same");
            else
                Console.WriteLine("The two hash values are not the same");
            Console.ReadLine();
        }
    }
}


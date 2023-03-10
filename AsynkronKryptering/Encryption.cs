using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AsynkronKryptering
{
    internal class Encryption
    {
        public byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        public string HexPrint(string text)
        {
            byte[] ba = Encoding.Default.GetBytes(text);
            var hexString = BitConverter.ToString(ba);
            return hexString;
        }

        public byte[] Encrypt(byte[] dataToEncrypt, string exponentInput, string modulusInput)
        {
            byte[] cipherbytes;
            RSAParameters rsaParameters = new RSAParameters();
            byte[] exponent = FromHex(exponentInput);
            byte[] modulus = FromHex(modulusInput);
            rsaParameters.Exponent = exponent;
            rsaParameters.Modulus = modulus;
            CspParameters csp = new CspParameters();
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048, csp);
            rsa.ImportParameters(rsaParameters);
            cipherbytes = rsa.Encrypt(dataToEncrypt, false);

            return cipherbytes;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CodeezTech.POS.CommonProject
{
    public class CryptoEngine
    {
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            string _base64String = string.Empty;
            byte[] _keyArray;
            byte[] _toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            string _key = "codeeztech";
            if (useHashing)
            {
                MD5CryptoServiceProvider _hashMD5 = new MD5CryptoServiceProvider();
                _keyArray = _hashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
                _hashMD5.Clear();
            }
            else
            {
                _keyArray = UTF8Encoding.UTF8.GetBytes(_key);
            }

            TripleDESCryptoServiceProvider _tripleDesServiceProvider = new TripleDESCryptoServiceProvider();
            _tripleDesServiceProvider.Key = _keyArray;
            _tripleDesServiceProvider.Mode = CipherMode.ECB;
            _tripleDesServiceProvider.Padding = PaddingMode.PKCS7;

            ICryptoTransform _cryptoTransform = _tripleDesServiceProvider.CreateEncryptor();
            byte[] _resultArray = _cryptoTransform.TransformFinalBlock(_toEncryptArray, 0, _toEncryptArray.Length);
            _tripleDesServiceProvider.Clear();
            _base64String = Convert.ToBase64String(_resultArray, 0, _resultArray.Length);

            return _base64String;
        }
        public static string Decrypt(string cipherString, bool useHashing)
        {
            string _decryptString = string.Empty;
            byte[] _keyArray;
            byte[] _toEncryptArray = Convert.FromBase64String(cipherString);
            string _key = "codeeztech";
            if (useHashing)
            {
                MD5CryptoServiceProvider _hashMD5 = new MD5CryptoServiceProvider();
                _keyArray = _hashMD5.ComputeHash(UTF8Encoding.UTF8.GetBytes(_key));
                _hashMD5.Clear();
            }
            else
            {
                _keyArray = UTF8Encoding.UTF8.GetBytes(_key);
            }
            TripleDESCryptoServiceProvider _tripleDesServiceProvider = new TripleDESCryptoServiceProvider();
            _tripleDesServiceProvider.Key = _keyArray;
            _tripleDesServiceProvider.Mode = CipherMode.ECB;
            _tripleDesServiceProvider.Padding = PaddingMode.PKCS7;

            ICryptoTransform _cryptoTransform = _tripleDesServiceProvider.CreateEncryptor();
            byte[] _resultArray = _cryptoTransform.TransformFinalBlock(_toEncryptArray, 0, _toEncryptArray.Length);
            _tripleDesServiceProvider.Clear();

            _decryptString = UTF8Encoding.UTF8.GetString(_resultArray);

            return _decryptString;
        }
    }
}

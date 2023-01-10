using System.Security.Cryptography;
public static class StringExtensions{
    public static string ToSqlSafeString(this string message){
        return message.Replace("'", "''");
    }

    public static string Truncate(this string s, int length){
        if(s.Length<length)
            return s;
        return s.Substring(0, length);
    }

    public static string Encrypt(this string input)
        {
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            Aes aesManaged = Aes.Create();
            aesManaged.Key = UTF8.GetBytes(AppConfig.EncryptionKey);
            aesManaged.Mode = CipherMode.ECB;
            aesManaged.Padding = PaddingMode.PKCS7;
            ICryptoTransform crypt = aesManaged.CreateEncryptor();
            byte[] plain = UTF8.GetBytes(input);
            byte[] cipher = crypt.TransformFinalBlock(plain, 0, plain.Length);
            return Convert.ToBase64String(cipher);
            
        }
}
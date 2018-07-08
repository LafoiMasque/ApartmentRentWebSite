using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LafoiApp.Common.SecurityEncrypt
{
	/// <summary>
	/// DES AES Blowfish
	///  对称加密算法的优点是速度快，
	///  缺点是密钥管理不方便，要求共享密钥。
	/// 可逆对称加密  密钥长度8
	/// </summary>
	public class DesEncrypt
	{
		//8位长度
		private static string m_key = "desEncrypt";
		private static byte[] m_rgbKey = null;
		private static byte[] m_rgbIV = null;
		
		public static void SetEncryptKey(string key)
		{
			if (!string.IsNullOrEmpty(key) && key.Length > 7)
			{
				m_key = key;
				m_rgbKey = Encoding.ASCII.GetBytes(m_key.Substring(0, 8));
				m_rgbIV = Encoding.ASCII.GetBytes(m_key.Insert(0, "w").Substring(0, 8));
			}
		}

		/// <summary>
		/// DES 加密
		/// </summary>
		/// <param name="strValue"></param>
		/// <returns></returns>
		public static string Encrypt(string strValue)
		{
			DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
			using (MemoryStream memStream = new MemoryStream())
			{
				CryptoStream crypStream = new CryptoStream(memStream, dsp.CreateEncryptor(m_rgbKey, m_rgbIV), CryptoStreamMode.Write);
				StreamWriter sWriter = new StreamWriter(crypStream);
				sWriter.Write(strValue);
				sWriter.Flush();
				crypStream.FlushFinalBlock();
				memStream.Flush();
				return Convert.ToBase64String(memStream.GetBuffer(), 0, (int)memStream.Length);
			}
		}

		/// <summary>
		/// DES解密
		/// </summary>
		/// <param name="EncValue"></param>
		/// <returns></returns>
		public static string Decrypt(string EncValue)
		{
			DESCryptoServiceProvider dsp = new DESCryptoServiceProvider();
			byte[] buffer = Convert.FromBase64String(EncValue);

			using (MemoryStream memStream = new MemoryStream())
			{
				CryptoStream crypStream = new CryptoStream(memStream, dsp.CreateDecryptor(m_rgbKey, m_rgbIV), CryptoStreamMode.Write);
				crypStream.Write(buffer, 0, buffer.Length);
				crypStream.FlushFinalBlock();
				return Encoding.UTF8.GetString(memStream.ToArray());
			}
		}
	}
}


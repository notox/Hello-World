using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Key
{
	class Program
	{
		static bool Validate(string hospitalName, string License)
		{
			string[] licenseCodes = License.Split('-');
			if (licenseCodes.Length != 8)
				return false;

			byte[] bHospitalName
				= Encoding.GetEncoding("GB2312").GetBytes(string.Format("sym{0}biont", hospitalName));
			HashAlgorithm hash = HashAlgorithm.Create("MD5");
			byte[] hashCode = hash.ComputeHash(bHospitalName);

			try
			{
				for (int i = 0; i < hashCode.Length; i++)
				{
					byte b = byte.Parse(licenseCodes[i++ / 2], System.Globalization.NumberStyles.HexNumber);
					if (b != hashCode[i - 1])
						return false;

				}
			}
			catch (Exception e)
			{
				return false;
			}
			return true;
		}

		static void Main(string[] args)
		{
			string hospitalName = "医院名称";
			string License = "f8-e9-24-e6-df-f5-73-22";

			byte[] bHospitalName
				= Encoding.GetEncoding("GB2312").GetBytes(string.Format("sym{0}biont", hospitalName));
			HashAlgorithm hash = HashAlgorithm.Create("MD5");
			byte[] hashCode = hash.ComputeHash(bHospitalName);

			for (int i = 0; i < hashCode.Length; i++)
			{
				Console.Write(Convert.ToString(hashCode[i++], 16));
			}

			if (Validate(hospitalName, License))
			{
				Console.Write("OK");
			}

			Console.ReadKey();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LafoiApp.Common.UtilityClass
{
	public static class AnyRadixConvert
	{
		#region 基数

		private static readonly char[] m_numchar = new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9'
		};

		private static readonly char[] m_rDigits = new char[]
		{
			'0',
			'1',
			'2',
			'3',
			'4',
			'5',
			'6',
			'7',
			'8',
			'9',
			'A',
			'B',
			'C',
			'D',
			'E',
			'F',
			'G',
			'H',
			'I',
			'J',
			'K',
			'L',
			'M',
			'N',
			'O',
			'P',
			'Q',
			'R',
			'S',
			'T',
			'U',
			'V',
			'W',
			'X',
			'Y',
			'Z'
		};

		#endregion

		/// <summary>
		/// 生成随机数
		/// </summary>
		/// <param name="len">长度</param>
		/// <returns></returns>
		public static string GetRandomNum(int len)
		{
			if (0 >= len)
			{
				return string.Empty;
			}
			Random random = new Random();
			if (len <= 9)
			{
				return random.Next((int)Math.Pow(10.0, (double)(len - 1)), (int)(Math.Pow(10.0, (double)len) - 1.0)).ToString();
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < len; i++)
			{
				stringBuilder.Append(AnyRadixConvert.m_numchar[random.Next(10)]);
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// 将指定基数的数字的 System.String 表示形式转换为等效的 64 位有符号整数。
		/// </summary>
		/// <param name="value">包含数字的 System.String。</param>
		/// <param name="fromBase">value 中数字的基数，它必须是[2,36]</param>
		/// <returns>等效于 value 中的数字的 64 位有符号整数。- 或 - 如果 value 为 null，则为零。</returns>
		private static long StringToLong(string value, int fromBase)
		{
			value = value != null ? value.Trim() : null;
			if (string.IsNullOrEmpty(value))
			{
				return 0L;
			}
			string text = new string(m_rDigits, 0, fromBase);
			long num = 0L;
			value = value.ToUpper();
			for (int i = 0; i < value.Length; i++)
			{
				if (!text.Contains(value[i].ToString()))
				{
					throw new ArgumentException(string.Format("The argument \"{0}\" is not in {1} system.", value[i], fromBase));
				}
				try
				{
					num += (long)Math.Pow((double)fromBase, (double)i) * (long)AnyRadixConvert.GetCharIndex(AnyRadixConvert.m_rDigits, value[value.Length - i - 1]);
				}
				catch
				{
					throw new OverflowException("运算溢出.");
				}
			}
			return num;
		}

		/// <summary>
		/// 获取字符在字符数组的索引号
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		private static int GetCharIndex(char[] arr, char value)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == value)
				{
					return i;
				}
			}
			return 0;
		}

		/// <summary>
		///  long转化为toBase进制
		/// </summary>
		/// <param name="value"></param>
		/// <param name="toBase"></param>
		/// <returns></returns>
		private static string LongToString(long value, int toBase)
		{
			long num = Math.Abs(value);
			char[] array = new char[63];
			int num2 = 0;
			while (num2 <= 64 && num != 0L)
			{
				array[array.Length - num2 - 1] = AnyRadixConvert.m_rDigits[(int)checked((IntPtr)(num % unchecked((long)toBase)))];
				num /= (long)toBase;
				num2++;
			}
			return new string(array, array.Length - num2, num2);
		}

		/// <summary>
		/// 任意进制转换,将fromBase进制表示的value转换为toBase进制
		/// </summary>
		/// <param name="value"></param>
		/// <param name="fromBase">原来进制（2-36进制）</param>
		/// <param name="toBase">转换后的进制（2-36进制）</param>
		/// <returns></returns>
		public static string AryConvert(string value, int fromBase, int toBase)
		{
			if (string.IsNullOrEmpty(value.Trim()))
			{
				return string.Empty;
			}
			if (fromBase < 2 || fromBase > 36)
			{
				throw new ArgumentException(string.Format("The fromBase radix \"{0}\" is not in the range 2..36.", fromBase));
			}
			if (toBase < 2 || toBase > 36)
			{
				throw new ArgumentException(string.Format("The toBase radix \"{0}\" is not in the range 2..36.", toBase));
			}
			return AnyRadixConvert.LongToString(AnyRadixConvert.StringToLong(value, fromBase), toBase);
		}

	}
}

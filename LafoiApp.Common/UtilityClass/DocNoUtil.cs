using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LafoiApp.Common.UtilityClass
{
	public static class DocNoUtil
	{
		/// <summary>
		/// 生成基础资料ID
		/// </summary>
		/// <param name="uctTimeNow">时间</param>
		/// <param name="suffix">后缀只能是由26个字母加数字组成</param>
		/// <param name="fixLen">固定长度</param>
		/// <returns></returns>
		public static string MakeBaseDataId(DateTime uctTimeNow, string suffix, int fixLen)
		{
			Thread.Sleep(1);
			string text = string.Format("{0}{1}", uctTimeNow.Ticks.ToString(), suffix);
			int length = text.Length;
			if (length > fixLen)//大于指定的长度
			{
				text = text.Substring(0, fixLen);
			}
			else if (length < fixLen)//小于指定的长度
			{
				text = string.Format("{0}{1}", text, AnyRadixConvert.GetRandomNum(fixLen - length));
			}
			return text;
		}

		/// <summary>
		/// 组合后缀生成唯一ID  
		/// </summary>
		/// <param name="uctTimeNow">时间</param>
		/// <param name="suffix">后缀只能是由26个字母加数字组成</param>
		/// <param name="fixLen">固定长度</param>
		/// <returns></returns>
		public static string MakeTradeNo(DateTime UctTimeNow, string suffix, int fixLen)
		{
			Thread.Sleep(1);
			if (fixLen < 17)
			{
				fixLen = 17;
			}
			string text = UctTimeNow.ToString("yyMMddHHmmssfffff");
			string str = string.Empty;
			if (!string.IsNullOrEmpty(suffix))
			{
				suffix = RegExMatch.RegexReplace(suffix, "[^A-Za-z0-9]+", "", true);
				try
				{
					str = AnyRadixConvert.AryConvert(suffix, 36, 10);
				}
				catch
				{
					str = string.Empty;
				}
			}
			text += str;
			int length = text.Length;
			if (length > fixLen)//大于指定的长度
			{
				return text.Substring(0, fixLen);
			}
			else if (length < fixLen)//小于指定的长度
			{
				text = string.Format("{0}{1}", text, AnyRadixConvert.GetRandomNum(fixLen - length));
			}
			return text;
		}

	}
}

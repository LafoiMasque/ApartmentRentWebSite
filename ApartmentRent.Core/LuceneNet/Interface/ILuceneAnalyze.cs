using System.Collections.Generic;

namespace ApartmentRent.Core.LuceneNet.Interface
{
	public interface ILuceneAnalyze
	{
		/// <summary>
		/// 根据查询的field将keyword分词
		/// </summary>
		/// <param name="fieldName"></param>
		/// <param name="keyword"></param>
		/// <returns></returns>
		List<string> AnalyzerKey(string fieldName, string keyword);
	}
}
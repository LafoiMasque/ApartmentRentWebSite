﻿using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using LafoiApp.Core.LuceneNet.Model;

namespace LafoiApp.Core.LuceneNet
{
	public static class IndexManager<T>
	{
		private static string m_directoryPath = string.Empty;
		private static IList<FieldDataModel> m_luceneDataModels = null;

		public static Queue<KeyValuePair<T, LuceneTypeEnum>> Queue { get; private set; }

		static IndexManager()
		{
			Queue = new Queue<KeyValuePair<T, LuceneTypeEnum>>();
		}

		public static void InitData(string directoryPath, IList<FieldDataModel> luceneDataModels)
		{
			m_directoryPath = directoryPath;
			m_luceneDataModels = luceneDataModels;
			StartThread();
		}

		/// <summary>
		/// 向队列中添加数据
		/// </summary>
		/// <param name="model"></param>
		public static void AddQueue(T model)
		{
			if (model != null)
			{
				Queue.Enqueue(new KeyValuePair<T, LuceneTypeEnum>(model, LuceneTypeEnum.Add));
			}
		}

		/// <summary>
		/// 要删除的数据
		/// </summary>
		/// <param name="model"></param>
		public static void DeleteQueue(T model)
		{
			if (model != null)
			{
				Queue.Enqueue(new KeyValuePair<T, LuceneTypeEnum>(model, LuceneTypeEnum.Delete));
			}
		}

		/// <summary>
		/// 开始一个线程
		/// </summary>
		private static void StartThread()
		{
			if (m_luceneDataModels != null && m_luceneDataModels.Count > 0)
			{
				Task.Factory.StartNew(WriteIndexContent);
			}
		}

		/// <summary>
		/// 检查队列中是否有数据，如果有数据获取。
		/// </summary>
		private static void WriteIndexContent()
		{
			while (true)
			{
				if (Queue.Count > 0)
				{
					CreateIndexContent();
				}
				else
				{
					System.Threading.Thread.Sleep(3000);
				}
			}
		}

		private static void CreateIndexContent()
		{
			using (FSDirectory directory = FSDirectory.Open(new DirectoryInfo(m_directoryPath), new NativeFSLockFactory()))//指定索引文件(打开索引目录) FS指的是就是FileSystem
			{
				bool isUpdate = IndexReader.IndexExists(directory);//IndexReader:对索引进行读取的类。该语句的作用：判断索引库文件夹是否存在以及索引特征文件是否存在。
				if (isUpdate)
				{
					//同时只能有一段代码对索引库进行写操作。当使用IndexWriter打开directory时会自动对索引库文件上锁。
					//如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁（提示一下：如果我现在正在写着已经加锁了，但是还没有写完，这时候又来一个请求，那么不就解锁了吗？这个问题后面会解决）
					if (IndexWriter.IsLocked(directory))
					{
						IndexWriter.Unlock(directory);
					}
				}

				using (IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, IndexWriter.MaxFieldLength.UNLIMITED))//向索引库中写索引。这时在这里加锁。
				{
					//如果队列中有数据，获取队列中的数据写到Lucene.Net中。
					while (Queue.Count > 0)
					{
						KeyValuePair<T, LuceneTypeEnum> keyValuePair = Queue.Dequeue();
						T model = keyValuePair.Key;
						Type type = model.GetType();
						PropertyInfo propertyInfo = type.GetProperty(m_luceneDataModels[0].PropertyName);
						var propertyValue = propertyInfo.GetValue(model);
						string valueString = propertyValue != null ? propertyValue.ToString() : null;
						writer.DeleteDocuments(new Term(m_luceneDataModels[0].FieldName, valueString));//删除
						if (keyValuePair.Value == LuceneTypeEnum.Delete)
						{
							continue;
						}
						//表示一篇文档。
						Document document = new Document();
						//Field.Store.YES:表示是否存储原值。只有当Field.Store.YES在后面才能用doc.Get("number")取出值来.Field.Index. NOT_ANALYZED:不进行分词保存
						//Field.Index. ANALYZED:进行分词保存:也就是要进行全文的字段要设置分词 保存（因为要进行模糊查询
						//Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS:不仅保存分词还保存分词的距离。
						foreach (FieldDataModel item in m_luceneDataModels)
						{
							propertyInfo = type.GetProperty(item.PropertyName);
							propertyValue = propertyInfo.GetValue(model);
							if (propertyValue != null)
							{
								valueString = propertyValue.ToString();
								IFieldable fieldable = null;
								if (item.FieldType == TypeCode.String)
								{
									fieldable = new Field(item.FieldName, valueString, item.Store, item.Index, item.TermVector);
								}
								else
								{
									NumericField numericField = new NumericField(item.FieldName, item.Store, item.Index == Field.Index.ANALYZED_NO_NORMS);
									switch (item.FieldType)
									{
										case TypeCode.Double:
											numericField.SetDoubleValue(Convert.ToDouble(valueString));
											break;
										case TypeCode.Single:
											numericField.SetFloatValue(Convert.ToSingle(valueString));
											break;
										case TypeCode.Int32:
											numericField.SetIntValue(Convert.ToInt32(valueString));
											break;
										case TypeCode.Int64:
											numericField.SetLongValue(Convert.ToInt64(valueString));
											break;
										default:
											break;
									}
									fieldable = numericField;
								}
								document.Add(fieldable);
							}
						}
						writer.AddDocument(document);
					}
				}//会自动解锁。
			}
		}
	}
}

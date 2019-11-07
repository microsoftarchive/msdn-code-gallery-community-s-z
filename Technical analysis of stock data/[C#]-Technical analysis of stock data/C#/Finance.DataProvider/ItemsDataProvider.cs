using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using Finance.Common;
using Finance.Common.Base;

namespace Finance.DataProvider
{
	public class ItemsDataProvider
	{
		public ItemsDataProvider()
		{
		}

		private Dictionary<String, Element> ConvertToMap(Element[] elements)
		{
			Dictionary<String, Element> result = new Dictionary<String, Element>();

			for (Int32 q = 0; q < elements.Length; q++)
			{
				Element element = elements[q];

				if (!result.ContainsKey(element.Symbol))
				{
					result.Add(element.Symbol, element);
				}
			}

			return result;
		}

		private static T FirstElementOrNull<T>(T[] input) where T : class
		{
			if (input == null)
			{
				return null;
			}

			if (input.Length <= 0)
			{
				return null;
			}

			return input[0];
		}

		public ElementCorrelation UpdateElementCorrelation(String tickerA, String tickerB, CorrelationPeriodType correlationPeriodType, Decimal value)
		{
			Byte correlationPeriodTypeValue = (Byte)correlationPeriodType;

			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				using (TransactionScope transaction = new TransactionScope())
				{
					ElementCorrelation item = FirstElementOrNull<ElementCorrelation>((from er in context.ElementCorrelation
						 where
							 er.PeriodType == correlationPeriodTypeValue &&
							 (er.TickerA == tickerA && er.TickerB == tickerB ||
							 er.TickerA == tickerB && er.TickerB == tickerA)
						 select er).ToArray<ElementCorrelation>());

					if (null != item)
					{
						item.Upd = DateTime.Now;
						item.Correlation = value;

						LoggerFactory.AppLogger.Debug("[ItemsDataProvider.UpdateElementCorrelation] Updating existing item " + item.TickerA + " " + item.TickerB + " " + correlationPeriodType.ToString());
					}
					else
					{
						item = context.ElementCorrelation.CreateObject();
						item.TickerB = tickerB;
						item.TickerA = tickerA;
						item.PeriodType = correlationPeriodTypeValue;
						item.Upd = DateTime.Now;
						item.Correlation = value;

						LoggerFactory.AppLogger.Debug("[ItemsDataProvider.UpdateElementCorrelation] Adding new item " + item.TickerA + " " + item.TickerB + " " + correlationPeriodType.ToString());

						context.ElementCorrelation.AddObject(item);
					}

					context.SaveChanges();

					transaction.Complete();

					return item;
				}
			}
		}

		public ElementMovementDistribution UpdateElementDistribution(String ticker, Int32 rangeId, Byte[] result)
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				using (TransactionScope transaction = new TransactionScope())
				{
					ElementMovementDistribution item = FirstElementOrNull<ElementMovementDistribution>((from er in context.ElementMovementDistributions
																					  where
																						  er.RangeId == rangeId &&
																						  er.Ticker == ticker
																										select er).ToArray<ElementMovementDistribution>());

					if (null != item)
					{
						item.Upd = DateTime.Now;
						item.DistributionData = result;

						LoggerFactory.AppLogger.Debug("[ItemsDataProvider.UpdateElementCorrelation] Updating existing item " + item.Ticker + " " + item.RangeId);
					}
					else
					{
						item = context.ElementMovementDistributions.CreateObject();
						item.Ticker = ticker;
						item.RangeId = rangeId;
						item.Upd = DateTime.Now;
						item.DistributionData = result;

						LoggerFactory.AppLogger.Debug("[ItemsDataProvider.UpdateElementCorrelation] Adding new item " + item.Ticker + " " + item.RangeId);

						context.ElementMovementDistributions.AddObject(item);
					}

					context.SaveChanges();

					transaction.Complete();

					return item;
				}
			}
		}

		public ElementCorrelation[] SelectCorrelationResults(ElementTypeDefs typeA, ElementTypeDefs typeB, CorrelationPeriodType periodType)
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				return context.SelectCorrelationResults((Int16)typeA, (Int16)typeB, (Byte)periodType).ToArray<ElementCorrelation>();
			}
		}

		public DailyData[] LoadItemDailyData(String ticker, DateTime dayFrom, DateTime dayTo)
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				return (from edd in context.DailyDatas where edd.Ticker == ticker && edd.Day >= dayFrom && edd.Day <= dayTo orderby edd.Day ascending select edd).ToArray<DailyData>();
			}
		}

		public DailyData[] LoadItemDailyData(String ticker)
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				return (from edd in context.DailyDatas where edd.Ticker == ticker orderby edd.Day ascending select edd).ToArray<DailyData>();
			}
		}

		public ElementCorrelation[] LoadCalculatedElementCorrelation()
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				return (from ec in context.ElementCorrelation orderby ec.Upd ascending select ec).ToArray<ElementCorrelation>();
			}
		}

		public Element[] GetElementsByType(ElementTypeDefs itemType)
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				if (itemType == ElementTypeDefs.Wszystko)
				{
					return (from e in context.Elements select e).ToArray<Element>();
				}
				else
				{
					return (from e in context.Elements where e.Type == (Int16)itemType select e).ToArray<Element>();
				}
			}
		}

		public Element[] GetElementsForCorrelation()
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				return (from e in context.Elements where e.Type == (Int16)ElementTypeDefs.GPWAkcje /* GPW Akcje */ || e.Type == (Int16)ElementTypeDefs.GPWIndeksy /* GPW Indeksy */ orderby e.Type descending select e).ToArray<Element>();
			}
		}

		public void AddDailyData(String ticker, DailyData[] records, FileType sourceFileType)
		{
			LoggerFactory.AppLogger.Info("[ItemsDataProvider.AddDailyData] Adding data for item item " + ticker);

			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				using (TransactionScope transaction = new TransactionScope())
				{
					Element element = FirstElementOrNull<Element>((from es in context.Elements where es.Symbol == ticker select es).Take<Element>(1).ToArray<Element>());
					 
					if (null == element)
					{
						element = new Element();

						element.Symbol = ticker;
						element.Type = 0;
						element.Domain = 0;
						element.Name = ticker;

						context.Elements.AddObject(element);

						LoggerFactory.AppLogger.Info("[ItemsDataProvider.AddDailyData] Adding new item " + element.Symbol);
					}

					DailyData lastStoredRecord = FirstElementOrNull<DailyData>((from dd in context.DailyDatas where dd.Ticker == ticker orderby dd.Day descending select dd).Take<DailyData>(1).ToArray<DailyData>());
					
					//////////////////////////////////////////////////////////////////////////////////////////////////
					/// check if records overlap
					/// 

					if (sourceFileType != FileType.AllData)
					{
						if (null == lastStoredRecord)
						{
							LoggerFactory.AppLogger.Warn("[ItemsDataProvider.AddDailyData] Can not import daily data as there is no ALL data for the item " + ticker);

							return;
						}

						if (!records.Any<DailyData>(x => x.Day <= lastStoredRecord.Day))
						{
							LoggerFactory.AppLogger.Warn("[ItemsDataProvider.AddDailyData] Can not import daily data asrecords are not continuous with already stored ALL data for the item " + ticker);

							return;
						}
					}

					if (null != lastStoredRecord)
					{
						LoggerFactory.AppLogger.Trace("[ItemsDataProvider.AddDailyData] Skipping records older then " + ticker + " " + lastStoredRecord.Day);

						List<DailyData> tempList = new List<DailyData>(records);

						records = tempList.FindAll(x => x.Day > lastStoredRecord.Day).ToArray();
					}

					if (records.Length <= 0)
					{
						LoggerFactory.AppLogger.Info("[ItemsDataProvider.AddDailyData] No records to add " + ticker);

						return;
					}

					for (Int32 q = 0; q < records.Length; q++)
					{
						DailyData record = records[q];

						context.DailyDatas.AddObject(records[q]);
					}

					context.SaveChanges();

					transaction.Complete();
				}
			}
		}

		public void RemoveProcessedFile(FilesToProcess file)
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				using (TransactionScope transaction = new TransactionScope())
				{
					FilesToProcess toRemove = FirstElementOrNull<FilesToProcess>((from fs in context.FilesToProcess where fs.RecId == file.RecId select fs).Take<FilesToProcess>(1).ToArray<FilesToProcess>());

					if (null != toRemove)
					{
						context.FilesToProcess.DeleteObject(toRemove);

						context.SaveChanges();

						transaction.Complete();
					}
				}
			}
		}

		public FilesToProcess GetPendingFile()
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				return FirstElementOrNull<FilesToProcess>((from fs in context.FilesToProcess orderby fs.RecId select fs).Take<FilesToProcess>(1).ToArray<FilesToProcess>());
			}
		}

		public SmallElementMovementDistribution[] LoadSmallDistributionResults()
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				return (from emd in context.ElementMovementDistributions select new SmallElementMovementDistribution
							{
								Ticker = emd.Ticker, 
								RangeId = emd.RangeId,
								Upd = emd.Upd
							}).ToArray<SmallElementMovementDistribution>();
			}
		}

		public DistributionRange[] LoadDistributionRanges()
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				return (from dr in context.DistributionRanges select dr).ToArray<DistributionRange>();
			}
		}

		public void AddFileToProcess(String source, Byte[] bytes, FileType fileType)
		{
			using (FinanceDBEntities context = new FinanceDBEntities())
			{
				using (TransactionScope transaction = new TransactionScope())
				{
					FilesToProcess newItem = FilesToProcess.CreateFilesToProcess(0, source, bytes, DateTime.Now, (Byte)fileType);

					context.FilesToProcess.AddObject(newItem);

					context.SaveChanges();

					transaction.Complete();
				}
			}
		}
	}

	public enum FileType : byte
	{
		AllData = 0,
		LastData = 1
	}

	public enum CorrelationPeriodType : byte
	{
		All = 1,
		LastYear = 2,
		LastMonth = 3
	}
}

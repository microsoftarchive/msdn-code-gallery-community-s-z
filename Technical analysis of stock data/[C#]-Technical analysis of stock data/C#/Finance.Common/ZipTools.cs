using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace Finance.Common
{
	public static class ZipTools
	{
		public static MemoryStream ExtractFirstFromZipArchive(MemoryStream zipStream)
		{
			MemoryStream plainText = new MemoryStream();

			using (ZipInputStream z = new ZipInputStream(zipStream))
			{
				ZipEntry entry = z.GetNextEntry();

				if (null == entry)
				{
					throw new ZipException("No entries has been found in the supplied archive");
				}

				Int32 count = 1;

				Byte[] buffer = new Byte[4096];

				while (count > 0)
				{
					count = z.Read(buffer, 0, buffer.Length);

					if (count > 0)
					{
						plainText.Write(buffer, 0, count);
					}
				}
			}

			return plainText;
		}

		public static Byte[][] ExtractAllFromZipArchive(MemoryStream zipStream)
		{
			List<Byte[]> result = new List<Byte[]>();

			using (ZipInputStream z = new ZipInputStream(zipStream))
			{
				ZipEntry entry = null;

				while ((entry = z.GetNextEntry()) != null)
				{
					if (entry.IsFile)
					{
						LoggerFactory.AppLogger.Trace("[ZipTools.ExtractAllFromZipArchive] Extracting zip entry " + entry.Name);

						MemoryStream plainText = new MemoryStream();

						Int32 count = 1;

						Byte[] buffer = new Byte[4096];

						while (count > 0)
						{
							count = z.Read(buffer, 0, buffer.Length);

							if (count > 0)
							{
								plainText.Write(buffer, 0, count);
							}
						}

						result.Add(plainText.ToArray());
					}
					else
					{
						LoggerFactory.AppLogger.Warn("[ZipTools.ExtractAllFromZipArchive] Directory entry skipped " + entry.Name);
					}
				}
			}

			if (result.Count <= 0)
			{
				throw new ZipException("No entries has been found in the supplied archive");
			}

			return result.ToArray();
		}
	}
}

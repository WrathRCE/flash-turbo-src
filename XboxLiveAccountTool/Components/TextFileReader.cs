using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using CsvHelper;
using Microsoft.Win32;

namespace XboxLiveAccountTool.Components
{
	// Token: 0x0200003C RID: 60
	public static class TextFileReader
	{
		// Token: 0x06000184 RID: 388 RVA: 0x00005550 File Offset: 0x00003750
		public static void ImportXuidsFromTextFile(IList<User> users, Logger logger)
		{
			bool flag = users == null;
			bool flag2 = flag;
			bool flag11 = flag2;
			if (flag11)
			{
				throw new ArgumentException("Users cannot be null");
			}
			bool flag3 = logger == null;
			bool flag4 = flag3;
			bool flag12 = flag4;
			if (flag12)
			{
				throw new ArgumentException("Logger logger cannot be null");
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			bool? flag5 = openFileDialog.ShowDialog();
			bool flag6 = true;
			bool flag7 = flag5.GetValueOrDefault() == flag6 & flag5 != null;
			bool flag8 = flag7;
			bool flag13 = flag8;
			if (flag13)
			{
				using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
				{
					string text = streamReader.ReadToEnd();
					string[] array = text.Split(new char[]
					{
						' ',
						',',
						'\t',
						'\n',
						';',
						'|'
					});
					int num = 0;
					foreach (string text2 in array)
					{
						string text3 = text2.Trim();
						bool flag9 = TextFileReader.XuidValid(text3);
						bool flag10 = flag9;
						bool flag14 = flag10;
						if (flag14)
						{
							users.Add(new User
							{
								xuid = text3
							});
							num++;
						}
						else
						{
							logger.LogToOutputWindow("Unable to import xuid " + text3);
						}
					}
					logger.LogToOutputWindow("Succesfully imported " + num.ToString() + " xuids", Colors.Green);
				}
			}
		}

		// Token: 0x06000185 RID: 389 RVA: 0x000056B8 File Offset: 0x000038B8
		public static void ImportXuidsFromCSV(IList<User> users, Logger logger)
		{
			bool flag = users == null;
			bool flag2 = flag;
			bool flag15 = flag2;
			if (flag15)
			{
				throw new ArgumentException("Users cannot be null");
			}
			bool flag3 = logger == null;
			bool flag4 = flag3;
			bool flag16 = flag4;
			if (flag16)
			{
				throw new ArgumentException("Logger logger cannot be null");
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.DefaultExt = "csv";
			openFileDialog.Filter = "CSV dump of dev accounts from XDP|*.csv";
			bool? flag5 = openFileDialog.ShowDialog();
			bool flag6 = true;
			bool flag7 = flag5.GetValueOrDefault() == flag6 & flag5 != null;
			bool flag8 = flag7;
			bool flag17 = flag8;
			if (flag17)
			{
				using (StreamReader streamReader = new StreamReader(openFileDialog.FileName))
				{
					CsvParser csvParser = new CsvParser(streamReader);
					string[] array = csvParser.Read();
					int num = -1;
					for (int i = 0; i < array.Length; i++)
					{
						bool flag9 = string.Equals(array[i], "Xuid", StringComparison.CurrentCultureIgnoreCase);
						bool flag10 = flag9;
						bool flag18 = flag10;
						if (flag18)
						{
							num = i;
							break;
						}
					}
					bool flag11 = num == -1;
					bool flag12 = !flag11;
					bool flag19 = flag12;
					if (flag19)
					{
						string[] array2 = csvParser.Read();
						int num2 = 0;
						while (array2 != null)
						{
							string text = array2[num].Trim(new char[]
							{
								'=',
								'"'
							});
							bool flag13 = TextFileReader.XuidValid(text);
							bool flag14 = flag13;
							bool flag20 = flag14;
							if (flag20)
							{
								users.Add(new User
								{
									xuid = text
								});
								num2++;
							}
							else
							{
								logger.LogToOutputWindow("Unable to import xuid " + text, Colors.Yellow);
							}
							array2 = csvParser.Read();
						}
						logger.LogToOutputWindow("Succesfully imported " + num2.ToString() + " xuids", Colors.Green);
					}
				}
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x000058A8 File Offset: 0x00003AA8
		public static bool XuidValid(string xuidstr)
		{
			ulong num = 0UL;
			return ulong.TryParse(xuidstr, out num);
		}
	}
}

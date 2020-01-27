using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x02000003 RID: 3
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x06000002 RID: 2 RVA: 0x0000205C File Offset: 0x0000025C
		private static string CultureToString(CultureInfo culture)
		{
			bool flag = culture == null;
			bool flag2 = flag;
			string result;
			if (flag2)
			{
				result = "";
			}
			else
			{
				result = culture.Name;
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000208C File Offset: 0x0000028C
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				AssemblyName name2 = assembly.GetName();
				bool flag = string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase);
				bool flag2 = flag;
				if (flag2)
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000210C File Offset: 0x0000030C
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002148 File Offset: 0x00000348
		private static Stream LoadStream(string fullname)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			bool flag = fullname.EndsWith(".compressed");
			bool flag2 = flag;
			if (flag2)
			{
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullname))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(fullname);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021E4 File Offset: 0x000003E4
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string fullname;
			bool flag = resourceNames.TryGetValue(name, out fullname);
			bool flag2 = flag;
			Stream result;
			if (flag2)
			{
				result = AssemblyLoader.LoadStream(fullname);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002218 File Offset: 0x00000418
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002244 File Offset: 0x00000444
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			bool flag = requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name);
			bool flag4 = flag;
			if (flag4)
			{
				text = string.Format("{0}.{1}", requestedAssemblyName.CultureInfo.Name, text);
			}
			byte[] rawAssembly;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				bool flag2 = stream == null;
				bool flag5 = flag2;
				if (flag5)
				{
					return null;
				}
				rawAssembly = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				bool flag3 = stream2 != null;
				bool flag6 = flag3;
				if (flag6)
				{
					byte[] rawSymbolStore = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(rawAssembly, rawSymbolStore);
				}
			}
			return Assembly.Load(rawAssembly);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000233C File Offset: 0x0000053C
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			object obj2 = obj;
			object obj4 = obj2;
			lock (obj4)
			{
				bool flag2 = AssemblyLoader.nullCache.ContainsKey(e.Name);
				bool flag7 = flag2;
				if (flag7)
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			bool flag3 = assembly != null;
			bool flag8 = flag3;
			Assembly result;
			if (flag8)
			{
				result = assembly;
			}
			else
			{
				assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
				bool flag4 = assembly == null;
				bool flag9 = flag4;
				if (flag9)
				{
					obj = AssemblyLoader.nullCacheLock;
					object obj3 = obj;
					object obj5 = obj3;
					lock (obj5)
					{
						AssemblyLoader.nullCache[e.Name] = true;
					}
					bool flag5 = assemblyName.Flags == AssemblyNameFlags.Retargetable;
					bool flag11 = flag5;
					if (flag11)
					{
						assembly = Assembly.Load(assemblyName);
					}
				}
				result = assembly;
			}
			return result;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002470 File Offset: 0x00000670
		static AssemblyLoader()
		{
			AssemblyLoader.assemblyNames.Add("csvhelper", "costura.csvhelper.dll.compressed");
			AssemblyLoader.symbolNames.Add("csvhelper", "costura.csvhelper.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000024EC File Offset: 0x000006EC
		public static void Attach()
		{
			bool flag = Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1;
			bool flag2 = !flag;
			if (flag2)
			{
				AppDomain.CurrentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
			}
		}

		// Token: 0x04000003 RID: 3
		private static readonly object nullCacheLock = new object();

		// Token: 0x04000004 RID: 4
		private static readonly Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		// Token: 0x04000005 RID: 5
		private static readonly Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		// Token: 0x04000006 RID: 6
		private static readonly Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		// Token: 0x04000007 RID: 7
		private static int isAttached = 0;
	}
}

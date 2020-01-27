using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000032 RID: 50
	[DataContract]
	public class XASUTokenResponse
	{
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0000509D File Offset: 0x0000329D
		// (set) Token: 0x06000145 RID: 325 RVA: 0x000050A5 File Offset: 0x000032A5
		[DataMember(Name = "IssueInstant", Order = 0)]
		public string IssueInstant { get; set; }

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000146 RID: 326 RVA: 0x000050AE File Offset: 0x000032AE
		// (set) Token: 0x06000147 RID: 327 RVA: 0x000050B6 File Offset: 0x000032B6
		[DataMember(Name = "NotAfter", Order = 1)]
		public string NotAfter { get; set; }

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000148 RID: 328 RVA: 0x000050BF File Offset: 0x000032BF
		// (set) Token: 0x06000149 RID: 329 RVA: 0x000050C7 File Offset: 0x000032C7
		[DataMember(Name = "Token", Order = 2)]
		public string Token { get; set; }

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600014A RID: 330 RVA: 0x000050D0 File Offset: 0x000032D0
		// (set) Token: 0x0600014B RID: 331 RVA: 0x000050D8 File Offset: 0x000032D8
		[DataMember(Name = "DisplayClaims", Order = 3)]
		public XasuDisplayClaims DisplayClaims { get; set; }

		// Token: 0x0600014C RID: 332 RVA: 0x000050E4 File Offset: 0x000032E4
		public static XASUTokenResponse Create(byte[] bytes)
		{
			DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(XASUTokenResponse));
			XASUTokenResponse result;
			using (MemoryStream memoryStream = new MemoryStream(bytes))
			{
				result = (XASUTokenResponse)dataContractJsonSerializer.ReadObject(memoryStream);
			}
			return result;
		}
	}
}

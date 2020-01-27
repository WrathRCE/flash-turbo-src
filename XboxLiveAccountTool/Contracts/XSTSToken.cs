using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000035 RID: 53
	[DataContract]
	public class XSTSToken
	{
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000158 RID: 344 RVA: 0x00005180 File Offset: 0x00003380
		// (set) Token: 0x06000159 RID: 345 RVA: 0x00005188 File Offset: 0x00003388
		[DataMember(Name = "IssueInstant", Order = 0)]
		public string IssueInstant { get; set; }

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00005191 File Offset: 0x00003391
		// (set) Token: 0x0600015B RID: 347 RVA: 0x00005199 File Offset: 0x00003399
		[DataMember(Name = "NotAfter", Order = 1)]
		public string NotAfter { get; set; }

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x0600015C RID: 348 RVA: 0x000051A2 File Offset: 0x000033A2
		// (set) Token: 0x0600015D RID: 349 RVA: 0x000051AA File Offset: 0x000033AA
		[DataMember(Name = "Token", Order = 2)]
		public string Token { get; set; }

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600015E RID: 350 RVA: 0x000051B3 File Offset: 0x000033B3
		// (set) Token: 0x0600015F RID: 351 RVA: 0x000051BB File Offset: 0x000033BB
		[DataMember(Name = "DisplayClaims", Order = 3)]
		public XSTSDisplayClaims DisplayClaims { get; set; }

		// Token: 0x06000160 RID: 352 RVA: 0x000051C4 File Offset: 0x000033C4
		public static XSTSToken Create(byte[] bytes)
		{
			DataContractJsonSerializer dataContractJsonSerializer = new DataContractJsonSerializer(typeof(XSTSToken));
			XSTSToken result;
			using (MemoryStream memoryStream = new MemoryStream(bytes))
			{
				XSTSToken xststoken = (XSTSToken)dataContractJsonSerializer.ReadObject(memoryStream);
				xststoken.ParsePrivileges();
				result = xststoken;
			}
			return result;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00005228 File Offset: 0x00003428
		public void ParsePrivileges()
		{
			foreach (XuiClaims xuiClaims2 in this.DisplayClaims.XuiClaims)
			{
				xuiClaims2.ParsePrivileges();
			}
		}
	}
}

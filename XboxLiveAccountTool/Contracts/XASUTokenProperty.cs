using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000031 RID: 49
	[DataContract]
	public class XASUTokenProperty
	{
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0000506A File Offset: 0x0000326A
		// (set) Token: 0x0600013E RID: 318 RVA: 0x00005072 File Offset: 0x00003272
		[DataMember(Name = "AuthMethod")]
		public string AuthMethod { get; set; }

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x0600013F RID: 319 RVA: 0x0000507B File Offset: 0x0000327B
		// (set) Token: 0x06000140 RID: 320 RVA: 0x00005083 File Offset: 0x00003283
		[DataMember(Name = "SiteName")]
		public string SiteName { get; set; }

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x06000141 RID: 321 RVA: 0x0000508C File Offset: 0x0000328C
		// (set) Token: 0x06000142 RID: 322 RVA: 0x00005094 File Offset: 0x00003294
		[DataMember(Name = "RpsTicket")]
		public string RpsTicket { get; set; }
	}
}

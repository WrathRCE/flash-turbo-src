using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000028 RID: 40
	[DataContract]
	public class ReputationChangeRequestContract
	{
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00004ED2 File Offset: 0x000030D2
		// (set) Token: 0x06000105 RID: 261 RVA: 0x00004EDA File Offset: 0x000030DA
		[DataMember(Name = "fairplayReputation")]
		public string FairplayRepuation { get; set; }

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00004EE3 File Offset: 0x000030E3
		// (set) Token: 0x06000107 RID: 263 RVA: 0x00004EEB File Offset: 0x000030EB
		[DataMember(Name = "commsReputation")]
		public string CommsReputation { get; set; }

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00004EF4 File Offset: 0x000030F4
		// (set) Token: 0x06000109 RID: 265 RVA: 0x00004EFC File Offset: 0x000030FC
		[DataMember(Name = "userContentReputation")]
		public string UserContentReputation { get; set; }
	}
}

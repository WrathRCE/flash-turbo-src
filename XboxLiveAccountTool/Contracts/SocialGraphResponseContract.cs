using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x0200002B RID: 43
	[DataContract]
	public class SocialGraphResponseContract
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600011B RID: 283 RVA: 0x00004F7C File Offset: 0x0000317C
		// (set) Token: 0x0600011C RID: 284 RVA: 0x00004F84 File Offset: 0x00003184
		[DataMember(Name = "totalCount")]
		public uint TotalCount { get; set; }

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00004F8D File Offset: 0x0000318D
		// (set) Token: 0x0600011E RID: 286 RVA: 0x00004F95 File Offset: 0x00003195
		[DataMember(Name = "people")]
		public SocialGraphPersonContract[] SocialGraphPeople { get; set; }
	}
}

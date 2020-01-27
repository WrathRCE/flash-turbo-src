using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x0200002E RID: 46
	[DataContract]
	public class subscriptionEntitlementInfo
	{
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600012A RID: 298 RVA: 0x00004FE2 File Offset: 0x000031E2
		// (set) Token: 0x0600012B RID: 299 RVA: 0x00004FEA File Offset: 0x000031EA
		[DataMember(Name = "legacyOfferId")]
		public string legacyOfferId { get; set; }

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600012C RID: 300 RVA: 0x00004FF3 File Offset: 0x000031F3
		// (set) Token: 0x0600012D RID: 301 RVA: 0x00004FFB File Offset: 0x000031FB
		[DataMember(Name = "offerId")]
		public string offerId { get; set; }

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00005004 File Offset: 0x00003204
		// (set) Token: 0x0600012F RID: 303 RVA: 0x0000500C File Offset: 0x0000320C
		[DataMember(Name = "offerInstanceId")]
		public string offerInstanceId { get; set; }

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00005015 File Offset: 0x00003215
		// (set) Token: 0x06000131 RID: 305 RVA: 0x0000501D File Offset: 0x0000321D
		[DataMember(Name = "serviceInstanceId")]
		public string serviceInstanceId { get; set; }
	}
}

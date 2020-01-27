using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000021 RID: 33
	[DataContract]
	public class PrivacyRequestContract
	{
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x00004E06 File Offset: 0x00003006
		// (set) Token: 0x060000E6 RID: 230 RVA: 0x00004E0E File Offset: 0x0000300E
		[DataMember(Name = "operation")]
		public string Operation { get; set; }

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x00004E17 File Offset: 0x00003017
		// (set) Token: 0x060000E8 RID: 232 RVA: 0x00004E1F File Offset: 0x0000301F
		[DataMember(Name = "users")]
		public PrivacyUserContract[] Users { get; set; }
	}
}

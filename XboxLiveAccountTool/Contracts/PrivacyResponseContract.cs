using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000022 RID: 34
	[DataContract]
	public class PrivacyResponseContract
	{
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00004E28 File Offset: 0x00003028
		// (set) Token: 0x060000EB RID: 235 RVA: 0x00004E30 File Offset: 0x00003030
		[DataMember(Name = "Users")]
		public PrivacyUserContract[] Users { get; set; }
	}
}

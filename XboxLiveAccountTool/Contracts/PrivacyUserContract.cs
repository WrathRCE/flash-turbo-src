using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000023 RID: 35
	[DataContract]
	public class PrivacyUserContract
	{
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00004E39 File Offset: 0x00003039
		// (set) Token: 0x060000EE RID: 238 RVA: 0x00004E41 File Offset: 0x00003041
		[DataMember(Name = "Xuid")]
		public string Xuid { get; set; }
	}
}

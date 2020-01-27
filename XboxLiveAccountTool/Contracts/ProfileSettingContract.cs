using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000026 RID: 38
	[DataContract]
	public class ProfileSettingContract
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00004E7D File Offset: 0x0000307D
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00004E85 File Offset: 0x00003085
		[DataMember(Name = "id")]
		public string id { get; set; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00004E8E File Offset: 0x0000308E
		// (set) Token: 0x060000FB RID: 251 RVA: 0x00004E96 File Offset: 0x00003096
		[DataMember(Name = "value")]
		public string value { get; set; }
	}
}

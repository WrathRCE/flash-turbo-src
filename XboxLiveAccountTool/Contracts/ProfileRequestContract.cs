using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000024 RID: 36
	[DataContract]
	public class ProfileRequestContract
	{
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00004E4A File Offset: 0x0000304A
		// (set) Token: 0x060000F1 RID: 241 RVA: 0x00004E52 File Offset: 0x00003052
		[DataMember(Name = "userIds")]
		public ulong[] userIds { get; set; }

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00004E5B File Offset: 0x0000305B
		// (set) Token: 0x060000F3 RID: 243 RVA: 0x00004E63 File Offset: 0x00003063
		[DataMember(Name = "settings")]
		public string[] settings { get; set; }
	}
}

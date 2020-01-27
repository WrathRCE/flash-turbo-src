using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000025 RID: 37
	[DataContract]
	public class ProfileResponseContract
	{
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00004E6C File Offset: 0x0000306C
		// (set) Token: 0x060000F6 RID: 246 RVA: 0x00004E74 File Offset: 0x00003074
		[DataMember(Name = "profileUsers")]
		public ProfileUserContract[] profileUsers { get; set; }
	}
}

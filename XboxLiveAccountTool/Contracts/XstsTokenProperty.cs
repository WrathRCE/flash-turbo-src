using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000036 RID: 54
	[DataContract]
	public class XstsTokenProperty
	{
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000163 RID: 355 RVA: 0x0000525E File Offset: 0x0000345E
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00005266 File Offset: 0x00003466
		[DataMember(Name = "UserTokens")]
		public string[] UserTokens { get; set; }

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000165 RID: 357 RVA: 0x0000526F File Offset: 0x0000346F
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00005277 File Offset: 0x00003477
		[DataMember(Name = "SandboxId")]
		public string SandboxId { get; set; }
	}
}

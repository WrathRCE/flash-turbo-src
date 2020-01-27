using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x0200002A RID: 42
	[DataContract]
	public class SocialGraphRequestContract
	{
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00004F6B File Offset: 0x0000316B
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00004F73 File Offset: 0x00003173
		[DataMember(Name = "xuids")]
		public string[] xuids { get; set; }
	}
}

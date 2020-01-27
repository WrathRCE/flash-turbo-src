using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x0200001F RID: 31
	[DataContract]
	public class AccountsGtChangeRequestContract
	{
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x00004D8F File Offset: 0x00002F8F
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x00004D97 File Offset: 0x00002F97
		[DataMember(Name = "Gamertag")]
		public string Gamertag { get; set; }
	}
}

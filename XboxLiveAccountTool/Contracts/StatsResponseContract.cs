using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x0200002D RID: 45
	[DataContract]
	public class StatsResponseContract
	{
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000127 RID: 295 RVA: 0x00004FD1 File Offset: 0x000031D1
		// (set) Token: 0x06000128 RID: 296 RVA: 0x00004FD9 File Offset: 0x000031D9
		[DataMember(Name = "stats")]
		public StatContract[] stats { get; set; }
	}
}

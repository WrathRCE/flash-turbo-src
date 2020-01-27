using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000027 RID: 39
	[DataContract]
	public class ProfileUserContract
	{
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00004E9F File Offset: 0x0000309F
		// (set) Token: 0x060000FE RID: 254 RVA: 0x00004EA7 File Offset: 0x000030A7
		[DataMember(Name = "id")]
		public ulong id { get; set; }

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00004EB0 File Offset: 0x000030B0
		// (set) Token: 0x06000100 RID: 256 RVA: 0x00004EB8 File Offset: 0x000030B8
		[DataMember(Name = "hostId")]
		public string hostId { get; set; }

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00004EC1 File Offset: 0x000030C1
		// (set) Token: 0x06000102 RID: 258 RVA: 0x00004EC9 File Offset: 0x000030C9
		[DataMember(Name = "settings")]
		public ProfileSettingContract[] settings { get; set; }
	}
}

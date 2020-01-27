using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000029 RID: 41
	[DataContract]
	public class SocialGraphPersonContract
	{
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00004F05 File Offset: 0x00003105
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00004F0D File Offset: 0x0000310D
		[DataMember(Name = "xuid")]
		public string Xuid { get; set; }

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00004F16 File Offset: 0x00003116
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00004F1E File Offset: 0x0000311E
		[DataMember(Name = "isFavorite")]
		public bool IsFavorite { get; set; }

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00004F27 File Offset: 0x00003127
		// (set) Token: 0x06000110 RID: 272 RVA: 0x00004F2F File Offset: 0x0000312F
		[DataMember(Name = "socialNetworks")]
		public string[] SocialNetworks { get; set; }

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00004F38 File Offset: 0x00003138
		// (set) Token: 0x06000112 RID: 274 RVA: 0x00004F40 File Offset: 0x00003140
		[DataMember(Name = "IsFollowedByCaller")]
		public bool IsFollowedByCaller { get; set; }

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000113 RID: 275 RVA: 0x00004F49 File Offset: 0x00003149
		// (set) Token: 0x06000114 RID: 276 RVA: 0x00004F51 File Offset: 0x00003151
		[DataMember(Name = "IsFollowingCaller")]
		public bool IsFollowingCaller { get; set; }

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00004F5A File Offset: 0x0000315A
		// (set) Token: 0x06000116 RID: 278 RVA: 0x00004F62 File Offset: 0x00003162
		[DataMember(Name = "isIdentityShared")]
		public bool IsIdentityShared { get; set; }
	}
}

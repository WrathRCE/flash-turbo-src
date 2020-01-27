using System;
using System.Collections.Generic;

namespace XboxLiveAccountTool
{
	// Token: 0x0200000D RID: 13
	public class User
	{
		// Token: 0x0600005D RID: 93 RVA: 0x000040B6 File Offset: 0x000022B6
		public User()
		{
			this.isFavorite = false;
			this.isFollowingBack = false;
			this.isBlocked = false;
			this.networks = new List<string>();
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600005E RID: 94 RVA: 0x000040E4 File Offset: 0x000022E4
		// (set) Token: 0x0600005F RID: 95 RVA: 0x000040EC File Offset: 0x000022EC
		public string xuid { get; set; }

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000060 RID: 96 RVA: 0x000040F5 File Offset: 0x000022F5
		// (set) Token: 0x06000061 RID: 97 RVA: 0x000040FD File Offset: 0x000022FD
		public bool isFavorite { get; set; }

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00004106 File Offset: 0x00002306
		// (set) Token: 0x06000063 RID: 99 RVA: 0x0000410E File Offset: 0x0000230E
		public bool isFollowingBack { get; set; }

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00004117 File Offset: 0x00002317
		// (set) Token: 0x06000065 RID: 101 RVA: 0x0000411F File Offset: 0x0000231F
		public bool isBlocked { get; set; }

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00004128 File Offset: 0x00002328
		// (set) Token: 0x06000067 RID: 103 RVA: 0x00004130 File Offset: 0x00002330
		public List<string> networks { get; private set; }
	}
}

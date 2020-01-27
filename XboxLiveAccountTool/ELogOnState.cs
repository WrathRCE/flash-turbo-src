using System;

namespace XboxLiveAccountTool
{
	// Token: 0x02000005 RID: 5
	public enum ELogOnState
	{
		// Token: 0x0400000B RID: 11
		None,
		// Token: 0x0400000C RID: 12
		SigningIn,
		// Token: 0x0400000D RID: 13
		SignedIn,
		// Token: 0x0400000E RID: 14
		RefreshingToken,
		// Token: 0x0400000F RID: 15
		SigningOut,
		// Token: 0x04000010 RID: 16
		SignedOut,
		// Token: 0x04000011 RID: 17
		Error
	}
}

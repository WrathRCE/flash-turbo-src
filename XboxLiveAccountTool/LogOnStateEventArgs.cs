using System;

namespace XboxLiveAccountTool
{
	// Token: 0x02000008 RID: 8
	public class LogOnStateEventArgs : EventArgs
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000029A3 File Offset: 0x00000BA3
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000029AB File Offset: 0x00000BAB
		public ELogOnState PreviousState { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000029B4 File Offset: 0x00000BB4
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000029BC File Offset: 0x00000BBC
		public ELogOnState NewState { get; set; }
	}
}

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Windows;

namespace XboxLiveAccountTool
{
	// Token: 0x02000004 RID: 4
	public partial class App : Application
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000C RID: 12 RVA: 0x0000252A File Offset: 0x0000072A
		// (set) Token: 0x0600000D RID: 13 RVA: 0x00002531 File Offset: 0x00000731
		public static string XToken { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000E RID: 14 RVA: 0x00002539 File Offset: 0x00000739
		// (set) Token: 0x0600000F RID: 15 RVA: 0x00002540 File Offset: 0x00000740
		public static string XUserHash { get; set; }
	}
}

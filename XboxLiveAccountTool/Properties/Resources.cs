using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace XboxLiveAccountTool.Properties
{
	// Token: 0x02000010 RID: 16
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000079 RID: 121 RVA: 0x0000441D File Offset: 0x0000261D
		internal Resources()
		{
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600007A RID: 122 RVA: 0x00004428 File Offset: 0x00002628
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				bool flag2 = flag;
				if (flag2)
				{
					ResourceManager resourceManager = new ResourceManager("XboxLiveAccountTool.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00004470 File Offset: 0x00002670
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00004487 File Offset: 0x00002687
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400006F RID: 111
		private static ResourceManager resourceMan;

		// Token: 0x04000070 RID: 112
		private static CultureInfo resourceCulture;
	}
}

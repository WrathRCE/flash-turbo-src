using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace XboxLiveAccountTool.Properties
{
	// Token: 0x02000011 RID: 17
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00004490 File Offset: 0x00002690
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000071 RID: 113
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}

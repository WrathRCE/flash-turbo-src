using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x0200002F RID: 47
	[DataContract]
	public class XasuDisplayClaims
	{
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x06000133 RID: 307 RVA: 0x00005026 File Offset: 0x00003226
		// (set) Token: 0x06000134 RID: 308 RVA: 0x0000502E File Offset: 0x0000322E
		[DataMember(Name = "xui")]
		public XuiClaims[] Claims { get; set; }
	}
}

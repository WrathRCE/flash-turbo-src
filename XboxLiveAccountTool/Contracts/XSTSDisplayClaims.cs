using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000033 RID: 51
	[DataContract]
	public class XSTSDisplayClaims
	{
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x0600014E RID: 334 RVA: 0x0000513C File Offset: 0x0000333C
		// (set) Token: 0x0600014F RID: 335 RVA: 0x00005144 File Offset: 0x00003344
		[DataMember(Name = "xui")]
		public XuiClaims[] XuiClaims { get; set; }
	}
}

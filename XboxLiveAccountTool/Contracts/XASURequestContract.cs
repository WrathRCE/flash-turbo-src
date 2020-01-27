using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000030 RID: 48
	[DataContract]
	public class XASURequestContract
	{
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000136 RID: 310 RVA: 0x00005037 File Offset: 0x00003237
		// (set) Token: 0x06000137 RID: 311 RVA: 0x0000503F File Offset: 0x0000323F
		[DataMember(Name = "RelyingParty")]
		public string RelyingParty { get; set; }

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000138 RID: 312 RVA: 0x00005048 File Offset: 0x00003248
		// (set) Token: 0x06000139 RID: 313 RVA: 0x00005050 File Offset: 0x00003250
		[DataMember(Name = "TokenType")]
		public string TokenType { get; set; }

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x0600013A RID: 314 RVA: 0x00005059 File Offset: 0x00003259
		// (set) Token: 0x0600013B RID: 315 RVA: 0x00005061 File Offset: 0x00003261
		[DataMember(Name = "Properties")]
		public XASUTokenProperty TokenProperties { get; set; }
	}
}

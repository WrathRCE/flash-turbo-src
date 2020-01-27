using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000034 RID: 52
	[DataContract]
	public class XSTSRequestContract
	{
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000151 RID: 337 RVA: 0x0000514D File Offset: 0x0000334D
		// (set) Token: 0x06000152 RID: 338 RVA: 0x00005155 File Offset: 0x00003355
		[DataMember(Name = "RelyingParty")]
		public string RelyingParty { get; set; }

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000153 RID: 339 RVA: 0x0000515E File Offset: 0x0000335E
		// (set) Token: 0x06000154 RID: 340 RVA: 0x00005166 File Offset: 0x00003366
		[DataMember(Name = "TokenType")]
		public string TokenType { get; set; }

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000155 RID: 341 RVA: 0x0000516F File Offset: 0x0000336F
		// (set) Token: 0x06000156 RID: 342 RVA: 0x00005177 File Offset: 0x00003377
		[DataMember(Name = "Properties")]
		public XstsTokenProperty TokenProperties { get; set; }
	}
}

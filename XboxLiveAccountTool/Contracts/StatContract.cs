using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x0200002C RID: 44
	[DataContract]
	public class StatContract
	{
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00004F9E File Offset: 0x0000319E
		// (set) Token: 0x06000121 RID: 289 RVA: 0x00004FA6 File Offset: 0x000031A6
		[DataMember(Name = "statname")]
		public string statname { get; set; }

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000122 RID: 290 RVA: 0x00004FAF File Offset: 0x000031AF
		// (set) Token: 0x06000123 RID: 291 RVA: 0x00004FB7 File Offset: 0x000031B7
		[DataMember(Name = "type")]
		public string type { get; set; }

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00004FC0 File Offset: 0x000031C0
		// (set) Token: 0x06000125 RID: 293 RVA: 0x00004FC8 File Offset: 0x000031C8
		[DataMember(Name = "value")]
		public string value { get; set; }
	}
}

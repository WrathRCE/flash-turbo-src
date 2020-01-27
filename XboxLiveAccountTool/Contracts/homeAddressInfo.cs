using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000020 RID: 32
	[DataContract]
	public class homeAddressInfo
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x00004DA0 File Offset: 0x00002FA0
		// (set) Token: 0x060000D9 RID: 217 RVA: 0x00004DA8 File Offset: 0x00002FA8
		[DataMember(Name = "street1")]
		public string street1 { get; set; }

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000DA RID: 218 RVA: 0x00004DB1 File Offset: 0x00002FB1
		// (set) Token: 0x060000DB RID: 219 RVA: 0x00004DB9 File Offset: 0x00002FB9
		[DataMember(Name = "street2")]
		public string streets2 { get; set; }

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00004DC2 File Offset: 0x00002FC2
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00004DCA File Offset: 0x00002FCA
		[DataMember(Name = "city")]
		public string city { get; set; }

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00004DD3 File Offset: 0x00002FD3
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00004DDB File Offset: 0x00002FDB
		[DataMember(Name = "state")]
		public string state { get; set; }

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004DE4 File Offset: 0x00002FE4
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00004DEC File Offset: 0x00002FEC
		[DataMember(Name = "postalCode")]
		public string postalCode { get; set; }

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00004DF5 File Offset: 0x00002FF5
		// (set) Token: 0x060000E3 RID: 227 RVA: 0x00004DFD File Offset: 0x00002FFD
		[DataMember(Name = "country")]
		public string country { get; set; }
	}
}

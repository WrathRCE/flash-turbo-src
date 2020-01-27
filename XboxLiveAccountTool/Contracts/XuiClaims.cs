using System;
using System.Linq;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x02000037 RID: 55
	[DataContract]
	public class XuiClaims
	{
		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000168 RID: 360 RVA: 0x00005280 File Offset: 0x00003480
		// (set) Token: 0x06000169 RID: 361 RVA: 0x00005288 File Offset: 0x00003488
		[DataMember(Name = "agg", EmitDefaultValue = false)]
		public string AgeGroup { get; set; }

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600016A RID: 362 RVA: 0x00005291 File Offset: 0x00003491
		// (set) Token: 0x0600016B RID: 363 RVA: 0x00005299 File Offset: 0x00003499
		[DataMember(Name = "gtg", EmitDefaultValue = false)]
		public string Gamertag { get; set; }

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600016C RID: 364 RVA: 0x000052A2 File Offset: 0x000034A2
		// (set) Token: 0x0600016D RID: 365 RVA: 0x000052AA File Offset: 0x000034AA
		[DataMember(Name = "prv", EmitDefaultValue = false)]
		public string PrivilegeString { get; set; }

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600016E RID: 366 RVA: 0x000052B3 File Offset: 0x000034B3
		// (set) Token: 0x0600016F RID: 367 RVA: 0x000052BB File Offset: 0x000034BB
		[DataMember(Name = "xid", EmitDefaultValue = false)]
		public string Xuid { get; set; }

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000170 RID: 368 RVA: 0x000052C4 File Offset: 0x000034C4
		// (set) Token: 0x06000171 RID: 369 RVA: 0x000052CC File Offset: 0x000034CC
		[DataMember(Name = "uhs", EmitDefaultValue = false)]
		public string UserHash { get; set; }

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000172 RID: 370 RVA: 0x000052D5 File Offset: 0x000034D5
		// (set) Token: 0x06000173 RID: 371 RVA: 0x000052DD File Offset: 0x000034DD
		public int[] Privileges { get; set; }

		// Token: 0x06000174 RID: 372 RVA: 0x000052E8 File Offset: 0x000034E8
		public void ParsePrivileges()
		{
			bool flag = this.PrivilegeString != null;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				string[] array = this.PrivilegeString.Split(new char[]
				{
					' '
				});
				int num = array.Count<string>();
				this.Privileges = new int[num];
				for (int i = 0; i < num; i++)
				{
					this.Privileges[i] = int.Parse(array[i]);
				}
			}
		}
	}
}

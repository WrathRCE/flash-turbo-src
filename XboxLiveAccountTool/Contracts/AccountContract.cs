using System;
using System.Runtime.Serialization;

namespace XboxLiveAccountTool.Contracts
{
	// Token: 0x0200001E RID: 30
	[DataContract]
	public class AccountContract
	{
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00004BD5 File Offset: 0x00002DD5
		// (set) Token: 0x060000A1 RID: 161 RVA: 0x00004BDD File Offset: 0x00002DDD
		[DataMember(Name = "administeredConsoles")]
		public string[] administeredConsoles { get; set; }

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00004BE6 File Offset: 0x00002DE6
		// (set) Token: 0x060000A3 RID: 163 RVA: 0x00004BEE File Offset: 0x00002DEE
		[DataMember(Name = "dateCreated")]
		public DateTime dateCreated { get; set; }

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00004BF7 File Offset: 0x00002DF7
		// (set) Token: 0x060000A5 RID: 165 RVA: 0x00004BFF File Offset: 0x00002DFF
		[DataMember(Name = "dateOfBirth")]
		public DateTime dateOfBirth { get; set; }

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00004C08 File Offset: 0x00002E08
		// (set) Token: 0x060000A7 RID: 167 RVA: 0x00004C10 File Offset: 0x00002E10
		[DataMember(Name = "email")]
		public string email { get; set; }

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00004C19 File Offset: 0x00002E19
		// (set) Token: 0x060000A9 RID: 169 RVA: 0x00004C21 File Offset: 0x00002E21
		[DataMember(Name = "firstName")]
		public string firstName { get; set; }

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000AA RID: 170 RVA: 0x00004C2A File Offset: 0x00002E2A
		// (set) Token: 0x060000AB RID: 171 RVA: 0x00004C32 File Offset: 0x00002E32
		[DataMember(Name = "gamerTag")]
		public string gamerTag { get; set; }

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000AC RID: 172 RVA: 0x00004C3B File Offset: 0x00002E3B
		// (set) Token: 0x060000AD RID: 173 RVA: 0x00004C43 File Offset: 0x00002E43
		[DataMember(Name = "homeAddressInfo")]
		public homeAddressInfo homeAddressInfo { get; set; }

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000AE RID: 174 RVA: 0x00004C4C File Offset: 0x00002E4C
		// (set) Token: 0x060000AF RID: 175 RVA: 0x00004C54 File Offset: 0x00002E54
		[DataMember(Name = "homeConsole")]
		public int? homeConsole { get; set; }

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x00004C5D File Offset: 0x00002E5D
		// (set) Token: 0x060000B1 RID: 177 RVA: 0x00004C65 File Offset: 0x00002E65
		[DataMember(Name = "imageUrl")]
		public string imageUrl { get; set; }

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x00004C6E File Offset: 0x00002E6E
		// (set) Token: 0x060000B3 RID: 179 RVA: 0x00004C76 File Offset: 0x00002E76
		[DataMember(Name = "isAdult")]
		public string isAdult { get; set; }

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x00004C7F File Offset: 0x00002E7F
		// (set) Token: 0x060000B5 RID: 181 RVA: 0x00004C87 File Offset: 0x00002E87
		[DataMember(Name = "lastName")]
		public string lastName { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x00004C90 File Offset: 0x00002E90
		// (set) Token: 0x060000B7 RID: 183 RVA: 0x00004C98 File Offset: 0x00002E98
		[DataMember(Name = "legalCountry")]
		public string legalCountry { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00004CA1 File Offset: 0x00002EA1
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00004CA9 File Offset: 0x00002EA9
		[DataMember(Name = "locale")]
		public string locale { get; set; }

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00004CB2 File Offset: 0x00002EB2
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00004CBA File Offset: 0x00002EBA
		[DataMember(Name = "msftOptin")]
		public string msftOptin { get; set; }

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000BC RID: 188 RVA: 0x00004CC3 File Offset: 0x00002EC3
		// (set) Token: 0x060000BD RID: 189 RVA: 0x00004CCB File Offset: 0x00002ECB
		[DataMember(Name = "ownerHash")]
		public string ownerHash { get; set; }

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000BE RID: 190 RVA: 0x00004CD4 File Offset: 0x00002ED4
		// (set) Token: 0x060000BF RID: 191 RVA: 0x00004CDC File Offset: 0x00002EDC
		[DataMember(Name = "ownerXuid")]
		public string ownerXuid { get; set; }

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x00004CE5 File Offset: 0x00002EE5
		// (set) Token: 0x060000C1 RID: 193 RVA: 0x00004CED File Offset: 0x00002EED
		[DataMember(Name = "midasConsole")]
		public string midasConsole { get; set; }

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x00004CF6 File Offset: 0x00002EF6
		// (set) Token: 0x060000C3 RID: 195 RVA: 0x00004CFE File Offset: 0x00002EFE
		[DataMember(Name = "partnerOptin")]
		public string partnerOptin { get; set; }

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x00004D07 File Offset: 0x00002F07
		// (set) Token: 0x060000C5 RID: 197 RVA: 0x00004D0F File Offset: 0x00002F0F
		[DataMember(Name = "requirePasskeyForPurchase")]
		public string requirePasskeyForPurchase { get; set; }

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x00004D18 File Offset: 0x00002F18
		// (set) Token: 0x060000C7 RID: 199 RVA: 0x00004D20 File Offset: 0x00002F20
		[DataMember(Name = "requirePasskeyForSignin")]
		public string requirePasskeyForSignin { get; set; }

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x00004D29 File Offset: 0x00002F29
		// (set) Token: 0x060000C9 RID: 201 RVA: 0x00004D31 File Offset: 0x00002F31
		[DataMember(Name = "subscriptionEntitlementInfo")]
		public subscriptionEntitlementInfo subscriptionEntitlementInfo { get; set; }

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000CA RID: 202 RVA: 0x00004D3A File Offset: 0x00002F3A
		// (set) Token: 0x060000CB RID: 203 RVA: 0x00004D42 File Offset: 0x00002F42
		[DataMember(Name = "userHash")]
		public string userHash { get; set; }

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000CC RID: 204 RVA: 0x00004D4B File Offset: 0x00002F4B
		// (set) Token: 0x060000CD RID: 205 RVA: 0x00004D53 File Offset: 0x00002F53
		[DataMember(Name = "userKey")]
		public string userKey { get; set; }

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000CE RID: 206 RVA: 0x00004D5C File Offset: 0x00002F5C
		// (set) Token: 0x060000CF RID: 207 RVA: 0x00004D64 File Offset: 0x00002F64
		[DataMember(Name = "userXuid")]
		public string userXuid { get; set; }

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00004D6D File Offset: 0x00002F6D
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x00004D75 File Offset: 0x00002F75
		[DataMember(Name = "touAcceptanceDate")]
		public DateTime touAcceptanceDate { get; set; }

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00004D7E File Offset: 0x00002F7E
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x00004D86 File Offset: 0x00002F86
		[DataMember(Name = "gamerTagChangeReason")]
		public string gamertagChangeReason { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XboxLiveAccountTool.Contracts;
using XboxLiveAccountTool.DataAccess;

namespace XboxLiveAccountTool
{
	// Token: 0x0200000F RID: 15
	public class XTokenManager
	{
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600006D RID: 109 RVA: 0x0000434F File Offset: 0x0000254F
		// (set) Token: 0x0600006E RID: 110 RVA: 0x00004357 File Offset: 0x00002557
		public string userHash { get; set; }

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00004360 File Offset: 0x00002560
		// (set) Token: 0x06000070 RID: 112 RVA: 0x00004368 File Offset: 0x00002568
		public string xuid { get; set; }

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00004371 File Offset: 0x00002571
		// (set) Token: 0x06000072 RID: 114 RVA: 0x00004379 File Offset: 0x00002579
		public string XToken { get; set; }

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00004382 File Offset: 0x00002582
		// (set) Token: 0x06000074 RID: 116 RVA: 0x0000438A File Offset: 0x0000258A
		public int[] privileges { get; set; }

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000075 RID: 117 RVA: 0x00004393 File Offset: 0x00002593
		// (set) Token: 0x06000076 RID: 118 RVA: 0x0000439B File Offset: 0x0000259B
		public Dictionary<TokenType, XSTSToken> Tokens { get; set; }

		// Token: 0x06000077 RID: 119 RVA: 0x000043A4 File Offset: 0x000025A4
		public XTokenManager()
		{
			this.Tokens = new Dictionary<TokenType, XSTSToken>();
			this.XSTSDAL = new XSTSDataAccess();
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000043C8 File Offset: 0x000025C8
		public async Task AuthWithServiceAsync(string MSAToken, string sandboxId)
		{
			this.Tokens = new Dictionary<TokenType, XSTSToken>();
			try
			{
				Dictionary<TokenType, XSTSToken> dictionary2 = await this.XSTSDAL.GetTokens(MSAToken, sandboxId);
				Dictionary<TokenType, XSTSToken> dictionary = dictionary2;
				dictionary2 = null;
				Dictionary<TokenType, XSTSToken> tokens = dictionary;
				dictionary = null;
				this.Tokens = tokens;
				tokens = null;
				this.userHash = this.Tokens[TokenType.XboxLive].DisplayClaims.XuiClaims[0].UserHash;
				this.xuid = this.Tokens[TokenType.XboxLive].DisplayClaims.XuiClaims[0].Xuid;
				this.XToken = this.Tokens[TokenType.XboxLive].Token;
				this.privileges = this.Tokens[TokenType.XboxLive].DisplayClaims.XuiClaims[0].Privileges;
				tokens = null;
				dictionary = null;
				tokens = null;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		// Token: 0x0400006E RID: 110
		private XSTSDataAccess XSTSDAL;
	}
}

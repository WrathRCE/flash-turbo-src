using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XboxLiveAccountTool.Contracts;

namespace XboxLiveAccountTool.DataAccess
{
	// Token: 0x0200001D RID: 29
	public class XSTSDataAccess
	{
		// Token: 0x0600009E RID: 158 RVA: 0x00004B80 File Offset: 0x00002D80
		public async Task<Dictionary<TokenType, XSTSToken>> GetTokens(string MSAToken, string sandboxId)
		{
			Dictionary<TokenType, XSTSToken> Tokens = new Dictionary<TokenType, XSTSToken>();
			WebClient wr = new WebClient();
			wr.Headers[HttpRequestHeader.ContentType] = "application/json";
			wr.Headers["x-xbl-contract-version"] = "0";
			XASURequestContract XASURequestBody = new XASURequestContract
			{
				RelyingParty = "http://auth.xboxlive.com",
				TokenType = "JWT",
				TokenProperties = new XASUTokenProperty
				{
					AuthMethod = "RPS",
					SiteName = "user.auth.xboxlive.com",
					RpsTicket = "d=" + MSAToken
				}
			};
			byte[] requestContent = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(XASURequestBody));
			byte[] array7 = await wr.UploadDataTaskAsync(new Uri("https://user.auth.xboxlive.com/user/authenticate"), requestContent);
			byte[] array3 = array7;
			array7 = null;
			byte[] array4 = array3;
			array3 = null;
			byte[] response = array4;
			array4 = null;
			XASUTokenResponse xasuTokenResponse = XASUTokenResponse.Create(response);
			XSTSRequestContract xstsRequestBody = new XSTSRequestContract
			{
				RelyingParty = "http://xboxlive.com",
				TokenType = "JWT",
				TokenProperties = new XstsTokenProperty
				{
					UserTokens = new string[]
					{
						xasuTokenResponse.Token
					},
					SandboxId = sandboxId
				}
			};
			requestContent = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(xstsRequestBody));
			wr = new WebClient();
			wr.Headers[HttpRequestHeader.ContentType] = "application/json";
			byte[] array8 = await wr.UploadDataTaskAsync(new Uri("https://xsts.auth.xboxlive.com/xsts/authorize"), requestContent);
			byte[] array5 = array8;
			array8 = null;
			byte[] array6 = array5;
			array5 = null;
			response = array6;
			array6 = null;
			Tokens[TokenType.XboxLive] = XSTSToken.Create(response);
			return Tokens;
		}

		// Token: 0x04000099 RID: 153
		private const string XASUBaseURI = "https://user.auth.xboxlive.com/user/authenticate";

		// Token: 0x0400009A RID: 154
		private const string XSTSBaseURI = "https://xsts.auth.xboxlive.com/xsts/authorize";
	}
}

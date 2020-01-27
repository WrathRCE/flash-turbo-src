using System;
using System.Threading.Tasks;
using System.Windows.Media;
using Newtonsoft.Json;
using XboxLiveAccountTool.Contracts;

namespace XboxLiveAccountTool.DataAccess
{
	// Token: 0x02000013 RID: 19
	public class AccountsDataAccess
	{
		// Token: 0x06000084 RID: 132 RVA: 0x00004631 File Offset: 0x00002831
		public AccountsDataAccess(XTokenManager TokenManager, Logger logger)
		{
			this.logger = logger;
			this.TokenManager = TokenManager;
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00004654 File Offset: 0x00002854
		public async Task UpdateGamertagAsync(string gamertag)
		{
			try
			{
				string requestBody = JsonConvert.SerializeObject(new AccountsGtChangeRequestContract
				{
					Gamertag = gamertag
				});
				Response response = await XBLCall.PostAsync(this.AccountsBaseURI + "/gamertag", requestBody, this.TokenManager.userHash, this.TokenManager.XToken, "2");
				this.logger.LogToOutputWindow(Environment.NewLine + "Gamertag changed successfully.", Colors.Green);
				requestBody = null;
				requestBody = null;
				requestBody = null;
			}
			catch (Exception Exception)
			{
				this.logger.LogToOutputWindow(Exception.Message, Colors.Red);
			}
		}

		// Token: 0x04000072 RID: 114
		private XTokenManager TokenManager;

		// Token: 0x04000073 RID: 115
		private Logger logger;

		// Token: 0x04000074 RID: 116
		private string AccountsBaseURI = "https://accounts.xboxlive.com/users/current/profile";
	}
}

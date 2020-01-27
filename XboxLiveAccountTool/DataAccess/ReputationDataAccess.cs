using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XboxLiveAccountTool.Contracts;

namespace XboxLiveAccountTool.DataAccess
{
	// Token: 0x02000017 RID: 23
	public class ReputationDataAccess
	{
		// Token: 0x0600008E RID: 142 RVA: 0x000048A3 File Offset: 0x00002AA3
		public ReputationDataAccess(XTokenManager TokenManager, Logger logger)
		{
			this.logger = logger;
			this.TokenManager = TokenManager;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000048C8 File Offset: 0x00002AC8
		public async Task ResetRepAsync(string fairplayRep, string commsRep, string UGCRep)
		{
			try
			{
				ReputationChangeRequestContract repRequestContract = new ReputationChangeRequestContract
				{
					FairplayRepuation = fairplayRep,
					CommsReputation = commsRep,
					UserContentReputation = UGCRep
				};
				Response response = await XBLCall.PostAsync(this.ReputationBaseURI, JsonConvert.SerializeObject(repRequestContract), this.TokenManager.userHash, this.TokenManager.XToken, "101");
				this.logger.LogToOutputWindow("Reputation set successfully.");
				repRequestContract = null;
				repRequestContract = null;
				repRequestContract = null;
			}
			catch (Exception e)
			{
				this.logger.LogToOutputWindow("Error resetting reputation: " + e.Message);
			}
		}

		// Token: 0x0400007F RID: 127
		private XTokenManager TokenManager;

		// Token: 0x04000080 RID: 128
		private Logger logger;

		// Token: 0x04000081 RID: 129
		private const string contractVersion = "101";

		// Token: 0x04000082 RID: 130
		private string ReputationBaseURI = "https://reputation.xboxlive.com/users/me/resetreputation";
	}
}

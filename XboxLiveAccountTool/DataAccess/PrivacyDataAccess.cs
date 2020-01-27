using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Media;
using Newtonsoft.Json;
using XboxLiveAccountTool.Contracts;
using XboxLiveAccountTool.Helpers;

namespace XboxLiveAccountTool.DataAccess
{
	// Token: 0x02000014 RID: 20
	public class PrivacyDataAccess
	{
		// Token: 0x06000086 RID: 134 RVA: 0x000046A2 File Offset: 0x000028A2
		public PrivacyDataAccess(XTokenManager TokenManager, Logger logger)
		{
			this.logger = logger;
			this.TokenManager = TokenManager;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x000046C8 File Offset: 0x000028C8
		public async Task<List<User>> DownloadBlockListAsync()
		{
			List<User> blockList = new List<User>();
			Response response4 = await XBLCall.GetAsync(this.PrivacyBaseURI + "/users/xuid(" + this.TokenManager.xuid + ")/people/avoid", this.TokenManager.userHash, this.TokenManager.XToken, "2");
			Response response2 = response4;
			response4 = null;
			Response response3 = response2;
			response2 = null;
			Response resp = response3;
			response3 = null;
			PrivacyResponseContract privacyResponse = JsonConvert.DeserializeObject<PrivacyResponseContract>(resp.responseBody);
			foreach (PrivacyUserContract p in privacyResponse.Users)
			{
				blockList.Add(new User
				{
					xuid = p.Xuid
				});
				p = null;
			}
			PrivacyUserContract[] array = null;
			return blockList;
		}

		// Token: 0x06000088 RID: 136 RVA: 0x00004710 File Offset: 0x00002910
		public async Task UpdateUsers(List<User> users, PrivacyOperation operation)
		{
			try
			{
				for (int i = 0; i < users.Count; i += 10)
				{
					List<User> batch = users.Skip(i).Take(10).ToList<User>();
					await this.BatchPrivacyCallAsync(batch, operation);
					batch = null;
					batch = null;
					batch = null;
				}
				this.logger.LogToOutputWindow("Operation complete.");
			}
			catch (Exception ex)
			{
				this.logger.LogToOutputWindow("Error " + ex.Message, Colors.Red);
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00004768 File Offset: 0x00002968
		private async Task BatchPrivacyCallAsync(List<User> PrivacyXuidBatch, PrivacyOperation operation)
		{
			bool flag = PrivacyXuidBatch.Count > 10;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				throw new ArgumentException("PrivacyXuidBatch can only update " + 10.ToString() + " users at a time");
			}
			string operationStr = (operation == PrivacyOperation.Block) ? "Add" : "Remove";
			PrivacyRequestContract privacyRequestData = new PrivacyRequestContract
			{
				Operation = operationStr,
				Users = PrivacyXuidBatch.ToPrivacyUserArray()
			};
			string body = JsonConvert.SerializeObject(privacyRequestData);
			this.logger.LogToOutputWindow("Attempting to update block list status for " + PrivacyXuidBatch.Count + " xuids...");
			Response response = await XBLCall.PostAsync(this.PrivacyBaseURI + "/users/xuid(" + this.TokenManager.xuid + ")/people/never", body, this.TokenManager.userHash, this.TokenManager.XToken, "2");
		}

		// Token: 0x04000075 RID: 117
		private XTokenManager TokenManager;

		// Token: 0x04000076 RID: 118
		private Logger logger;

		// Token: 0x04000077 RID: 119
		private string PrivacyBaseURI = "https://privacy.xboxlive.com";

		// Token: 0x04000078 RID: 120
		private const int PrivacyBatchSize = 10;
	}
}

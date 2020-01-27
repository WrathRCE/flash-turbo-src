using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XboxLiveAccountTool.DataAccess;

namespace XboxLiveAccountTool.Components
{
	// Token: 0x0200003B RID: 59
	public class ReputationManager
	{
		// Token: 0x06000180 RID: 384 RVA: 0x00005440 File Offset: 0x00003640
		public ReputationManager(XTokenManager TokenManager, Logger logger)
		{
			this.statsDAL = new StatsDataAccess(TokenManager);
			this.repDAL = new ReputationDataAccess(TokenManager, logger);
		}

		// Token: 0x06000181 RID: 385 RVA: 0x00005470 File Offset: 0x00003670
		public async Task Load()
		{
			ReputationManager reputationManager = this;
			Dictionary<StatName, string> dictionary = reputationManager.settingsById;
			Dictionary<StatName, string> dictionary4 = await this.statsDAL.DownloadAllStatsAsync();
			Dictionary<StatName, string> dictionary2 = dictionary4;
			dictionary4 = null;
			Dictionary<StatName, string> dictionary3 = dictionary2;
			dictionary2 = null;
			reputationManager.settingsById = dictionary3;
			reputationManager = null;
			dictionary3 = null;
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000054B8 File Offset: 0x000036B8
		public string GetStatValue(StatName name)
		{
			string result = "";
			bool flag = !this.settingsById.TryGetValue(name, out result);
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				result = "N/A";
			}
			return result;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x000054F4 File Offset: 0x000036F4
		public async Task ResetRep(string fairplayRep, string commsRep, string UGCRep)
		{
			await this.repDAL.ResetRepAsync(fairplayRep, commsRep, UGCRep);
		}

		// Token: 0x04000104 RID: 260
		private StatsDataAccess statsDAL;

		// Token: 0x04000105 RID: 261
		private ReputationDataAccess repDAL;

		// Token: 0x04000106 RID: 262
		private Dictionary<StatName, string> settingsById = new Dictionary<StatName, string>();
	}
}

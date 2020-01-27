using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XboxLiveAccountTool.Contracts;

namespace XboxLiveAccountTool.DataAccess
{
	// Token: 0x0200001C RID: 28
	public class StatsDataAccess
	{
		// Token: 0x0600009A RID: 154 RVA: 0x00004A91 File Offset: 0x00002C91
		public StatsDataAccess(XTokenManager TokenManager)
		{
			this.tokenManager = TokenManager;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00004AB0 File Offset: 0x00002CB0
		private static StatName ToStatName(string name)
		{
			return (StatName)Enum.Parse(typeof(StatName), name);
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00004AD8 File Offset: 0x00002CD8
		private string GetStatsURI()
		{
			string text = "7492baca-c1b4-440d-a391-b7ef364a8d40";
			return string.Format("{0}/users/xuid({1})/scids/{2}/stats/{3}", new object[]
			{
				this.statsBaseURI,
				this.tokenManager.xuid,
				text,
				string.Join(",", Enum.GetNames(typeof(StatName)))
			});
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00004B38 File Offset: 0x00002D38
		public async Task<Dictionary<StatName, string>> DownloadAllStatsAsync()
		{
			Dictionary<StatName, string> repStats = new Dictionary<StatName, string>();
			Response response4 = await XBLCall.GetAsync(this.GetStatsURI(), this.tokenManager.userHash, this.tokenManager.XToken, "1");
			Response response2 = response4;
			response4 = null;
			Response response3 = response2;
			response2 = null;
			Response resp = response3;
			response3 = null;
			StatsResponseContract statsResponse = JsonConvert.DeserializeObject<StatsResponseContract>(resp.responseBody);
			foreach (StatContract stat in statsResponse.stats)
			{
				repStats[StatsDataAccess.ToStatName(stat.statname)] = stat.value;
				stat = null;
			}
			StatContract[] array = null;
			return repStats;
		}

		// Token: 0x04000097 RID: 151
		private XTokenManager tokenManager;

		// Token: 0x04000098 RID: 152
		private string statsBaseURI = "https://userstats.xboxlive.com";
	}
}

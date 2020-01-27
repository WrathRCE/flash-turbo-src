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
	// Token: 0x02000018 RID: 24
	public class SocialGraphDataAccess
	{
		// Token: 0x06000090 RID: 144 RVA: 0x00004924 File Offset: 0x00002B24
		public SocialGraphDataAccess(XTokenManager TokenManager, Logger logger)
		{
			this.TokenManager = TokenManager;
			this.logger = logger;
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004948 File Offset: 0x00002B48
		public async Task UpdateSocialGraph(List<User> users, SocialGraphOperation operation)
		{
			for (int i = 0; i < users.Count; i += 25)
			{
				List<User> batch = (from p in users.Skip(i).Take(25)
				where p.xuid != this.TokenManager.xuid
				select p).ToList<User>();
				await this.UpdateSocialGraphBatchAsync(batch, operation);
				batch = null;
				batch = null;
				batch = null;
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000049A0 File Offset: 0x00002BA0
		public async Task<List<User>> DownloadSocialGraphAsync()
		{
			List<User> following = new List<User>();
			Response response4 = await XBLCall.GetAsync(this.SocialGraphBaseURI + "/users/me/people", this.TokenManager.userHash, this.TokenManager.XToken, "2");
			Response response2 = response4;
			response4 = null;
			Response response3 = response2;
			response2 = null;
			Response resp = response3;
			response3 = null;
			SocialGraphResponseContract responseBody = JsonConvert.DeserializeObject<SocialGraphResponseContract>(resp.responseBody);
			foreach (SocialGraphPersonContract s in responseBody.SocialGraphPeople)
			{
				User user = new User();
				user.xuid = s.Xuid;
				user.isFollowingBack = s.IsFollowingCaller;
				user.isFavorite = s.IsFavorite;
				following.Add(user);
				user = null;
				user = null;
				user = null;
				s = null;
			}
			SocialGraphPersonContract[] array = null;
			return following;
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000049E8 File Offset: 0x00002BE8
		public async Task UpdateSocialGraphBatchAsync(List<User> users, SocialGraphOperation operation)
		{
			bool flag = users.Count > 25;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				throw new ArgumentException("AddFollowers can only add " + 25 + " followers at a time");
			}
			this.logger.LogToOutputWindow("Calling social graph with " + users.Count + " xuids...");
			SocialGraphRequestContract requestBody = new SocialGraphRequestContract
			{
				xuids = users.ToXuidArray()
			};
			string body = JsonConvert.SerializeObject(requestBody);
			try
			{
				switch (operation)
				{
				case SocialGraphOperation.Favorite:
				{
					Response response = await XBLCall.PostAsync(this.SocialGraphBaseURI + "/users/xuid(" + this.TokenManager.xuid + ")/people/favorites/xuids?method=add", body, this.TokenManager.userHash, this.TokenManager.XToken, "2");
					break;
				}
				case SocialGraphOperation.Unfavorite:
				{
					Response response2 = await XBLCall.PostAsync(this.SocialGraphBaseURI + "/users/xuid(" + this.TokenManager.xuid + ")/people/favorites/xuids?method=remove", body, this.TokenManager.userHash, this.TokenManager.XToken, "2");
					break;
				}
				case SocialGraphOperation.Follow:
				{
					Response response3 = await XBLCall.PostAsync(this.SocialGraphBaseURI + "/users/xuid(" + this.TokenManager.xuid + ")/people/xuids?method=add", body, this.TokenManager.userHash, this.TokenManager.XToken, "2");
					break;
				}
				case SocialGraphOperation.Unfollow:
				{
					Response response4 = await XBLCall.PostAsync(this.SocialGraphBaseURI + "/users/xuid(" + this.TokenManager.xuid + ")/people/xuids?method=remove", body, this.TokenManager.userHash, this.TokenManager.XToken, "2");
					break;
				}
				}
			}
			catch (Exception ex)
			{
				this.logger.LogToOutputWindow("Failed to update social graph, error: " + ex.Message, Colors.Red);
			}
		}

		// Token: 0x04000083 RID: 131
		private XTokenManager TokenManager;

		// Token: 0x04000084 RID: 132
		private Logger logger;

		// Token: 0x04000085 RID: 133
		private string SocialGraphBaseURI = "https://social.xboxlive.com";

		// Token: 0x04000086 RID: 134
		private const int PeopleBatchSize = 25;
	}
}

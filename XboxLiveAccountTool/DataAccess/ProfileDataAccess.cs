using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XboxLiveAccountTool.Components;
using XboxLiveAccountTool.Contracts;

namespace XboxLiveAccountTool.DataAccess
{
	// Token: 0x02000016 RID: 22
	public class ProfileDataAccess
	{
		// Token: 0x0600008A RID: 138 RVA: 0x000047BD File Offset: 0x000029BD
		public ProfileDataAccess(XTokenManager TokenManager)
		{
			this.TokenManager = TokenManager;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x000047DC File Offset: 0x000029DC
		public async Task<Dictionary<ProfileSettingName, string>> CallProfileService()
		{
			Response response4 = await XBLCall.PostAsync("https://profile.xboxlive.com/users/batch/profile/settings", this.SerializeRequestBody(), this.TokenManager.userHash, this.TokenManager.XToken, "2");
			Response response2 = response4;
			response4 = null;
			Response response3 = response2;
			response2 = null;
			Response resp = response3;
			response3 = null;
			ProfileResponseContract profileResponse = JsonConvert.DeserializeObject<ProfileResponseContract>(resp.responseBody);
			foreach (ProfileSettingContract setting in profileResponse.profileUsers[0].settings)
			{
				this.ProfileSettingById[ProfileDataAccess.StringToProfileSettingName(setting.id)] = setting.value;
				setting = null;
			}
			ProfileSettingContract[] array = null;
			return this.ProfileSettingById;
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00004824 File Offset: 0x00002A24
		private static ProfileSettingName StringToProfileSettingName(string name)
		{
			return (ProfileSettingName)Enum.Parse(typeof(ProfileSettingName), name);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000484C File Offset: 0x00002A4C
		public string SerializeRequestBody()
		{
			ProfileRequestContract value = new ProfileRequestContract
			{
				userIds = new ulong[]
				{
					Convert.ToUInt64(this.TokenManager.xuid)
				},
				settings = Enum.GetNames(typeof(ProfileSettingName))
			};
			return JsonConvert.SerializeObject(value, Formatting.None);
		}

		// Token: 0x0400007C RID: 124
		private XTokenManager TokenManager;

		// Token: 0x0400007D RID: 125
		private const string baseURI = "https://profile.xboxlive.com/users/batch/profile/settings";

		// Token: 0x0400007E RID: 126
		private Dictionary<ProfileSettingName, string> ProfileSettingById = new Dictionary<ProfileSettingName, string>();
	}
}

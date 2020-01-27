using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XboxLiveAccountTool.DataAccess;

namespace XboxLiveAccountTool.Components
{
	// Token: 0x02000039 RID: 57
	public class ProfileManager
	{
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x0600017B RID: 379 RVA: 0x00005383 File Offset: 0x00003583
		// (set) Token: 0x0600017C RID: 380 RVA: 0x0000538B File Offset: 0x0000358B
		public Dictionary<ProfileSettingName, string> settingsById { get; set; }

		// Token: 0x0600017D RID: 381 RVA: 0x00005394 File Offset: 0x00003594
		public ProfileManager(XTokenManager TokenManager)
		{
			this.settingsById = new Dictionary<ProfileSettingName, string>();
			this.profileDAL = new ProfileDataAccess(TokenManager);
		}

		// Token: 0x0600017E RID: 382 RVA: 0x000053B8 File Offset: 0x000035B8
		public async Task LoadAsync()
		{
			Dictionary<ProfileSettingName, string> dictionary2 = await this.profileDAL.CallProfileService();
			Dictionary<ProfileSettingName, string> dictionary = dictionary2;
			dictionary2 = null;
			Dictionary<ProfileSettingName, string> settingsById = dictionary;
			dictionary = null;
			this.settingsById = settingsById;
			settingsById = null;
		}

		// Token: 0x0600017F RID: 383 RVA: 0x00005400 File Offset: 0x00003600
		public string GetProfileSetting(ProfileSettingName setting)
		{
			string result;
			try
			{
				result = this.settingsById[setting];
			}
			catch (KeyNotFoundException)
			{
				result = "";
			}
			return result;
		}

		// Token: 0x040000FA RID: 250
		private ProfileDataAccess profileDAL;
	}
}

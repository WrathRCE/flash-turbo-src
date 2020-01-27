using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using XboxLiveAccountTool.Components;
using XboxLiveAccountTool.DataAccess;
using XboxLiveAccountTool.Helpers;

namespace XboxLiveAccountTool
{
	// Token: 0x02000009 RID: 9
	public partial class MainWindow : Window
	{
		// Token: 0x17000009 RID: 9
		// (set) Token: 0x0600002A RID: 42 RVA: 0x000029D0 File Offset: 0x00000BD0
		private bool PerformingPeopleAction
		{
			set
			{
				this.ButtonUnfollowSelected.IsEnabled = !value;
				this.ButtonBlockSelected.IsEnabled = !value;
				this.ButtonFavSelected.IsEnabled = !value;
				this.ButtonUnFavSelected.IsEnabled = !value;
				this.ButtonUnblockSelected.IsEnabled = !value;
				this.ProgBar.Visibility = (value ? Visibility.Visible : Visibility.Collapsed);
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002A44 File Offset: 0x00000C44
		private async Task FavUnFavFollowSelected(SocialGraphOperation operation)
		{
			this.PerformingPeopleAction = true;
			await this.socialGraphDAL.UpdateSocialGraph(this.ListNowFollowing.ToUserList(), operation);
			this.PerformingPeopleAction = false;
			await this.RefreshAsync();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002A94 File Offset: 0x00000C94
		private async Task BlockOrUnblockSelected(PrivacyOperation operation)
		{
			this.PerformingPeopleAction = true;
			await this.privacyDAL.UpdateUsers(this.ListNowFollowing.ToUserList(), operation);
			this.PerformingPeopleAction = false;
			await this.RefreshAsync();
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002AE4 File Offset: 0x00000CE4
		private async void ButtonUnFavSelected_Click(object sender, RoutedEventArgs e)
		{
			await this.FavUnFavFollowSelected(SocialGraphOperation.Unfavorite);
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002B30 File Offset: 0x00000D30
		private async void ButtonFavSelected_Click(object sender, RoutedEventArgs e)
		{
			await this.FavUnFavFollowSelected(SocialGraphOperation.Favorite);
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002B7C File Offset: 0x00000D7C
		private async void ButtonUnfollowSelected_Click(object sender, RoutedEventArgs e)
		{
			await this.FavUnFavFollowSelected(SocialGraphOperation.Unfollow);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002BC8 File Offset: 0x00000DC8
		private async void ButtonBlockSelected_Click(object sender, RoutedEventArgs e)
		{
			await this.BlockOrUnblockSelected(PrivacyOperation.Block);
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00002C14 File Offset: 0x00000E14
		private async void ButtonUnblockSelected_Click(object sender, RoutedEventArgs e)
		{
			await this.BlockOrUnblockSelected(PrivacyOperation.Unblock);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002C60 File Offset: 0x00000E60
		public async Task UpdateSocialGraphTabAsync()
		{
			List<User> list7 = await this.socialGraphDAL.DownloadSocialGraphAsync();
			List<User> list3 = list7;
			list7 = null;
			List<User> list4 = list3;
			list3 = null;
			List<User> followers = list4;
			list4 = null;
			foreach (User user in followers)
			{
				this.FollowingPeople.Add(user);
				user = null;
			}
			List<User>.Enumerator enumerator7 = default(List<User>.Enumerator);
			List<User>.Enumerator enumerator3 = default(List<User>.Enumerator);
			List<User>.Enumerator enumerator4 = default(List<User>.Enumerator);
			List<User> list8 = await this.privacyDAL.DownloadBlockListAsync();
			List<User> list5 = list8;
			list8 = null;
			List<User> list6 = list5;
			list5 = null;
			List<User> blockList = list6;
			list6 = null;
			foreach (User user2 in blockList)
			{
				User blocked = new User();
				blocked.xuid = user2.xuid;
				blocked.isBlocked = true;
				this.FollowingPeople.Add(blocked);
				blocked = null;
				blocked = null;
				blocked = null;
				user2 = null;
			}
			List<User>.Enumerator enumerator8 = default(List<User>.Enumerator);
			List<User>.Enumerator enumerator5 = default(List<User>.Enumerator);
			List<User>.Enumerator enumerator6 = default(List<User>.Enumerator);
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002CA7 File Offset: 0x00000EA7
		private void TabFollow_Loaded(object sender, RoutedEventArgs e)
		{
			this.DGFollowXuid.DataContext = this;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002CB8 File Offset: 0x00000EB8
		private void ButtonFollowImportXuids(object sender, RoutedEventArgs e)
		{
			try
			{
				TextFileReader.ImportXuidsFromTextFile(this.FollowXuidCollection, this.logger);
			}
			catch (Exception ex)
			{
				this.LogToOutputWindow("Import xuids failed: " + ex.Message, Colors.Red);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002D10 File Offset: 0x00000F10
		private void ButtonFollowImportCSVXuids(object sender, RoutedEventArgs e)
		{
			this.LogToOutputWindow("Importing CSV export of dev accounts from XDP...");
			try
			{
				TextFileReader.ImportXuidsFromCSV(this.FollowXuidCollection, this.logger);
			}
			catch (Exception ex)
			{
				this.LogToOutputWindow("Parse CSV failed: " + ex.Message, Colors.Red);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002D74 File Offset: 0x00000F74
		private async void ButtonFollowGo(object sender, RoutedEventArgs e)
		{
			await this.socialGraphDAL.UpdateSocialGraph(this.FollowXuidCollection.ToUserList(), SocialGraphOperation.Follow);
			this.logger.LogToOutputWindow("Operation complete.");
			this.FollowXuidCollection.Clear();
			await this.RefreshAsync();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002DC0 File Offset: 0x00000FC0
		private async void ButtonChgGT_Click(object sender, RoutedEventArgs e)
		{
			bool flag = this.ButtonChgGT.Content.ToString().Contains("Start") && this.TextboxChgGT.Text.Length >= 1;
			bool flag2 = flag;
			if (flag2)
			{
				this.Bool2 = true;
				this.ButtonChgGT.Content = "Stop";
				this.ButtonChgGT.IsEnabled = false;
				this.TabLogin.IsEnabled = false;
				this.TextboxChgGT.IsEnabled = false;
				bool flag3 = !this.Bool3;
				if (flag3)
				{
					DispatcherTimer DispatcherTimer = new DispatcherTimer();
					DispatcherTimer.Tick += this.dispatcherTimer_Tick;
					DispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 75);
					DispatcherTimer.Start();
					this.Bool3 = true;
					DispatcherTimer = null;
				}
				while (this.ButtonChgGT.Content.ToString().Contains("Stop"))
				{
					await this.accountsDAL.UpdateGamertagAsync(this.TextboxChgGT.Text);
					this.ButtonChgGT.IsEnabled = true;
					await Task.Delay(3000);
					this.Integer2++;
					if (this.Integer2 == 6)
					{
						this.Integer2 = 1;
						this.TextLog.Text = null;
					}
				}
			}
			else if (this.ButtonChgGT.Content.ToString().Contains("Stop"))
			{
				this.Bool2 = false;
				this.ButtonChgGT.Content = "Start";
				this.Integer = 1;
				this.TabLogin.IsEnabled = true;
				this.TextboxChgGT.IsEnabled = true;
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002E0C File Offset: 0x0000100C
		private void dispatcherTimer_Tick(object sender, EventArgs e)
		{
			bool @bool = this.Bool2;
			if (@bool)
			{
				bool flag = !this.Bool;
				if (flag)
				{
					ContentControl buttonChgGT = this.ButtonChgGT;
					object arg = "Stop (";
					int integer = this.Integer;
					this.Integer = integer + 1;
					buttonChgGT.Content = arg + integer + ")";
					bool flag2 = this.TextLog.Text.Contains("Gamertag changed successfully.");
					if (flag2)
					{
						this.Bool = true;
						this.ButtonChgGT.Content = "Claimed!";
						base.Hide();
						MessageBox.Show("Claimed '" + this.TextboxChgGT.Text + "' successfully!", base.Title, MessageBoxButton.OK, MessageBoxImage.Asterisk);
						base.Close();
					}
				}
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002ED6 File Offset: 0x000010D6
		private void TabProfileLoaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002EDC File Offset: 0x000010DC
		private async void ButtonProfileRefresh_Click(object sender, RoutedEventArgs e)
		{
			await this.RefreshAsync();
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002F28 File Offset: 0x00001128
		private async Task UpdateProfileTabAsync()
		{
			this.ProfileDisplaySettings.Clear();
			await this.profileManager.LoadAsync();
			foreach (KeyValuePair<ProfileSettingName, string> kvp in this.profileManager.settingsById)
			{
				DisplaySetting ps = new DisplaySetting
				{
					name = kvp.Key.ToString(),
					value = kvp.Value
				};
				if (!this.DisplaySettingsExclude.Contains(kvp.Key))
				{
					this.ProfileDisplaySettings.Add(ps);
				}
				ps = null;
				ps = null;
				ps = null;
				kvp = default(KeyValuePair<ProfileSettingName, string>);
			}
			Dictionary<ProfileSettingName, string>.Enumerator enumerator4 = default(Dictionary<ProfileSettingName, string>.Enumerator);
			Dictionary<ProfileSettingName, string>.Enumerator enumerator2 = default(Dictionary<ProfileSettingName, string>.Enumerator);
			Dictionary<ProfileSettingName, string>.Enumerator enumerator3 = default(Dictionary<ProfileSettingName, string>.Enumerator);
			this.ImgGamerPic.Source = new BitmapImage(new Uri(this.profileManager.GetProfileSetting(ProfileSettingName.GameDisplayPicRaw)));
			this.DisplayPrivileges.Clear();
			foreach (int priv in this.tokenManager.privileges)
			{
				if (PrivilegeNames.Has(priv))
				{
					this.DisplayPrivileges.Add(PrivilegeNames.Get(priv));
				}
			}
			int[] array = null;
			this.LabelGt.Content = this.profileManager.GetProfileSetting(ProfileSettingName.Gamertag);
			this.LabelXuid.Content = this.tokenManager.xuid;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002F70 File Offset: 0x00001170
		private void ProfileSettingsList_Copy_Click(object sender, RoutedEventArgs e)
		{
			bool flag = this.ProfileSettingsList.SelectedItem != null;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				DisplaySetting displaySetting = (DisplaySetting)this.ProfileSettingsList.SelectedItem;
				Clipboard.SetData(DataFormats.Text, displaySetting.value);
			}
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002ED6 File Offset: 0x000010D6
		private void TabReputation_Loaded(object sender, RoutedEventArgs e)
		{
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002FB8 File Offset: 0x000011B8
		private async Task UpdateRepTabAsync()
		{
			await this.reputationManager.Load();
			try
			{
				this.TextCurFairplayRep.Text = this.reputationManager.GetStatValue(StatName.FairplayReputation);
				this.TextCurUGCRep.Text = this.reputationManager.GetStatValue(StatName.UserContentReputation);
				this.TextCurCommsRep.Text = this.reputationManager.GetStatValue(StatName.CommsReputation);
				this.TextCurOverallRep.Text = this.reputationManager.GetStatValue(StatName.OverallReputation);
				this.TextCurOverallStatIsBad.Text = this.reputationManager.GetStatValue(StatName.OverallReputationIsBad);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("rep get fail " + ex.Message);
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00003000 File Offset: 0x00001200
		private async void ButtonRepSetClick(object sender, RoutedEventArgs ev)
		{
			try
			{
				this.LogToOutputWindow("Setting reputation...");
				this.ProgBar.Visibility = Visibility.Visible;
				await this.reputationManager.ResetRep(this.TextFairplayRep.Text, this.TextCommsRep.Text, this.TextUGCRep.Text);
				await this.RefreshAsync();
			}
			catch (Exception ex)
			{
				this.LogToOutputWindow("Reputation set failed: " + ex.Message, Colors.Red);
			}
			this.ProgBar.Visibility = Visibility.Collapsed;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000304A File Offset: 0x0000124A
		private void ButtonRepBad_Click(object sender, RoutedEventArgs e)
		{
			this.TextFairplayRep.Text = "5";
			this.TextCommsRep.Text = "5";
			this.TextUGCRep.Text = "5";
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003080 File Offset: 0x00001280
		private void ButtonRepGood_Click(object sender, RoutedEventArgs e)
		{
			this.TextFairplayRep.Text = "75";
			this.TextCommsRep.Text = "75";
			this.TextUGCRep.Text = "75";
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000042 RID: 66 RVA: 0x000030B8 File Offset: 0x000012B8
		// (remove) Token: 0x06000043 RID: 67 RVA: 0x000030F0 File Offset: 0x000012F0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private event EventHandler ProfileUpdated;

		// Token: 0x06000044 RID: 68 RVA: 0x00003128 File Offset: 0x00001328
		public MainWindow()
		{
			this.InitializeComponent();
			ServicePointManager.DefaultConnectionLimit = 247473773;
			this.logger = new Logger(this);
			this.tokenManager = new XTokenManager();
			this.accountsDAL = new AccountsDataAccess(this.tokenManager, this.logger);
			this.privacyDAL = new PrivacyDataAccess(this.tokenManager, this.logger);
			this.socialGraphDAL = new SocialGraphDataAccess(this.tokenManager, this.logger);
			this.profileManager = new ProfileManager(this.tokenManager);
			this.reputationManager = new ReputationManager(this.tokenManager, this.logger);
			this.liveAuthManager = new LiveAuthManager(this.WebLogin);
			this.liveAuthManager.LogOnStateUpdated += this.LiveAuthManager_LoginStateUpdated;
			this.UpdateLoginState(MainWindow.LoginState.LoggedOut);
			this.ListNowFollowing.ItemsSource = this.FollowingPeople;
			this.ProfileSettingsList.ItemsSource = this.ProfileDisplaySettings;
			this.ListPrivs.ItemsSource = this.DisplayPrivileges;
			this.DGFollowXuid.ItemsSource = this.FollowXuidCollection;
			this.LogToOutputWindow("Welcome!");
			this.LastErrorMessage = "";
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000032BE File Offset: 0x000014BE
		private void Clear()
		{
			this.LastErrorMessage = "";
			this.ProfileDisplaySettings.Clear();
			this.FollowingPeople.Clear();
			this.DisplayPrivileges.Clear();
		}

		// Token: 0x06000046 RID: 70 RVA: 0x000032F0 File Offset: 0x000014F0
		public async Task RefreshAsync()
		{
			this.LogToOutputWindow("Reloading all data...");
			this.ProgBar.Visibility = Visibility.Visible;
			this.Clear();
			try
			{
				await this.UpdateProfileTabAsync();
			}
			catch (Exception ex)
			{
				this.LastErrorMessage = this.LastErrorMessage + "Error getting profile settings " + ex.Message;
			}
			try
			{
				await this.UpdateSocialGraphTabAsync();
			}
			catch (Exception ex2)
			{
				this.LastErrorMessage = this.LastErrorMessage + "Error getting social graph information " + ex2.Message;
				Debug.WriteLine("Exception figuring out friends - " + ex2.Message);
			}
			try
			{
				await this.UpdateRepTabAsync();
			}
			catch (Exception ex3)
			{
				this.LastErrorMessage = this.LastErrorMessage + "Error getting profile reputation information " + ex3.Message;
			}
			EventHandler profileUpdate = this.ProfileUpdated;
			if (profileUpdate != null)
			{
				profileUpdate(this, new EventArgs());
			}
			this.ProgBar.Visibility = Visibility.Collapsed;
			if (this.LastErrorMessage == "")
			{
				this.LogToOutputWindow("Get profile data complete.");
			}
			else
			{
				this.LogToOutputWindow("Profile refresh errors :\n" + this.LastErrorMessage, Colors.Red);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00003338 File Offset: 0x00001538
		private void LiveAuthManager_LoginStateUpdated(object sender, LogOnStateEventArgs e)
		{
			switch (e.NewState)
			{
			case ELogOnState.SignedIn:
				this.UpdateLoginState(MainWindow.LoginState.LoggedInToLive);
				try
				{
					this.LoginToXBL(this.liveAuthManager.MSAToken, this.TextBoxSandbox.Text);
				}
				catch
				{
					this.UpdateLoginState(MainWindow.LoginState.LoggedInXTokenError);
				}
				break;
			case ELogOnState.SignedOut:
				this.UpdateLoginState(MainWindow.LoginState.LoggedOut);
				break;
			case ELogOnState.Error:
				this.LogToOutputWindow("LIve auth error: " + this.liveAuthManager.LastError, Colors.Red);
				this.UpdateLoginState(MainWindow.LoginState.LoggedOut);
				break;
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000033E8 File Offset: 0x000015E8
		private void LogToOutputWindow(string s)
		{
			this.logger.LogToOutputWindow(s);
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000033F8 File Offset: 0x000015F8
		private void LogToOutputWindow(string s, Color c)
		{
			this.logger.LogToOutputWindow(s, c);
		}

		// Token: 0x0600004A RID: 74 RVA: 0x0000340C File Offset: 0x0000160C
		private async void UpdateLoginState(MainWindow.LoginState state)
		{
			switch (state)
			{
			case MainWindow.LoginState.LoggedOut:
				this.ButtonLogout.IsEnabled = true;
				this.ButtonLogout.Content = "Clear cached login";
				this.ButtonLogin.IsEnabled = true;
				this.ButtonLogin.IsDefault = true;
				this.ButtonXToken.IsEnabled = false;
				this.TextBoxSandbox.IsEnabled = true;
				this.ProgBar.Visibility = Visibility.Collapsed;
				this.XBLTabsAreEnabled = false;
				break;
			case MainWindow.LoginState.LoggingIntoLive:
				this.ButtonLogout.IsEnabled = false;
				this.ButtonLogout.Content = "Logout";
				this.ButtonLogin.IsEnabled = false;
				this.ButtonLogin.IsDefault = false;
				this.ButtonXToken.IsEnabled = false;
				this.TextBoxSandbox.IsEnabled = false;
				this.ProgBar.Visibility = Visibility.Visible;
				this.ProgBar.IsIndeterminate = true;
				this.XBLTabsAreEnabled = false;
				break;
			case MainWindow.LoginState.LoggedInToLive:
				this.ButtonLogout.IsEnabled = true;
				this.ButtonLogout.Content = "Logout";
				this.ButtonLogin.IsEnabled = false;
				this.ButtonXToken.IsEnabled = true;
				this.ButtonXToken.IsDefault = true;
				this.TextBoxSandbox.IsEnabled = true;
				this.ProgBar.Visibility = Visibility.Collapsed;
				this.XBLTabsAreEnabled = false;
				break;
			case MainWindow.LoginState.GettingXToken:
				this.ButtonLogout.IsEnabled = false;
				this.ButtonLogout.Content = "Logout";
				this.ButtonLogin.IsEnabled = false;
				this.ButtonXToken.IsEnabled = false;
				this.ButtonLogin.IsDefault = false;
				this.TextBoxSandbox.IsEnabled = false;
				this.ProgBar.Visibility = Visibility.Visible;
				this.ProgBar.IsIndeterminate = true;
				this.XBLTabsAreEnabled = false;
				break;
			case MainWindow.LoginState.LoggedInXTokenError:
				this.ButtonLogout.IsEnabled = true;
				this.ButtonLogout.Content = "Logout";
				this.ButtonLogin.IsEnabled = false;
				this.ButtonXToken.IsEnabled = true;
				this.ButtonLogin.IsDefault = true;
				this.TextBoxSandbox.IsEnabled = true;
				this.ProgBar.Visibility = Visibility.Collapsed;
				this.XBLTabsAreEnabled = false;
				break;
			case MainWindow.LoginState.LoggedInHaveXToken:
				await this.RefreshAsync();
				this.ButtonLogout.IsEnabled = true;
				this.ButtonLogout.Content = "Logout";
				this.ButtonLogin.IsEnabled = false;
				this.ButtonXToken.IsEnabled = true;
				this.ButtonLogin.IsDefault = true;
				this.TextBoxSandbox.IsEnabled = true;
				this.ProgBar.Visibility = Visibility.Collapsed;
				this.XBLTabsAreEnabled = true;
				break;
			case MainWindow.LoginState.LoggingOut:
				this.ButtonLogout.IsEnabled = false;
				this.ButtonLogout.Content = "Logout";
				this.ButtonLogin.IsEnabled = false;
				this.ButtonXToken.IsEnabled = false;
				this.TextBoxSandbox.IsEnabled = false;
				this.ProgBar.Visibility = Visibility.Visible;
				this.ProgBar.IsIndeterminate = true;
				this.XBLTabsAreEnabled = false;
				break;
			}
		}

		// Token: 0x1700000A RID: 10
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00003450 File Offset: 0x00001650
		private bool XBLTabsAreEnabled
		{
			set
			{
				bool flag = !value;
				bool flag2 = flag;
				bool flag3 = flag2;
				if (flag3)
				{
					foreach (object obj in ((IEnumerable)this.Tabses.Items))
					{
						TabItem tabItem = (TabItem)obj;
						tabItem.IsEnabled = false;
					}
					((TabItem)this.Tabses.Items[0]).IsEnabled = true;
				}
				else
				{
					foreach (object obj2 in ((IEnumerable)this.Tabses.Items))
					{
						TabItem tabItem2 = (TabItem)obj2;
						tabItem2.IsEnabled = true;
					}
				}
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x0000354C File Offset: 0x0000174C
		private void LoginToMSA()
		{
			this.LogToOutputWindow("Logging into Microsoft Account...");
			this.UpdateLoginState(MainWindow.LoginState.LoggingIntoLive);
			try
			{
				this.liveAuthManager.SignIn();
			}
			catch (Exception ex)
			{
				this.LogToOutputWindow("Error signing in: " + ex.Message);
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x000035AC File Offset: 0x000017AC
		private void LogoutOfMSA()
		{
			this.LogToOutputWindow("Logging out of Microsoft Account...");
			this.UpdateLoginState(MainWindow.LoginState.LoggingOut);
			try
			{
				this.liveAuthManager.SignOut();
			}
			catch (Exception ex)
			{
				this.LogToOutputWindow("Error signing out: " + ex.Message);
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000360C File Offset: 0x0000180C
		private async void LoginToXBL(string MSAToken, string sandboxId)
		{
			this.UpdateLoginState(MainWindow.LoginState.GettingXToken);
			this.LogToOutputWindow("Authenticating with Xbox Live...");
			try
			{
				await this.tokenManager.AuthWithServiceAsync(MSAToken, sandboxId);
				this.UpdateLoginState(MainWindow.LoginState.LoggedInHaveXToken);
				this.LogToOutputWindow("Xbox Live Authentication succeeded\nXuid = " + this.tokenManager.xuid);
			}
			catch (Exception e)
			{
				this.LogToOutputWindow("Authentication failed: " + e.Message, Colors.Red);
				if (e.GetType() == typeof(WebException))
				{
					WebException we = (WebException)e;
					if (((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.Unauthorized)
					{
						this.LogToOutputWindow("The account may not have access to sandbox \"" + sandboxId + "\".  Enter a sandbox to which this account has access and try Switch Sandbox.", Colors.Orange);
					}
					we = null;
					we = null;
					we = null;
				}
				this.UpdateLoginState(MainWindow.LoginState.LoggedInXTokenError);
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003656 File Offset: 0x00001856
		private void ButtonLogin_Click(object sender, RoutedEventArgs e)
		{
			this.LoginToMSA();
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003660 File Offset: 0x00001860
		private void ButtonLogout_Click(object sender, RoutedEventArgs e)
		{
			this.LogoutOfMSA();
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000366A File Offset: 0x0000186A
		private void SandboxLogin_Click(object sender, RoutedEventArgs e)
		{
			this.LoginToXBL(this.liveAuthManager.MSAToken, this.TextBoxSandbox.Text);
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000368A File Offset: 0x0000188A
		private void TextBoxSandbox_MouseDown(object sender, MouseButtonEventArgs e)
		{
			this.TextBoxSandbox.Text = "";
		}

		// Token: 0x04000022 RID: 34
		private bool Bool2 = false;

		// Token: 0x04000023 RID: 35
		private bool Bool3 = false;

		// Token: 0x04000024 RID: 36
		private int Integer2 = 1;

		// Token: 0x04000026 RID: 38
		private bool Bool = false;

		// Token: 0x04000027 RID: 39
		private int Integer = 1;

		// Token: 0x04000028 RID: 40
		private LiveAuthManager liveAuthManager;

		// Token: 0x04000029 RID: 41
		private XTokenManager tokenManager;

		// Token: 0x0400002A RID: 42
		private Logger logger;

		// Token: 0x0400002B RID: 43
		private AccountsDataAccess accountsDAL;

		// Token: 0x0400002C RID: 44
		private PrivacyDataAccess privacyDAL;

		// Token: 0x0400002D RID: 45
		private SocialGraphDataAccess socialGraphDAL;

		// Token: 0x0400002E RID: 46
		private ProfileManager profileManager;

		// Token: 0x0400002F RID: 47
		private ReputationManager reputationManager;

		// Token: 0x04000030 RID: 48
		private ObservableCollection<DisplaySetting> ProfileDisplaySettings = new ObservableCollection<DisplaySetting>();

		// Token: 0x04000031 RID: 49
		private ObservableCollection<User> FollowXuidCollection = new ObservableCollection<User>();

		// Token: 0x04000032 RID: 50
		private ObservableCollection<User> FollowingPeople = new ObservableCollection<User>();

		// Token: 0x04000033 RID: 51
		private ObservableCollection<string> DisplayPrivileges = new ObservableCollection<string>();

		// Token: 0x04000034 RID: 52
		private string LastErrorMessage;

		// Token: 0x04000035 RID: 53
		private ProfileSettingName[] DisplaySettingsExclude = new ProfileSettingName[1];

		// Token: 0x02000040 RID: 64
		private enum LoginState
		{
			// Token: 0x0400010F RID: 271
			LoggedOut,
			// Token: 0x04000110 RID: 272
			LoggingIntoLive,
			// Token: 0x04000111 RID: 273
			LoggedInToLive,
			// Token: 0x04000112 RID: 274
			GettingXToken,
			// Token: 0x04000113 RID: 275
			LoggedInXTokenError,
			// Token: 0x04000114 RID: 276
			LoggedInHaveXToken,
			// Token: 0x04000115 RID: 277
			LoggingOut
		}
	}
}

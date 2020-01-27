using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace XboxLiveAccountTool
{
	// Token: 0x02000006 RID: 6
	public class LiveAuthManager
	{
		// Token: 0x06000013 RID: 19 RVA: 0x0000258C File Offset: 0x0000078C
		public LiveAuthManager(WebBrowser weblogin)
		{
			bool flag = weblogin == null;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				throw new ArgumentException("WebBrowser weblogin cannot be null");
			}
			this.m_webLogin = weblogin;
			this.m_webLogin.LoadCompleted += this.WebLogin_LoadCompleted;
			this.LogOnState = ELogOnState.None;
			this.LastError = "";
			this.TokenValid = false;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000025F4 File Offset: 0x000007F4
		public void SignIn()
		{
			bool flag = this.LogOnState == ELogOnState.None || this.LogOnState == ELogOnState.SignedOut || this.LogOnState == ELogOnState.Error;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				this.LogOnState = ELogOnState.SigningIn;
				this.m_webLogin.Visibility = Visibility.Visible;
				this.m_webLogin.Navigate("https://login.live.com/oauth20_authorize.srf?client_id=0000000040177187&scope=Xboxlive.signin&response_type=token&redirect_uri=https://login.live.com/oauth20_desktop.srf");
				return;
			}
			this.LogOnState = ELogOnState.Error;
			throw new Exception("Invalid state to start signin");
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002664 File Offset: 0x00000864
		public void SignOut()
		{
			bool flag = this.LogOnState == ELogOnState.SignedIn || this.LogOnState == ELogOnState.None || this.LogOnState == ELogOnState.SignedOut || this.LogOnState == ELogOnState.Error;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				this.LogOnState = ELogOnState.SigningOut;
				this.m_webLogin.Navigate("https://login.live.com/oauth20_logout.srf");
				return;
			}
			this.LogOnState = ELogOnState.Error;
			throw new Exception("Invalid state to sign out");
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000016 RID: 22 RVA: 0x000026CF File Offset: 0x000008CF
		// (set) Token: 0x06000017 RID: 23 RVA: 0x000026D7 File Offset: 0x000008D7
		public string MSAToken { get; private set; }

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000018 RID: 24 RVA: 0x000026E0 File Offset: 0x000008E0
		// (set) Token: 0x06000019 RID: 25 RVA: 0x000026E8 File Offset: 0x000008E8
		public bool TokenValid { get; private set; }

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600001A RID: 26 RVA: 0x000026F1 File Offset: 0x000008F1
		// (set) Token: 0x0600001B RID: 27 RVA: 0x000026F9 File Offset: 0x000008F9
		public string LastError { get; private set; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002704 File Offset: 0x00000904
		// (set) Token: 0x0600001D RID: 29 RVA: 0x0000271C File Offset: 0x0000091C
		public ELogOnState LogOnState
		{
			get
			{
				return this.m_logonState;
			}
			private set
			{
				bool flag = this.m_logonState != value;
				bool flag2 = flag;
				bool flag5 = flag2;
				if (flag5)
				{
					ELogOnState logonState = this.m_logonState;
					this.m_logonState = value;
					bool flag3 = this.LogOnStateUpdated != null;
					bool flag4 = flag3;
					bool flag6 = flag4;
					if (flag6)
					{
						this.LogOnStateUpdated(this, new LogOnStateEventArgs
						{
							PreviousState = logonState,
							NewState = value
						});
					}
				}
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600001E RID: 30 RVA: 0x0000278C File Offset: 0x0000098C
		// (remove) Token: 0x0600001F RID: 31 RVA: 0x000027C4 File Offset: 0x000009C4
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<LogOnStateEventArgs> LogOnStateUpdated;

		// Token: 0x06000020 RID: 32 RVA: 0x000027FC File Offset: 0x000009FC
		private static string GetAccessTokenFromUri(Uri uri)
		{
			string text = "#access_token=";
			bool flag = uri.Fragment.StartsWith(text);
			bool flag2 = flag;
			bool flag3 = flag2;
			string result;
			if (flag3)
			{
				result = uri.Fragment.Substring(text.Length);
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x0000284C File Offset: 0x00000A4C
		private void WebLogin_LoadCompleted(object sender, NavigationEventArgs e)
		{
			bool flag = e.Uri.LocalPath.IndexOf("oauth20_desktop.srf") >= 0;
			bool flag2 = flag;
			bool flag5 = flag2;
			if (flag5)
			{
				this.MSAToken = LiveAuthManager.GetAccessTokenFromUri(e.Uri);
				this.TokenValid = true;
				this.LogOnState = ELogOnState.SignedIn;
				this.m_webLogin.Visibility = Visibility.Collapsed;
			}
			else
			{
				bool flag3 = e.Uri.LocalPath.IndexOf("oauth20_logout.srf") >= 0;
				bool flag4 = flag3;
				bool flag6 = flag4;
				if (flag6)
				{
					this.m_webLogin.Visibility = Visibility.Collapsed;
					this.LogOnState = ELogOnState.SignedOut;
				}
			}
		}

		// Token: 0x04000016 RID: 22
		private ELogOnState m_logonState;

		// Token: 0x04000017 RID: 23
		private const string CLIENT_ID = "0000000040177187";

		// Token: 0x04000018 RID: 24
		private const string OAUTH_SIGNIN_COMPLETION_PAGE = "oauth20_desktop.srf";

		// Token: 0x04000019 RID: 25
		private const string OAUTH_SIGNIN_URL = "https://login.live.com/oauth20_authorize.srf?client_id=0000000040177187&scope=Xboxlive.signin&response_type=token&redirect_uri=https://login.live.com/oauth20_desktop.srf";

		// Token: 0x0400001A RID: 26
		private const string OAUTH_SIGNOUT_URL = "https://login.live.com/oauth20_logout.srf";

		// Token: 0x0400001B RID: 27
		private const string OAUTH_GETTOKEN_URL = "https://login.live.com/oauth20_token.srf";

		// Token: 0x0400001C RID: 28
		private const string OAUTH_GETTOKEN_CONTENT = "client_id=0000000040177187&redirect_uri=https://login.live.com/oauth20_desktop.srf&grant_type=authorization_code";

		// Token: 0x0400001D RID: 29
		private const string OAUTH_SIGNOUT_PAGE = "oauth20_logout.srf";

		// Token: 0x0400001E RID: 30
		private WebBrowser m_webLogin;

		// Token: 0x0200003E RID: 62
		private enum GetTokenType
		{
			// Token: 0x04000109 RID: 265
			FromCode,
			// Token: 0x0400010A RID: 266
			FromRefreshToken
		}
	}
}

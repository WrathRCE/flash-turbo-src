using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using XboxLiveAccountTool.Contracts;

namespace XboxLiveAccountTool.Helpers
{
	// Token: 0x02000012 RID: 18
	internal static class UserListHelpers
	{
		// Token: 0x06000080 RID: 128 RVA: 0x000044C8 File Offset: 0x000026C8
		public static List<User> ToUserList(this DataGrid datagrid)
		{
			List<User> list = new List<User>();
			foreach (object obj in datagrid.SelectedItems)
			{
				User item = (User)obj;
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000453C File Offset: 0x0000273C
		public static List<User> ToUserList(this ObservableCollection<User> observable)
		{
			List<User> list = new List<User>();
			foreach (User item in observable)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00004598 File Offset: 0x00002798
		public static string[] ToXuidArray(this List<User> list)
		{
			string[] array = new string[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = list[i].xuid;
			}
			return array;
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000045E0 File Offset: 0x000027E0
		public static PrivacyUserContract[] ToPrivacyUserArray(this List<User> list)
		{
			PrivacyUserContract[] array = new PrivacyUserContract[list.Count];
			for (int i = 0; i < list.Count; i++)
			{
				array[i] = new PrivacyUserContract
				{
					Xuid = list[i].xuid
				};
			}
			return array;
		}
	}
}

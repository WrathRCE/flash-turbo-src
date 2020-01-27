using System;

namespace XboxLiveAccountTool.DataAccess
{
	// Token: 0x0200001A RID: 26
	public class Stat
	{
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00004A55 File Offset: 0x00002C55
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00004A5D File Offset: 0x00002C5D
		public string statname { get; set; }

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00004A66 File Offset: 0x00002C66
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00004A6E File Offset: 0x00002C6E
		public string value { get; set; }

		// Token: 0x06000099 RID: 153 RVA: 0x00004A77 File Offset: 0x00002C77
		public Stat(string statname, string value)
		{
			this.statname = statname;
			this.value = value;
		}
	}
}

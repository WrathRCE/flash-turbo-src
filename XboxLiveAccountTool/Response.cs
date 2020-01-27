using System;

namespace XboxLiveAccountTool
{
	// Token: 0x0200000B RID: 11
	public class Response
	{
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00004082 File Offset: 0x00002282
		// (set) Token: 0x06000059 RID: 89 RVA: 0x0000408A File Offset: 0x0000228A
		public bool valid { get; set; }

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00004093 File Offset: 0x00002293
		// (set) Token: 0x0600005B RID: 91 RVA: 0x0000409B File Offset: 0x0000229B
		public string responseBody { get; set; }

		// Token: 0x0600005C RID: 92 RVA: 0x000040A4 File Offset: 0x000022A4
		public Response()
		{
			this.valid = false;
		}
	}
}

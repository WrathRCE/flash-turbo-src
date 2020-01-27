using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace XboxLiveAccountTool
{
	// Token: 0x0200000E RID: 14
	public static class XBLCall
	{
		// Token: 0x06000068 RID: 104 RVA: 0x0000413C File Offset: 0x0000233C
		public static async Task<Response> GetAsync(string uri, string userhash, string xststoken, string contractVersion = "2")
		{
			Response resp = new Response();
			WebClient wc = XBLCall.CreateWCForCall(userhash, xststoken, contractVersion);
			byte[] array4 = await wc.DownloadDataTaskAsync(uri);
			byte[] array2 = array4;
			array4 = null;
			byte[] array3 = array2;
			array2 = null;
			byte[] responseBuffer = array3;
			array3 = null;
			resp.responseBody = Encoding.UTF8.GetString(responseBuffer, 0, responseBuffer.Length);
			resp.valid = true;
			return resp;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x00004198 File Offset: 0x00002398
		public static async Task<Response> PostAsync(string uri, string body, string userhash, string xststoken, string contractVersion = "2")
		{
			return await XBLCall.UploadBodyAsync(uri, body, userhash, xststoken, contractVersion, "POST");
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000041FC File Offset: 0x000023FC
		public static async Task<Response> UploadBodyAsync(string uri, string requestBody, string userhash, string xststoken, string contractVersion = "2", string method = "POST")
		{
			Response resp = new Response();
			try
			{
				WebClient wc = XBLCall.CreateWCForCall(userhash, xststoken, contractVersion);
				byte[] postBuffer = Encoding.UTF8.GetBytes(requestBody);
				byte[] array4 = await wc.UploadDataTaskAsync(uri, method, postBuffer);
				byte[] array2 = array4;
				array4 = null;
				byte[] array3 = array2;
				array2 = null;
				byte[] responseBuffer = array3;
				array3 = null;
				resp.responseBody = Encoding.UTF8.GetString(responseBuffer, 0, responseBuffer.Length);
				resp.valid = true;
				wc = null;
				postBuffer = null;
				responseBuffer = null;
				wc = null;
				postBuffer = null;
				array3 = null;
				responseBuffer = null;
				wc = null;
				postBuffer = null;
				array2 = null;
				array3 = null;
				responseBuffer = null;
			}
			catch (Exception e)
			{
				throw e;
			}
			return resp;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00004268 File Offset: 0x00002468
		public static async Task<Response> DeleteAsync(string uri, string requestBody, string userhash, string xststoken, string contractVersion = "2")
		{
			return await XBLCall.UploadBodyAsync(uri, requestBody, userhash, xststoken, contractVersion, "DELETE");
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000042CC File Offset: 0x000024CC
		private static WebClient CreateWCForCall(string userhash, string xststoken, string contractVersion)
		{
			WebClient webClient = new WebClient();
			webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
			webClient.Headers[HttpRequestHeader.Authorization] = "XBL3.0 x=" + userhash + ";" + xststoken;
			webClient.Headers[HttpRequestHeader.AcceptCharset] = "UTF-8";
			webClient.Headers[HttpRequestHeader.Accept] = "application/json";
			webClient.Headers["x-xbl-contract-version"] = contractVersion;
			return webClient;
		}
	}
}

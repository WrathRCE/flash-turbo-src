using System;
using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Media;

namespace XboxLiveAccountTool
{
	// Token: 0x02000007 RID: 7
	public class Logger
	{
		// Token: 0x06000022 RID: 34 RVA: 0x000028F0 File Offset: 0x00000AF0
		public Logger(MainWindow window)
		{
			this.window = window;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002904 File Offset: 0x00000B04
		public void LogToOutputWindow(string s, Color c)
		{
			this.window.TextLog.Dispatcher.BeginInvoke(new Action(delegate()
			{
				Run run = new Run(s + "\n");
				run.Foreground = new SolidColorBrush(c);
				this.window.TextLog.Inlines.Add(run);
			}), new object[0]);
			this.window.ScrollLog.Dispatcher.BeginInvoke(new Action(delegate()
			{
				this.window.ScrollLog.UpdateLayout();
				this.window.ScrollLog.ScrollToVerticalOffset(this.window.TextLog.ActualHeight);
			}), new object[0]);
			Debug.WriteLine("LOG: " + s);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002993 File Offset: 0x00000B93
		public void LogToOutputWindow(string s)
		{
			this.LogToOutputWindow(s, Colors.White);
		}

		// Token: 0x0400001F RID: 31
		private MainWindow window;
	}
}

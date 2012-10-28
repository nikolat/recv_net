using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace recv_net
{
	static class Program
	{
		// ウィンドウクラスの名前
		private const String ClassName = "れしば";

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			IntPtr hWnd = WindowsAPI.FindWindow(ClassName, null);
			if (hWnd != IntPtr.Zero)
			{
				// ウィンドウが最小化されていた場合には、それを元に戻す
				if (WindowsAPI.IsIconic(hWnd)) WindowsAPI.ShowWindowAsync(hWnd, WindowsAPI.ShowWindowEnum.SW_RESTORE);
				// 既存のウィンドウを前面にだす
				if (!WindowsAPI.SetForegroundWindow(hWnd))
				{
					// ウィンドウを前面に出すのに失敗した場合は、メッセージで通知する
					MessageBox.Show("アプリケーションは既に起動しています。");
				}
			}
			else
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new FormMain());
			}
		}
	}
}

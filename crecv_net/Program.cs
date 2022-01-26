using System;
using System.Runtime.InteropServices;
using recv_net;

namespace crecv_net
{
	// ハンドラ・ルーチンに渡される定数の定義
	public enum CtrlTypes
	{
		CTRL_C_EVENT = 0,
		CTRL_BREAK_EVENT = 1,
		CTRL_CLOSE_EVENT = 2,
		CTRL_LOGOFF_EVENT = 5,
		CTRL_SHUTDOWN_EVENT = 6
	}

	class Program
	{
		// ウィンドウクラスの名前
		private const string ClassName = "れしば";
		// 里々からのメッセージ受信処理オブジェクト
		private ClassResv RecvObj = new ClassResv();

		// Win32 APIであるSetConsoleCtrlHandler関数の宣言
		[DllImport("Kernel32")]
		static extern bool SetConsoleCtrlHandler(HandlerRoutine Handler, bool Add);

		// SetConsoleCtrlHandler関数にメソッド（ハンドラ・ルーチン）を
		// 渡すためのデリゲート型
		delegate bool HandlerRoutine(CtrlTypes CtrlType);

		HandlerRoutine myHandlerDele;

		private Program()
		{
			// myHandlerメソッドの登録
			myHandlerDele = new HandlerRoutine(myHandler);
			SetConsoleCtrlHandler(myHandlerDele, true);

			// 里々からのメッセージ受信処理開始
			RecvObj.RecvEvt += RecvObj_RecvInfoEvt;
			RecvObj.Start_GetMsgFromSATORI();
		}

		// ハンドラ・ルーチン
		private bool myHandler(CtrlTypes ctrlType)
		{
			// 里々からのメッセージ受信処理終了
			RecvObj.End_GetMsgFromSATORI();
			return false;
		}

		private void RecvObj_RecvInfoEvt(object sender, ClassResv.RecvInfEventArgs e)
		{
			// 里々のログを表示
			Console.Write(e.RecvInf);
		}

		private void Run()
		{
			while (true)
			{
				System.Threading.Thread.Sleep(1000); // 終了はCtrl+Cで
			}
		}

		static void Main(string[] args)
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
					Console.WriteLine("アプリケーションは既に起動しています。");
					Console.WriteLine("（何かキーを押してください）");
					Console.ReadLine();
				}
			}
			else
			{
				(new Program()).Run();
			}
		}
	}
}

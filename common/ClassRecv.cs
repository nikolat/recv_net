using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Threading;

namespace recv_net
{
	class ClassResv
	{
		// 里々からの情報を送信するイベントの定義
		public class RecvInfEventArgs : EventArgs
		{
			public String RecvInf;
		}
		public delegate void RecvEventHandler(object sender, RecvInfEventArgs e);
		public event RecvEventHandler RecvEvt;
		protected virtual void OnRecvEvt(RecvInfEventArgs e)
		{
			if (RecvEvt != null)
			{
				RecvEvt(this, e);
			}
		}

		// ウィンドウクラスの名前
		private const String ClassName = "れしば";

		// ウィンドウクラス登録API
		private delegate int D_WNDPROC(int hWnd, int wMsg, int wParam, int lParam);
		[StructLayout(LayoutKind.Sequential)]
		private struct WNDCLASSEX
		{
			public int cbSize;              // 構造体サイズ
			public int style;               // スタイル
			public D_WNDPROC lpfnWndProc;   // ウィンドウ処理関数
			public int cbClsExtra;          // 拡張情報1
			public int cbWndExtra;          // 拡張情報2
			public int hInstance;           // インスタンのスハンドル
			public int hIcon;               // アイコンのハンドル
			public int hCursor;             // カーソルのハンドル
			public int hbrBackground;       // ウィンドウ背景のハンドル
			public int lpszMenuName;        // メニューの名前
			public String lpszClassName;    // ウィンドウクラスの名前
			public int hIconSm;             // 小さいアイコンのハンドル
		};
		[DllImport("user32.dll", EntryPoint = "RegisterClassExA")]
		private static extern int RegisterClassEx(ref WNDCLASSEX wcex);

		// ウィンドウ作成API
		[DllImport("user32.dll", EntryPoint = "CreateWindowExA")]
		private static extern int CreateWindowEx(
			int dwExStyle, String lpClassName,
			String lpWindowName, int dwStyle,
			int X, int Y, int nWidth, int nHeight,
			int hWndParent, int hMenu,
			int hInstance, int lpParam);

		// ウィンドウ破棄API
		[DllImport("user32.dll")]
		private static extern int DestroyWindow(int hWnd);

		// メッセージ取得API
		[DllImport("user32.dll", EntryPoint = "GetMessageA")]
		private static extern int GetMessage(
			ref Message lpMsg, int hWnd,
			int wMsgFilterMin, int wMsgFilterMax);

		// ウィンドウプロシージャへのメッセージ送信API
		[DllImport("user32.dll")]
		private static extern int TranslateMessage(ref Message lpMsg);
		[DllImport("user32.dll", EntryPoint = "DispatchMessageA")]
		private static extern int DispatchMessage(ref Message lpMsg);

		// デフォルトのメッセージ処理API
		[DllImport("user32.dll", EntryPoint = "DefWindowProcA")]
		private static extern int DefWindowProc(
			int hWnd, int wMsg, int wParam, int lParam);

		// メッセージ送信API
		[DllImport("user32.dll", EntryPoint = "SendMessageA")]
		private static extern int SendMessage(
			int hWnd, int wMsg, int wParam, int lParam);
		[DllImport("user32.dll", EntryPoint = "PostMessageA")]
		private static extern int PostMessage(
			int hWnd, int wMsg, int wParam, int lParam);

		// ウィンドウ・メッセージの定義
		private const int WM_NULL = 0x0;
		private const int WM_DESTROY = 0x2;
		private const int WM_CLOSE = 0x10;
		private const int WM_QUIT = 0x12;

		// 里々からのメッセージ定義
		private const int WM_COPYDATA = 0x4A;
		[StructLayout(LayoutKind.Sequential)]
		private struct COPYDATASTRUCT
		{
		    public IntPtr dwData;
			public int cbData;
			public IntPtr lpData;
		};

		// ウィンドウ処理関数をデリゲート変数に保存
		// (ガベージ コレクションされたデリゲートのエラー例外の対応)
		private D_WNDPROC MsgFromSATORI_WndProc;

		// ウィンドウクラスのスレッド
		private Thread MsgFromSATORI_Thread = null;

		// ウィンドウクラスのハンドル
		private int MsgFromSATORI_hWnd = 0;

		// 里々からのメッセージ受信処理開始
		public void Start_GetMsgFromSATORI()
		{
			try
			{
				MsgFromSATORI_WndProc = MyWndProc;
				MsgFromSATORI_Thread = new Thread(new ThreadStart(GetMsgFromSATORI));
				if (MsgFromSATORI_Thread != null)
				{
					MsgFromSATORI_Thread.Start();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// 里々からのメッセージ受信処理終了
		public void End_GetMsgFromSATORI()
		{
			try
			{
				if (MsgFromSATORI_hWnd != 0)
				{
					SendMessage(MsgFromSATORI_hWnd, WM_DESTROY, 0, 0);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// 里々からのメッセージ受信処理
		private void GetMsgFromSATORI()
		{
			try
			{
				// ウィンドウクラス登録
				WNDCLASSEX wcex = new WNDCLASSEX();
				wcex.cbSize = Marshal.SizeOf(wcex);
				wcex.hInstance =
					(int)Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().ManifestModule);
				wcex.lpszClassName = ClassName;
				wcex.lpfnWndProc = MsgFromSATORI_WndProc;
				wcex.style = 0;
				wcex.hIcon = 0;
				wcex.hIconSm = 0;
				wcex.hCursor = 0;
				wcex.lpszMenuName = 0;
				wcex.cbClsExtra = 0;
				wcex.cbWndExtra = 0;
				wcex.hbrBackground = 0;
				int a = RegisterClassEx(ref wcex);

				// ウィンドウ作成
				MsgFromSATORI_hWnd =
					CreateWindowEx(0, wcex.lpszClassName, wcex.lpszClassName,
					0, 0, 0, 0, 0, 0, 0, wcex.hInstance, 0);

				if (MsgFromSATORI_hWnd != 0)
				{
					// メッセージ取得
					int rtn;
					Message mmm = new Message();
					while (true)
					{
						rtn = GetMessage(ref mmm, MsgFromSATORI_hWnd, 0, 0);
						if (rtn <= 0) break;
						// ウィンドウプロシージャへのメッセージ送信
						try { TranslateMessage(ref mmm); }
						catch (Exception) { }
						try { DispatchMessage(ref mmm); }
						catch (Exception) { }
					}
				}
			}
			catch (Exception) { }
			finally
			{
				// ウィンドウ破棄
				try { DestroyWindow(MsgFromSATORI_hWnd); }
				catch (Exception) { }
				// ウィンドウクラスのハンドル初期化
				MsgFromSATORI_hWnd = 0;
			}
		}

		// カスタマイズしたウィンドウ処理関数
		private int MyWndProc(int hWnd, int wMsg, int wParam, int lParam)
		{
			try
			{
				switch (wMsg)
				{
					case WM_COPYDATA:
						string str = "";
						COPYDATASTRUCT cds = new COPYDATASTRUCT();
						cds = (COPYDATASTRUCT)Marshal.PtrToStructure((IntPtr)lParam, typeof(COPYDATASTRUCT));
						if (cds.cbData > 0)
						{
							byte[] data = new byte[cds.cbData];
							Marshal.Copy(cds.lpData, data, 0, cds.cbData);
							Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
							str = sjisEnc.GetString(data).Replace("\0", "\r\n");
						}
						RecvInfEventArgs e = new RecvInfEventArgs();
						e.RecvInf = str;
						OnRecvEvt(e);
						return 0;
					case WM_DESTROY:
						PostMessage(hWnd, WM_QUIT, 0, 0);
						break;
					case WM_CLOSE:
						break;
					case WM_QUIT:
						break;
					case WM_NULL:
						break;
				}
				// デフォルトのメッセージ処理
				return DefWindowProc(hWnd, wMsg, wParam, lParam);
			}
			catch (Exception) { }
			return 0;
		}
	}
}

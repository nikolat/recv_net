using System;
using System.Runtime.InteropServices;

namespace recv_net
{
	/// <summary>
	/// Windows API にアクセスするための静的クラスです。
	/// </summary>
	public static class WindowsAPI
	{
		/// <summary>
		/// ShowWindow Commands 定数を列挙型にしたものです。
		/// VC\PratformSDK\Includes\winuser.h を参考にしました。
		/// </summary>
		public enum ShowWindowEnum : int
		{
			SW_HIDE = 0,
			SW_NORMAL = 1,
			SW_SHOWMINIMIZED = 2,
			SW_MAXIMIZE = 3,
			SW_SHOWNOACTIVATE = 4,
			SW_SHOW = 5,
			SW_MINIMIZE = 6,
			SW_SHOWMINNOACTIVE = 7,
			SW_SHOWNA = 8,
			SW_RESTORE = 9,
			SW_SHOWDEFAULT = 10,
			SW_MAX = 11
		}

		/// <summary>
		/// 最前面に表示されるウィンドウを指定する Windows API です。
		/// </summary>
		/// <param name="hWnd">対象となるウィンドウハンドルです。</param>
		/// <returns>正常に終了した場合に true が返ります。</returns>
		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		/// <summary>
		/// ウィンドウの状態を変更する Windows API です。
		/// </summary>
		/// <param name="hWnd">対象となるウィンドウハンドルです。</param>
		/// <param name="nCmdShow">ウィンドウの状態を示す ShowWindowEnum 列挙子です。</param>
		/// <returns>設定前にウィンドウが可視状態だった場合に true が返ります。</returns>
		[DllImport("user32.dll")]
		public static extern bool ShowWindowAsync(IntPtr hWnd, ShowWindowEnum nCmdShow);

		/// <summary>
		/// 指定したウィンドウが最小化されているかどうかを判定する Windows API です。
		/// </summary>
		/// <param name="hWnd">対象となるウィンドウハンドルです。</param>
		/// <returns>ウィンドウが最小化に設定されている場合に true が返ります。</returns>
		[DllImport("user32.dll")]
		public static extern bool IsIconic(IntPtr hWnd);

		/// <summary>
		/// ウィンドウクラス名やウィンドウタイトルから、該当するウィンドウハンドルを取得する Windows API です。
		/// </summary>
		/// <param name="lpClassName">ウィンドウクラス名を指定します。null を指定した場合には、あらゆるウィンドウクラス名が該当するものとします。</param>
		/// <param name="lpWindowName">ウィンドウタイトルを指定します。null を指定した場合には、あらゆるウィンドウタイトルが該当するものとします。</param>
		/// <returns>該当したウィンドウハンドルです。取得できなかった場合は IntPtr.Zero が返ります。</returns>
		[DllImport("user32.dll")]
		public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
	}
}

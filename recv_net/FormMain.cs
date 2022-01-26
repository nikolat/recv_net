using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace recv_net
{
	public partial class FormMain : Form
	{
		// 里々からのメッセージ受信処理オブジェクト
		private ClassResv RecvObj = new ClassResv();
		// 内部保持用ログテキスト
		private string logMsg = "";

		public FormMain()
		{
			InitializeComponent();
		}

		private void FormMain_Load(object sender, EventArgs e)
		{
			// 里々からのメッセージ受信処理開始
			RecvObj.RecvEvt += RecvObj_RecvInfoEvt;
			RecvObj.Start_GetMsgFromSATORI();
		}

		private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
		{
			// 里々からのメッセージ受信処理終了
			RecvObj.End_GetMsgFromSATORI();
		}

		// デリゲートの宣言(有効で無いスレッド間の操作用)
		private delegate void D_DspMyTextBox(string inf);

		private void RecvObj_RecvInfoEvt(object sender, ClassResv.RecvInfEventArgs e)
		{
			// TextBoxLogに里々のログを表示(有効で無いスレッド間の操作用)
			TextBoxLog.Invoke(new D_DspMyTextBox(DspMyTextBox), e.RecvInf);
		}

		public void DspMyTextBox(string inf)
		{
			if (this.ToolStripMenuItem_Pause.Checked)
			{
				// ログを内部に保持し、表示は反映しない
				logMsg += inf;
			}
			else
			{
				// ログを内部に保持し、TextBoxLogに里々のログを表示
				logMsg += inf;
				TextBoxLog.AppendText(inf);
			}
		}

		//======================================================================
		// 特殊ショートカットキー
		//======================================================================
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Escape:
					ClearText();
					return false;
				case Keys.Pause:
					PauseUpdate();
					return false;
				default:
					return base.ProcessCmdKey(ref msg, keyData);
			}
		}

		//======================================================================
		// メニュー
		//======================================================================
		// [ファイル]
		// 保存
		private void ToolStripMenuItem_Save_Click(object sender, EventArgs e)
		{
			string path = Path.ChangeExtension(
				Application.ExecutablePath, ".txt");
			StreamWriter sw = new StreamWriter(
				path, false, Encoding.GetEncoding("shift_jis"));
			sw.Write(TextBoxLog.Text);
			sw.Close();
			System.Diagnostics.Process.Start(path);
		}
		// 終了
		private void ToolStripMenuItem_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// [編集]
		// クリア
		private void ToolStripMenuItem_Clear_Click(object sender, EventArgs e)
		{
			ClearText();
		}
		private void ClearText()
		{
			TextBoxLog.Text = "";
			logMsg = "";
		}
		// 表示を更新
		private void ToolStripMenuItem_Update_Click(object sender, EventArgs e)
		{
			updateTextBox();
		}
		private void updateTextBox()
		{
			TextBoxLog.Text = logMsg;
			TextBoxLog.SelectionStart = TextBoxLog.Text.Length;
			TextBoxLog.Focus();
			TextBoxLog.ScrollToCaret();
		}

		// [設定]
		// リアルタイムで更新しない
		private void RToolStripMenuItem_Pause_Click(object sender, EventArgs e)
		{
			PauseUpdate();
		}
		private void PauseUpdate()
		{
			if (this.ToolStripMenuItem_Pause.Checked)
			{
				updateTextBox();
			}
			this.ToolStripMenuItem_Pause.Checked =
				!this.ToolStripMenuItem_Pause.Checked;
		}
		// 常に手前に表示
		private void ToolStripMenuItem_TopMost_Click(object sender, EventArgs e)
		{
			this.ToolStripMenuItem_TopMost.Checked =
				!this.ToolStripMenuItem_TopMost.Checked;
			this.TopMost = !this.TopMost;
		}
	}
}

namespace recv_net
{
	partial class FormMain
	{
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナで生成されたコード

		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.TextBoxLog = new System.Windows.Forms.TextBox();
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Sep1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Clear = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Update = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Config = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Pause = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_RecieveCondition = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Sep2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItem_TopMost = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// TextBoxLog
			// 
			this.TextBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.TextBoxLog.Location = new System.Drawing.Point(12, 29);
			this.TextBoxLog.Multiline = true;
			this.TextBoxLog.Name = "TextBoxLog";
			this.TextBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.TextBoxLog.Size = new System.Drawing.Size(560, 372);
			this.TextBoxLog.TabIndex = 0;
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.ToolStripMenuItem_Edit,
            this.ToolStripMenuItem_Config});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(584, 26);
			this.menuStripMain.TabIndex = 1;
			this.menuStripMain.Text = "menuStripMain";
			// 
			// ToolStripMenuItem_File
			// 
			this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Save,
            this.ToolStripMenuItem_Sep1,
            this.ToolStripMenuItem_Close});
			this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
			this.ToolStripMenuItem_File.Size = new System.Drawing.Size(85, 22);
			this.ToolStripMenuItem_File.Text = "ファイル(&F)";
			// 
			// ToolStripMenuItem_Save
			// 
			this.ToolStripMenuItem_Save.Name = "ToolStripMenuItem_Save";
			this.ToolStripMenuItem_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.ToolStripMenuItem_Save.Size = new System.Drawing.Size(165, 22);
			this.ToolStripMenuItem_Save.Text = "保存(&T)";
			this.ToolStripMenuItem_Save.Click += new System.EventHandler(this.ToolStripMenuItem_Save_Click);
			// 
			// ToolStripMenuItem_Sep1
			// 
			this.ToolStripMenuItem_Sep1.Name = "ToolStripMenuItem_Sep1";
			this.ToolStripMenuItem_Sep1.Size = new System.Drawing.Size(162, 6);
			// 
			// ToolStripMenuItem_Close
			// 
			this.ToolStripMenuItem_Close.Name = "ToolStripMenuItem_Close";
			this.ToolStripMenuItem_Close.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.ToolStripMenuItem_Close.Size = new System.Drawing.Size(165, 22);
			this.ToolStripMenuItem_Close.Text = "終了(&E)";
			this.ToolStripMenuItem_Close.Click += new System.EventHandler(this.ToolStripMenuItem_Close_Click);
			// 
			// ToolStripMenuItem_Edit
			// 
			this.ToolStripMenuItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Clear,
            this.ToolStripMenuItem_Update});
			this.ToolStripMenuItem_Edit.Name = "ToolStripMenuItem_Edit";
			this.ToolStripMenuItem_Edit.Size = new System.Drawing.Size(61, 22);
			this.ToolStripMenuItem_Edit.Text = "編集(&E)";
			// 
			// ToolStripMenuItem_Clear
			// 
			this.ToolStripMenuItem_Clear.Name = "ToolStripMenuItem_Clear";
			this.ToolStripMenuItem_Clear.ShortcutKeyDisplayString = "Esc";
			this.ToolStripMenuItem_Clear.Size = new System.Drawing.Size(177, 22);
			this.ToolStripMenuItem_Clear.Text = "クリア(&C)";
			this.ToolStripMenuItem_Clear.Click += new System.EventHandler(this.ToolStripMenuItem_Clear_Click);
			// 
			// ToolStripMenuItem_Update
			// 
			this.ToolStripMenuItem_Update.Name = "ToolStripMenuItem_Update";
			this.ToolStripMenuItem_Update.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.ToolStripMenuItem_Update.Size = new System.Drawing.Size(177, 22);
			this.ToolStripMenuItem_Update.Text = "表示を更新(&U)";
			this.ToolStripMenuItem_Update.Click += new System.EventHandler(this.ToolStripMenuItem_Update_Click);
			// 
			// ToolStripMenuItem_Config
			// 
			this.ToolStripMenuItem_Config.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Pause,
            this.ToolStripMenuItem_RecieveCondition,
            this.ToolStripMenuItem_Sep2,
            this.ToolStripMenuItem_TopMost});
			this.ToolStripMenuItem_Config.Name = "ToolStripMenuItem_Config";
			this.ToolStripMenuItem_Config.Size = new System.Drawing.Size(62, 22);
			this.ToolStripMenuItem_Config.Text = "設定(&C)";
			// 
			// ToolStripMenuItem_Pause
			// 
			this.ToolStripMenuItem_Pause.Name = "ToolStripMenuItem_Pause";
			this.ToolStripMenuItem_Pause.ShortcutKeyDisplayString = "Pause";
			this.ToolStripMenuItem_Pause.Size = new System.Drawing.Size(280, 22);
			this.ToolStripMenuItem_Pause.Text = "リアルタイムで更新しない(&S)";
			this.ToolStripMenuItem_Pause.Click += new System.EventHandler(this.RToolStripMenuItem_Pause_Click);
			// 
			// ToolStripMenuItem_RecieveCondition
			// 
			this.ToolStripMenuItem_RecieveCondition.Enabled = false;
			this.ToolStripMenuItem_RecieveCondition.Name = "ToolStripMenuItem_RecieveCondition";
			this.ToolStripMenuItem_RecieveCondition.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.ToolStripMenuItem_RecieveCondition.Size = new System.Drawing.Size(280, 22);
			this.ToolStripMenuItem_RecieveCondition.Text = "受付条件(&R)";
			// 
			// ToolStripMenuItem_Sep2
			// 
			this.ToolStripMenuItem_Sep2.Name = "ToolStripMenuItem_Sep2";
			this.ToolStripMenuItem_Sep2.Size = new System.Drawing.Size(277, 6);
			// 
			// ToolStripMenuItem_TopMost
			// 
			this.ToolStripMenuItem_TopMost.Name = "ToolStripMenuItem_TopMost";
			this.ToolStripMenuItem_TopMost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.ToolStripMenuItem_TopMost.Size = new System.Drawing.Size(280, 22);
			this.ToolStripMenuItem_TopMost.Text = "常に手前に表示(&T)";
			this.ToolStripMenuItem_TopMost.Click += new System.EventHandler(this.ToolStripMenuItem_TopMost_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 413);
			this.Controls.Add(this.TextBoxLog);
			this.Controls.Add(this.menuStripMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripMain;
			this.Name = "FormMain";
			this.Text = "れしば.NET";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TextBoxLog;
		private System.Windows.Forms.MenuStrip menuStripMain;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Save;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Edit;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Config;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Clear;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Update;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Pause;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_RecieveCondition;
		private System.Windows.Forms.ToolStripSeparator ToolStripMenuItem_Sep1;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Close;
		private System.Windows.Forms.ToolStripSeparator ToolStripMenuItem_Sep2;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_TopMost;
	}
}


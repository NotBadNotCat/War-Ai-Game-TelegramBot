namespace Shotgun_Roulette_Game_TelegramBot
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userIdListBox = new System.Windows.Forms.ListBox();
            this.openChatButton = new System.Windows.Forms.Button();
            this.loadInfoButton = new System.Windows.Forms.Button();
            this.infoGroupBox = new System.Windows.Forms.GroupBox();
            this.stopAllMatchButton = new System.Windows.Forms.Button();
            this.matchInfoLabel = new System.Windows.Forms.Label();
            this.buttonGroupBox = new System.Windows.Forms.GroupBox();
            this.saveAllButton = new System.Windows.Forms.Button();
            this.clearMessageDBButton = new System.Windows.Forms.Button();
            this.buttonGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // userIdListBox
            // 
            this.userIdListBox.BackColor = System.Drawing.Color.AntiqueWhite;
            this.userIdListBox.DisplayMember = "1";
            this.userIdListBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userIdListBox.FormattingEnabled = true;
            this.userIdListBox.ItemHeight = 21;
            this.userIdListBox.Location = new System.Drawing.Point(12, 72);
            this.userIdListBox.Name = "userIdListBox";
            this.userIdListBox.Size = new System.Drawing.Size(320, 571);
            this.userIdListBox.TabIndex = 0;
            // 
            // openChatButton
            // 
            this.openChatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.openChatButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.openChatButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.openChatButton.Location = new System.Drawing.Point(12, 12);
            this.openChatButton.Name = "openChatButton";
            this.openChatButton.Size = new System.Drawing.Size(158, 53);
            this.openChatButton.TabIndex = 1;
            this.openChatButton.Text = "Открыть чат с пользователем";
            this.openChatButton.UseVisualStyleBackColor = false;
            this.openChatButton.Click += new System.EventHandler(this.openChatButton_Click);
            // 
            // loadInfoButton
            // 
            this.loadInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.loadInfoButton.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.loadInfoButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loadInfoButton.Location = new System.Drawing.Point(176, 12);
            this.loadInfoButton.Name = "loadInfoButton";
            this.loadInfoButton.Size = new System.Drawing.Size(156, 53);
            this.loadInfoButton.TabIndex = 1;
            this.loadInfoButton.Text = "Загрузить информацию о пользователе";
            this.loadInfoButton.UseVisualStyleBackColor = false;
            // 
            // infoGroupBox
            // 
            this.infoGroupBox.BackColor = System.Drawing.Color.DarkSlateGray;
            this.infoGroupBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.infoGroupBox.ForeColor = System.Drawing.Color.White;
            this.infoGroupBox.Location = new System.Drawing.Point(338, 12);
            this.infoGroupBox.Name = "infoGroupBox";
            this.infoGroupBox.Size = new System.Drawing.Size(578, 451);
            this.infoGroupBox.TabIndex = 2;
            this.infoGroupBox.TabStop = false;
            this.infoGroupBox.Text = "Информация";
            // 
            // stopAllMatchButton
            // 
            this.stopAllMatchButton.BackColor = System.Drawing.Color.Brown;
            this.stopAllMatchButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopAllMatchButton.Location = new System.Drawing.Point(6, 32);
            this.stopAllMatchButton.Name = "stopAllMatchButton";
            this.stopAllMatchButton.Size = new System.Drawing.Size(94, 58);
            this.stopAllMatchButton.TabIndex = 3;
            this.stopAllMatchButton.Text = "Остановить все матчи";
            this.stopAllMatchButton.UseVisualStyleBackColor = false;
            // 
            // matchInfoLabel
            // 
            this.matchInfoLabel.AutoSize = true;
            this.matchInfoLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.matchInfoLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.matchInfoLabel.Location = new System.Drawing.Point(348, 487);
            this.matchInfoLabel.Name = "matchInfoLabel";
            this.matchInfoLabel.Size = new System.Drawing.Size(11, 13);
            this.matchInfoLabel.TabIndex = 4;
            this.matchInfoLabel.Text = "-";
            // 
            // buttonGroupBox
            // 
            this.buttonGroupBox.BackColor = System.Drawing.Color.SeaGreen;
            this.buttonGroupBox.Controls.Add(this.saveAllButton);
            this.buttonGroupBox.Controls.Add(this.clearMessageDBButton);
            this.buttonGroupBox.Controls.Add(this.stopAllMatchButton);
            this.buttonGroupBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGroupBox.ForeColor = System.Drawing.Color.White;
            this.buttonGroupBox.Location = new System.Drawing.Point(524, 469);
            this.buttonGroupBox.Name = "buttonGroupBox";
            this.buttonGroupBox.Size = new System.Drawing.Size(392, 174);
            this.buttonGroupBox.TabIndex = 3;
            this.buttonGroupBox.TabStop = false;
            this.buttonGroupBox.Text = "Кнопки управления";
            // 
            // saveAllButton
            // 
            this.saveAllButton.BackColor = System.Drawing.Color.Brown;
            this.saveAllButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveAllButton.Location = new System.Drawing.Point(288, 32);
            this.saveAllButton.Name = "saveAllButton";
            this.saveAllButton.Size = new System.Drawing.Size(94, 58);
            this.saveAllButton.TabIndex = 3;
            this.saveAllButton.Text = "Сохранить всё";
            this.saveAllButton.UseVisualStyleBackColor = false;
            // 
            // clearMessageDBButton
            // 
            this.clearMessageDBButton.BackColor = System.Drawing.Color.Brown;
            this.clearMessageDBButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.clearMessageDBButton.Location = new System.Drawing.Point(106, 32);
            this.clearMessageDBButton.Name = "clearMessageDBButton";
            this.clearMessageDBButton.Size = new System.Drawing.Size(176, 58);
            this.clearMessageDBButton.TabIndex = 3;
            this.clearMessageDBButton.Text = "Удалить все сохраненные сообщения";
            this.clearMessageDBButton.UseVisualStyleBackColor = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(928, 659);
            this.Controls.Add(this.buttonGroupBox);
            this.Controls.Add(this.matchInfoLabel);
            this.Controls.Add(this.infoGroupBox);
            this.Controls.Add(this.loadInfoButton);
            this.Controls.Add(this.openChatButton);
            this.Controls.Add(this.userIdListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Окно администрирования";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.buttonGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox userIdListBox;
        private Button openChatButton;
        private Button loadInfoButton;
        private GroupBox infoGroupBox;
        private Button stopAllMatchButton;
        private Label matchInfoLabel;
        private GroupBox buttonGroupBox;
        private Button saveAllButton;
        private Button clearMessageDBButton;
    }
}
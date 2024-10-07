namespace War_Ai_Game_TelegramBot
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
            components = new System.ComponentModel.Container();
            userIdListBox = new ListBox();
            openChatButton = new Button();
            loadInfoButton = new Button();
            infoGroupBox = new GroupBox();
            stopAllMatchButton = new Button();
            matchInfoLabel = new Label();
            buttonGroupBox = new GroupBox();
            usersBannedRadioButton = new RadioButton();
            usersRadioButton = new RadioButton();
            saveAllButton = new Button();
            clearMessageDBButton = new Button();
            banUserButton = new Button();
            updateTimer = new System.Windows.Forms.Timer(components);
            buttonGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // userIdListBox
            // 
            userIdListBox.BackColor = Color.AntiqueWhite;
            userIdListBox.DisplayMember = "1";
            userIdListBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            userIdListBox.FormattingEnabled = true;
            userIdListBox.ItemHeight = 21;
            userIdListBox.Location = new Point(12, 72);
            userIdListBox.Name = "userIdListBox";
            userIdListBox.Size = new Size(320, 571);
            userIdListBox.TabIndex = 0;
            // 
            // openChatButton
            // 
            openChatButton.BackColor = Color.FromArgb(0, 64, 0);
            openChatButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            openChatButton.ForeColor = SystemColors.ButtonHighlight;
            openChatButton.Location = new Point(12, 12);
            openChatButton.Name = "openChatButton";
            openChatButton.Size = new Size(158, 53);
            openChatButton.TabIndex = 1;
            openChatButton.Text = "Открыть чат с пользователем";
            openChatButton.UseVisualStyleBackColor = false;
            openChatButton.Click += openChatButton_Click;
            // 
            // loadInfoButton
            // 
            loadInfoButton.BackColor = Color.FromArgb(192, 64, 0);
            loadInfoButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            loadInfoButton.ForeColor = SystemColors.ButtonHighlight;
            loadInfoButton.Location = new Point(176, 12);
            loadInfoButton.Name = "loadInfoButton";
            loadInfoButton.Size = new Size(156, 53);
            loadInfoButton.TabIndex = 1;
            loadInfoButton.Text = "Загрузить информацию о пользователе";
            loadInfoButton.UseVisualStyleBackColor = false;
            // 
            // infoGroupBox
            // 
            infoGroupBox.BackColor = Color.DarkSlateGray;
            infoGroupBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            infoGroupBox.ForeColor = Color.White;
            infoGroupBox.Location = new Point(338, 12);
            infoGroupBox.Name = "infoGroupBox";
            infoGroupBox.Size = new Size(578, 451);
            infoGroupBox.TabIndex = 2;
            infoGroupBox.TabStop = false;
            infoGroupBox.Text = "Информация";
            // 
            // stopAllMatchButton
            // 
            stopAllMatchButton.BackColor = Color.Brown;
            stopAllMatchButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            stopAllMatchButton.Location = new Point(6, 32);
            stopAllMatchButton.Name = "stopAllMatchButton";
            stopAllMatchButton.Size = new Size(94, 58);
            stopAllMatchButton.TabIndex = 3;
            stopAllMatchButton.Text = "Остановить все матчи";
            stopAllMatchButton.UseVisualStyleBackColor = false;
            stopAllMatchButton.Click += stopAllMatchButton_Click;
            // 
            // matchInfoLabel
            // 
            matchInfoLabel.BackColor = Color.DarkOliveGreen;
            matchInfoLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            matchInfoLabel.ForeColor = SystemColors.Control;
            matchInfoLabel.Location = new Point(338, 469);
            matchInfoLabel.Name = "matchInfoLabel";
            matchInfoLabel.Size = new Size(180, 174);
            matchInfoLabel.TabIndex = 4;
            matchInfoLabel.Text = "-";
            matchInfoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonGroupBox
            // 
            buttonGroupBox.BackColor = Color.SeaGreen;
            buttonGroupBox.Controls.Add(usersBannedRadioButton);
            buttonGroupBox.Controls.Add(usersRadioButton);
            buttonGroupBox.Controls.Add(saveAllButton);
            buttonGroupBox.Controls.Add(clearMessageDBButton);
            buttonGroupBox.Controls.Add(banUserButton);
            buttonGroupBox.Controls.Add(stopAllMatchButton);
            buttonGroupBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            buttonGroupBox.ForeColor = Color.White;
            buttonGroupBox.Location = new Point(524, 469);
            buttonGroupBox.Name = "buttonGroupBox";
            buttonGroupBox.Size = new Size(392, 174);
            buttonGroupBox.TabIndex = 3;
            buttonGroupBox.TabStop = false;
            buttonGroupBox.Text = "Кнопки управления";
            // 
            // usersBannedRadioButton
            // 
            usersBannedRadioButton.AutoSize = true;
            usersBannedRadioButton.Location = new Point(193, 96);
            usersBannedRadioButton.Name = "usersBannedRadioButton";
            usersBannedRadioButton.Size = new Size(189, 29);
            usersBannedRadioButton.TabIndex = 4;
            usersBannedRadioButton.Text = "Заблокированные";
            usersBannedRadioButton.UseVisualStyleBackColor = true;
            usersBannedRadioButton.CheckedChanged += usersBannedRadioButton_CheckedChanged;
            // 
            // usersRadioButton
            // 
            usersRadioButton.AutoSize = true;
            usersRadioButton.Checked = true;
            usersRadioButton.Location = new Point(6, 96);
            usersRadioButton.Name = "usersRadioButton";
            usersRadioButton.Size = new Size(153, 29);
            usersRadioButton.TabIndex = 4;
            usersRadioButton.TabStop = true;
            usersRadioButton.Text = "Пользователи";
            usersRadioButton.UseVisualStyleBackColor = true;
            usersRadioButton.CheckedChanged += usersRadioButton_CheckedChanged;
            // 
            // saveAllButton
            // 
            saveAllButton.BackColor = Color.Brown;
            saveAllButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            saveAllButton.Location = new Point(288, 32);
            saveAllButton.Name = "saveAllButton";
            saveAllButton.Size = new Size(94, 58);
            saveAllButton.TabIndex = 3;
            saveAllButton.Text = "Сохранить всё";
            saveAllButton.UseVisualStyleBackColor = false;
            saveAllButton.Click += saveAllButton_Click;
            // 
            // clearMessageDBButton
            // 
            clearMessageDBButton.BackColor = Color.Brown;
            clearMessageDBButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            clearMessageDBButton.Location = new Point(106, 32);
            clearMessageDBButton.Name = "clearMessageDBButton";
            clearMessageDBButton.Size = new Size(176, 58);
            clearMessageDBButton.TabIndex = 3;
            clearMessageDBButton.Text = "Удалить все сохраненные сообщения";
            clearMessageDBButton.UseVisualStyleBackColor = false;
            clearMessageDBButton.Click += clearMessageDBButton_Click;
            // 
            // banUserButton
            // 
            banUserButton.BackColor = Color.Brown;
            banUserButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            banUserButton.Location = new Point(6, 126);
            banUserButton.Name = "banUserButton";
            banUserButton.Size = new Size(125, 42);
            banUserButton.TabIndex = 3;
            banUserButton.Text = "Заблокировать";
            banUserButton.UseVisualStyleBackColor = false;
            banUserButton.Click += banUserButton_Click;
            // 
            // updateTimer
            // 
            updateTimer.Enabled = true;
            updateTimer.Interval = 200;
            updateTimer.Tick += updateTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(928, 659);
            Controls.Add(buttonGroupBox);
            Controls.Add(matchInfoLabel);
            Controls.Add(infoGroupBox);
            Controls.Add(loadInfoButton);
            Controls.Add(openChatButton);
            Controls.Add(userIdListBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Окно администрирования";
            Load += MainForm_Load;
            buttonGroupBox.ResumeLayout(false);
            buttonGroupBox.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.Timer updateTimer;
        private RadioButton usersBannedRadioButton;
        private RadioButton usersRadioButton;
        private Button banUserButton;
    }
}
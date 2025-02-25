﻿namespace War_Ai_Game_TelegramBot
{
    partial class ChatForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            userMessageListBox = new ListBox();
            botMessageListBox = new ListBox();
            messageTextBox = new TextBox();
            sendButton = new Button();
            button1 = new Button();
            seeFullMessageButton = new Button();
            pictureBox1 = new PictureBox();
            updateTimer = new System.Windows.Forms.Timer(components);
            clearUserMessagesButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Teal;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(336, 47);
            label1.TabIndex = 0;
            label1.Text = "Сообщения пользователя:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.DarkSlateGray;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(354, 9);
            label2.Name = "label2";
            label2.Size = new Size(278, 47);
            label2.TabIndex = 0;
            label2.Text = "Ваши сообщения";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // userMessageListBox
            // 
            userMessageListBox.BackColor = Color.PaleTurquoise;
            userMessageListBox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            userMessageListBox.FormattingEnabled = true;
            userMessageListBox.ItemHeight = 20;
            userMessageListBox.Location = new Point(12, 56);
            userMessageListBox.Name = "userMessageListBox";
            userMessageListBox.Size = new Size(336, 284);
            userMessageListBox.TabIndex = 1;
            // 
            // botMessageListBox
            // 
            botMessageListBox.BackColor = Color.LightSeaGreen;
            botMessageListBox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            botMessageListBox.ForeColor = SystemColors.Window;
            botMessageListBox.FormattingEnabled = true;
            botMessageListBox.ItemHeight = 20;
            botMessageListBox.Location = new Point(354, 56);
            botMessageListBox.Name = "botMessageListBox";
            botMessageListBox.Size = new Size(278, 284);
            botMessageListBox.TabIndex = 1;
            // 
            // messageTextBox
            // 
            messageTextBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            messageTextBox.Location = new Point(23, 346);
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(561, 29);
            messageTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            sendButton.BackColor = Color.SeaGreen;
            sendButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            sendButton.ForeColor = SystemColors.ControlLightLight;
            sendButton.Location = new Point(119, 381);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(189, 36);
            sendButton.TabIndex = 3;
            sendButton.Text = "Отправить";
            sendButton.UseVisualStyleBackColor = false;
            sendButton.Click += sendButton_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Turquoise;
            button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Firebrick;
            button1.Location = new Point(590, 346);
            button1.Name = "button1";
            button1.Size = new Size(30, 29);
            button1.TabIndex = 3;
            button1.Text = "C";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // seeFullMessageButton
            // 
            seeFullMessageButton.BackColor = Color.Teal;
            seeFullMessageButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            seeFullMessageButton.ForeColor = SystemColors.ControlLightLight;
            seeFullMessageButton.Location = new Point(314, 381);
            seeFullMessageButton.Name = "seeFullMessageButton";
            seeFullMessageButton.Size = new Size(189, 36);
            seeFullMessageButton.TabIndex = 3;
            seeFullMessageButton.Text = "Развернуть";
            seeFullMessageButton.UseVisualStyleBackColor = false;
            seeFullMessageButton.Click += seeFullMessageButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.CadetBlue;
            pictureBox1.Location = new Point(12, 346);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(620, 79);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // updateTimer
            // 
            updateTimer.Enabled = true;
            updateTimer.Interval = 200;
            updateTimer.Tick += updateTimer_Tick;
            // 
            // clearUserMessagesButton
            // 
            clearUserMessagesButton.BackColor = Color.PaleTurquoise;
            clearUserMessagesButton.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            clearUserMessagesButton.Location = new Point(279, 56);
            clearUserMessagesButton.Name = "clearUserMessagesButton";
            clearUserMessagesButton.Size = new Size(69, 22);
            clearUserMessagesButton.TabIndex = 5;
            clearUserMessagesButton.Text = "Очистить";
            clearUserMessagesButton.UseVisualStyleBackColor = false;
            clearUserMessagesButton.Click += clearUserMessagesButton_Click;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MintCream;
            ClientSize = new Size(646, 436);
            Controls.Add(clearUserMessagesButton);
            Controls.Add(button1);
            Controls.Add(seeFullMessageButton);
            Controls.Add(sendButton);
            Controls.Add(messageTextBox);
            Controls.Add(label1);
            Controls.Add(botMessageListBox);
            Controls.Add(userMessageListBox);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChatForm";
            Text = "Чат";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private ListBox userMessageListBox;
        private ListBox botMessageListBox;
        private TextBox messageTextBox;
        private Button sendButton;
        private Button button1;
        private Button seeFullMessageButton;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer updateTimer;
        private Button clearUserMessagesButton;
    }
}
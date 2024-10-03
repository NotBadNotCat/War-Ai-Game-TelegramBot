namespace Shotgun_Roulette_Game_TelegramBot
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.userMessageListBox = new System.Windows.Forms.ListBox();
            this.botMessageListBox = new System.Windows.Forms.ListBox();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.seeFullMessageButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Teal;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сообщения пользователя:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(354, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(278, 47);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ваши сообщения";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userMessageListBox
            // 
            this.userMessageListBox.BackColor = System.Drawing.Color.PaleTurquoise;
            this.userMessageListBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.userMessageListBox.FormattingEnabled = true;
            this.userMessageListBox.ItemHeight = 20;
            this.userMessageListBox.Location = new System.Drawing.Point(12, 56);
            this.userMessageListBox.Name = "userMessageListBox";
            this.userMessageListBox.Size = new System.Drawing.Size(336, 284);
            this.userMessageListBox.TabIndex = 1;
            // 
            // botMessageListBox
            // 
            this.botMessageListBox.BackColor = System.Drawing.Color.LightSeaGreen;
            this.botMessageListBox.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.botMessageListBox.ForeColor = System.Drawing.SystemColors.Window;
            this.botMessageListBox.FormattingEnabled = true;
            this.botMessageListBox.ItemHeight = 20;
            this.botMessageListBox.Location = new System.Drawing.Point(354, 56);
            this.botMessageListBox.Name = "botMessageListBox";
            this.botMessageListBox.Size = new System.Drawing.Size(278, 284);
            this.botMessageListBox.TabIndex = 1;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.MessageTextBox.Location = new System.Drawing.Point(23, 346);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(561, 29);
            this.MessageTextBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.BackColor = System.Drawing.Color.SeaGreen;
            this.sendButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sendButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.sendButton.Location = new System.Drawing.Point(119, 381);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(189, 36);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.Firebrick;
            this.button1.Location = new System.Drawing.Point(590, 346);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "C";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // seeFullMessageButton
            // 
            this.seeFullMessageButton.BackColor = System.Drawing.Color.Teal;
            this.seeFullMessageButton.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.seeFullMessageButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.seeFullMessageButton.Location = new System.Drawing.Point(314, 381);
            this.seeFullMessageButton.Name = "seeFullMessageButton";
            this.seeFullMessageButton.Size = new System.Drawing.Size(189, 36);
            this.seeFullMessageButton.TabIndex = 3;
            this.seeFullMessageButton.Text = "Развернуть";
            this.seeFullMessageButton.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.CadetBlue;
            this.pictureBox1.Location = new System.Drawing.Point(12, 346);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(620, 79);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(646, 436);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.seeFullMessageButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.MessageTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botMessageListBox);
            this.Controls.Add(this.userMessageListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ChatForm";
            this.Text = "Чат";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private ListBox userMessageListBox;
        private ListBox botMessageListBox;
        private TextBox MessageTextBox;
        private Button sendButton;
        private Button button1;
        private Button seeFullMessageButton;
        private PictureBox pictureBox1;
    }
}
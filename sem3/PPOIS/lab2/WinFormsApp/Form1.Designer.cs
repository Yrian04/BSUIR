namespace WinFormsApp
{
    partial class Form1
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
            nameTextBox = new TextBox();
            button1 = new Button();
            button2 = new Button();
            userNameLabel = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            createLetterButton = new Button();
            RefreshLettersButton = new Button();
            receiverNameTextBox = new TextBox();
            label2 = new Label();
            lettersRichTextBox = new RichTextBox();
            numericOfLetter = new NumericUpDown();
            SendButton = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericOfLetter).BeginInit();
            SuspendLayout();
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(6, 26);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(125, 27);
            nameTextBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(137, 24);
            button1.Name = "button1";
            button1.Size = new Size(74, 29);
            button1.TabIndex = 1;
            button1.Text = "Sign up";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(217, 24);
            button2.Name = "button2";
            button2.Size = new Size(74, 29);
            button2.TabIndex = 2;
            button2.Text = "Log In";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // userNameLabel
            // 
            userNameLabel.AutoSize = true;
            userNameLabel.Location = new Point(388, 33);
            userNameLabel.Name = "userNameLabel";
            userNameLabel.Size = new Size(0, 20);
            userNameLabel.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(300, 33);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 4;
            label1.Text = "User name:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nameTextBox);
            groupBox1.Controls.Add(userNameLabel);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 63);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Logging in";
            // 
            // createLetterButton
            // 
            createLetterButton.Location = new Point(18, 150);
            createLetterButton.Name = "createLetterButton";
            createLetterButton.Size = new Size(125, 40);
            createLetterButton.TabIndex = 5;
            createLetterButton.Text = "Create letter";
            createLetterButton.UseVisualStyleBackColor = true;
            createLetterButton.Click += createLetterButton_Click;
            // 
            // RefreshLettersButton
            // 
            RefreshLettersButton.Location = new Point(18, 196);
            RefreshLettersButton.Name = "RefreshLettersButton";
            RefreshLettersButton.Size = new Size(125, 40);
            RefreshLettersButton.TabIndex = 7;
            RefreshLettersButton.Text = "Refresh letters";
            RefreshLettersButton.UseVisualStyleBackColor = true;
            RefreshLettersButton.Click += refreshLettersButton_Click;
            // 
            // receiverNameTextBox
            // 
            receiverNameTextBox.Location = new Point(18, 117);
            receiverNameTextBox.Name = "receiverNameTextBox";
            receiverNameTextBox.Size = new Size(125, 27);
            receiverNameTextBox.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 92);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 9;
            label2.Text = "Name of receiver";
            // 
            // lettersRichTextBox
            // 
            lettersRichTextBox.Location = new Point(149, 92);
            lettersRichTextBox.Name = "lettersRichTextBox";
            lettersRichTextBox.Size = new Size(639, 346);
            lettersRichTextBox.TabIndex = 10;
            lettersRichTextBox.Text = "";
            // 
            // numericOfLetter
            // 
            numericOfLetter.Location = new Point(18, 242);
            numericOfLetter.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericOfLetter.Name = "numericOfLetter";
            numericOfLetter.Size = new Size(125, 27);
            numericOfLetter.TabIndex = 11;
            numericOfLetter.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SendButton
            // 
            SendButton.Location = new Point(18, 275);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(125, 40);
            SendButton.TabIndex = 12;
            SendButton.Text = "Send letter";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SendButton);
            Controls.Add(numericOfLetter);
            Controls.Add(lettersRichTextBox);
            Controls.Add(label2);
            Controls.Add(receiverNameTextBox);
            Controls.Add(RefreshLettersButton);
            Controls.Add(createLetterButton);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericOfLetter).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox nameTextBox;
        private Button button1;
        private Button button2;
        private Label userNameLabel;
        private Label label1;
        private GroupBox groupBox1;
        private Button createLetterButton;
        private Button RefreshLettersButton;
        private TextBox receiverNameTextBox;
        private Label label2;
        private RichTextBox lettersRichTextBox;
        private NumericUpDown numericOfLetter;
        private Button SendButton;
    }
}
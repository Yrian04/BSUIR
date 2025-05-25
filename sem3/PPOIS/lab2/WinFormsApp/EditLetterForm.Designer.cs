namespace WinFormsApp
{
    partial class EditLetterForm
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
            HeaderLabel = new Label();
            headerRichTextBox = new RichTextBox();
            label2 = new Label();
            bodyRichTextBox = new RichTextBox();
            okButton = new Button();
            cancelButton = new Button();
            SuspendLayout();
            // 
            // HeaderLabel
            // 
            HeaderLabel.AutoSize = true;
            HeaderLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            HeaderLabel.Location = new Point(12, 9);
            HeaderLabel.Name = "HeaderLabel";
            HeaderLabel.Size = new Size(91, 32);
            HeaderLabel.TabIndex = 1;
            HeaderLabel.Text = "Header";
            // 
            // headerRichTextBox
            // 
            headerRichTextBox.Location = new Point(12, 44);
            headerRichTextBox.Name = "headerRichTextBox";
            headerRichTextBox.Size = new Size(539, 34);
            headerRichTextBox.TabIndex = 2;
            headerRichTextBox.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(68, 32);
            label2.TabIndex = 3;
            label2.Text = "Body";
            // 
            // bodyRichTextBox
            // 
            bodyRichTextBox.Location = new Point(12, 116);
            bodyRichTextBox.Name = "bodyRichTextBox";
            bodyRichTextBox.Size = new Size(539, 284);
            bodyRichTextBox.TabIndex = 4;
            bodyRichTextBox.Text = "";
            // 
            // okButton
            // 
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new Point(458, 409);
            okButton.Name = "okButton";
            okButton.Size = new Size(94, 29);
            okButton.TabIndex = 5;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(358, 409);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(94, 29);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // CreateLetterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 450);
            Controls.Add(cancelButton);
            Controls.Add(okButton);
            Controls.Add(bodyRichTextBox);
            Controls.Add(label2);
            Controls.Add(headerRichTextBox);
            Controls.Add(HeaderLabel);
            Name = "CreateLetterForm";
            Text = "Create letter";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HeaderLabel;
        private RichTextBox headerRichTextBox;
        private Label label2;
        private RichTextBox bodyRichTextBox;
        private Button okButton;
        private Button cancelButton;
    }
}
using PPOIS_l2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class EditLetterForm : Form
    {
        Letter letter;
        public EditLetterForm(ref Letter letter)
        {
            InitializeComponent();
            this.letter = letter;
            headerRichTextBox.Text = letter.Header;
            bodyRichTextBox.Text = letter.Body;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            letter.Header = headerRichTextBox.Text;
            letter.Body = bodyRichTextBox.Text;

            this.Close();
        }
    }
}

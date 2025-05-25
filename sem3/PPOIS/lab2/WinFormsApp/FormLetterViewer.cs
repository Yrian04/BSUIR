using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPOIS_l2;

namespace WinFormsApp
{
    internal class FormLetterViewer : ILetterViewer
    {
        RichTextBox lettersBox;
        public FormLetterViewer(RichTextBox lettersBox)
        {
            this.lettersBox = lettersBox;
        }
        public void ViewLetters(params Letter[] letters)
        {
            lettersBox.Clear();
            for (int i = 0; i < letters.Length; i++)
            {
                Letter? letter = letters[i];
                lettersBox.AppendText($"---- letter {i+1}\r\n\tFrom: {letter.Sender.Name}     To:{letter.Receiver.Name}\r\n");
                lettersBox.AppendText("\t"+letter.Header + "\r\n");
                lettersBox.AppendText(letter.Body);
            }
        }
    }
}

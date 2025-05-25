using PPOIS_l2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp
{
    internal class FormLetterEditor : ILetterEditor
    {
        
        public Letter Create(Client sender, Client receiver)
        {
            var letter = new Letter(sender, receiver, "", "");
            Edit(ref letter);

            return letter;
        }

        public void Edit(ref Letter letter)
        {
            var form = new EditLetterForm(ref letter);
            form.Show();
        }
    }
}

using PPOIS_l2;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        Client? user;
        FormLetterViewer letterViewer;
        FormLetterEditor letterEditor = new();
        public Form1()
        {
            new CrutchServer();
            InitializeComponent();
            letterViewer = new(lettersRichTextBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            Server.Instance?.CreateClient(name);
            MessageBox.Show("You are successfully sing up");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            var newUser = Server.Instance?.GetClient(name);
            if (newUser is null)
                MessageBox.Show($"Client {name} is not exists");
            else
            {
                user = newUser;
                userNameLabel.Text = name;
                MessageBox.Show("You are logged in successfully");
            }
        }

        private void createLetterButton_Click(object sender, EventArgs e)
        {
            if (user is null)
            {
                MessageBox.Show("You have to log in");
                return;
            }
            var receiver = Server.Instance?.GetClient(receiverNameTextBox.Text);
            if (receiver is null)
            {
                MessageBox.Show($"Client {receiverNameTextBox.Text} is not exists");
                return;
            }
            user.CreateClientLetter(letterEditor, receiver);
        }

        private void refreshLettersButton_Click(object sender, EventArgs e)
        {
            if (user is null)
            {
                MessageBox.Show("You have to log in");
                return;
            }
            user.ShowAllClientLetters(letterViewer);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (user is null)
            {
                MessageBox.Show("You have to log in");
                return;
            }
            var index = (int)numericOfLetter.Value - 1;
            user.SendClientLetters(index);
        }
    }
}
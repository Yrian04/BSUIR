using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Graph_Editor.Model;
using Graph_Editor.ViewModels;

namespace Graph_Editor
{
    /// <summary>
    /// Логика взаимодействия для GetGraphDataWindow.xaml
    /// </summary>
    public partial class GetGraphDataWindow : Window
    {
        public GetGraphDataWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

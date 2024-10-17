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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Enigma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string key = "KEY";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonEncrypt_Click(object sender, RoutedEventArgs e)
        {
            textBox_EncryptDecrypt.Text = AutokeyCipher.Encrypt(textBox.Text, key);
        }

        private void buttonDecrypt_Click(object sender, RoutedEventArgs e)
        {
            textBox_EncryptDecrypt.Text = AutokeyCipher.Decrypt(textBox.Text, key);
        }
    }
}

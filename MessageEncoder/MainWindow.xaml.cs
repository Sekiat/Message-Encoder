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
using System.IO;

namespace MessageEncoder
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void run_Click(object sender, RoutedEventArgs e)
        {
            int key = 0;
            foreach(char c in pass.Password)
            {
                key += c;
            }
            string text = messageBox.Text;
            string Ntext = "";
            foreach(char c in text)
            {
                Ntext += (char)(c ^ key);
            }
            messageBox.Text = Ntext;
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new System.Windows.Forms.SaveFileDialog()
            {
                Filter = "暗号ファイル(*.me)|*.me"
            };
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, messageBox.Text);
                MessageBox.Show("保存が完了しました。");
            }
            else
            {
                MessageBox.Show("保存に失敗しました。");
            }
        }

        private void import_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new System.Windows.Forms.OpenFileDialog()
            {
                Filter = "暗号ファイル(*.me)|*.me"
            };
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                messageBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("ファイルが開けませんでした。");
            }
        }

        private void ShowPass_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(String.Format("パスワードは「{0}」です。", pass.Password));
        }
    }
}

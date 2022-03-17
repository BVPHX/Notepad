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

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isSaved = false;
        bool isChangesSaved = false;
        public string FileName { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            FileName = "Безымянный";
            Title = FileName + " " + "-" + " " + "Блокнот";

        }



        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void StatusBarOnOff(object sender, RoutedEventArgs e)
        {
            if (statBatItem.IsChecked == true) statusBar.Visibility = Visibility.Visible;
            if (statBatItem.IsChecked == false) statusBar.Visibility = Visibility.Hidden;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (isChangesSaved == false)
            {
                var result = MessageBox.Show("Сохранить изменения?", "Изменения не сохранены", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) SaveOpen.Save(textField.Text);
            }
            if (isSaved == false)
            {
                var result = MessageBox.Show("Документ не сохранён. Сохранить документ?", "Файл не сохранен", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) SaveOpen.SaveAs(textField.Text, out bool issaved, out string name);

            }


        }

        private void textField_TextChanged(object sender, TextChangedEventArgs e)
        {
            isChangesSaved = false;
        }

        private void SaveButon_Click(object sender, RoutedEventArgs e)
        {
            if (textField.Text != null)
            {
                if (isSaved == false) SaveOpen.Save(textField.Text);
                else
                {
                    SaveOpen.SaveAs(textField.Text, out bool IsSaved, out string name);
                }
                isSaved = true;
                isChangesSaved = true;
            }
            

        }

        private void SaveAsButton_click(object sender, RoutedEventArgs e)
        {
            if (textField.Text != null)
            {
                SaveOpen.Save(textField.Text);
            }
            isSaved = true;
            isChangesSaved = true;
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            SaveOpen.Open(out string text, out string name);
            textField.Text = text;
            FileName = name;
            Title = FileName + " " + "-" + " " + "Блокнот";
            isSaved = true;
            isChangesSaved = true;
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            textField.Undo();
        }
    }
}

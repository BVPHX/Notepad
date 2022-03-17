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
            textField.CanUndo = true;
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
                if (result == MessageBoxResult.Yes) SaveOpen.Save(textField.Document.ToString());
            }
            if (isSaved == false)
            {
                var result = MessageBox.Show("Документ не сохранён. Сохранить документ?", "Файл не сохранен", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes) SaveOpen.SaveAs(textField., out bool issaved, out string name);
                textField.SaveFile();
            }
        

        }

        private void textField_TextChanged(object sender, TextChangedEventArgs e)
        {
            isChangesSaved = false;
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Notepad
{
    class SaveOpen
    {
        public static void SaveAs(string text, out bool issaved, out string name)
        {
            issaved = false;
            name = string.Empty;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Текстовые документы (*.rtf)|*.rtf|Все файлы (*.*)|*.rtf*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                StreamWriter _stream = new StreamWriter(dialog.FileName);
                _stream.WriteLine(dialog.SafeFileName);
                _stream.Write(text);
                    // Code to write the stream goes here.
                    _stream.Close();
                issaved = true;
                name = dialog.SafeFileName ;
            }



            else issaved = false;

        }
        public static void Save(string text)
        {

        }
        public void Open(out string text, out string name)
        {

            text = string.Empty;
            name = string.Empty;
        }
    }
}

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
            dialog.Filter = "Текстовые документы (*.rtf)|*.rtf|Текстовый документ (*.rtf*)|*.rtf*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                StreamWriter _stream = new StreamWriter(dialog.FileName);
                _stream.WriteLine(dialog.SafeFileName.Substring(0, dialog.SafeFileName.IndexOf(".")));
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
        public static void Open(out string text, out string name)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые документы (*.rtf)|*.rtf|Текстовый документ (*.rtf*)|*.rtf*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            text = string.Empty;
            name = string.Empty;
            if (dialog.ShowDialog() == true)
            {
                StreamReader _stream = new StreamReader(dialog.FileName);
                name = _stream.ReadLine();
                text = _stream.ReadToEnd();
                // Code to write the stream goes here.
                _stream.Close();
            }
        }
    }
}

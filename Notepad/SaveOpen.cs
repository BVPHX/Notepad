using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Notepad
{
    class SaveOpen
    {
        private static string Path { get; set; }
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
                _stream.Write(text);
                // Code to write the stream goes here.
                _stream.Close();
                issaved = true;
                name = dialog.SafeFileName ;
                Path = dialog.FileName;
            }



            else issaved = false;

        }
        public static void Save(string text)
        {
            StreamWriter _stream = new StreamWriter(Path);
            _stream.Write(text);
            _stream.Close();
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
                text = _stream.ReadToEnd();
                name = dialog.SafeFileName.Substring(0, dialog.SafeFileName.IndexOf("."));
                Path = dialog.FileName;
                _stream.Close();
            }
        }
        public static void Create(out string name)
        {
            name = string.Empty;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Текстовые документы (*.rtf)|*.rtf|Текстовый документ (*.rtf*)|*.rtf*";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == true)
            {
                StreamWriter _stream = new StreamWriter(dialog.FileName);
                _stream.Close();
                Path = dialog.FileName;
                name = dialog.SafeFileName;
            }

        }
    }
}

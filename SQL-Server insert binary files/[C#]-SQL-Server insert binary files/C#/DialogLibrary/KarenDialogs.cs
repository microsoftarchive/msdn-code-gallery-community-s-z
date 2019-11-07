using System;
using System.Windows.Forms;
namespace DialogLibrary
{
    public static class KarenDialogs
    {
        public static bool Question(string Text)
        {
            return (MessageBox.Show(Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
        public static bool Question(string Text, string Title)
        {
            return (MessageBox.Show(Text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
        public static bool Question(string Text, string Title, DialogResult DefaultButton)
        {
            MessageBoxDefaultButton db = 0;
            if (DefaultButton == DialogResult.No)
            {
                db = MessageBoxDefaultButton.Button2;
            }
            return (MessageBox.Show(Text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, db) == DialogResult.Yes);
        }
        public static void InformationDialog(string Text)
        {
            MessageBox.Show(Text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void InformationDialog(string Text, string Title)
        {
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ExceptionDialog(string Text)
        {
            MessageBox.Show(Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ExceptionDialog(string Text, string Title)
        {
            MessageBox.Show(Text, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ExceptionDialog(string Text, string Title, Exception ex)
        {
            string Message = $"{Text}{Environment.NewLine} {ex.Message}";
            MessageBox.Show(Message, Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ExceptionDialog(Exception ex, string Text, string Title)
        {
            MessageBox.Show($"{Text}{Environment.NewLine}{ex.Message}{ex.Message}", Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;


namespace WpfApp1
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button) sender;
            if (button.Tag?.ToString() == "1")
            {
                if (textBox.Text == "0")
                    textBox.Text = "";
                textBox.Text += button.Content.ToString();
            }
            if (button.Tag?.ToString() == "2")
            {
                if (textBox.Text == "")
                {
                    string buffer = label.Content?.ToString();
                    buffer = buffer?.Remove(buffer.Length-1);
                   // buffer += button.Content;
                   if (label.Content == null) 
                       label.Content = "0" + buffer;
                   else
                       label.Content = buffer;
                }
                else
                {
                 if (textBox.Text[textBox.Text.Length - 1] == ',')
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                 if (Convert.ToDouble(textBox.Text)==0 )
                    textBox.Text = "0";
                }

                label.Content += textBox.Text + button.Content;
                textBox.Text = "";
            }
            if (button.Content.ToString() == ",")
            {
                if (textBox.Text == "")
                    textBox.Text = "0,";
                else
                {
                    if (textBox.Text.IndexOf(',') == -1)
                        textBox.Text += ",";
                }
            }
            if (button.Content.ToString() == "+-")
            {
                if (textBox.Text != "" && textBox.Text != "0")
                {
                    if (textBox.Text[0] != '-')
                    {
                        textBox.Text = "-" + textBox.Text;
                    }
                    else
                    {
                        textBox.Text = textBox.Text.Remove(0, 1);
                    }
                }
            }

            if (button.Content.ToString() == "BSP")
            {
                if (textBox.Text.Length>0)
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                if (textBox.Text == "-")
                    textBox.Text = "";
            }

            if (button.Content.ToString() == "C")
            {
                label.Content = "";
                textBox.Text = "";
            }
        }
    }
}

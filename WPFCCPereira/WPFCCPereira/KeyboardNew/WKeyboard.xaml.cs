using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static WPFCCPereira.KeyboardNew.Keyboard2;

namespace WPFCCPereira.KeyboardNew
{
    /// <summary>
    /// Lógica de interacción para WKeyboard.xaml
    /// </summary>
    public partial class WKeyboard : Window
    {
        public static Action<string> callBackKeyboard;
        public double _WindowTop = 0, _WindowLeft = 0;
        private AppSettingsReader reader;
        private Uri backStandar;
        private Uri backColor;
        private bool UPPER = true;
        private int num = 0;

        public WKeyboard(EType eType, string color)
        {
            InitializeComponent();

            try
            {
                reader = new AppSettingsReader();
                string url = reader.GetValue("UrlBackground", typeof(String)).ToString();
                backStandar = new Uri(url + "Gris.png", UriKind.Relative);
                backColor = new Uri(url + color + ".png", UriKind.Relative);

                if (eType == EType.Standar)
                {
                    this.Height = 280;
                    this.Width = 550;
                    grvStandar.Visibility = Visibility.Visible;
                    grvNumeric.Visibility = Visibility.Hidden;
                    SetControlsEventStandar();
                }
                else
                {
                    this.Height = 220;
                    this.Width = 170;
                    grvStandar.Visibility = Visibility.Hidden;
                    grvNumeric.Visibility = Visibility.Visible;
                    SetControlsEventNumeric();
                }
            }
            catch { }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Top = _WindowTop;
            this.Left = _WindowLeft;

        }

        private void SetControlsEventStandar()
        {
            try
            {
                foreach (var stack in spControls.Children)
                {
                    if (stack is StackPanel)
                    {
                        foreach (var control in (stack as StackPanel).Children)
                        {
                            if (control is Label)
                            {
                                (control as Label).TouchDown += new EventHandler<TouchEventArgs>(imgClick);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void SetControlsEventStandar(bool UPPER)
        {
            try
            {
                foreach (var stack in spControls.Children)
                {
                    if (stack is StackPanel)
                    {
                        foreach (var control in (stack as StackPanel).Children)
                        {
                            if (control is Label)
                            {
                                if (UPPER)
                                {
                                    (control as Label).Content = (control as Label).Content.ToString().ToUpper();
                                }
                                else
                                {
                                    (control as Label).Content = (control as Label).Content.ToString().ToLower();
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void SetControlsEventNumeric()
        {
            try
            {
                foreach (var stack in spControls2.Children)
                {
                    if (stack is StackPanel)
                    {
                        foreach (var control in (stack as StackPanel).Children)
                        {
                            if (control is Label)
                            {
                                (control as Label).TouchDown += new EventHandler<TouchEventArgs>(imgClick);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void imgClick(object sender, TouchEventArgs e)
        {
            try
            {

                var label = sender as Label;
                string Tag = label.Tag.ToString();

                if (Tag.ToUpper() != "DELETE")
                {
                    label.Background = new ImageBrush(new BitmapImage(backColor));
                }


                if (Tag.ToUpper() == "SHIFT")
                {
                    UPPER = UPPER ? false : true;
                    SetControlsEventStandar(UPPER);
                }
                else
                {
                    if (UPPER)
                    {
                        Tag = Tag.ToUpper();
                    }
                    else
                    {
                        Tag = Tag.ToLower();
                    }

                    callBackKeyboard?.Invoke(Tag);


                    if (num == 0 && Tag.ToUpper() != "SHIFT")
                    {
                        num = 1;
                        UPPER = false;
                        SetControlsEventStandar(false);
                    }

                    Task.Run(() =>
                    {
                        Thread.Sleep(500);
                        Dispatcher.BeginInvoke((Action)delegate
                        {
                            if (Tag.ToUpper() != "DELETE")
                            {
                                label.Background = new ImageBrush(new BitmapImage(backStandar));
                            }
                        });
                    });
                }
            }
            catch { }
        }
    }
}

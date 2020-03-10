using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WPFCCPereira.KeyboardNew
{
    public static class Keyboard2
    {
        public static string Color { get; set; }

        public static void ConsttrucKeyyboard(EColor eColor)
        {
            switch (eColor)
            {
                case EColor.Azul:
                    Color = "Azul";
                    break;
                case EColor.Rojo:
                    Color = "Rojo";
                    break;
                case EColor.Amarillo:
                    Color = "Amarillo";
                    break;
                case EColor.Verde:
                    Color = "Verde";
                    break;
                default:
                    Color = "Gris";
                    break;
            }
        }

        public static void InitKeyboard(TextBox control, UserControl userControl, EType eType)
        {
            try
            {
                WKeyboard board = new WKeyboard(eType, Color);
                userControl.IsEnabled = false;
                WKeyboard.callBackKeyboard = Value =>
                {
                    Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                    {
                        switch (Value.ToUpper())
                        {
                            case "DELETE":
                                var text = control.Text;
                                if (text.Length > 0)
                                {
                                    control.Text = text.Remove(text.Length - 1, 1);
                                }
                                break;
                            case "OK":
                                board.Close();
                                WKeyboard.callBackKeyboard = null;
                                userControl.IsEnabled = true;
                                break;
                            default:
                                control.Text += Value;
                                break;
                        }
                    }));
                };

                Point relativePoint = control.TransformToAncestor(userControl)
                                             .Transform(new Point(0, 0));

                board._WindowTop = relativePoint.Y + control.ActualHeight;
                board._WindowLeft = relativePoint.X;
                board.Show();
            }
            catch { }
        }

        public enum EType
        {
            Numeric = 0,
            Standar = 1
        }

        public enum EColor
        {
            Azul = 0,
            Rojo = 1,
            Amarillo = 2,
            Verde = 3
        }
    }
}


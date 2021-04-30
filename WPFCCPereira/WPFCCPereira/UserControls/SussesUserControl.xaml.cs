using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;

namespace WPFCCPereira.UserControls
{
    /// <summary>
    /// Lógica de interacción para SussesUserControl.xaml
    /// </summary>
    public partial class SussesUserControl : UserControl
    {
        private Transaction transaction;

        public SussesUserControl(Transaction transaction)
        {
            InitializeComponent();

            this.transaction = transaction;

            FinishTrnsaction();
        }

        private void FinishTrnsaction()
        {
            try
            {
                Task.Run(() =>
                {
                    AdminPayPlus.UpdateTransaction(this.transaction);

                    Thread.Sleep(2000);

                    Utilities.PrintVoucher(this.transaction);

                    Thread.Sleep(6000);

                    Dispatcher.BeginInvoke((Action)delegate
                    {
                        if (transaction.State == ETransactionState.Error)
                        {
                            Utilities.RestartApp();
                        }
                        else
                        {
                            Utilities.navigator.Navigate(UserControlView.Main);
                        }

                    });
                    GC.Collect();
                });
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}
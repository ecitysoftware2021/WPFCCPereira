using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;

namespace WPFCCPereira.UserControls.Renewal
{
    /// <summary>
    /// Interaction logic for ListEstablecimientosUC.xaml
    /// </summary>
    public partial class ListEstablecimientosUC : UserControl
    {
        #region "Referencias"
        private Transaction transaction;
        private ObservableCollection<ListEstablecimientos> listEstablecimientos;
        #endregion

        public ListEstablecimientosUC(Transaction ts)
        {
            InitializeComponent();

            this.listEstablecimientos = new ObservableCollection<ListEstablecimientos>();

            this.transaction = ts;
            
            ConfigureViewList();
        }


        private void ConfigureViewList()
        {
            try
            {
                this.DataContext = transaction.ExpedientesMercantil;

                foreach (var item in transaction.ExpedientesMercantil.establecimientos)
                {
                    if ((item.ultanorenovado + 1) == DateTime.Now.Year)
                    {
                        item.anoporrenovar = item.ultanorenovado + 1;

                        DateTime dtm;

                        DateTime.TryParseExact(item.fecharenovacion, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dtm);

                        item.fecharenovacion = dtm.ToString("MMMM dd, yyyy");

                        item.status = true;

                        listEstablecimientos.Add(item);
                    }
                }

                if (listEstablecimientos.Count > 0)
                {
                    lv_data_list.DataContext = listEstablecimientos;
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }

        private void Btn_exit_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Menu);
        }

        private void frmPpal_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.Ppal_Identificacion, data: transaction);
        }

        private void btnReturn_TouchDown(object sender, TouchEventArgs e)
        {
            Utilities.navigator.Navigate(UserControlView.MenuRenovacion, data: transaction);
        }
    }
}

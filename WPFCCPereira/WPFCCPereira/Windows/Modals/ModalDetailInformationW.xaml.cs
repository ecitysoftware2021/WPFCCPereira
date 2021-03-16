using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.ObjectIntegration;

namespace WPFCCPereira.Windows.Modals
{
    /// <summary>
    /// Interaction logic for ModalDetailInformationW.xaml
    /// </summary>
    public partial class ModalDetailInformationW : Window
    {
        #region "Referencias"
        private Transaction transaction;
        private ObservableCollection<Matricula> Matriculas;
        #endregion

        #region "Constructor"
        public ModalDetailInformationW(Transaction ts)
        {
            InitializeComponent();

            this.Matriculas = new ObservableCollection<Matricula>();

            this.transaction = ts;

            ConfigureViewList();
        }
        #endregion

        #region "Métodos"
        private void ConfigureViewList()
        {
            try
            {
                foreach (var item in transaction.LiquidarRenovacionNormal.matriculas)
                {
                    Matriculas.Add(item);
                }

                if (Matriculas.Count > 0)
                {
                    lv_data_list.DataContext = Matriculas;
                }

                this.DataContext = transaction;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
        #endregion

        #region "Eventos"
        private void CloseDetail_TouchDown(object sender, TouchEventArgs e)
        {
            this.DialogResult = true;
        }
        #endregion
    }
}

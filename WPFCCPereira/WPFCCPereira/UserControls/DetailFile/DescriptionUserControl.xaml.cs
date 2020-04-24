using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;
using WPFCCPereira.ViewModel;

namespace WPFCCPereira.UserControls.DetailFile
{
    /// <summary>
    /// Lógica de interacción para DescriptionUserControl.xaml
    /// </summary>
    /// 

    public partial class DescriptionUserControl : UserControl
    {

        private ResponseTransact file;

        private DataListViewModel viewModel;
        public DescriptionUserControl(ResponseTransact file)
        {
            InitializeComponent();

            this.file = file;

            ConfigurateView();
        }

        private void ConfigurateView()
        {
            //2232238-S000960759
            try
            {
                    viewModel = new DataListViewModel
                    {
                        Tittle = "Pasos del Trámite",
                        ViewList = new CollectionViewSource(),
                        DataList = new List<ItemList>(),
                    };

                    foreach (var state in file.estados)
                    {
                        viewModel.DataList.Add(new ItemList { Item1 = state.estado,
                            Item2 = string.Concat("Operador: ", state.usuariofinal),
                            Item3 = string.Concat(DateTime.ParseExact(state.fecha, "yyyyMMdd", null).ToString("yyyy-MM-dd")," ", DateTime.ParseExact(state.hora, "HHmmss", null).ToString("HH:mm:ss"))
                        });
                    }
                
                
                this.DataContext = viewModel;
                viewModel.ViewList.Source = viewModel.DataList;
                lv_information.DataContext = viewModel.ViewList;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
        }
    }
}

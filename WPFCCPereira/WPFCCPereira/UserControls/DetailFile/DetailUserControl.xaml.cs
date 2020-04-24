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
    /// Lógica de interacción para DetailUserControl.xaml
    /// </summary>
    public partial class DetailUserControl : UserControl
    {
        private object file;

        private ETransactionType type;

        private DataListViewModel viewModel;

        public DetailUserControl(object file, ETransactionType type)
        {
            InitializeComponent();

            this.file = file;

            this.type = type;

            ConfigurateView();
        }

        private void ConfigurateView()
        {
            //2232238-960759
            try
            {
                if (type == ETransactionType.ConsultTransact)
                {
                    viewModel = new DataListViewModel
                    {
                        Tittle = "Detalle del Trámite",
                        ViewList = new CollectionViewSource(),
                        DataList = new List<ItemList> {
                            { new ItemList {Item1 = "Fecha Estado Actual", Item2 = ((ResponseTransact)file).fechaestadofinal}},
                            { new ItemList {Item1 = "Código de barras", Item2 = ((ResponseTransact)file).radicado }},
                            { new ItemList {Item1 = "Operación", Item2 = ((ResponseTransact)file).operacion }},
                            { new ItemList {Item1 = "Matrícula", Item2 = ((ResponseTransact)file).matricula }},
                            { new ItemList {Item1 = "Nombre", Item2 = ((ResponseTransact)file).nombres }},
                            { new ItemList {Item1 = "Operador actual", Item2 = ((ResponseTransact)file).actoreparto }},
                        },
                    };
                }
                else
                {
                    viewModel = new DataListViewModel
                    {
                        Tittle = "EXPEDIENTE SELECCIONADO",
                        ViewList = new CollectionViewSource(),
                        DataList = new List<ItemList> {
                            { new ItemList {Item1 = "Matrícula", Item2 = ((Noun)file).matricula}},
                            { new ItemList {Item1 = "Proponente", Item2 = ((Noun)file).proponente }},
                            { new ItemList {Item1 = "Nombres o razón social", Item2 = ((Noun)file).nombre }},
                            { new ItemList {Item1 = "Identificación", Item2 = ((Noun)file).identificacion }},
                            { new ItemList {Item1 = "Organización juridíca", Item2 = ((Noun)file).organizaciontextual }},
                            { new ItemList {Item1 = "Categoria", Item2 = ((Noun)file).categoriatextual }},
                            { new ItemList {Item1 = "Estado de la matrícula", Item2 = ((Noun)file).estadomatricula }},
                            { new ItemList {Item1 = "Fecha de la matrícula", Item2 = ((Noun)file).fechamatricula }},
                            { new ItemList {Item1 = "Fecha última renovación", Item2 = ((Noun)file).fecharenovacion }},
                            { new ItemList {Item1 = "último año renovado", Item2 = ((Noun)file).ultanorenovado }},
                            { new ItemList {Item1 = "Matrícula afiliada", Item2 = ((Noun)file).afiliadotextual }},
                        },
                    };
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

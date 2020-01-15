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
        private Noun file;

        private DataListViewModel viewModel;

        public DetailUserControl(Noun file)
        {
            InitializeComponent();

            this.file = file;

            ConfigurateView();
        }

        private void ConfigurateView()
        {
            try
            {
                viewModel = new DataListViewModel
                {
                    Tittle = "EXPEDIENTE SELECCIONADO",
                    ViewList = new CollectionViewSource(),
                    DataList = new List<ItemList> {
                        { new ItemList {Item1 = "Matrícula", Item2 = file.matricula}},
                        { new ItemList {Item1 = "Proponente", Item2 = file.proponente }},
                        { new ItemList {Item1 = "Nombres o razón social", Item2 = file.nombre }},
                        { new ItemList {Item1 = "Identificación", Item2 = file.identificacion }},
                        { new ItemList {Item1 = "Organización juridíca", Item2 = file.organizaciontextual }},
                        { new ItemList {Item1 = "Categoria", Item2 = file.categoriatextual }},
                        { new ItemList {Item1 = "Estado de la matrícula", Item2 = file.estadomatricula }},
                        { new ItemList {Item1 = "Fecha de la matrícula", Item2 = file.fechamatricula }},
                        { new ItemList {Item1 = "Fecha última renovación", Item2 = file.fecharenovacion }},
                        { new ItemList {Item1 = "último año renovado", Item2 = file.ultanorenovado }},
                        { new ItemList {Item1 = "Matrícula afiliada", Item2 = file.afiliadotextual }},
                    },
                    
                };

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

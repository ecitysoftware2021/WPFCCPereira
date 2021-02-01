using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WPFCCPereira.Classes;
using WPFCCPereira.Models;
using WPFCCPereira.Resources;
using WPFCCPereira.Services.Object;

namespace WPFCCPereira.ViewModel
{
    class DataListViewModel : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Attributes
        private string _tittle;

        public string Tittle
        {
            get
            {
                return _tittle;
            }
            set
            {
                if (_tittle != value)
                {
                    _tittle = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tittle)));
                }
            }
        }

        private string _colum1;

        public string Colum1
        {
            get
            {
                return _colum1;
            }
            set
            {
                if (_colum1 != value)
                {
                    _colum1 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Colum1)));
                }
            }
        }

        private string _colum2;

        public string Colum2
        {
            get
            {
                return _colum2;
            }
            set
            {
                if (_colum2 != value)
                {
                    _colum2 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Colum2)));
                }
            }
        }

        private string _colum3;

        public string Colum3
        {
            get
            {
                return _colum3;
            }
            set
            {
                if (_colum3 != value)
                {
                    _colum3 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Colum3)));
                }
            }
        }

        private string _colum4;

        public string Colum4
        {
            get
            {
                return _colum4;
            }
            set
            {
                if (_colum4 != value)
                {
                    _colum4 = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Colum4)));
                }
            }
        }

        private string _sourceCheckId;

        public string SourceCheckId
        {
            get
            {
                return _sourceCheckId;
            }
            set
            {
                _sourceCheckId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SourceCheckId)));
            }
        }

        private string _background;

        public string Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Background)));
            }
        }

        private string _sourceCheckName;

        public string SourceCheckName
        {
            get
            {
                return _sourceCheckName;
            }
            set
            {
                _sourceCheckName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SourceCheckName)));
            }
        }

        private string _message;

        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
            }
        }

        private decimal _Amount;

        public decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Amount)));
            }
        }

        private int _currentPageIndex;

        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set
            {
                if (_currentPageIndex != value)
                {
                    _currentPageIndex = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentPageIndex)));
                }
            }
        }

        public int CuantityItems
        {
            get { return int.Parse(Utilities.GetConfiguration("CuantityItemsList")); }
        }

        private int _totalPage;

        public int TotalPage
        {
            get { return _totalPage; }
            set
            {
                if (_totalPage != value)
                {
                    _totalPage = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalPage)));
                }
            }
        }

        private Visibility _visibilityPagination;

        public Visibility VisibilityPagination
        {
            get
            {
                return _visibilityPagination;
            }
            set
            {
                _visibilityPagination = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibilityPagination)));
            }
        }

        private Visibility _visibilityName;

        public Visibility VisibilityName
        {
            get
            {
                return _visibilityName;
            }
            set
            {
                _visibilityName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibilityName)));
            }
        }

        private Visibility _visibilityId;

        public Visibility VisibilityId
        {
            get
            {
                return _visibilityId;
            }
            set
            {
                _visibilityId = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibilityId)));
            }
        }

        private Visibility _visibleTab;

        public Visibility VisibleTab
        {
            get
            {
                return _visibleTab;
            }
            set
            {
                _visibleTab = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibleTab)));
            }
        }

        private Visibility _visibilityPrevius;

        public Visibility VisibilityPrevius
        {
            get
            {
                return _visibilityPrevius;
            }
            set
            {
                _visibilityPrevius = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibilityPrevius)));
            }
        }

        private Visibility _visibilityNext;

        public Visibility VisibilityNext
        {
            get
            {
                return _visibilityNext;
            }
            set
            {
                _visibilityNext = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibilityNext)));
            }
        }

        private EtypeConsult _typeConsult;

        public EtypeConsult TypeConsult
        {
            get
            {
                return _typeConsult;
            }
            set
            {
                _typeConsult = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypeConsult)));
            }
        }

        private ETypeCertificate _typeCertificates;

        public ETypeCertificate TypeCertificates
        {
            get
            {
                return _typeCertificates;
            }
            set
            {
                _typeCertificates = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypeCertificates)));
            }
        }

        private ETransactionType _typeTransaction;

        public ETransactionType TypeTransaction
        {
            get
            {
                return _typeTransaction;
            }
            set
            {
                _typeTransaction = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypeTransaction)));
            }
        }

        private EtypeConsult _optionCheck;

        public EtypeConsult OptionCheck
        {
            get
            {
                return _optionCheck;
            }
            set
            {
                _optionCheck = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypeTransaction)));
            }
        }

        private EtypeConsult _optionChecktwo;

        public EtypeConsult OptionChecktwo
        {
            get
            {
                return _optionChecktwo;
            }
            set
            {
                _optionChecktwo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TypeTransaction)));
            }
        }

        private CollectionViewSource _viewList;

        public CollectionViewSource ViewList
        {
            get
            {
                return _viewList;
            }
            set
            {
                _viewList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ViewList)));
            }
        }

        private List<ItemList> _dataList;

        public List<ItemList> DataList
        {
            get { return _dataList; }
            set
            {
                _dataList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataList)));
            }
        }

        private List<ItemList> _dataListAux;

        public List<ItemList> DataListAux
        {
            get { return _dataListAux; }
            set
            {
                _dataListAux = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DataListAux)));
            }
        }
        #endregion

        public async Task<object> ConsultConcidences(string reference, EtypeConsult type)
        {
            try
            {
                _dataList.Clear();

                if (type == EtypeConsult.Receipt || type == EtypeConsult.Settled)
                {
                    return await AdminPayPlus.ApiIntegration.ConsultThrough(reference, type);
                }
                else
                {
                    var response = await AdminPayPlus.ApiIntegration.SearchFiles(reference, type);

                    if (response != null && response.Count > 0)
                    {
                        foreach (var item in response)
                        {
                            _dataList.Add(new ItemList
                            {
                                Item1 = item.nombre,
                                Item2 = string.Concat("NIT"),
                                Item3 = item.identificacion,
                                Item4 = string.Concat("Matrícula: ", item.matricula),
                                ImageSourse = item.estadomatricula.ToLower().Equals("mc") ? ImagesUrlResource.ImgCancel : ImagesUrlResource.ImgSelect,
                                Data = item
                            });
                        }
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }

            return null;
        }

        public Transaction GetListFiles(Transaction transaction)
        {
            try
            {
                List<Product> products = new List<Product>();

                if (DataList != null && DataList.Count > 0)
                {
                    foreach (var item in DataList)
                    {
                        if (item.Item6 > 0)
                        {
                            var certificate = (Certificates)item.Data;
                            products.Add(new Product
                            {
                                descripciontipocertificado = certificate.descripciontipocertificado,
                                descripcioncertificado = certificate.descripcioncertificado,
                                cantidad = item.Item6,
                                idservicio = certificate.servicio,
                                tipocertificado = certificate.tipocertificado,
                                valorservicio = certificate.valor * item.Item6,
                                valor = certificate.valor,
                                proponente = "m",//this.file.proponente,
                                matricula = ((Noun)transaction.File).matricula,
                                basse = certificate.valor,
                                porcentaje = 0//
                            });
                            transaction.Amount += (certificate.valor * item.Item6);
                        }
                    }
                }
                transaction.Products = products;
            }
            catch (Exception ex)
            {
                Error.SaveLogError(MethodBase.GetCurrentMethod().Name, this.GetType().Name, ex, MessageResource.StandarError);
            }
            return transaction;
        }
    }
}

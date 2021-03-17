using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCCPereira.Models
{
    public class FormularioPpalAux : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 
        
        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(direccion)));
            }
        }

        private string _municipio;
        public string municipio
        {
            get { return _municipio; }
            set
            {
                _municipio = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(municipio)));
            }
        }

        private string _barrio;
        public string barrio
        {
            get { return _barrio; }
            set
            {
                _barrio = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(barrio)));
            }
        }

        private string _zona;
        public string zona
        {
            get { return _zona; }
            set
            {
                _zona = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(zona)));
            }
        }

        private string _correo;
        public string correo
        {
            get { return _correo; }
            set
            {
                _correo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(correo)));
            }
        }

        private string _tel1;
        public string tel1
        {
            get { return _tel1; }
            set
            {
                _tel1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tel1)));
            }
        }

        private string _tel2;
        public string tel2
        {
            get { return _tel2; }
            set
            {
                _tel2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tel2)));
            }
        }

        private string _tel3;
        public string tel3
        {
            get { return _tel3; }
            set
            {
                _tel3 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tel3)));
            }
        }
        
        private string _numpredial;
        public string numpredial
        {
            get { return _numpredial; }
            set
            {
                _numpredial = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(numpredial)));
            }
        }
        
        private string _tipopropiedad;
        public string tipopropiedad
        {
            get { return _tipopropiedad; }
            set
            {
                _tipopropiedad = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tipopropiedad)));
            }
        }
        
        private string _tiposede;
        public string tiposede
        {
            get { return _tiposede; }
            set
            {
                _tiposede = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(tiposede)));
            }
        }
        
        private string _autorizo;
        public string autorizo
        {
            get { return _autorizo; }
            set
            {
                _autorizo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(autorizo)));
            }
        }
    }

}

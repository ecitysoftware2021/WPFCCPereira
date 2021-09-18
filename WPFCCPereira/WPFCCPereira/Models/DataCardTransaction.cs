using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCCPereira.Models
{
    public class DataCardTransaction : INotifyPropertyChanged
    {
        private string Mensaje;

        public string mensaje
        {
            get { return this.Mensaje; }
            set
            {
                if (this.Mensaje != value)
                {
                    this.Mensaje = value;
                    this.NotifyPropertyChanged("Mensaje");
                }
            }
        }

        public int maxlen { get; set; }

        public int minlen { get; set; }

        public string peticion { get; set; }

        public bool isCredit { get; set; }

        public string imagen { get; set; }

        private string Visible;

        public string visible
        {
            get { return this.Visible; }
            set
            {
                if (this.Visible != value)
                {
                    this.Visible = value;
                    this.NotifyPropertyChanged("Visible");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Ink;
using System.Windows.Media;

namespace UluhaPaint
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Model model;

        public ViewModel()
        {
            this.model = new Model();
        }

        public DrawingAttributes DrawingAttributes
        {
            get { return model.DrawingAttributes; }
            set { if (model.DrawingAttributes != value) model.DrawingAttributes = value; OnPropertyChanged("DrawingAttributes"); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

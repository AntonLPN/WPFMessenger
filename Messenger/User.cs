using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Messenger
{
    class User : INotifyPropertyChanged //     Возникает при смене значения свойства.
    {
        private string name;
        private string picture;//картинка пользователя
        private List<string> text;
        string dir_txt;
        /// <summary>
        /// Set get name user
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

       

        public string Picture
        {
            get { return picture; }
            set { picture = value; OnPropertyChanged("Picture"); }
        }

        public List<string> Text
        {
            get { return text; }

            set
            {
                text = value;
                

            }
        }
                
        public string DirTxt
        {
            get { return dir_txt; }

            set
            {
                dir_txt = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}

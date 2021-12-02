using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.ViewModels
{
    public class ItemReiceptVm: BaseViewModel
    {
        private int _Id;
        private string _Name;

        public ItemReiceptVm(int Id, string Name)
        {
            _Id = Id;
            _Name = Name;
        }

        public int Id
        {
            get
            {
                return _Id;
            }
            set
            {
                _Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }


        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimatecWPF.Model;

namespace VimatecWPF.ViewModels
{
    public class ItemVM:BaseViewModel
    {
        private int _IntValue;
        private PLCdescription _PLCdescription;
        private PLCValue _PLCValue;
        public int IntValue
        {
            get { return _IntValue; }
            set
            {
                if (_IntValue != value)
                {
                    _IntValue = value;
                    OnPropertyChanged("IntValue");
                }
            }
        }
        public void RecivePLCChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            if(PLCdescription.Id== _PLCdescription.Id)
            {
                _PLCValue = PLCValue;
                IntValue = PLCValue.IntValue;
                OnPropertyChanged("IntValue");
              
            }
        }        
        public ItemVM(PLCdescription Descriptions)
        {
            _PLCdescription = Descriptions;

        }

    }
}

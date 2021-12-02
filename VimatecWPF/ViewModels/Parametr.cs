using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimatecWPF.Model;

namespace VimatecWPF.ViewModels
{
    public class Parametr : BaseViewModel
    {
        public Parametr(int id, string param, int pLCValue, int recieptValue, bool flagboolParam = false, bool boolValue = false, bool RboolValue = false)
        {
            Id = id;
            Param = param;
            PLCValue = pLCValue;
            RecieptValue = recieptValue;
            FlagboolParam = flagboolParam;

            _RecieptBoolValue = RboolValue;
            _PLCBoolValue = boolValue;

        }
        public Parametr(int id, string param, int pLCValue, int recieptValue, PLCdescription PLCdescription, bool flagboolParam = false, bool boolValue = false, bool RboolValue = false)
        {
            Id = id;
            Param = param;
            PLCValue = pLCValue;
            RecieptValue = recieptValue;
            FlagboolParam = flagboolParam;
            _RecieptBoolValue = RboolValue;
            _PLCdescription = PLCdescription;
            PLCBoolValue = boolValue;

        }


        public string Param { get; set; }
        //public int PLCValue { get; set; }
        public int RecieptValue { get; set; }
        public bool FlagboolParam { get; set; }
        //public bool PLCBoolValue { get; set; }
        //public bool _RecieptBoolValue { get; set; }
        public PLCdescription _PLCdescription { get; set; }


        private bool _RecieptBoolValue { get; set; }
        public bool RecieptBoolValue
        {
            get
            {
                return _RecieptBoolValue;
            }
            set
            {
                _RecieptBoolValue = value;
                OnPropertyChanged(nameof(RecieptBoolValue));
            }
        }

        private bool _PLCBoolValue { get; set; }
        public bool PLCBoolValue
        {
            get
            {
                return _PLCBoolValue;
            }
            set
            {
                _PLCBoolValue = value;
                OnPropertyChanged(nameof(PLCBoolValue));
            }
        }
        private int _PLCValue { get; set; }
        public int PLCValue
        {
            get
            {
                return _PLCValue;
            }
            set
            {
                _PLCValue = value;
                OnPropertyChanged(nameof(PLCValue));
            }
        }

        private int _Id { get; set; }
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
    }

}

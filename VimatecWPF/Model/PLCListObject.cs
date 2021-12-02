using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class PLCListObject
    {
        List<PLCdescription> _PLCdescriptionList = new List<PLCdescription>();

        public delegate void delegateChangePLCValue(PLCdescription PLCdescription, PLCValue PLCValue);
        public event delegateChangePLCValue ChangePLCValue;

        PLC_Manager _WriteReadPLCManager;

        private void EventChangePLCValue(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            if (ChangePLCValue != null)
            {
                ChangePLCValue(PLCdescription, PLCValue);
            }
        }
        public PLCListObject(PLC_Manager WriteReadPLCManager, List<PLCdescription> PLCdescriptionList)
        {
            _WriteReadPLCManager = WriteReadPLCManager;
            _PLCdescriptionList = PLCdescriptionList;
            CreatePLCObjects(_WriteReadPLCManager, _PLCdescriptionList);
        }
        private void CreatePLCObjects(PLC_Manager WriteReadPLCManager, List<PLCdescription> PLCdescriptionList)
        {
            foreach (var PLCdescription in PLCdescriptionList)
            {
          
                    var PLCObject = new PLCObject(PLCdescription);
                    PLCObject.ChangePLCValue += EventChangePLCValue;
                    _WriteReadPLCManager.Add_PLCObject(PLCObject);
                          
            }
        }
        public PLCObject GetPLCObjectBool(PLCdescription PLCdescription)
        {
            var PLCObject = new PLCObject(PLCdescription);
            PLCObject.ChangePLCValue += EventChangePLCValue;
            _WriteReadPLCManager.Add_PLCObject(PLCObject);
            return PLCObject;
        }
        public void WritePLCValue(PLCdescription PLCdescription,PLCValue PLCValue)
        {
            _WriteReadPLCManager.WriteValue( PLCdescription,  PLCValue);
        }
    }
}

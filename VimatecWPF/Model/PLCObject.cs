using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace VimatecWPF.Model
{
    public class PLCObject
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public string PLCName;
        private string _ADSAdress = "192.168.0.163.1.1";
        private int _PLCObjecValue;
        public PLCdescription _PLCdescription;
        public delegate void delegateVoid(int PLCObjecValue);
        public event delegateVoid Change;

        public delegate void delegateChangePLCValue(PLCdescription PLCdescription, PLCValue PLCValue);
        public event delegateChangePLCValue ChangePLCValue;
      
        public PLCObject(string inPLCName)
        {
            PLCName = inPLCName;
        }
        public PLCObject(PLCdescription PLCdescription)
        {
            _PLCdescription = PLCdescription;
            PLCName = PLCdescription.PLCName;
        }

        public void Update(PLCdescription PLCdescription, PLCValue PLCValue )
        {           
            if (ChangePLCValue != null)
            {
                ChangePLCValue(PLCdescription, PLCValue);
            }
        }
      
        public void Write(int WriteValue)
        {
            using (var adsClient = new TcAdsClient())
            {
                try
                {
                    adsClient.Connect(_ADSAdress, 801);
                    AdsStream dataStream = new AdsStream(4);
                    AdsBinaryReader binReader = new AdsBinaryReader(dataStream);

                    var iHandle = adsClient.CreateVariableHandle(PLCName);
                    adsClient.WriteAny(iHandle, WriteValue);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex, "Error ADS Write int");
                }
            }
        }
    }
}

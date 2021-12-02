using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace VimatecWPF.Model
{
    public class PLCWriteObject
    {
        private string _ADSAdress = "192.168.0.163.1.1";
        private PLCValue _PLCValue;
        public PLCdescription _PLCdescription;

        public PLCWriteObject(PLCdescription plcdescription)
        {
            _PLCdescription = plcdescription;

        }
        public void Write(int WriteValue)
        {
            using (var adsClient = new TcAdsClient())
            {
                try
                {
                    adsClient.Connect(_ADSAdress, 801);                  
                    var iHandle = adsClient.CreateVariableHandle(_PLCdescription.PLCName);
                    adsClient.WriteAny(iHandle, (Int16) WriteValue);                   
                    _PLCValue = new PLCValue(TypeCode.Boolean, (Int16)WriteValue);
                }
                catch (Exception ex)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error( "Error ADS Write " +ex);
                }
            }
        }
        public void Write(bool WriteValue)
        {
            using (var adsClient = new TcAdsClient())
            {
                try
                {
                    adsClient.Connect(_ADSAdress, 801);               

                    var iHandle = adsClient.CreateVariableHandle(_PLCdescription.PLCName);
                    adsClient.WriteAny(iHandle,(Boolean) WriteValue);
                    _PLCValue = new PLCValue(TypeCode.Boolean , (Boolean)WriteValue );
                }
                catch (Exception ex)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error("Error ADS Write  bool" + ex);
                }
            }
        }
    }
}

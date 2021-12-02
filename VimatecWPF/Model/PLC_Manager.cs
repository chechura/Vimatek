using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace VimatecWPF.Model
{
    public class PLC_Manager
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        private List<PLCObject> _PLCObject = new List<PLCObject>();

        private string _ADSAdress = "192.168.0.163.1.1";

        public PLC_Manager(string ADSAdress)
        {
            _ADSAdress = ADSAdress;
        }
        public void Update()
        {
            var IEnumPLCObjec = _PLCObject.GetEnumerator();
            try
            {
                using (var adsClient = new TcAdsClient())
                {
                    adsClient.Connect(_ADSAdress, 801);
                    //AdsStream dataStream = new AdsStream(4);
                    //AdsBinaryReader binReader = new AdsBinaryReader(dataStream);

                    while (IEnumPLCObjec.MoveNext())
                    {
                        var PLCObject = IEnumPLCObjec.Current;
                        UpdatePLCObjec(adsClient ,PLCObject);
                        //var iHandle = adsClient.CreateVariableHandle(PLCObject.PLCName);
                        //adsClient.Read(iHandle, dataStream);
                        //if (PLCObject._PLCdescription._type == TypeCode.Int32)
                        //{
                        //    var iValue = binReader.ReadInt32();
                        //    dataStream.Position = 0;
                        //    PLCObject.Update(PLCObject._PLCdescription, new PLCValue(PLCObject._PLCdescription._type, iValue));
                        //}
                        //if (PLCObject._PLCdescription._type == TypeCode.Boolean)
                        //{
                        //    var iValue = binReader.ReadBoolean();
                        //    dataStream.Position = 0;
                        //    PLCObject.Update(PLCObject._PLCdescription, new PLCValue(PLCObject._PLCdescription._type, iValue));
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error ADS" + ex.Message);
                Logger.Error("Error ADS" + ex.StackTrace);
                Logger.Error("Error ADS" + ex);
            }
        }
        private void UpdatePLCObjec(TcAdsClient adsClient, PLCObject PLCObject)
        {
            try
            {
                //using (var adsClient = new TcAdsClient())
                //{
                    adsClient.Connect(_ADSAdress, 801);
                    AdsStream dataStream = new AdsStream(4);
                    AdsBinaryReader binReader = new AdsBinaryReader(dataStream);

                    //while (IEnumPLCObjec.MoveNext())
                    //{
                    //    var PLCObject = IEnumPLCObjec.Current;
                        var iHandle = adsClient.CreateVariableHandle(PLCObject.PLCName);
                        adsClient.Read(iHandle, dataStream);
                        if (PLCObject._PLCdescription._type == TypeCode.Int32)
                        {
                            var iValue = binReader.ReadInt32();
                            dataStream.Position = 0;
                            PLCObject.Update(PLCObject._PLCdescription, new PLCValue(PLCObject._PLCdescription._type, iValue));
                        }
                        if (PLCObject._PLCdescription._type == TypeCode.Boolean)
                        {
                            var iValue = binReader.ReadBoolean();
                            dataStream.Position = 0;
                            PLCObject.Update(PLCObject._PLCdescription, new PLCValue(PLCObject._PLCdescription._type, iValue));
                        }
                    //}
                //}
            }
            catch (Exception ex)
            {
                Logger.Error("Error ADS" + ex.Message);
                Logger.Error("Error ADS" + ex.StackTrace);
                Logger.Error("Error ADS" + ex);
            }
        } 

        public void Add_PLCObject(PLCObject PLCObject)
        {
            if (PLCObject != null)
            {
                _PLCObject.Add(PLCObject);
            }
        }
        public void WriteValue(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            using (var adsClient = new TcAdsClient())
            {
                try
                {
                    adsClient.Connect(_ADSAdress, 801);
                    AdsStream dataStream = new AdsStream(4);
                    AdsBinaryReader binReader = new AdsBinaryReader(dataStream);

                    var iHandle = adsClient.CreateVariableHandle(PLCdescription.PLCName);
                    if (PLCdescription._type == TypeCode.Int32)
                    {
                        adsClient.WriteAny(iHandle,(Int16) PLCValue.IntValue);
                    }
                    if (PLCdescription._type == TypeCode.Boolean)
                    {
                        adsClient.WriteAny(iHandle, PLCValue.BoolValue);
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error( "Error ADS Write int "+ex);
                }
            }
        }
    }
    
}

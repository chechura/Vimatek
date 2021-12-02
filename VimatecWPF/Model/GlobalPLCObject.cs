using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace VimatecWPF.Model
{
    public class GlobalPLCObject
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        public delegate void InitDelegate();
    
        public void StartTimer()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 600;
            timer.Start();
            timer.Elapsed += Tiks;
        }

        public void Tiks(object sender, EventArgs e)
        {
            PLCManager2.Update();
        }
        private PLC_Manager PLCManager2 = new PLC_Manager("192.168.0.163.1.1");
        public PLCListObject PLCSettingList;
        public PLCListObject PLCALLObject;

        public GlobalPLCObject()
        {
            StartTimer();
            PLCSettingList = new PLCListObject(PLCManager2, DescriptionFactory.GetSettingDescriptionList());            
            PLCALLObject = new PLCListObject(PLCManager2, DescriptionFactory.GetPLCAlldescriptionList());
        }       
    }
}

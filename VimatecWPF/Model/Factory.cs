using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class Factory
    {
        System.Timers.Timer timer = new System.Timers.Timer();
        public Factory()
        {            
            timer.Interval = 2000;
            timer.Start();
            timer.Elapsed += Tik;            
        }
        public void Tik(object sender, EventArgs e)
        {
           var Datatime = DateTime.Now.ToString();
          
        }
        public GlobalPLCObject Get_GlobalPLCObject()
        {
            var GlobalPLCObject = new GlobalPLCObject();           
            return GlobalPLCObject;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
     static public  class PLCFactory
    {
        static public PLCWriteObject CreatePlcWriteObject(PLCdescription PLCdescription)
        {
            return new PLCWriteObject(PLCdescription);
        }
    }
}

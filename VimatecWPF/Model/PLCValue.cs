using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class PLCValue
    {  
        public TypeCode _type;
        public int IntValue;
        public bool BoolValue;

        public PLCValue(TypeCode type, int intValue)
        {
            _type = type;
            IntValue = intValue;           
        }
        public PLCValue(TypeCode type, bool boolValue)
        {
            _type = type;           
            BoolValue = boolValue;
        }
    }
}

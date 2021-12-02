using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class PLCdescription
    {
        public int Id;
        public string PLCName;
        public string Label;
        public TypeCode _type;
        public PLCdescription(int id, TypeCode type, string pLCName, string label)
        {
            Id = id;
            PLCName = pLCName;
            Label = label;
            _type = type;
        }
    }
}

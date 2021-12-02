using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class RecepParam
    {
        public int Id { get; set; }
        public int ReceptNamber { get; set; }
        public int PCLObject_Id { get; set; }
        public string Name { get; set; }
        public ParamType ParamType { get; set; }
        public TypeCode ValueType { get; set; }
        public int Value { get; set; }
        public bool BoolValue { get; set; }

        public int ReceptDbId { get; set; }
        public ReceptDb ReceptDb { get; set; }
    }
}

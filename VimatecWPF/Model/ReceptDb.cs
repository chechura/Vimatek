using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public enum ParamType{
        ParamlonCarLongWay,
        ParamlonCarShotWay,
        Resiver,
        Generator,
        Rotation,
        Rotation180,
        Reconfiguration,
        Other
    }
    public enum TypeValue
    {
        Int,
        Bool 
    }
    public class ReceptDb
    {
        public int Id { get; set; }
        public int ReceptNamber { get; set; }
        public string ReceptName { get; set; }
        public List<RecepParam> RecepParams { get; set; }      
    }
}

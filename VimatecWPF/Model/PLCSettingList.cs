using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VimatecWPF.ViewModels.ViewModel;

namespace VimatecWPF.Model
{
    public class PLCSettingList
    {
        private List<PLCdescription> PLCdescriptionList = new List<PLCdescription>();
        private List<PLCdescription> PLCAlldescriptionList = new List<PLCdescription>();

        public PLCSettingList()
        {
                 //ВСЕ ОБЬЕКТЫ
            PLCAlldescriptionList.Add(new PLCdescription(17, TypeCode.Boolean, ".HMI_WeintekRetain.RotationForward", "ВРАЩЕНИЕ ПО ЧАСОВОЙ ПРИ ВЫГРУЗКЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(18, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationSec", "ВРЕМЯ ВРАЩЕНИЕ ПРИ ВЫГРУЗКЕ В СЕК"));
            PLCAlldescriptionList.Add(new PLCdescription(19, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec", "ВРЕМЯ ВРАЩЕНИЕ ПРИ ВЫГРУЗКЕ В МСЕКх100"));
            PLCAlldescriptionList.Add(new PLCdescription(20, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed", "СКОРОСТЬ  ВРАЩЕНИЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(21, TypeCode.Boolean, ".HMI_WeintekRetain.RotationForward180", "ВРАЩЕНИЕ ПО ЧАСОВОЙ ПРИ ПОВОРОТЕ НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(22, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationSec180", "ВРЕМЯ ВРАЩЕНИЯ В СЕК НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(23, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec180", "ВРЕМЯ ВРАЩЕНИЯ В МСЕКх100 НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(24, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed180", "СКОРОСТЬ ВРАЩЕНИЯ НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(25, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec180slow", "ВРЕМЯ ВРАЩЕНИЯ МЕДЛЕННО В СЕК НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(26, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed180slow", "СКОРОСТЬ ВРАЩЕНИЯ НА 180 ГРАДУСОВ"));


            PLCAlldescriptionList.Add(new PLCdescription(1, TypeCode.Boolean, ".gx_PowerOnLonCar1", "УПРАВЛЕНИЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(2, TypeCode.Boolean, ".HMI_Weintek.Hydraulic", "ГИДРАВЛИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(3, TypeCode.Boolean, ".gx_ModeAutoLonCar1", "АВТО"));
            PLCAlldescriptionList.Add(new PLCdescription(4, TypeCode.Boolean, ".gx_Clock_1Hz", "Связь с ПЛК"));

            PLCAlldescriptionList.Add(new PLCdescription(5, TypeCode.Int32, ".HMI_Weintek.ActualPosEncoderPos1608X1", "ПОЗИЦИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(6, TypeCode.Int32, ".HMI_Weintek.ActualPosPos1608X2", "ПОЗИЦИЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(7, TypeCode.Int32, ".HMI_Weintek.ActualDistance_XrayTube_Pipe", "РАССТОЯНИЕ ОТ ИЗЛУЧАТЕЛЯ ДО ТРУБЫ"));
            PLCAlldescriptionList.Add(new PLCdescription(8, TypeCode.Int32, ".HMI_Weintek.ActualDistance_Detector_Pipe", "РАССТОЯНИЕ ОТ ПРИЕМНИКА ДО ТРУБЫ"));
            PLCAlldescriptionList.Add(new PLCdescription(9, TypeCode.Int32, ".HMI_Weintek.ActualRearFistPos", "КООРДИНАТА КРАЯ ТРУБЫ"));


            PLCAlldescriptionList.Add(new PLCdescription(10, TypeCode.Boolean, ".HMI_Weintek.Error", "ОШИБКА"));
            PLCAlldescriptionList.Add(new PLCdescription(11, TypeCode.Boolean, ".HMI_Weintek.RotationOn", "ДОВОРОТ ТРУБЫ НА ВЫГРУЗКЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(12, TypeCode.Boolean, ".HMI_Weintek.StepSizeMode", "ПОШАГОВЫЙ РЕЖИМ"));
            PLCAlldescriptionList.Add(new PLCdescription(13, TypeCode.Boolean, ".HMI_Weintek.TwoWeldSeam", "ДВУХШОВНЫЙ РЕЖИМ КОНТРОЛЯ"));

            PLCAlldescriptionList.Add(new PLCdescription(14, TypeCode.Boolean, ".HMI_Weintek.Reconfiguration", "РЕЖИМ ПЕРЕНАЛАДКИ"));
            PLCAlldescriptionList.Add(new PLCdescription(15, TypeCode.Boolean, ".HMI_Weintek.ReconfigurationApply", "ПЕРЕХОД"));
            PLCAlldescriptionList.Add(new PLCdescription(16, TypeCode.Boolean, ".HMI_Weintek.Tranzit_16100_1611_1701", "ТРАНЗИТ"));

            PLCAlldescriptionList.Add(new PLCdescription(17, TypeCode.Boolean, ".HMI_WeintekRetain.RotationForward", "ВРАЩЕНИЕ ПО ЧАСОВОЙ ПРИ ВЫГРУЗКЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(18, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationSec", "ВРЕМЯ ВРАЩЕНИЕ ПРИ ВЫГРУЗКЕ В СЕК"));
            PLCAlldescriptionList.Add(new PLCdescription(19, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec", "ВРЕМЯ ВРАЩЕНИЕ ПРИ ВЫГРУЗКЕ В МСЕКх100"));
            PLCAlldescriptionList.Add(new PLCdescription(20, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed", "СКОРОСТЬ  ВРАЩЕНИЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(21, TypeCode.Boolean, ".HMI_WeintekRetain.RotationForward180", "ВРАЩЕНИЕ ПО ЧАСОВОЙ ПРИ ПОВОРОТЕ НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(22, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationSec180", "ВРЕМЯ ВРАЩЕНИЯ В СЕК НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(23, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec180", "ВРЕМЯ ВРАЩЕНИЯ В МСЕКх100 НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(24, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed180", "СКОРОСТЬ ВРАЩЕНИЯ НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(25, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec180slow", "ВРЕМЯ ВРАЩЕНИЯ МЕДЛЕННО В СЕК НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(26, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed180slow", "СКОРОСТЬ ВРАЩЕНИЯ НА 180 ГРАДУСОВ"));

            //PlcObjects.Add(new PLCdescription(11, ".HMI_WeintekRetain.ParamModeXray", "ПАРАМЕТР РЕЖИМА "));
            PLCAlldescriptionList.Add(new PLCdescription(27, TypeCode.Int32, ".HMI_WeintekRetain.DistanceShotWayStepSize", "ДИСТАНЦИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));

            PLCAlldescriptionList.Add(new PLCdescription(28, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedVelocity", "СКОРОСТЬ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(29, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedRamp", "РАМПА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(30, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedSlowVelocity", "МЕДЛЕННАЯ СКОРОСТЬ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));

            PLCAlldescriptionList.Add(new PLCdescription(31, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedSlowRamp", "МЕДЛЕННАЯ РАМПА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(32, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(33, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(34, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));

            PLCAlldescriptionList.Add(new PLCdescription(35, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedVelocity", "СКОРОСТЬ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(36, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedRamp", "РАМПА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(37, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedSlowVelocity", "МЕДЛЕННАЯ СКОРОСТЬ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));

            PLCAlldescriptionList.Add(new PLCdescription(38, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedSlowRamp", "МЕДЛЕННАЯ РАМПА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(39, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(40, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(41, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            //Setting
              PLCdescriptionList.Add(new PLCdescription(43, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityPosition", "СКОРОСТЬ ПЕРЕМЕЩЕНИЯ ИЗЛУЧАТЕЛЯ"));
            PLCdescriptionList.Add(new PLCdescription(44, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityCreep", "СКОРОСТЬ МЕДЛЕННАЯ ИЗЛУЧАТЕЛЯ"));
            PLCdescriptionList.Add(new PLCdescription(45, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocitySlowManu", "СКОРОСТЬ МЕДЛЕННАЯ ИЗЛУЧАТЕЛЯ В РУЧНОМ РЕЖИМЕ"));
            PLCdescriptionList.Add(new PLCdescription(46, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityMan", "СКОРОСТЬ ИЗЛУЧАТЕЛЯ В РУЧНОМ РЕЖИМЕ"));
            PLCdescriptionList.Add(new PLCdescription(47, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.Ramp", "РАМПА ИЗЛУЧАТЕЛЯ "));

            PLCdescriptionList.Add(new PLCdescription(48, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ИЗЛУЧАТЕЛЯ "));
            PLCdescriptionList.Add(new PLCdescription(49, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ИЗЛУЧАТЕЛЯ "));
            PLCdescriptionList.Add(new PLCdescription(50, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ИЗЛУЧАТЕЛЯ "));

             PLCdescriptionList.Add(new PLCdescription(52, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityPosition", "СКОРОСТЬ ПЕРЕМЕЩЕНИЯ ПРИЕМНИКА"));
            PLCdescriptionList.Add(new PLCdescription(53, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityCreep", "СКОРОСТЬ МЕДЛЕННАЯ ПРИЕМНИКА"));
            PLCdescriptionList.Add(new PLCdescription(54, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocitySlowManu", "СКОРОСТЬ МЕДЛЕННАЯ ПРИЕМНИКА В РУЧНОМ РЕЖИМЕ"));
            PLCdescriptionList.Add(new PLCdescription(55, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityMan", "СКОРОСТЬ ПРИЕМНИКА В РУЧНОМ РЕЖИМЕ"));
            PLCdescriptionList.Add(new PLCdescription(56, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.Ramp", "РАМПА ПРИЕМНИКА "));

            PLCdescriptionList.Add(new PLCdescription(57, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ПРИЕМНИКА "));
            PLCdescriptionList.Add(new PLCdescription(58, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ПРИЕМНИКА "));
            PLCdescriptionList.Add(new PLCdescription(59, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ПРИЕМНИКА "));

            PLCdescriptionList.Add(new PLCdescription(60, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ИЗЛУЧАТЕЛЯ"));
            PLCdescriptionList.Add(new PLCdescription(61, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ПРИЕМНИКА"));
      }
        public List<PLCdescription> GetPLCdescriptionList()
        {
            return PLCdescriptionList;
        }
        public List<PLCdescription> GetPLCAlldescriptionList()
        {
            return PLCAlldescriptionList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwinCAT.Ads;

namespace VimatecWPF.Model
{
    static class DescriptionFactory
    {       
        private static List<PLCdescription> PLCAlldescriptionList = new List<PLCdescription>();
        private static void Creat()
        {
            PLCAlldescriptionList.Clear();
            //ЗАГОЛОВОК ОКНА
            PLCAlldescriptionList.Add(new PLCdescription(1, TypeCode.Boolean, ".gx_PowerOnLonCar1", "УПРАВЛЕНИЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(2, TypeCode.Boolean, ".HMI_Weintek.Hydraulic", "ГИДРАВЛИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(3, TypeCode.Boolean, ".gx_ModeAutoLonCar1", "АВТО"));
            PLCAlldescriptionList.Add(new PLCdescription(4, TypeCode.Boolean, ".gx_Clock_1Hz", "Связь с ПЛК"));

            //ОСНОВНОЕ ОКНО
            PLCAlldescriptionList.Add(new PLCdescription(5, TypeCode.Int32, ".HMI_Weintek.ActualPosEncoderPos1608X1", "ПОЗИЦИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(6, TypeCode.Int32, ".HMI_Weintek.ActualPosPos1608X2", "ПОЗИЦИЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(7, TypeCode.Int32, ".HMI_Weintek.ActualDistance_XrayTube_Pipe", "РАССТОЯНИЕ ОТ ИЗЛУЧАТЕЛЯ ДО ТРУБЫ"));
            PLCAlldescriptionList.Add(new PLCdescription(8, TypeCode.Int32, ".HMI_Weintek.ActualDistance_Detector_Pipe", "РАССТОЯНИЕ ОТ ПРИЕМНИКА ДО ТРУБЫ"));
            PLCAlldescriptionList.Add(new PLCdescription(9, TypeCode.Int32, ".HMI_Weintek.ActualRearFistPos", "КООРДИНАТА КРАЯ ТРУБЫ"));

            //РЕЖИМЫ
            PLCAlldescriptionList.Add(new PLCdescription(10, TypeCode.Boolean, ".HMI_Weintek.Error", "ОШИБКА"));
            PLCAlldescriptionList.Add(new PLCdescription(11, TypeCode.Boolean, ".HMI_Weintek.RotationOn", "ДОВОРОТ ТРУБЫ НА ВЫГРУЗКЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(12, TypeCode.Boolean, ".HMI_Weintek.StepSizeMode", "ПОШАГОВЫЙ РЕЖИМ"));
            PLCAlldescriptionList.Add(new PLCdescription(13, TypeCode.Boolean, ".HMI_Weintek.TwoWeldSeam", "ДВУХШОВНЫЙ РЕЖИМ КОНТРОЛЯ"));

            PLCAlldescriptionList.Add(new PLCdescription(14, TypeCode.Boolean, ".HMI_Weintek.Reconfiguration", "РЕЖИМ ПЕРЕНАЛАДКИ"));
            PLCAlldescriptionList.Add(new PLCdescription(15, TypeCode.Boolean, ".HMI_Weintek.ReconfigurationApply", "ПЕРЕХОД"));
            PLCAlldescriptionList.Add(new PLCdescription(16, TypeCode.Boolean, ".HMI_Weintek.Tranzit_16100_1611_1701", "ТРАНЗИТ"));
           
            //ВРАЩЕНИЕ   
            PLCAlldescriptionList.Add(new PLCdescription(17, TypeCode.Boolean, ".HMI_WeintekRetain.RotationForward", "ВРАЩЕНИЕ ПО ЧАСОВОЙ ПРИ ВЫГРУЗКЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(18, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationSec", "ВРЕМЯ ВРАЩЕНИЕ ПРИ ВЫГРУЗКЕ В СЕК"));
            PLCAlldescriptionList.Add(new PLCdescription(19, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec", "ВРЕМЯ ВРАЩЕНИЕ ПРИ ВЫГРУЗКЕ В МСЕКх100"));
            PLCAlldescriptionList.Add(new PLCdescription(20, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed", "СКОРОСТЬ  ВРАЩЕНИЯ"));
           
            //ВРАЩЕНИЕ НА 180 ГРАДУСОВ
            PLCAlldescriptionList.Add(new PLCdescription(21, TypeCode.Boolean, ".HMI_WeintekRetain.RotationForward180", "ВРАЩЕНИЕ ПО ЧАСОВОЙ ПРИ ПОВОРОТЕ НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(22, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationSec180", "ВРЕМЯ ВРАЩЕНИЯ В СЕК НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(23, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec180", "ВРЕМЯ ВРАЩЕНИЯ В МСЕКх100 НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(24, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed180", "СКОРОСТЬ ВРАЩЕНИЯ НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(25, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec180slow", "ВРЕМЯ ВРАЩЕНИЯ МЕДЛЕННО В СЕК НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(26, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed180slow", "СКОРОСТЬ ВРАЩЕНИЯ НА 180 ГРАДУСОВ"));

            //PlcObjects.Add(new PLCdescription(11, ".HMI_WeintekRetain.ParamModeXray", "ПАРАМЕТР РЕЖИМА "));
           
            //ПАРАМЕТРЫ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ ТЕЛЕГИ
            PLCAlldescriptionList.Add(new PLCdescription(28, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedVelocity", "СКОРОСТЬ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(29, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedRamp", "РАМПА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(30, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedSlowVelocity", "МЕДЛЕННАЯ СКОРОСТЬ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));

            PLCAlldescriptionList.Add(new PLCdescription(31, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedSlowRamp", "МЕДЛЕННАЯ РАМПА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(32, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(33, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(34, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
           
            //ПАРАМЕТРЫ КОРОТКИХ ПЕРЕМЕЩЕНИЙ ТЕЛЕГИ
            PLCAlldescriptionList.Add(new PLCdescription(35, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedVelocity", "СКОРОСТЬ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(36, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedRamp", "РАМПА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(37, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedSlowVelocity", "МЕДЛЕННАЯ СКОРОСТЬ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));

            PLCAlldescriptionList.Add(new PLCdescription(38, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedSlowRamp", "МЕДЛЕННАЯ РАМПА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(39, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(40, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(41, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(42, TypeCode.Int32, ".HMI_WeintekRetain.DistanceShotWayStepSize", "ДИСТАНЦИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));

            //НАСТРОЙКИ ПОСТОЯННЫЕ
            //PLCdescriptionList.Add(new PLCdescription(42, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(43, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityPosition", "СКОРОСТЬ ПЕРЕМЕЩЕНИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(44, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityCreep", "СКОРОСТЬ МЕДЛЕННАЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(45, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocitySlowManu", "СКОРОСТЬ МЕДЛЕННАЯ ИЗЛУЧАТЕЛЯ В РУЧНОМ РЕЖИМЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(46, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityMan", "СКОРОСТЬ ИЗЛУЧАТЕЛЯ В РУЧНОМ РЕЖИМЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(47, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.Ramp", "РАМПА ИЗЛУЧАТЕЛЯ "));

            PLCAlldescriptionList.Add(new PLCdescription(48, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ИЗЛУЧАТЕЛЯ "));
            PLCAlldescriptionList.Add(new PLCdescription(49, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ИЗЛУЧАТЕЛЯ "));
            PLCAlldescriptionList.Add(new PLCdescription(50, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ИЗЛУЧАТЕЛЯ "));

            //PLCdescriptionList.Add(new PLCdescription(51, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(52, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityPosition", "СКОРОСТЬ ПЕРЕМЕЩЕНИЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(53, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityCreep", "СКОРОСТЬ МЕДЛЕННАЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(54, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocitySlowManu", "СКОРОСТЬ МЕДЛЕННАЯ ПРИЕМНИКА В РУЧНОМ РЕЖИМЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(55, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityMan", "СКОРОСТЬ ПРИЕМНИКА В РУЧНОМ РЕЖИМЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(56, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.Ramp", "РАМПА ПРИЕМНИКА "));

            PLCAlldescriptionList.Add(new PLCdescription(57, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ПРИЕМНИКА "));
            PLCAlldescriptionList.Add(new PLCdescription(58, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ПРИЕМНИКА "));
            PLCAlldescriptionList.Add(new PLCdescription(59, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ПРИЕМНИКА "));

            //ПАРАМЕТРЫ ПЕРЕВАЛКИ
            PLCAlldescriptionList.Add(new PLCdescription(60, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(61, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ПРИЕМНИКА"));

        }
        private static List<PLCdescription> GetdescriptionList()
        {
            List<PLCdescription> PLCAlldescriptionList = new List<PLCdescription>();
            //ЗАГОЛОВОК ОКНА
            PLCAlldescriptionList.Add(new PLCdescription(1, TypeCode.Boolean, ".gx_PowerOnLonCar1", "УПРАВЛЕНИЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(2, TypeCode.Boolean, ".HMI_Weintek.Hydraulic", "ГИДРАВЛИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(3, TypeCode.Boolean, ".gx_ModeAutoLonCar1", "АВТО"));
            PLCAlldescriptionList.Add(new PLCdescription(4, TypeCode.Boolean, ".gx_Clock_1Hz", "Связь с ПЛК"));

            //ОСНОВНОЕ ОКНО
            PLCAlldescriptionList.Add(new PLCdescription(5, TypeCode.Int32, ".HMI_Weintek.ActualPosPos1608X1", "ПОЗИЦИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(6, TypeCode.Int32, ".HMI_Weintek.ActualPosPos1608X2", "ПОЗИЦИЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(7, TypeCode.Int32, ".HMI_Weintek.ActualDistance_XrayTube_Pipe", "РАССТОЯНИЕ ОТ ИЗЛУЧАТЕЛЯ ДО ТРУБЫ"));
            PLCAlldescriptionList.Add(new PLCdescription(8, TypeCode.Int32, ".HMI_Weintek.ActualDistance_Detector_Pipe", "РАССТОЯНИЕ ОТ ПРИЕМНИКА ДО ТРУБЫ"));
            PLCAlldescriptionList.Add(new PLCdescription(9, TypeCode.Int32, ".HMI_Weintek.ActualRearFistPos", "КООРДИНАТА КРАЯ ТРУБЫ"));

            //РЕЖИМЫ
            PLCAlldescriptionList.Add(new PLCdescription(10, TypeCode.Boolean, ".HMI_Weintek.Error", "ОШИБКА"));
            PLCAlldescriptionList.Add(new PLCdescription(11, TypeCode.Boolean, ".HMI_Weintek.RotationOn", "ДОВОРОТ ТРУБЫ НА ВЫГРУЗКЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(12, TypeCode.Boolean, ".HMI_Weintek.StepSizeMode", "ПОШАГОВЫЙ РЕЖИМ"));
            PLCAlldescriptionList.Add(new PLCdescription(13, TypeCode.Boolean, ".HMI_Weintek.TwoWeldSeam", "ДВУХШОВНЫЙ РЕЖИМ КОНТРОЛЯ"));

            PLCAlldescriptionList.Add(new PLCdescription(14, TypeCode.Boolean, ".HMI_Weintek.Reconfiguration", "РЕЖИМ ПЕРЕНАЛАДКИ"));
            PLCAlldescriptionList.Add(new PLCdescription(15, TypeCode.Boolean, ".HMI_Weintek.ReconfigurationApply", "ПЕРЕХОД"));
            PLCAlldescriptionList.Add(new PLCdescription(16, TypeCode.Boolean, ".HMI_Weintek.Tranzit_16100_1611_1701", "ТРАНЗИТ"));

            //ВРАЩЕНИЕ   
            PLCAlldescriptionList.Add(new PLCdescription(17, TypeCode.Boolean, ".HMI_WeintekRetain.RotationForward", "ВРАЩЕНИЕ ПО ЧАСОВОЙ ПРИ ВЫГРУЗКЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(18, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationSec", "ВРЕМЯ ВРАЩЕНИЕ ПРИ ВЫГРУЗКЕ В СЕК"));
            PLCAlldescriptionList.Add(new PLCdescription(19, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec", "ВРЕМЯ ВРАЩЕНИЕ ПРИ ВЫГРУЗКЕ В МСЕКх100"));
            PLCAlldescriptionList.Add(new PLCdescription(20, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed", "СКОРОСТЬ  ВРАЩЕНИЯ"));

            //ВРАЩЕНИЕ НА 180 ГРАДУСОВ
            PLCAlldescriptionList.Add(new PLCdescription(21, TypeCode.Boolean, ".HMI_WeintekRetain.RotationForward180", "ВРАЩЕНИЕ ПО ЧАСОВОЙ ПРИ ПОВОРОТЕ НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(22, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationSec180", "ВРЕМЯ ВРАЩЕНИЯ В СЕК НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(23, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec180", "ВРЕМЯ ВРАЩЕНИЯ В МСЕКх100 НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(24, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed180", "СКОРОСТЬ ВРАЩЕНИЯ НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(25, TypeCode.Int32, ".HMI_WeintekRetain.TimeRotationMiliSec180slow", "ВРЕМЯ ВРАЩЕНИЯ МЕДЛЕННО В СЕК НА 180 ГРАДУСОВ"));
            PLCAlldescriptionList.Add(new PLCdescription(26, TypeCode.Int32, ".HMI_WeintekRetain.RotationSpeed180slow", "СКОРОСТЬ ВРАЩЕНИЯ НА 180 ГРАДУСОВ"));


            //ПАРАМЕТРЫ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ ТЕЛЕГИ
            PLCAlldescriptionList.Add(new PLCdescription(28, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedVelocity", "СКОРОСТЬ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(29, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedRamp", "РАМПА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(30, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedSlowVelocity", "МЕДЛЕННАЯ СКОРОСТЬ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));

            PLCAlldescriptionList.Add(new PLCdescription(31, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.AutoLoadedSlowRamp", "МЕДЛЕННАЯ РАМПА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(32, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(33, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(34, TypeCode.Int32, ".HMI_WeintekRetain.ParamFistLastPos.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ДЛИННЫХ ПЕРЕМЕЩЕНИЙ"));

            //ПАРАМЕТРЫ КОРОТКИХ ПЕРЕМЕЩЕНИЙ ТЕЛЕГИ
            PLCAlldescriptionList.Add(new PLCdescription(35, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedVelocity", "СКОРОСТЬ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(36, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedRamp", "РАМПА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(37, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedSlowVelocity", "МЕДЛЕННАЯ СКОРОСТЬ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));

            PLCAlldescriptionList.Add(new PLCdescription(38, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.AutoLoadedSlowRamp", "МЕДЛЕННАЯ РАМПА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(39, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(40, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(41, TypeCode.Int32, ".HMI_WeintekRetain.ParamShotWay.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));
            PLCAlldescriptionList.Add(new PLCdescription(42, TypeCode.Int32, ".HMI_WeintekRetain.DistanceShotWayStepSize", "ДИСТАНЦИЯ КОРОТКИХ ПЕРЕМЕЩЕНИЙ"));

            //НАСТРОЙКИ ПОСТОЯННЫЕ
            //PLCdescriptionList.Add(new PLCdescription(42, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(43, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityPosition", "СКОРОСТЬ ПЕРЕМЕЩЕНИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(44, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityCreep", "СКОРОСТЬ МЕДЛЕННАЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(45, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocitySlowManu", "СКОРОСТЬ МЕДЛЕННАЯ ИЗЛУЧАТЕЛЯ В РУЧНОМ РЕЖИМЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(46, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.VelocityMan", "СКОРОСТЬ ИЗЛУЧАТЕЛЯ В РУЧНОМ РЕЖИМЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(47, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.Ramp", "РАМПА ИЗЛУЧАТЕЛЯ "));

            PLCAlldescriptionList.Add(new PLCdescription(48, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ИЗЛУЧАТЕЛЯ "));
            PLCAlldescriptionList.Add(new PLCdescription(49, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ИЗЛУЧАТЕЛЯ "));
            PLCAlldescriptionList.Add(new PLCdescription(50, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ИЗЛУЧАТЕЛЯ "));

            //PLCdescriptionList.Add(new PLCdescription(51, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(52, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityPosition", "СКОРОСТЬ ПЕРЕМЕЩЕНИЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(53, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityCreep", "СКОРОСТЬ МЕДЛЕННАЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(54, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocitySlowManu", "СКОРОСТЬ МЕДЛЕННАЯ ПРИЕМНИКА В РУЧНОМ РЕЖИМЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(55, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.VelocityMan", "СКОРОСТЬ ПРИЕМНИКА В РУЧНОМ РЕЖИМЕ"));
            PLCAlldescriptionList.Add(new PLCdescription(56, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.Ramp", "РАМПА ПРИЕМНИКА "));

            PLCAlldescriptionList.Add(new PLCdescription(57, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.TargetRange", "ДОПУСК ПОЗИЦИОНИРОВАНИЯ ПРИЕМНИКА "));
            PLCAlldescriptionList.Add(new PLCdescription(58, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.BrakeDistance", "РАССТОЯНИЕ ОСТАНОВА ПРИЕМНИКА "));
            PLCAlldescriptionList.Add(new PLCdescription(59, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.CreepDistance", "РАССТОЯНИЕ ЗАМЕДЛЕНИЯ ПРИЕМНИКА "));

            //ПАРАМЕТРЫ ПЕРЕВАЛКИ
            PLCAlldescriptionList.Add(new PLCdescription(60, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X1.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ИЗЛУЧАТЕЛЯ"));
            PLCAlldescriptionList.Add(new PLCdescription(61, TypeCode.Int32, ".HMI_WeintekRetain.ParamTagetPos1608X2.TargetPosition", "НАЗНАЧЕНИЕ ПЕРЕМЕЩЕНИЯ ПРИЕМНИКА"));
            PLCAlldescriptionList.Add(new PLCdescription(62, TypeCode.Boolean, ".HMI_Weintek.Pos_Ok_X1", "ИЗЛУЧАТЕЛЬ В ПОЗИЦИИ"));
            PLCAlldescriptionList.Add(new PLCdescription(63, TypeCode.Boolean, ".HMI_Weintek.Pos_Ok_X2", "ПРИЕМНИК В ПОЗИЦИИ"));
            return PLCAlldescriptionList;
        }
        public static List<PLCdescription> RotationDescriptionList()
        {
            var t = GetDescriptionRange(17, 20);
            return t;
        }
        public static List<PLCdescription> Rotation180DescriptionList()
        {            
            var t = GetDescriptionRange(21, 26);
            return t;
        }
        public static List<PLCdescription> ReconfigurationDescriptionList()
        {
            var t= GetDescriptionRange(60, 61);
            return t;
        }
        public static List<PLCdescription> GetSettingDescriptionList()
        {           
            return GetDescriptionRange(43, 59);
        }
        public static List<PLCdescription> GetLongWayDescriptionList()
        {
            return GetDescriptionRange(28, 34);
        }
        public static List<PLCdescription> GetShotWayrDescriptionList()
        {
            return GetDescriptionRange(35, 42);
        }
        public static List<PLCdescription> GetResiverDescriptionList()
        {
            return GetDescriptionRange(43, 50);
        }
        public static List<PLCdescription> GetGeneratorDescriptionList()
        {
            return GetDescriptionRange(52, 59);
        }
        public static PLCdescription GetDescriptionById(int id)
        { 
            return GetdescriptionList().
                    Where(t => t.Id == id).
                        First<PLCdescription>();
        }
        private static List<PLCdescription> GetDescriptionRange(int Fist_id,int End_id)
        {
            
            return GetdescriptionList().                  
                   Where(t => t.Id > Fist_id|| t.Id == Fist_id).
                   Where(t=>t.Id< End_id|| t.Id == End_id).                 
                        ToList<PLCdescription>();
        }
        public static PLCdescription GetDescriptionByName( string Name)
        {
            var tq = GetdescriptionList().
                    Where(t => t.PLCName.Contains(Name)).
                        ToList<PLCdescription>();
            var m = tq;
            return tq.First();
        }  
        public static List<PLCdescription> GetPLCAlldescriptionList()
        {
            return GetdescriptionList();
        }
    }
}



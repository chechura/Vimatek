using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    static class RecipeFactory { 

    public static List<RecepParam> RotationRecipeParam()
    {
        List<RecepParam> ListRecepParam = new List<RecepParam>();
        foreach (var Description in DescriptionFactory.RotationDescriptionList())
        {
            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.Rotation, Name = Description.Label, Value = 0 });
        }
        return ListRecepParam;
    }
    public static List<RecepParam> Rotation180RecipeParam()
    {
        List<RecepParam> ListRecepParam = new List<RecepParam>();
        foreach (var Description in DescriptionFactory.Rotation180DescriptionList())
        {
            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.Rotation180, Name = Description.Label, Value = 0 });
        }
        return ListRecepParam;
    }
    public static List<RecepParam> ReconfigurationRecipeParam()
    {
        List<RecepParam> ListRecepParam = new List<RecepParam>();
        foreach (var Description in DescriptionFactory.ReconfigurationDescriptionList())
        {
            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.Reconfiguration, Name = Description.Label, Value = 0 });
        }
        return ListRecepParam;
    }
    public static List<RecepParam> GetSettingRecipeParam()
    {
        List<RecepParam> ListRecepParam = new List<RecepParam>();
        foreach (var Description in DescriptionFactory.GetSettingDescriptionList())
        {
            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.Other, Name = Description.Label, Value = 0 });
        }
        return ListRecepParam;
    }
    public static List<RecepParam> GetLongWayRecipeParam()
    {
        List<RecepParam> ListRecepParam = new List<RecepParam>();
        foreach (var Description in DescriptionFactory.GetLongWayDescriptionList())
        {
            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.ParamlonCarLongWay, Name = Description.Label, Value = 0 });
        }
        return ListRecepParam;
    }

    public static List<RecepParam> GetShotWayRecipeParam()
    {
        List<RecepParam> ListRecepParam = new List<RecepParam>();
        foreach (var Description in DescriptionFactory.GetShotWayrDescriptionList())
        {
            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.ParamlonCarShotWay, Name = Description.Label, Value = 0 });
        }
        return ListRecepParam;
    }
    public static List<RecepParam> GetResiverRecipeParam()
    {
        List<RecepParam> ListRecepParam = new List<RecepParam>();
        foreach (var Description in DescriptionFactory.GetResiverDescriptionList())
        {
            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.Resiver, Name = Description.Label, Value = 0 });
        }
        return ListRecepParam;
    }
    public static List<RecepParam> GetGeneratorRecipeParam()
    {
        List<RecepParam> ListRecepParam = new List<RecepParam>();
        foreach (var Description in DescriptionFactory.GetGeneratorDescriptionList())
        {
            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.Generator, Name = Description.Label, Value = 0 });
        }
        return ListRecepParam;
    }
    //{
    //    public static  List<RecepParam> GetLongWayRecipeParam()
    //    {
    //        List <RecepParam> ListRecepParam= new List<RecepParam>();
    //        foreach (var Description in DescriptionFactory.GetLongWayDescriptionList())
    //        {
    //            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.ParamlonCarLongWay, Name = Description.Label, Value = 0 });
    //        }
    //        return ListRecepParam;
    //    }
    //    public static List<RecepParam> GetShotWayRecipeParam()
    //    {
    //        List<RecepParam> ListRecepParam = new List<RecepParam>();
    //        foreach (var Description in DescriptionFactory.GetShotWayrDescriptionList())
    //        {
    //            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.ParamlonCarLongWay, Name = Description.Label, Value = 0 });
    //        }
    //        return ListRecepParam;
    //    }
    //    public static List<RecepParam> ReconfigurationRecipeParam()
    //    {
    //        List<RecepParam> ListRecepParam = new List<RecepParam>();
    //        foreach (var Description in DescriptionFactory.ReconfigurationDescriptionList())
    //        {
    //            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.ParamlonCarLongWay, Name = Description.Label, Value = 0 });
    //        }
    //        return ListRecepParam;
    //    }
    ////
    //    public static List<RecepParam> GetGeneratorRecipeParam()
    //    {
    //        List<RecepParam> ListRecepParam = new List<RecepParam>();
    //        foreach (var Description in DescriptionFactory.ReconfigurationDescriptionList())
    //        {
    //            ListRecepParam.Add(new RecepParam { PCLObject_Id = Description.Id, ValueType = Description._type, ParamType = ParamType.ParamlonCarLongWay, Name = Description.Label, Value = 0 });
    //        }
    //        return ListRecepParam;
    //    }

}
}

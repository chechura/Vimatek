using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VimatecWPF.Model
{
    public class Recept : IDisposable
    {

        public void Add_Recept()
        {
            using (var db = new DateContext())
            {
                db.Database.Log = Console.Write;
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var RecepParams = new List<RecepParam>();
                        RecepParams = RecepParams.Concat(RecipeFactory.ReconfigurationRecipeParam()).ToList();
                        RecepParams = RecepParams.Concat(RecipeFactory.GetLongWayRecipeParam()).ToList();
                        RecepParams = RecepParams.Concat(RecipeFactory.GetShotWayRecipeParam()).ToList();                       
                       
                        RecepParams = RecepParams.Concat(RecipeFactory.Rotation180RecipeParam()).ToList();
                        RecepParams = RecepParams.Concat(RecipeFactory.RotationRecipeParam()).ToList();


                        foreach (var RecepParam in RecepParams)
                        {
                            db.RecepParams.Add(RecepParam);
                        }
                        db.SaveChanges();
                        db.Reciepts.Add(new ReceptDb { ReceptName = "НОВЫЙ РЕЦЕПТ 0000х00", RecepParams = RecepParams });
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        NLog.LogManager.GetCurrentClassLogger().Error("Base error " + ex);
                    }
                }
            }
        }
        public void CopyRecept(int id)
        {
            using (var db = new DateContext())
            {
                db.Database.Log = Console.Write;
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var RecepParams = Get_ReceptByRecipeId(id);
                        foreach (var RecepParam in RecepParams)
                        {
                            db.RecepParams.Add(RecepParam);
                        }
                        db.SaveChanges();
                        db.Reciepts.Add(new ReceptDb { ReceptName = "НОВЫЙ РЕЦЕПТ 0000х00", RecepParams = RecepParams });
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        NLog.LogManager.GetCurrentClassLogger().Error("Base error " + ex);
                    }
                }
            }
        }
        public void Delite_ReceptById(int id)
        {
            using (var db = new DateContext())
            {
                db.Database.Log = Console.Write;
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (db.Reciepts.Where(t => t.Id == id).Count() != 0)
                        {
                            var Recept = db.Reciepts.Where(t => t.Id == id).First();
                            var ReceptRange = db.RecepParams.Where(t => t.ReceptDbId == Recept.Id);
                            db.RecepParams.RemoveRange(ReceptRange);

                            db.Reciepts.Remove(Recept);
                            db.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        NLog.LogManager.GetCurrentClassLogger().Error("Base error " + ex);
                    }
                }
            }
        }
        
        public List<RecepParam> Get_ReceptByRecipeId(int Recipe_Id)
            {
                var RecepParam = new List<RecepParam>();
                using (var db = new DateContext())
                {
                    try
                    {
                        RecepParam = db.RecepParams                           
                             .Where(t => t.ReceptDbId == Recipe_Id)
                             .OrderBy(t => t.Id).ToList();
                    }
                    catch (Exception ex)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Error("Get_ReceptByRecipeId error " + ex);
                    }
                }
          return RecepParam;

        }
        public List<RecepParam> Get_ReceptByParamTypeByValueType( int Id,ParamType ParamType, TypeCode ValueType)
        {
            var RecepParam = new List<RecepParam>();
            using (var db = new DateContext())
            {
                try
                {
                    RecepParam = db.RecepParams
                         .Where(t => t.ParamType == ParamType)
                         .Where(t => t.ValueType == ValueType)
                         .Where(t => t.ReceptDbId == Id)
                         .OrderBy(t => t.Id).ToList();
                }
                catch (Exception ex)
                {

                }
            }
            return RecepParam;
        
        }
        public List<RecepParam> Get_ReceptByParamType(int Recipe_Id, ParamType ParamType)
        {
            var RecepParam = new List<RecepParam>();
            using (var db = new DateContext())
            {
                try
                {
                    RecepParam = db.RecepParams
                         .Where(t => t.ParamType == ParamType)                        
                         .Where(t => t.ReceptDbId == Recipe_Id)
                         .OrderBy(t => t.Id).ToList();
                }
                catch (Exception ex)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error("Base error " + ex);
                }
            }
            return RecepParam;

        }
        public List<RecepParam> Get_ReceptByDescriptorList(List<PLCdescription> PLCdescriptionList)
        {
            var RecepParam = new List<RecepParam>();
            using (var db = new DateContext())
            {
                try
                {
                    RecepParam = db.RecepParams.
                         Where(t => PLCdescriptionList.Select(l=>l.Id).Contains(t.Id)).                        
                         OrderBy(t => t.Id).ToList();
                }
                catch (Exception ex)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error("Base error " + ex);
                }
            }
            return RecepParam;
        }

        public void Rename_ReceptById(int id,string Name)
        {
            using (var db = new DateContext())
            {
                db.Database.Log = Console.Write;
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (db.Reciepts.Where(t => t.Id == id).Count() != 0)
                        {
                            var Recept = db.Reciepts.Where(t => t.Id == id).First();
                            Recept.ReceptName = Name;
                            db.SaveChanges();
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        NLog.LogManager.GetCurrentClassLogger().Error("Base error " + ex);
                    }
                }
            }
        }
        public void ChangeValue_ReceptById(int id, bool ChangeBoolValue )
        {
            using (var db = new DateContext())
            {
                db.Database.Log = Console.Write;
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (db.RecepParams.Where(t => t.Id == id).Count() != 0)
                        {
                            var RecepParams = db.RecepParams.Where(t => t.Id == id).First();
                            RecepParams.Value = 0;
                            RecepParams.BoolValue = ChangeBoolValue;
                            db.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        NLog.LogManager.GetCurrentClassLogger().Error("Base error " + ex);
                    }
                }
            }
        }

        public void ChangeValue_ReceptById(int id, int ChangeValue)
        {
            using (var db = new DateContext())
            {
                db.Database.Log = Console.Write;
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (db.RecepParams.Where(t => t.Id == id).Count() != 0)
                        {
                            var RecepParams = db.RecepParams.Where(t => t.Id == id).First();
                            RecepParams.Value = ChangeValue;
                            RecepParams.BoolValue = false;
                            db.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        NLog.LogManager.GetCurrentClassLogger().Error("Base error " + ex);
                    }
                }
            }
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}

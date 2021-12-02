using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using VimatecWPF.Model;

namespace VimatecWPF.ViewModels

{
    public class ViewModel : BaseViewModel
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        private GlobalPLCObject _GlobalPLCObject;

        public bool _AuthorizedUserаflag;
        public bool AuthorizedUserаflag
        {
            get
            {
                return _AuthorizedUserаflag;
            }
            set
            {
                _AuthorizedUserаflag = value;
                OnPropertyChanged("AuthorizedUserаflag");
            }
        }
        private Visibility _visibilityIsAuthenticated;
        public Visibility VisibilityIsAuthenticated
        {
            get
            {
                if (_AuthorizedUserаflag)
                {
                    _visibilityIsAuthenticated = Visibility.Visible;
                }
                else
                {
                    _visibilityIsAuthenticated = Visibility.Hidden;
                }
                return _visibilityIsAuthenticated;
            }
            set
            {
                _visibilityIsAuthenticated = value;

                OnPropertyChanged("VisibilityIsAuthenticated");
            }
        }

        ObservableCollection<ItemReiceptVm> _ListReicept = new ObservableCollection<ItemReiceptVm>();

        public ObservableCollection<ItemReiceptVm> ListReicept { get { return _ListReicept; } }

        ObservableCollection<Parametr> _ListReicept2 = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> ListReicept2 { get { return _ListReicept2; } }

        //ПАРАМЕТРЫ ПЕРЕМЕЩЕНИЙ ТЕЛЕГИ
        #region ВКЛАДКИ
        public ObservableCollection<Parametr> ListParamLonCar { get { return _ListParamLonCar; } }
        ObservableCollection<Parametr> _ListParamLonCar = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> ListParamReciver { get { return _ListParamReciver; } }
        ObservableCollection<Parametr> _ListParamReciver = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> ListParamGenerator { get { return _ListParamGenerator; } }
        ObservableCollection<Parametr> _ListParamGenerator = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> ListParamOther { get { return _ListParamOther; } }
        ObservableCollection<Parametr> _ListParamOther = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> ListSetting
        {
            get
            {
                return _ListSetting;
            }
            set
            {
                _ListSetting = value;
                OnPropertyChanged("ListSetting");
            }
        }
        ObservableCollection<Parametr> _ListSetting = new ObservableCollection<Parametr>();
        #endregion
        #region ВЫБОР И РЕДАКТИРОВАНИЕ НАЗВАНИЯ  РЕЦЕПТА
        private ItemReiceptVm _ListReiceptSelected;
        public ItemReiceptVm ListReiceptSelected
        {
            get { return _ListReiceptSelected; }
            set
            {
                if ((null != value) && (_ListReiceptSelected != value))
                {
                    _ListReiceptSelected = value;                    
                    _ListReiceptEdit = _ListReiceptSelected;
                    _ListParametrEdit = null;
                    OnPropertyChanged("ListParametrEdit");
                    ListReiceptEditName = _ListReiceptSelected.Name;
                    OnPropertyChanged("ListReiceptEditName");
                    UpdatParamTable(ListReiceptEdit.Id);
                    OnPropertyChanged("ListReiceptSelected");
                }
            }
        }
        private string _ListReiceptEditName;
        public string ListReiceptEditName
        {
            get { return _ListReiceptEditName; }
            set
            {
                if ((null != value) && (_ListReiceptEditName != value))
                {
                    _ListReiceptEditName = value;
                    OnPropertyChanged("ListReiceptEditName");

                }
            }
        }

        private RelayCommand _RenameRecept;
        public RelayCommand RenameRecept
        {
            get
            {
                return _DeleteRecept ?? (_SelectComand = new RelayCommand(obj => RenameRecept_Execute(), obj2 => RenameRecept_CanExecute()));
            }
        }
        void RenameRecept_Execute()
        {
            using (var Recept = new Recept())
            {
                Recept.Rename_ReceptById(_ListReiceptSelected.Id, ListReiceptEditName);
                _ListReicept = GetRecept();
                OnPropertyChanged(nameof(ListReicept));
            }
        }
        bool RenameRecept_CanExecute()
        {
            return _AuthorizedUserаflag;
        }

        private ItemReiceptVm _ListReiceptEdit;
        public ItemReiceptVm ListReiceptEdit
        {
            get { return _ListReiceptEdit; }
            set
            {
                if ((null != value) && (_ListReiceptEdit != value))
                {
                    _ListReiceptEdit = value;
                    OnPropertyChanged("ListReiceptEdit");

                }
            }
        }
        #endregion
        #region  Квадратные индикаторы 
        private SolidColorBrush _FillOn = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE55300"));
        private SolidColorBrush _FillOff = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF2B2B2B"));
        private SolidColorBrush _FillWite = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

        private SolidColorBrush _fillpower;
        private SolidColorBrush _fillhydraulic;
        private SolidColorBrush _fillmanuauto;
        private SolidColorBrush _fillplcconect;
        private SolidColorBrush _fillPos_Ok_X1;
        private SolidColorBrush _fillPos_Ok_X2;

        public SolidColorBrush fillPos_Ok_X1
        {
            get
            {
                return _fillPos_Ok_X1;
            }
            set
            {
                _fillPos_Ok_X1 = value;
                OnPropertyChanged(nameof(fillPos_Ok_X1));
            }
        }
        public SolidColorBrush fillPos_Ok_X2
        {
            get
            {
                return _fillPos_Ok_X2;
            }
            set
            {
                _fillPos_Ok_X2 = value;
                OnPropertyChanged(nameof(fillPos_Ok_X2));
            }
        }
        public SolidColorBrush Fillpower
        {
            get
            {
                return _fillpower;
            }
            set
            {
                _fillpower = value;
                OnPropertyChanged(nameof(Fillpower));
            }
        }
        public SolidColorBrush Fillhydraulic
        {
            get
            {
                return _fillhydraulic;
            }
            set
            {
                _fillhydraulic = value;
                OnPropertyChanged(nameof(Fillhydraulic));
            }
        }
        public SolidColorBrush Fillmanuauto
        {
            get
            {
                return _fillmanuauto;
            }
            set
            {
                _fillmanuauto = value;
                OnPropertyChanged(nameof(Fillmanuauto));
            }
        }
        public SolidColorBrush Fillplcconect
        {
            get
            {
                return _fillplcconect;
            }
            set
            {
                _fillplcconect = value;
                OnPropertyChanged(nameof(Fillplcconect));
            }
        }

        public void FillRectang(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            if (PLCdescription.Id == 1)
            {
                if (PLCValue.BoolValue == true)
                {
                    Fillpower = _FillOn;
                }
                else
                {
                    Fillpower = _FillOff;
                }
            }

            if (PLCdescription.Id == 2)
            {
                if (PLCValue.BoolValue == true)
                {
                    Fillhydraulic = _FillOn;
                }
                else
                {
                    Fillhydraulic = _FillOff;
                }
            }

            if (PLCdescription.Id == 3)
            {
                if (PLCValue.BoolValue == true)
                {
                    Fillmanuauto = _FillOn;
                }
                else
                {
                    Fillmanuauto = _FillOff;
                }
            }
            if (PLCdescription.Id == 4)
            {
                if (PLCValue.BoolValue == true)
                {
                    Fillplcconect = _FillOn;
                }
                else
                {
                    Fillplcconect = _FillOff;
                }
            }
            if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.Pos_Ok_X1").Id)
            {
                if (PLCValue.BoolValue == true)
                {
                    fillPos_Ok_X1 = _FillOn;
                }
                else
                {
                    fillPos_Ok_X1 = _FillWite;
                }
            }
            if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.Pos_Ok_X2").Id)
            {
                if (PLCValue.BoolValue == true)
                {
                    fillPos_Ok_X2 = _FillOn;
                }
                else
                {
                    fillPos_Ok_X2 = _FillWite;
                }
            }


        }
        #endregion
        #region РЕДАКТИРОВАНИЕ ПАРАМЕТРОВ РЕЦЕПТОВ
        private Parametr _ListParametrEdit;
        public Parametr ListParametrEdit
        {
            get { return _ListParametrEdit; }
            set
            {
                if ((null != value) && (_ListParametrEdit != value))
                {
                    _ListParametrEdit = value;
                    OnPropertyChanged("ListParametrEdit");
                }
            }
        }

        private int _ListParametrEdittext;
        public int ListParametrEdittext
        {
            get { return _ListParametrEdittext; }
            set
            {
                if (_ListParametrEdittext != value)
                {
                    _ListParametrEdittext = value;
                    OnPropertyChanged("ListParametrEdittext");
                }
            }
        }
        private bool _ListParametrEditRecieptBoolValue;
        public bool ListParametrEditRecieptBoolValue
        {
            get { return _ListParametrEditRecieptBoolValue; }
            set
            {
                if (_ListParametrEditRecieptBoolValue != value)
                {
                    _ListParametrEditRecieptBoolValue = value;
                    OnPropertyChanged("ListParametrEditRecieptBoolValue");
                }
            }
        }
      
        private RelayCommand _ParametrEdit;
        public RelayCommand ParametrEdit
        {
            get
            {
                return _ParametrEdit ??
                 (_ParametrEdit = new RelayCommand(obj => ParametrEdit_Execute(), obj2 => ParametrEdit_CanExecute()));
            }
        }
        void ParametrEdit_Execute()
        {
            if (ListParametrEdit != null)
            {
                if (ListParametrEdit._PLCdescription._type == TypeCode.Boolean)
                {
                    using (var Recept = new Recept())
                    {
                        Recept.ChangeValue_ReceptById(ListParametrEdit.Id, ListParametrEditRecieptBoolValue);
                        UpdatParamTable(ListReiceptEdit.Id);
                        OnPropertyChanged(nameof(ListReicept));
                        _ListParametrEdit.RecieptValue = _ListParametrEdittext;
                        OnPropertyChanged("ListParametrEdit");
                    }

                }
                if (ListParametrEdit._PLCdescription._type == TypeCode.Int32)
                {
                    using (var Recept = new Recept())
                    {
                        Recept.ChangeValue_ReceptById(ListParametrEdit.Id, _ListParametrEdittext);
                        UpdatParamTable(ListReiceptEdit.Id);
                        OnPropertyChanged(nameof(ListReicept));
                        _ListParametrEdit.RecieptValue = _ListParametrEdittext;
                        OnPropertyChanged("ListParametrEdit");
                    }
                }
            }
        }
        bool ParametrEdit_CanExecute()
        {
            return _AuthorizedUserаflag;
        }

        private RelayCommand _DeleteRecept;
        public RelayCommand DeleteRecept
        {
            get
            {
                return _DeleteRecept ?? (_SelectComand = new RelayCommand(obj => DeleteRecept_Execute(), obj2 => DeleteRecept_CanExecute()));
            }
        }
        void DeleteRecept_Execute()
        {
            if (_ListReiceptSelected != null)
            {
                var Result = MessageBox.Show("УВЕРЕННЫ! ЧТО ХОТИТЕ УДАЛИТЬ ДАННЫЙ РЕЦЕПТ", "УДАЛЕНИЕ РЕЦЕПТА",
                  MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (Result == MessageBoxResult.Yes)
                {

                    using (var Recept = new Recept())
                    {
                        Recept.Delite_ReceptById(_ListReiceptSelected.Id);
                        _ListReicept = GetRecept();
                        _ListReiceptSelected = null;
                        OnPropertyChanged(nameof(ListReicept));
                        TabSelectSetNull();
                        ParamEditSetZero();
                    }

                }
                else
                {
                    //MessageBox.Show("Нет");
                }
            }
        }
        bool DeleteRecept_CanExecute()
        {
            return _AuthorizedUserаflag;
        }
        private void TabSelectSetNull()
        {
            _ListReiceptSelected = null;
            OnPropertyChanged(nameof(ListReiceptSelected));
        }
        #endregion
        #region ЗАГРУЗКА РЕЦЕПТА В ПЛК
        private RelayCommand _DownLoadRecipeinPLCComand;
        public RelayCommand DownLoadRecipeinPLCComand
        {
            get
            {
                return _DownLoadRecipeinPLCComand ??
                 (_DownLoadRecipeinPLCComand = new RelayCommand(obj => DownLoadRecipeinPLCComand_Execute(), obj2 => DownLoadRecipeinPLCComand_CanExecute()));
            }
        }
        void DownLoadRecipeinPLCComand_Execute()
        {
            //if (ListReiceptSelected != null) {
            //    using (var Recept = new Recept())
            //    {

            //        foreach (var Param in Recept.Get_ReceptByRecipeId(ListReiceptSelected.Id))
            //        {
            //            if (Param.ValueType == TypeCode.Boolean)
            //            {
            //                PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionById(Param.PCLObject_Id)).Write(Param.BoolValue);
            //            }
            //            if (Param.ValueType == TypeCode.Int32)
            //            {
            //                PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionById(Param.PCLObject_Id)).Write(Param.Value);
            //            }
            //        }
            //    }
            //}

        }
        bool DownLoadRecipeinPLCComand_CanExecute()
        {
            return _AuthorizedUserаflag;
        }
        #endregion
        #region  ВЫБОР ВКЛАДОК
        private Parametr _ListParamGeneratorSelected;
        public Parametr ListParamGeneratorSelected
        {
            get { return _ListParamGeneratorSelected; }
            set
            {
                if ((null != value) && (_ListParamGeneratorSelected != value))
                {
                    _ListParamReciverSelected = value;
                    ParamEditSetSelect(value);
                    OnPropertyChanged("ListParamReciverSelected");   
                }
            }
        }
        private Parametr _ListParamReciverSelected;
        public Parametr ListParamReciverSelected
        {
            get { return _ListParamReciverSelected; }
            set
            {
                if ((null != value) && (_ListParamReciverSelected != value))
                {
                    _ListParamGeneratorSelected = value;
                    ParamEditSetSelect(value);
                    OnPropertyChanged("ListParamGeneratorSelected");
                }
            }
        }
        private Parametr _ListParamLonCarSelected;
        public Parametr ListParamLonCarSelected
        {
            get { return _ListParamLonCarSelected; }
            set
            {
                if ((null != value) && (_ListParamLonCarSelected != value))
                {
                    _ListParamLonCarSelected = value;
                    ParamEditSetSelect(value);
                    OnPropertyChanged("ListParamLonCarSelected");
                }
            }
        }
        private Parametr _ParamTabSelect;
        public Parametr ParamTabSelect
        {
            get { return _ParamTabSelect; }
            set
            {
                if ((null != value) && (_ParamTabSelect != value))
                {
                    _ParamTabSelect = value;
                    ParamEditSetZero();
                    OnPropertyChanged("ParamTabSelect");                   
                }
            }
        }
        private void ParamEditSetZero()
        {
            _ListParametrEdit = null;           
            OnPropertyChanged("ListParametrEdit");
            ListParametrEdittext = 0;
            OnPropertyChanged("ListParametrEdittext");
        }
        private void ParamEditSetSelect(Parametr Select)
        {            
            _ListParametrEdit = Select;
            _ListParametrEdittext = Select.RecieptValue;
            _ListParametrEditRecieptBoolValue = Select.RecieptBoolValue;
            OnPropertyChanged("ListParametrEditRecieptBoolValue");
            OnPropertyChanged("ListParametrEdittext");
            OnPropertyChanged("ListParametrEdit");  
        }
  
        private Parametr _ListParamOtherSelected;
        public Parametr ListParamOtherSelected
        {
            get { return _ListParamOtherSelected; }
            set
            {
                if ((null != value) && (_ListParamOtherSelected != value))
                {
                    _ListParamOtherSelected = value;
                    ParamEditSetSelect(value);
                    OnPropertyChanged("ListParamOtherSelected");                
                }
            }
        }
        private int _SelectedTab;
        public int SelectedTab
        {
            get { return _SelectedTab; }
            set
            {
                _SelectedTab = value;
                ParamEditSetZero();
                OnPropertyChanged("SelectedTab");               
            }
        }
        #endregion  
        private RelayCommand _SelectComand;
        public RelayCommand SelectComand
        {
            get
            {
                return _SelectComand ?? (_SelectComand = new RelayCommand(obj => SelectComand_Execute(), obj2 => SelectComand_CanExecute()));
            }
        }
        void SelectComand_Execute()
        {
            _ListParametrEdit = null;
            OnPropertyChanged("ListParametrEdit");
        }
        bool SelectComand_CanExecute()
        {
            return true;
        }
        #region НОВЫЙ РЕЦЕПТ
        private RelayCommand _CreateRecept;
        public RelayCommand CreateRecept
        {
            get
            {
                return _CreateRecept ?? (_SelectComand = new RelayCommand(obj => CreateRecept_Execute(), obj2 => CreateRecept_CanExecute()));
            }
        }
        void CreateRecept_Execute()
        {
            var Result = MessageBox.Show("УВЕРЕННЫ! ЧТО ХОТИТЕ СОЗДАТЬ НОВЫЙ РЕЦЕПТ", "НОВЫЙ РЕЦЕПТ",
             MessageBoxButton.YesNo, MessageBoxImage.Question);
            //DialogWindow DialogWindow = new DialogWindow();
            if (Result == MessageBoxResult.Yes)
            {        
                using (var Recept = new Recept())
                {
                    if (_ListReiceptSelected!=null)
                    {
                        Recept.CopyRecept(_ListReiceptSelected.Id); 
                    }
                    else
                    {
                        Recept.Add_Recept();                        
                    }
                    _ListReicept = GetRecept();
                    OnPropertyChanged(nameof(ListReicept));
                }
            }           
        }
        bool CreateRecept_CanExecute()
        {
            return _AuthorizedUserаflag;
        }
        #endregion
        #region  ВКЛАДКИ РЕЦЕПТОВ
        private ObservableCollection<ItemReiceptVm> GetRecept()
        {
            var ListItemReiceptVm = new ObservableCollection<ItemReiceptVm>();
            using (var db = new DateContext())
            {
                try
                {
                    if (db.Reciepts.OrderBy(t => t.Id).Count() != 0)
                    {
                        foreach (var Reciept in db.Reciepts.OrderBy(t => t.Id))
                        {
                            ListItemReiceptVm.Add(new ItemReiceptVm(Reciept.Id, Reciept.ReceptName));
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return ListItemReiceptVm;
        }

        private ObservableCollection<ItemReiceptVm> GetReceptBy()
        {
            var ListItemReiceptVm = new ObservableCollection<ItemReiceptVm>();
            using (var db = new DateContext())
            {
                try
                {
                    if (db.Reciepts.OrderBy(t => t.Id).Count() != 0)
                    {
                        foreach (var Reciept in db.Reciepts.OrderBy(t => t.Id))
                        {
                            ListItemReiceptVm.Add(new ItemReiceptVm(Reciept.Id, Reciept.ReceptName));
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return ListItemReiceptVm;
        }
        private ObservableCollection<Parametr> Get_ReceptByParamTypeByValueType(int id, ParamType ParamType, TypeCode ValueType)
        {
            var ListItemRecepParam = new ObservableCollection<Parametr>();
            using (  var Recept = new Recept())
                foreach (var p in Recept.Get_ReceptByParamType( id,ParamType))
                {
                   var flagBoolValue = ((p.ValueType == TypeCode.Boolean) ? true: false);
                   var BoolValue = ((p.ValueType == TypeCode.Boolean) ? p.BoolValue :false);
                    var PLCdescription = DescriptionFactory.GetDescriptionById(p.PCLObject_Id);
                    ListItemRecepParam.Add(new Parametr(p.Id,p.Name,  0, p.Value, PLCdescription,flagBoolValue, false, BoolValue));
                }
            return ListItemRecepParam;
        }

        public ObservableCollection<Parametr> ReconfigurationList { get { return _ReconfigurationList; } }
        ObservableCollection<Parametr> _ReconfigurationList = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> LongWayList { get { return _LongWayList; } }
        ObservableCollection<Parametr> _LongWayList = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> ShotWayList { get { return _ShotWayList; } }
        ObservableCollection<Parametr> _ShotWayList = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> Rotation180List { get { return _Rotation180List; } }
        ObservableCollection<Parametr> _Rotation180List = new ObservableCollection<Parametr>();

        public ObservableCollection<Parametr> RotationList { get { return _RotationList; } }
        ObservableCollection<Parametr> _RotationList = new ObservableCollection<Parametr>();

        private void UpdatParamTable(int id)
        {
            _ReconfigurationList= Get_ReceptByParamTypeByValueType(id, ParamType.Reconfiguration, TypeCode.Int32);
            _LongWayList = Get_ReceptByParamTypeByValueType(id, ParamType.ParamlonCarLongWay, TypeCode.Int32);
            _ShotWayList = Get_ReceptByParamTypeByValueType(id, ParamType.ParamlonCarShotWay, TypeCode.Int32);
            _Rotation180List = Get_ReceptByParamTypeByValueType(id, ParamType.Rotation180, TypeCode.Int32);
            _RotationList = Get_ReceptByParamTypeByValueType(id, ParamType.Rotation, TypeCode.Int32);

            OnPropertyChanged("ReconfigurationList");
            OnPropertyChanged("LongWayList");
            OnPropertyChanged("ShotWayList");
            OnPropertyChanged("Rotation180List");
            OnPropertyChanged("RotationList");
  
        }
        private void ReconfigurationListCange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            ListParamLonCarChange(PLCdescription, PLCValue);
            try
            {
                foreach (var ParamSetting in _ReconfigurationList)
                {
                    if (ParamSetting._PLCdescription.Id == PLCdescription.Id)
                    {
                        if (PLCdescription._type == TypeCode.Boolean)
                        {
                            ParamSetting.PLCBoolValue = PLCValue.BoolValue;
                        }
                        ParamSetting.PLCValue = PLCValue.IntValue;
                    }
                }
                OnPropertyChanged("ReconfigurationList ");
            }
            catch (Exception ex)
            {
                Logger.Error("_ReconfigurationList " + ex);
            }
        }
        private void LongWayListChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {

            try
            {
                foreach (var ParamSetting in _LongWayList)
                {
                    if (ParamSetting._PLCdescription.Id == PLCdescription.Id)
                    {
                        if (PLCdescription._type == TypeCode.Boolean)
                        {
                            ParamSetting.PLCBoolValue = PLCValue.BoolValue;
                        }
                        ParamSetting.PLCValue = PLCValue.IntValue;
                    }
                }
                OnPropertyChanged("_LongWayList ");
            }
            catch (Exception ex)
            {
                Logger.Error("_LongWayList " + ex);
            }
        }
        private void ShotWayListChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {

            try
            {
                foreach (var ParamSetting in _ShotWayList)
                {
                    if (ParamSetting._PLCdescription.Id == PLCdescription.Id)
                    {
                        if (PLCdescription._type == TypeCode.Boolean)
                        {
                            ParamSetting.PLCBoolValue = PLCValue.BoolValue;
                        }
                        ParamSetting.PLCValue = PLCValue.IntValue;
                    }
                }
                OnPropertyChanged("_ShotWayList ");
            }
            catch (Exception ex)
            {
                Logger.Error("_ShotWayList " + ex);
            }
        }
        private void Rotation180ListChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            try
            {
                foreach (var ParamSetting in _Rotation180List)
                {
                    if (ParamSetting._PLCdescription.Id == PLCdescription.Id)
                    {
                        if (PLCdescription._type == TypeCode.Boolean)
                        {
                            ParamSetting.PLCBoolValue = PLCValue.BoolValue;
                        }
                        ParamSetting.PLCValue = PLCValue.IntValue;
                    }
                }
                OnPropertyChanged("ListParamSetting");
            }
            catch (Exception ex)
            {
                Logger.Error("PLCSettingListChange" + ex);
            }
        }
        private void RotationListChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            try
            {
                foreach (var ParamSetting in _RotationList)
                {
                    if (ParamSetting._PLCdescription.Id == PLCdescription.Id)
                    {
                        if (PLCdescription._type == TypeCode.Boolean)
                        {
                            ParamSetting.PLCBoolValue = PLCValue.BoolValue;
                        }
                        ParamSetting.PLCValue = PLCValue.IntValue;
                    }
                }
                OnPropertyChanged("RotationList");
            }
            catch (Exception ex)
            {
                Logger.Error("_RotationList" + ex);
            }
        }
        private void ListParamLonCarChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            try
            {
                foreach (var ParamSetting in _ListParamLonCar)
                {
                    if (ParamSetting._PLCdescription.Id == PLCdescription.Id)
                    {
                        if (PLCdescription._type == TypeCode.Boolean)
                        {
                            ParamSetting.FlagboolParam = true;
                            ParamSetting.PLCBoolValue = PLCValue.BoolValue;
                        }
                        ParamSetting.PLCValue = PLCValue.IntValue;
                    }
                }
                OnPropertyChanged("ListParamLonCar");
            }
            catch (Exception ex)
            {
                Logger.Error("PLCSettingListChange" + ex);
            }
        }
        public ObservableCollection<Parametr> RekonfigurationSettings { get { return _ListParamOther; } }
        ObservableCollection<Parametr> _RekonfigurationSettings = new ObservableCollection<Parametr>();
        private void RekonfigurationSettingsChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            try
            {
                foreach (var ParamSetting in _RekonfigurationSettings)
                {
                    if (ParamSetting._PLCdescription.Id == PLCdescription.Id)
                    {
                        if (PLCdescription._type == TypeCode.Boolean)
                        {
                            ParamSetting.FlagboolParam = true;
                            ParamSetting.PLCBoolValue = PLCValue.BoolValue;
                        }
                        ParamSetting.PLCValue = PLCValue.IntValue;
                    }
                }
                OnPropertyChanged("RekonfigurationSettings");
            }
            catch (Exception ex)
            {
                Logger.Error("RekonfigurationSettings" + ex);
            }
        }
        #endregion  
        #region  вкладка авторизация
        private bool _locksetting = false;
        private bool _lockunlock = false;
        private string _Login;
        private string _HashPasswordtext = "";

        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string HashPasswordtext
        {
            get
            {
                return _HashPasswordtext;
            }
            set
            {
                _HashPasswordtext = value;
                OnPropertyChanged(nameof(HashPasswordtext));

            }
        }

        public bool Locksetting
        {
            get
            {
                return _locksetting;
            }
            set
            {
                _locksetting = value;
                OnPropertyChanged(nameof(Locksetting));
            }
        }

        private RelayCommand _lock;
        public RelayCommand Lock
        {
            get
            {
                return _lock ??
                 (_lock = new RelayCommand(obj => lockExecute(), obj2 => LocCanExecute()));
            }
        }
        void lockExecute()
        {
            if (_locksetting)
            {
                Locksetting = false;
            }
            else
            {
                Locksetting = true;
            }

        }
        bool LocCanExecute()
        {
            return _locksetting;

        }
        
        private void Pass(string st)
        {
            if (_HashPasswordtext.Count() < 9)
            {
                Login = Login + "X";
                _HashPasswordtext = _HashPasswordtext + st;
            }

        }
        private RelayCommand _Command_1;
        public RelayCommand Command_1
        {
            get
            {
                return _Command_1 ??
                 (_Command_1 = new RelayCommand(obj => Command_1_Execute(), obj2 => Command_1_CanExecute()));
            }
        }
        void Command_1_Execute()
        {
            Pass("1");
        }
        bool Command_1_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_2;
        public RelayCommand Command_2
        {
            get
            {
                return _Command_2 ??
                 (_Command_2 = new RelayCommand(obj => Command_2_Execute(), obj2 => Command_2_CanExecute()));
            }
        }
        void Command_2_Execute()
        {
            Pass("2");
        }
        bool Command_2_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_3;
        public RelayCommand Command_3
        {
            get
            {
                return _Command_3 ??
                 (_Command_3 = new RelayCommand(obj => Command_3_Execute(), obj2 => Command_3_CanExecute()));
            }
        }
        void Command_3_Execute()
        {
            Pass("3");
        }
        bool Command_3_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_4;
        public RelayCommand Command_4
        {
            get
            {
                return _Command_4 ??
                 (_Command_4 = new RelayCommand(obj => Command_4_Execute(), obj2 => Command_4_CanExecute()));
            }
        }
        void Command_4_Execute()
        {
            Pass("4");
        }
        bool Command_4_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_5;
        public RelayCommand Command_5
        {
            get
            {
                return _Command_5 ??
                 (_Command_5 = new RelayCommand(obj => Command_5_Execute(), obj2 => Command_5_CanExecute()));
            }
        }
        void Command_5_Execute()
        {
            Pass("5");
        }
        bool Command_5_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_6;
        public RelayCommand Command_6
        {
            get
            {
                return _Command_6 ??
                 (_Command_6 = new RelayCommand(obj => Command_6_Execute(), obj2 => Command_6_CanExecute()));
            }
        }
        void Command_6_Execute()
        {
            Pass("6");
        }
        bool Command_6_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_7;
        public RelayCommand Command_7
        {
            get
            {
                return _Command_7 ??
                 (_Command_7 = new RelayCommand(obj => Command_7_Execute(), obj2 => Command_7_CanExecute()));
            }
        }
        void Command_7_Execute()
        {
            Pass("7");
        }
        bool Command_7_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_8;
        public RelayCommand Command_8
        {
            get
            {
                return _Command_8 ??
                 (_Command_8 = new RelayCommand(obj => Command_8_Execute(), obj2 => Command_8_CanExecute()));
            }
        }
        void Command_8_Execute()
        {
            Pass("8");
        }

        bool Command_8_CanExecute()
        {
            return true;
        }
        private RelayCommand _Command_9;
        public RelayCommand Command_9
        {
            get
            {
                return _Command_9 ??
                 (_Command_9 = new RelayCommand(obj => Command_9_Execute(), obj2 => Command_9_CanExecute()));
            }
        }
        void Command_9_Execute()
        {
            Pass("9");
        }
        bool Command_9_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_0;
        public RelayCommand Command_0
        {
            get
            {
                return _Command_0 ??
                 (_Command_0 = new RelayCommand(obj => Command_0_Execute(), obj2 => Command_0_CanExecute()));
            }
        }
        void Command_0_Execute()
        {
            Pass("0");
        }
        bool Command_0_CanExecute()
        {
            return true;
        }

        private RelayCommand _Command_undo;
        public RelayCommand Command_undo
        {
            get
            {
                return _Command_undo ??
                 (_Command_undo = new RelayCommand(obj => Command_undo_Execute(), obj2 => Command_undo_CanExecute()));
            }
        }
        void Command_undo_Execute()
        {
            Login = "";
            _HashPasswordtext = "";
        }
        bool Command_undo_CanExecute()
        {
            return true;
        }
        #endregion

        #region  Основное окно
        private int _ActualPosPos1608X1;
        public int ActualPosPos1608X1
        {
            get { return _ActualPosPos1608X1; }
            set
            {
                _ActualPosPos1608X1 = value;
                OnPropertyChanged("ActualPosPos1608X1");
            }
        }

        private int _ActualPosPos1608X2;
        public int ActualPosPos1608X2
        {
            get { return _ActualPosPos1608X2; }
            set
            {
                _ActualPosPos1608X2 = value;
                OnPropertyChanged("ActualPosPos1608X2");
            }
        }

        private int _ActualDistance_XrayTube_Pipe;
        public int ActualDistance_XrayTube_Pipe
        {
            get { return _ActualDistance_XrayTube_Pipe; }
            set
            {
                _ActualDistance_XrayTube_Pipe = value;
                OnPropertyChanged("ActualDistance_XrayTube_Pipe");
            }
        }

        private int _ActualDistance_Detector_Pipe;
        public int ActualDistance_Detector_Pipe
        {
            get { return _ActualDistance_Detector_Pipe; }
            set
            {
                _ActualDistance_Detector_Pipe = value;
                OnPropertyChanged("ActualDistance_Detector_Pipe");
            }
        }

        private int _ActualRearFistPos;
        public int ActualRearFistPos
        {
            get { return _ActualRearFistPos; }
            set
            {
                _ActualRearFistPos = value;
                OnPropertyChanged("ActualRearFistPos");
            }
        }

        private void ActualParamChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            try
            {
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.ActualPosPos1608X1").Id)
                {
                    ActualPosPos1608X1 = PLCValue.IntValue;
                    OnPropertyChanged("ActualPosPos1608X1");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.ActualPosPos1608X2").Id)
                {
                    ActualPosPos1608X2 = PLCValue.IntValue;
                    OnPropertyChanged("ActualPosPos1608X2");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.ActualDistance_XrayTube_Pipe").Id)
                {
                    ActualDistance_XrayTube_Pipe = PLCValue.IntValue;
                    OnPropertyChanged("ActualDistance_XrayTube_Pipe");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.ActualDistance_Detector_Pipe").Id)
                {
                    ActualDistance_Detector_Pipe = PLCValue.IntValue;
                    OnPropertyChanged("ActualDistance_Detector_Pipe");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.ActualRearFistPos").Id)
                {
                    ActualRearFistPos = PLCValue.IntValue;
                    OnPropertyChanged("ActualRearFistPos");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_WeintekRetain.ParamTagetPos1608X1.TargetPosition").Id)
                {
                    ParamTagetPos1608X1 = PLCValue.IntValue;
                    OnPropertyChanged("ParamTagetPos1608X1");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_WeintekRetain.ParamTagetPos1608X2.TargetPosition").Id)
                {
                    ParamTagetPos1608X2 = PLCValue.IntValue;
                    OnPropertyChanged("ParamTagetPos1608X2");
                }

            }
            catch (Exception ex)
            {
                Logger.Error("ActualParamChange " + ex);
            }
        }

        private bool _Error;
        public bool Error
        {
            get { return _Error; }
            set
            {
                _Error = value;
                OnPropertyChanged("Error");
            }
        }
  
        private bool _RotationOn;
        public bool RotationOn
        {
            get { return _RotationOn; }
            set
            {
                _RotationOn = value;

                //PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionByName(".HMI_Weintek.RotationOn")).Write(value);
                OnPropertyChanged("RotationOn");
            }
        }
 
        private bool _StepSizeMode;
        public bool StepSizeMode
        {
            get { return _StepSizeMode; }
            set
            {
                _StepSizeMode = value;
                //PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionByName(".HMI_Weintek.StepSizeMode")).Write(value);
                OnPropertyChanged("StepSizeMode");
            }
        }
  
        private bool _TwoWeldSeam;
        public bool TwoWeldSeam
        {
            get { return _TwoWeldSeam; }
            set
            {
                _TwoWeldSeam = value;
                //PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionByName(".HMI_Weintek.TwoWeldSeam")).Write(value);
                OnPropertyChanged("TwoWeldSeam");
            }
        }
        
     
        private bool _Reconfiguration;
        public bool Reconfiguration
        {
            get { return _Reconfiguration; }
            set
            {
                _Reconfiguration = value;
                //PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionByName(".HMI_Weintek.Reconfiguration")).Write(value);
                OnPropertyChanged("Reconfiguration");
            }
        }
      
        private bool _ReconfigurationApply;
        public bool ReconfigurationApply
        {
            get { return _ReconfigurationApply; }
            set
            {
                _ReconfigurationApply = value;
                //PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionByName(".HMI_Weintek.ReconfigurationApply")).Write(value);                
                OnPropertyChanged("ReconfigurationApply");
            }
        }
      
        
        private bool _Tranzit_16100_1611_1701;
        public bool Tranzit_16100_1611_1701
        {
            get { return _Tranzit_16100_1611_1701; }
            set
            {
                _Tranzit_16100_1611_1701 = value;
                //PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionByName(".HMI_Weintek.Tranzit_16100_1611_1701")).Write(value);               
                OnPropertyChanged("Tranzit_16100_1611_1701");
            }
        }
        
        private void MainWindowParamChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            try
            {
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.Error").Id)
                {
                    _Error = PLCValue.BoolValue;
                    OnPropertyChanged("Error");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.RotationOn").Id)
                {
                    _RotationOn = PLCValue.BoolValue;
                    OnPropertyChanged("RotationOn");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.StepSizeMode").Id)
                {
                    _StepSizeMode = PLCValue.BoolValue;
                    OnPropertyChanged("StepSizeMode");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.TwoWeldSeam").Id)
                {
                    _TwoWeldSeam = PLCValue.BoolValue;
                    OnPropertyChanged("TwoWeldSeam");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.Reconfiguration").Id)
                {
                    _Reconfiguration = PLCValue.BoolValue;
                    OnPropertyChanged("Reconfiguration");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.ReconfigurationApply").Id)
                {
                    _ReconfigurationApply = PLCValue.BoolValue;
                    OnPropertyChanged("ReconfigurationApply");
                }
                if (PLCdescription.Id == DescriptionFactory.GetDescriptionByName(".HMI_Weintek.Tranzit_16100_1611_1701").Id)
                {
                    _Tranzit_16100_1611_1701 = PLCValue.BoolValue;
                    OnPropertyChanged("Tranzit_16100_1611_1701");
                }   
                


            }
            catch (Exception ex)
            {
                Logger.Error("ActualDistance_XrayTube_Pipe" + ex);
            }
        }
        #endregion
        #region  ПЕРЕНАЛАДКА
        private int _ParamTagetPos1608X1;
        public int ParamTagetPos1608X1
        {
            get { return _ParamTagetPos1608X1; }
            set
            {
                _ParamTagetPos1608X1 = value;
                OnPropertyChanged("ParamTagetPos1608X1");
            }
        }
 
        private int _ParamTagetPos1608X2;
        public int ParamTagetPos1608X2
        {
            get { return _ParamTagetPos1608X2; }
            set
            {
                _ParamTagetPos1608X2 = value;
                OnPropertyChanged("ParamTagetPos1608X2");
            }
        }
       
        private RelayCommand _ReconfigApplyComand;
        public RelayCommand ReconfigApplyComand
        {
            get
            {
                return _ReconfigApplyComand ??
                 (_ReconfigApplyComand = new RelayCommand(obj => ReconfigApplyComand_Execute(), obj2 => ReconfigApplyComand_CanExecute()));
            }
        }
        void ReconfigApplyComand_Execute()
        {
            PLCFactory.CreatePlcWriteObject(DescriptionFactory.GetDescriptionByName(".HMI_Weintek.ReconfigurationApply")).Write(true);
        }
        bool ReconfigApplyComand_CanExecute()
        {
            return _AuthorizedUserаflag;
        }
        #endregion

        #region РЕДАКТИРОВАНИЕ НАСТРОЕК
        private Parametr _ListSettingSelected;
        public Parametr ListSettingSelected
        {
            get { return _ListSettingSelected; }
            set
            {
                if ((null != value) && (_ListSettingSelected != value))
                {

                    _ListSettingSelected = value;
                    SettingEditSetSelect(value);

                    OnPropertyChanged("ListSettingSelected");
                    //    _ListParametrEdit = _ListParamOtherSelected;
                    //    OnPropertyChanged("ListParametrEdit");
                }
            }
        }
        private int _ListSettingSelectedText;
        public int ListSettingSelectedText
        {
            get { return _ListSettingSelectedText; }
            set
            {
                if ((null != value) && (_ListSettingSelectedText != value))
                {

                    _ListSettingSelectedText = value;

                    OnPropertyChanged("ListSettingSelectedText");
                    //    _ListParametrEdit = _ListParamOtherSelected;
                    //    OnPropertyChanged("ListParametrEdit");
                }
            }
        }
        private bool _ListSettingSelectedBool;
        public bool ListSettingSelectedBool
        {
            get { return _ListSettingSelectedBool; }
            set
            {
                if ((null != value) && (_ListSettingSelectedBool != value))
                {

                    _ListSettingSelectedBool = value;

                    OnPropertyChanged("ListSettingSelectedBool");
                    //    _ListParametrEdit = _ListParamOtherSelected;
                    //    OnPropertyChanged("ListParametrEdit");
                }
            }
        }
        private void SettingEditSetSelect(Parametr Select)
        {
            _ListSettingSelected = Select;
            _ListSettingSelectedText = Select.PLCValue;
            _ListSettingSelectedBool = Select.PLCBoolValue;
            OnPropertyChanged("ListSettingSelectedText");
            OnPropertyChanged("ListSettingSelected");
            OnPropertyChanged("ListSettingSelectedBool");
        }

        private RelayCommand _SettingEditCommand;
        public RelayCommand SettingEditCommand
        {
            get
            {
                return _SettingEditCommand ??
                 (_SettingEditCommand = new RelayCommand(obj => SettingEditCommand_Execute(), obj2 => SettingEditCommand_CanExecute()));
            }
        }
        void SettingEditCommand_Execute()
        {
            //if (_ListSettingSelected != null)
            //{
            //    if (_ListSettingSelected._PLCdescription._type == TypeCode.Int32)
            //    {
            //        _GlobalPLCObject.PLCSettingList.WritePLCValue(_ListSettingSelected._PLCdescription, new PLCValue(_ListSettingSelected._PLCdescription._type, _ListSettingSelectedText));
            //    }
            //    if (_ListSettingSelected._PLCdescription._type == TypeCode.Boolean)
            //    {
            //        _GlobalPLCObject.PLCSettingList.WritePLCValue(_ListSettingSelected._PLCdescription, new PLCValue(_ListSettingSelected._PLCdescription._type, _ListSettingSelectedBool));
            //    }
            //}
        }
        bool SettingEditCommand_CanExecute()
        {
            return _AuthorizedUserаflag;
        }

        public ObservableCollection<Parametr> ListSetting2 = new ObservableCollection<Parametr>();
        ObservableCollection<Parametr> _ListSetting2 = new ObservableCollection<Parametr>();
        private List<PLCdescription> PLCSettingList = new PLCSettingList().GetPLCdescriptionList();

        private void CreatePLCSetingList(List<PLCdescription> ListPLCdescription)
        {
            var TempListSetting = new ObservableCollection<Parametr>();
            foreach (var PLCdescription in ListPLCdescription)
            {
                var Param = new Parametr(PLCdescription.Id, PLCdescription.Label, 0, 0, PLCdescription);
                if (PLCdescription._type==TypeCode.Boolean)
                {
                    Param.FlagboolParam = true;
                };
                TempListSetting.Add(Param);
            }
            _ListSetting = TempListSetting;
            OnPropertyChanged("ListSetting");
        }
      
        private void PLCSettingListChange(PLCdescription PLCdescription, PLCValue PLCValue)
        {
            try
            {   
                foreach (var ParamSetting in _ListSetting)
                {
                    if (ParamSetting._PLCdescription.Id == PLCdescription.Id)
                    {
                        if (PLCdescription._type == TypeCode.Boolean)
                        {
                            ParamSetting.PLCBoolValue = PLCValue.BoolValue;
                        }
                        ParamSetting.PLCValue = PLCValue.IntValue;
                    }   
                }
                OnPropertyChanged("ListParamSetting");               
            }
            catch (Exception ex)
            {
                Logger.Error("PLCSettingListChange" + ex);
            }
        }
        #endregion  
       
        //Аунтификация
        #region Authentication

        private readonly IAuthenticationService _authenticationService= new AuthenticationService();

        private string _username;
        public string Username
        {
            get { return _username; }
            set {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public string AuthenticatedUser
        {
            get
            {
                if (IsAuthenticated)
                    return string.Format("Signed in as {0}. {1}",
                          Thread.CurrentPrincipal.Identity.Name,
                          Thread.CurrentPrincipal.IsInRole("Administrators") ? "You are an administrator!"
                              : "You are NOT a member of the administrators group.");

                return "Not authenticated!";
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private RelayCommand _Command_ok;
        public RelayCommand Command_ok
        {
            get
            {
                return _Command_ok ??
                 (_Command_ok = new RelayCommand(obj => Command_ok_Execute(), obj2 => Command_ok_CanExecute()));
            }
        }
        void Command_ok_Execute()
        {           
            Avtorizate();
        }
        bool Command_ok_CanExecute()
        {
            return true;
        }
        private RelayCommand _LogoutCommand;
        public RelayCommand LogoutCommand
        {
            get
            {
                return _LogoutCommand ??
                 (_LogoutCommand = new RelayCommand(obj => LogoutCommand_Execute(), obj2 => LogoutCommand_CanExecute()));
            }
        }
        void LogoutCommand_Execute()
        {
            Logout();
        }
        bool LogoutCommand_CanExecute()
        {
            return true;
        }

        private void Avtorizate()
        {
            string clearTextPassword = _HashPasswordtext;
            try
            {
                Username = "Admin";              
                User user = _authenticationService.AuthenticateUser(Username, clearTextPassword);
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("The application's default thread principal must be set to a CustomPrincipal object on startup.");
    
                customPrincipal.Identity = new CustomIdentity(user.Username, user.Email, user.Roles);
                _AuthorizedUserаflag = Thread.CurrentPrincipal.Identity.IsAuthenticated;
                Username = string.Empty;               
                _HashPasswordtext = string.Empty;
                Status = string.Empty;
                Login = string.Empty;
                OnPropertyChanged("VisibilityIsAuthenticated");
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Login failed! Please provide some valid credentials.";
            }
            catch (Exception ex)
            {
                Status = string.Format("ERROR: {0}", ex.Message);
            }
        }

        private bool CanLogin(object parameter)
        {
            return !IsAuthenticated;
        }

        private void Logout()
        {
            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            if (customPrincipal != null)
            {
                customPrincipal.Identity = new AnonymousIdentity();
                _AuthorizedUserаflag = Thread.CurrentPrincipal.Identity.IsAuthenticated;
                Status = string.Empty;
                OnPropertyChanged("VisibilityIsAuthenticated");
            }
        }

        private bool CanLogout(object parameter)
        {
            return IsAuthenticated;
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }

        public string _Datatime;
        public string Datatime
        {
            get { return _Datatime; }
            set
            {
                _Datatime = value;
                OnPropertyChanged(nameof(Datatime));
            }
        }

        private int _Tiket;
        public int Tiket
        {
            get { return _Tiket; }
            set
            {
                _Tiket = value;
                OnPropertyChanged(nameof(Tiket));
            }
        }
        private void DatatimeView()
        {           
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Task.Delay(1000).Wait();
                    Tiket--;                   
                    Datatime = DateTime.Now.ToString();                  
                    if (Tiket<0 & _AuthorizedUserаflag)
                    {
                        Logout();
                    }

                }
            });           
        }
        private RelayCommand _DoMouseMove;
        public RelayCommand DoMouseMove
        {
            get
            {
                return _DoMouseMove ??
                 (_DoMouseMove = new RelayCommand(obj => DoMouseMove_Execute(), obj2 => DoMouseMove_CanExecute()));
            }
        }
        void DoMouseMove_Execute()
        {
            int TimeTimOute = 150;
            Tiket = TimeTimOute;
        }
        bool DoMouseMove_CanExecute()
        {
            return true;
        }
   
      
        #endregion

        public ViewModel(GlobalPLCObject GlobalPLCObject)
        {
            DatatimeView();

            _ListReicept = GetRecept();
             CreatePLCSetingList( DescriptionFactory.GetSettingDescriptionList());
            _GlobalPLCObject = GlobalPLCObject;
   
            //Аунтификация
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            _GlobalPLCObject.PLCSettingList.ChangePLCValue += PLCSettingListChange;  
            //ПОДПИСКА НА СОБЫТИЯ ИЗМЕНИЕЙ В ПЛК
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += ActualParamChange;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += ListParamLonCarChange;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += ReconfigurationListCange;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += LongWayListChange;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += ShotWayListChange;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += Rotation180ListChange;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += RotationListChange;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += ListParamLonCarChange;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += FillRectang;
            _GlobalPLCObject.PLCALLObject.ChangePLCValue += MainWindowParamChange;
        }
    }
}

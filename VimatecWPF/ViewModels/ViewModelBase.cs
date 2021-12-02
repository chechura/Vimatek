using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VimatecWPF.ViewModels
{
    public class ViewModelBase:DependencyObject
    {
        //private ChildWindow _wnd = null;

        //public string Title
        //{
        //    get { return (string)GetValue(TitleProperty); }
        //    set { SetValue(TitleProperty, value); }
        //}
        //public static readonly DependencyProperty TitleProperty =
        //    DependencyProperty.Register("Title", typeof(string), typeof(ViewModelBase), new PropertyMetadata(""));

        //protected virtual void Closed()
        //{

        //}
        //public bool Close()
        //{
        //    var result = false;
        //    if(_wnd!=null)
        //    {
        //        _wnd.Close();
        //        _wnd = null;
        //        result = true;
        //    }
        //    return result;
        //}
        //protected virtual void Show(ViewModelBase viewModel)
        //{
        //    viewModel._wnd = new ChildWindow();
        //    viewModel._wnd.DataContext = viewModel;
        //    viewModel._wnd.Close += (sender, e) => Close();
        //    viewModel._wnd.Show();

        //}
    }
}

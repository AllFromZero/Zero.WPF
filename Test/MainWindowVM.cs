using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Zero.WPF.Core.MVVM;

namespace Test
{
    public partial class MainWindowVM : NavigationViewModel
    {

        protected override void OnViewLoaded(object? sender)
        {
            TotalDataCnt = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected override bool OnClosing(object? sender)
        {
            return base.OnClosing(sender);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="target"></param>
        protected override bool QueryPage()
        {
            Debug.WriteLine("导航到页面：" + TargetPage);
            return true; 
        }
    }
}

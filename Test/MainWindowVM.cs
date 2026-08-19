using System;
using System.Collections.Generic;
using System.Text;
using Zero.WPF.Core.MVVM;

namespace Test
{
    public partial class MainWindowVM : ZeroViewModel
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        protected override bool OnClosing(object? sender)
        {
            return base.OnClosing(sender);
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Zero.WPF.Core.MVVM;

namespace Test
{
    public partial class MainWindowVM : ZeroNavigationViewModel
    {
        public ObservableCollection<CompareOperator> CompareOperators { get; set; } = [.. Enum.GetValues<CompareOperator>()];

        [ObservableProperty]
        public partial CompareOperator CompareOperator { get; set; }

        [ObservableProperty]
        public partial bool IsOn { get; set; } = false;
 
        protected override void OnViewLoaded(object? sender)
        {
            TotalDataCnt = 300;
        }

        /// <summary>
        /// IsOn变更
        /// </summary>
        /// <param name="value"></param>
        partial void OnIsOnChanged(bool value)
        {
            Debug.WriteLine(string.Format("IsOn状态：{0}", IsOn));
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
        protected override void OnQuery(object? sender)
        {
            //TotalDataCnt ++;
            Debug.WriteLine("导航到页面：" + TargetPage + "/" + TotalPageCnt);
        }

        protected override async Task OnSendAsync(object? sender)
        {
            Debug.WriteLine("发送方法：");
           
            await Task.CompletedTask;
        }
    }
}

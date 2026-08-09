using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;

namespace Zero.WPF.Core.MVVM
{
    /// <summary>
    /// 属性变更通知
    /// </summary>
    [SupportedOSPlatform("windows")]
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged

        /// <summary>
        /// 属性更改通知事件
        /// </summary>
        [field: NonSerializedAttribute()]
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// 属性更改通知
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion INotifyPropertyChanged
    }
}

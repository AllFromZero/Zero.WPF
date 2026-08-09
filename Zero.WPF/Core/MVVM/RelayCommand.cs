using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zero.WPF.Core.MVVM
{
    /// <summary>
    /// Base command class.
    /// </summary>
    /// <remarks>通过事件委托，以便跨线程调用</remarks>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Event handler
        /// 事件出发时先调用CanExecute（），然后调用
        /// </summary>
        public event EventHandler? CanExecuteChanged;
        /// <summary>
        /// Execute action.
        /// </summary>
        public Action<object?>? DoExecute { get; set; }

        /// <summary>
        /// Canexecute method.
        /// </summary>
        public Func<object?, bool> DoCanExecute { get; set; } = new Func<object?, bool>(obj => true);

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public RelayCommand()
        {

        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="doAction"></param>
        public RelayCommand(Action<object?> doAction)
        {
            DoExecute = doAction;
        }

        /// <summary>
        /// 有参构造函数
        /// </summary>
        /// <param name="doAction">执行操作</param>
        /// <param name="doCanAction">确认是否执行操作</param>
        public RelayCommand(Action<object?> doAction, Func<object?, bool> doCanAction)
        {
            DoExecute = doAction;
            DoCanExecute = doCanAction;
        }


        /// <summary>
        /// Can execute.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object? parameter)
        {
            //初始化时会调用一次
            return DoCanExecute?.Invoke(parameter) == true;
        }
        /// <summary>
        /// Excute.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object? parameter)
        {
            //实例化委托。
            DoExecute?.Invoke(parameter);
        }

        /// <summary>
        /// 执行委托，调用CanExecute。
        /// </summary>
        public void DoCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

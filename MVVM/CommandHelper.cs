using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.MVVM
{
    public class CommandHelper : ICommand
    {
        /// <summary>
        /// 要执行的命令
        /// </summary>
        public Action<object> ExecuteCommand = null;
        /// <summary>
        /// 判断命令是否可以执行的方法
        /// </summary>
        public Func<object, bool> CanExecuteCommand = null;
        /// <summary>
        /// 检查命令是否可以执行的事件,在UI事件发生导致控件状态或数据发生变化时触发
        /// </summary>
        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                if (CanExecuteCommand != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (CanExecuteCommand != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }
        public CommandHelper(Action<object> execute) : this(execute, null)
        {
        }
        public CommandHelper(Action<object> execute, Func<object, bool> canExecute)
        {
            ExecuteCommand = execute;
            CanExecuteCommand = canExecute;
        }

        /// <summary>
        /// 判断命令是否可以执行
        /// </summary>
        /// <param name="parameter">命令传入的参数</param>
        /// <returns>是否可以执行</returns>
        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
            {
                return CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="parameter">命令传入的参数</param>
        public void Execute(object parameter)
        {
            ExecuteCommand?.Invoke(parameter);
        }
    }
}

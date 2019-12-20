using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.MVVM
{
    public class NotifyPropertyChangedHelper : INotifyPropertyChanged
    {
        private PropertyChangedEventHandler handler;
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                handler += value;
            }

            remove
            {
                handler -= value;
            }
        }
        /// <summary>
        /// 设置要通知的属性
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="storage">属性当前值</param>
        /// <param name="value">将要赋的值</param>
        /// <param name="action">表达式,表示更改</param>
        /// <returns>设置成功与否</returns>
        public bool SetProperty<T>(ref T storage, T value, Expression<Func<T>> action)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            var propertyName = GetPropertyName(action);
            this.OnPropertyChanged(propertyName);
            return true;
        }
        /// <summary>
        /// 获取要通知的属性名
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="action">指向属性名的表达式</param>
        /// <returns>属性名</returns>
        private string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;
            var propertyName = expression.Member.Name;
            return propertyName;
        }
        /// <summary>
        /// 发布事件
        /// </summary>
        /// <param name="propertyName">属性名</param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

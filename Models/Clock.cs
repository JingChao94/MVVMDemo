using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.Models
{
    /// <summary>
    /// 时钟类
    /// </summary>
    public class Clock
    {
        /// <summary>
        /// 小时
        /// </summary>
        public int Hour { get => DateTime.Now.Hour; }
        /// <summary>
        /// 分钟
        /// </summary>
        public int Minute { get => DateTime.Now.Minute; }
        /// <summary>
        /// 秒钟
        /// </summary>
        public int Second { get => DateTime.Now.Second; }
    }
}

using MVVMDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MVVMDemo.MVVM;

namespace MVVMDemo.ViewModels
{
    public class ClockViewModel : NotifyPropertyChangedHelper
    {
        //时钟类对象
        private Clock clock;
        //时针指针角度
        private int hourAngle;
        //是否启动时钟
        private bool enable = true;
        //分针指针角度
        private int minuteAngle;
        //秒针指针角度
        private int secondAngle;
        /// <summary>
        /// 时针角度
        /// </summary>
        public int HourAngle
        {
            get => hourAngle;
            set
            {
                SetProperty(ref hourAngle, value, () => HourAngle);
            }
        }
        /// <summary>
        /// 分针角度
        /// </summary>
        public int MinuteAngle
        {
            get => minuteAngle;
            set
            {
                SetProperty(ref minuteAngle, value, () => MinuteAngle);
            }
        }
        /// <summary>
        /// 秒针角度
        /// </summary>
        public int SecondAngle
        {
            get => secondAngle;
            set
            {
                SetProperty(ref secondAngle, value, () => SecondAngle);
            }
        }

        public ClockViewModel()
        {
            clock = new Clock();
            new Thread(() =>
            {
                while (enable)
                {
                    HourAngle = clock.Hour * 6;
                    MinuteAngle = clock.Minute * 6;
                    SecondAngle = clock.Second * 6;
                    Thread.Sleep(500);
                }
            })
            {
                IsBackground = true
            }.Start();
        }
        private CommandHelper shutDownCommand;
        public CommandHelper ShutDownCommand
        {
            get
            {
                if (shutDownCommand == null)
                {
                    shutDownCommand = new CommandHelper((o) =>
                    {
                        enable = false;
                    });//关闭
                }
                return shutDownCommand;
            }
        }
    }
}

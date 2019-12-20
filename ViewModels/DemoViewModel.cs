using MVVMDemo.Demo;
using MVVMDemo.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDemo.ViewModels
{
    public class DemoViewModel : NotifyPropertyChangedHelper
    {
        private DemoWindow demoWindow = null;
        public DemoViewModel(DemoWindow window)
        {
            demoWindow = window;
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
                        demoWindow.Close();
                        Environment.Exit(0);
                    });//关闭
                }
                return shutDownCommand;
            }
        }
    }
}

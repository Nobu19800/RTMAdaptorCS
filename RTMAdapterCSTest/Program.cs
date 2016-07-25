using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenRTM_aist;
using RTC;

namespace RTMAdapterCSTest
{
    class Program
    {
        static RTC.RTComponent rtc;

        static void MyModuleInit(Manager m)
        {
            MyRTComponent.MyRTComponent_init(m);
            rtc = m.createComponent("MyRTComponent");
        }

        static void Main(string[] args)
        {
            Manager m = Manager.initManager(args);
            m.init(args);
            m.setModuleInitProc(MyModuleInit);
            m.activateManager();
            m.runManager(false);
        }
    }
}

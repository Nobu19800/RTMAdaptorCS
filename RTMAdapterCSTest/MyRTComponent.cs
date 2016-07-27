using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTC;
using OpenRTM_aist;
using System.Threading;

namespace RTMAdapterCSTest
{

    using Manager_t = Int32;
    using Result_t = Int32;
    using RTC_t = Int32;
    using Port_t = Int32;


    class MyRTComponent : RTComponent
    {

        static Dictionary<string, string> specs = new Dictionary<string, string>()
        {
            {"implementation_id",  "MyRTComponent"},
            {"type_name",  "MyRTComponent"},
            {"conf.default.config01", "defaultValue01"},
            {"conf.default.config02", "defaultValue02"}
        };

        public MyRTComponent(RTC_t rtc)
            : base(rtc)
        {

        }

        public override int onInitialize(int ec_id)
        {
            System.Console.Write("onInitialize called.\n");

            bindParameter("config01", "default_conf01");
            bindParameter("config02", "default_conf02");
            return 0;
        }

        public override int onActivated(int ec_id)
        {
            System.Console.Write("onActivated called.\n");
            return 0;
        }

        public override int onDeactivated(int ec_id)
        {
            System.Console.Write("onDeactivated called.\n");
            return 0;
        }

        public override int onExecute(int ec_id)
        {
            System.Console.Write("onExecute called.\n");

            string value1 = getParameter("config01");
            System.Console.WriteLine("Parameter: {0}", value1);
            string value2 = getParameter("config02");
            System.Console.WriteLine("Parameter: {0}", value2);

           
           
            return 0;
        }

        public override int onError(int ec_id)
        {

            return 0;
        }

        public override int onReset(int ec_id)
        {

            return 0;
        }

        public override int onAborting(int ec_id)
        {

            return 0;
        }

        static RTComponent createMyRTComponent(RTC_t rtc)
        {
            return new MyRTComponent(rtc);
        }

        public static void MyRTComponent_init(Manager m)
        {
            m.RTMAdapter_init(specs, createMyRTComponent);
        }
    }
}

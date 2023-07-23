using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
///using System.Threading.Tasks;
///
using System.Runtime.InteropServices;

namespace RTC
{
    using Manager_t = Int32;
    using Result_t = Int32;
    using Port_t = Int32;
    using RTC_t = Int32;

    public class RTMAdapter : RTComponent
    {
        
        public RTMAdapter(RTC_t r)
            : base(r, false)
        {
            
        }

        public override int onInitialize(int ec_id)
        {
            return 0;
        }

        public override int onActivated(int ec_id)
        {
            return 0;
        }

        public override int onDeactivated(int ec_id)
        {
            return 0;

        }

        public override int onAborting(int ec_id)
        {
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

        public override int onExecute(int ec_id)
        {
            return 0;
        }
    }

}

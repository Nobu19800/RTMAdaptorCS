/// DataTypeBase 
/// author: Yuki Suga
/// copyright: Sugar Sweet Robotics All rights reserved. 2016


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace RTC
{

    using Manager_t = Int32;
    using Result_t = Int32;
    using RTC_t = Int32;
    using DataType_t = Int32;
    using Port_t = Int32;


    public interface DataTypeBase
    {
        Port_t createOutPort(string name);
        Port_t createInPort(string name);
        bool InPortIsNew(Port_t port);

        void up();
        void down();
    }
}


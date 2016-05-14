using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RTC;
using System.Runtime.InteropServices;



namespace OpenRTM_aist
{
    using Manager_t = Int32;
    using Result_t = Int32;
    using RTC_t = Int32;
    using Port_t = Int32;


    public class Manager
    {

        public const string rtmadapter_dll = "RTMAdapter.dll";

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Manager_t Manager_initManager(Int32 argc, string[] argv);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Result_t Manager_init(Manager_t m, Int32 argc, string[] argv);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Result_t Manager_setRTMAdapterModuleInitProc(Manager_t m);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Result_t Manager_activateManager(Manager_t m);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Result_t Manager_runManager(Manager_t m, Int32 flag);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static RTC_t Manager_createComponent(Manager_t m, string identifier);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static RTC_t Manager_createAdapterComponent(Manager_t m);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Result_t Manager_shutdown(Manager_t m);

        Manager_t _m;

        static Manager __manager;

        private Manager(Int32 argc, string[] argv)
        {
            byte[] d = {0x00};
            _m = Manager_initManager(argc, argv);
        }

         ~Manager()
        {
            //Manager_shutdown(_m);
        }

        public static Manager initManager(string[] args)
        {
            if (__manager == null)
            {
                __manager = new Manager(args.Length, args);
            }
            return __manager;
        }

        public void init(string[] args)
        {
            Manager_init(_m, args.Length, args);
        }

        public void setRTMAdapterModuleInitProc()
        {
            Manager_setRTMAdapterModuleInitProc(_m);
        }

        public void activateManager()
        {
            Manager_activateManager(_m);
        }

        public void runManager(bool flag)
        {
            Manager_runManager(_m, flag ? 1 : 0);
        }

        public void createComponent(string identifier)
        {
            Manager_createComponent(_m, identifier);
        }

        public RTComponent createAdapterComponent()
        {
            RTC_t r = Manager_createAdapterComponent(_m);
            if (r < 0) { return null; }

            //RTComponent rtc = new RTComponent(r);
            //rtc.initialize();
            //return rtc;
            return new  RTMAdapter(r);
        }
    }
}

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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void _ModuleInitProc(Manager_t m);

        public delegate void ModuleInitProc(Manager m);
        
        public delegate RTComponent RTCFactoryMethod(RTC_t rtc);

        Manager_t _m;

        static Manager __manager;

        private ModuleInitProc _moduleInitProc;

        private Dictionary<string, RTCFactoryMethod> factoryDictionary = new Dictionary<string, RTCFactoryMethod>();

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

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Result_t Manager_setModuleInitProc(Manager_t m, _ModuleInitProc proc);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Result_t Manager_RTMAdapter_init(Manager_t m);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        extern static Result_t Manager_setRTMAdapterSpec(Manager_t m, string key, string value);



        static Manager instance()
        {
            return __manager;
        }

        private Manager(Int32 argc, string[] argv)
        {
            byte[] d = { 0x00 };
            _m = Manager_initManager(argc, argv);
        }

        ~Manager()
        {
            /// Manager_shutdown(_m);
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

        public void RTMAdapter_init(Dictionary<string, string> specs, RTCFactoryMethod factory)
        {
            foreach (var spec in specs) {
               Manager_setRTMAdapterSpec(_m, spec.Key, spec.Value);
            }
            Manager_RTMAdapter_init(_m);
            factoryDictionary[specs["implementation_id"]] = factory;
        }

        private void DefaultModuleInitProc(Manager_t m)
        {

        }

        private static void myModuleInitCallBack(Manager_t m)
        {
            Manager.instance()._moduleInitProc(Manager.instance());
        }

        public void setModuleInitProc(ModuleInitProc proc)
        {
            _moduleInitProc = proc;
            Manager_setModuleInitProc(_m, myModuleInitCallBack);
        }

        public void activateManager()
        {
            Manager_activateManager(_m);
        }

        public void runManager(bool flag)
        {
            Manager_runManager(_m, flag ? 1 : 0);
        }

        public RTC.RTComponent createComponent(string identifier)
        {
            try
            {
                RTCFactoryMethod factory = factoryDictionary[identifier];
                RTC_t rtc = Manager_createComponent(_m, identifier);
                RTComponent r =  factory(rtc);
                r.initialize();
                return r;
            }
            catch (KeyNotFoundException ex)
            {
                System.Console.Write("Loading RTComponent (" + identifier + ") failed. Reason: Key Not Found.");
                return null;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
///using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace RTC
{
    using Manager_t = Int32;
    using Result_t = Int32;
    using Port_t = Int32;
    using RTC_t = Int32;

    public abstract class RTComponent
    {

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate Int32 RtcVoidCallback();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate Int32 RtcCallback(Int32 ec_id);

        public const string rtmadapter_dll = OpenRTM_aist.Manager.rtmadapter_dll;

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_addInPort(RTC_t rtc, string name, Port_t port);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_addOutPort(RTC_t rtc, string name, Port_t port);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_deletePort(RTC_t rtc, Port_t port);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_exit(RTC_t rtc);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern Result_t RTC_bindParameter(RTC_t rtc, [MarshalAs(UnmanagedType.LPArray)] byte[] name, 
            [MarshalAs(UnmanagedType.LPArray)] byte[] defaultValue);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern Result_t RTC_updateParameters(RTC_t rtc, [MarshalAs(UnmanagedType.LPArray)] byte[] confsetName);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern Result_t RTC_getParameterStringLength(RTC_t rtc, [MarshalAs(UnmanagedType.LPArray)] byte[] name, out Int32 size);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        private static extern Result_t RTC_getParameter(RTC_t rtc, [MarshalAs(UnmanagedType.LPArray)] byte[] name, [MarshalAs(UnmanagedType.LPArray)] byte[] value);


        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onFinalize_listen(RTC_t rtc, RtcVoidCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onStartup_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onShutdown_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onActivated_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onDeactivated_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onExecute_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onAborting_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onError_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onReset_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onStateUpdate_listen(RTC_t rtc, RtcCallback callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_onRateChanged_listen(RTC_t rtc, RtcCallback callback);


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate Int32 RtcVoidCallbackG(RTC_t rtc);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        protected delegate Int32 RtcCallbackG(RTC_t rtc, Int32 ec_id);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onFinalize_listen_g(RTC_t rtc, RtcVoidCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onStartup_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onShutdown_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onActivated_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onDeactivated_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onExecute_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onAborting_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onError_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onReset_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onStateUpdate_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        protected static extern Result_t RTC_onRateChanged_listen_g(RTC_t rtc, RtcCallbackG callback);

        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_tickExecutionContext(RTC_t rtc, Int32 ecId);
        [DllImport(rtmadapter_dll, CallingConvention = CallingConvention.Cdecl)]
        private static extern Result_t RTC_activateComponent(RTC_t rtc, Int32 ecId);

        protected RTC_t _r;

        protected static Dictionary<RTC_t, RTComponent> rtcList = new Dictionary<RTC_t, RTComponent>();

        static int onFinalizeCallbackG(RTC_t rtc_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                RTComponent rtc = rtcList[rtc_id];
                rtcList.Remove(rtc_id);
                

                try
                {
                    return rtc.onFinalize();
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }

            return 0;
        }

        static int onStartupCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onStartup(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onShutdownCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onShutdown(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onActivatedCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onActivated(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onDeactivatedCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onDeactivated(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onExecuteCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onExecute(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onAbortingCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onAborting(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onErrorCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onError(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onResetCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onReset(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onStateUpdateCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onStateUpdate(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }

        static int onRateChangedCallbackG(RTC_t rtc_id, int ec_id)
        {
            if (rtcList.ContainsKey(rtc_id))
            {
                try
                {
                    return rtcList[rtc_id].onRateChanged(ec_id);
                }
                catch (Exception ex)
                {
                    System.Console.Error.WriteLine(ex);
                    return 1;
                }
            }
            return 0;
        }


        public RTComponent(RTC_t r, bool staticCallback)
        {
            _r = r;

            if (!staticCallback)
            {
                RTC_onFinalize_listen(_r, onFinalizeCallback);
                RTC_onStartup_listen(_r, onStartupCallback);
                RTC_onShutdown_listen(_r, onShutdownCallback);
                RTC_onActivated_listen(_r, onActivatedCallback);
                RTC_onDeactivated_listen(_r, onDeactivatedCallback);
                RTC_onExecute_listen(_r, onExecuteCallback);
                RTC_onAborting_listen(_r, onAbortingCallback);
                RTC_onError_listen(_r, onErrorCallback);
                RTC_onReset_listen(_r, onResetCallback);
                RTC_onStateUpdate_listen(_r, onStateUpdateCallback);
                RTC_onRateChanged_listen(_r, onRateChangedCallback);
            }
            else
            {
                rtcList[_r] = this;
                RTC_onFinalize_listen_g(_r, onFinalizeCallbackG);
                RTC_onStartup_listen_g(_r, onStartupCallbackG);
                RTC_onShutdown_listen_g(_r, onShutdownCallbackG);
                RTC_onActivated_listen_g(_r, onActivatedCallbackG);
                RTC_onDeactivated_listen_g(_r, onDeactivatedCallbackG);
                RTC_onExecute_listen_g(_r, onExecuteCallbackG);
                RTC_onAborting_listen_g(_r, onAbortingCallbackG);
                RTC_onError_listen_g(_r, onErrorCallbackG);
                RTC_onReset_listen_g(_r, onResetCallbackG);
                RTC_onStateUpdate_listen_g(_r, onStateUpdateCallbackG);
                RTC_onRateChanged_listen_g(_r, onRateChangedCallbackG);
            }
        }

        public void addOutPort(PortBase port)
        {
            RTC_addOutPort(_r, port.getName(), port.d());
        }

        public void addInPort(PortBase port)
        {
            RTC_addInPort(_r, port.getName(), port.d());
        }

        public void exit()
        {
            RTC_exit(_r);
        }

        public void bindParameter(string name, string defaultValue)
        {
            RTC_bindParameter(_r, Encoding.ASCII.GetBytes(name), Encoding.ASCII.GetBytes(defaultValue));
        }

        public string getParameter(string name)
        {
            Int32 size = 0;
            RTC_getParameterStringLength(_r, Encoding.ASCII.GetBytes(name), out size);
            byte[] value= new byte[size+1];
            RTC_getParameter(_r, Encoding.ASCII.GetBytes(name), value);
            return Encoding.ASCII.GetString(value);
        }

        public void updateParameters(string name)
        {
            RTC_updateParameters(_r, Encoding.ASCII.GetBytes(name));
        }

        public void tick(int ec_id)
        {
            RTC_tickExecutionContext(_r, ec_id);
        }

        public void activate(int ec_id)
        {
            RTC_activateComponent(_r, ec_id);
        }

        public void initialize()
        {
            onInitialize(0);
            updateParameters("default");
        }

        public virtual int onInitialize(int ec_id)
        {
            return 0;
        }

        public virtual int onFinalize()
        {
            return 0;
        }

        public virtual int onStartup(int ec_id)
        {
            return 0;
        }

        public virtual int onShutdown(int ec_id)
        {
            return 0;
        }

        public virtual int onActivated(int ec_id)
        {
            return 0;
        }

        public virtual int onDeactivated(int ec_id)
        {
            return 0;
        }

        public virtual int onExecute(int ec_id)
        {
            return 0;
        }

        public virtual int onError(int ec_id)
        {
            return 0;
        }

        public virtual int onReset(int ec_id)
        {
            return 0;
        }

        public virtual int onAborting(int ec_id)
        {
            return 0;
        }

        public virtual int onStateUpdate(int ec_id)
        {
            return 0;
        }

        public virtual int onRateChanged(int ec_id)
        {
            return 0;
        }


        public virtual int onFinalizeCallback()
        {
            if (rtcList.ContainsKey(_r))
            {
                rtcList.Remove(_r);
            }
            try
            {
                return onFinalize();
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onStartupCallback(int ec_id)
        {
            try
            {
                return onStartup(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onShutdownCallback(int ec_id)
        {
            try
            {
                return onShutdown(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onActivatedCallback(int ec_id)
        {
            try
            {
                return onActivated(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onDeactivatedCallback(int ec_id)
        {
            try
            {
                return onDeactivated(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onExecuteCallback(int ec_id)
        {
            try
            {
                return onExecute(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onErrorCallback(int ec_id)
        {
            try
            {
                return onError(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onResetCallback(int ec_id)
        {
            try
            {
                return onReset(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onAbortingCallback(int ec_id)
        {
            try
            {
                return onAborting(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onStateUpdateCallback(int ec_id)
        {
            try
            {
                return onStateUpdate(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }

        public virtual int onRateChangedCallback(int ec_id)
        {
            try
            {
                return onRateChanged(ec_id);
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex);
                return 1;
            }
        }
    }

}

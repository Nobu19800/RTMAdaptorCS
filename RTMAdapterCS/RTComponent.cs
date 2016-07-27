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

        RTC_t _r;

        public RTComponent(RTC_t r)
        {
            _r = r;

            RTC_onFinalize_listen(_r, onFinalize);
            RTC_onStartup_listen(_r, onStartup);
            RTC_onShutdown_listen(_r, onShutdown);
            RTC_onActivated_listen(_r, onActivated);
            RTC_onDeactivated_listen(_r, onDeactivated);
            RTC_onExecute_listen(_r, onExecute);
            RTC_onAborting_listen(_r, onAborting);
            RTC_onError_listen(_r, onError);
            RTC_onReset_listen(_r, onReset);
            RTC_onStateUpdate_listen(_r, onStateUpdate);
            RTC_onRateChanged_listen(_r, onRateChanged);
        }

        public void addOutPort(PortBase port)
        {
            RTC_addOutPort(_r, port.getName(), port.d());
        }

        public void addInPort(PortBase port)
        {
            RTC_addInPort(_r, port.getName(), port.d());
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
    }

}

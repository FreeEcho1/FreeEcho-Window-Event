using System.Runtime.InteropServices;
using System.Text;
using System;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace FEWindowEventSample;

public partial class MainWindow : System.Windows.Window
{
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetWindowText(
        IntPtr hWnd,
        [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder lpString,
        int nMaxCount
        );
    [DllImport("user32.dll")]
    public static extern int GetWindowTextLength(
        IntPtr hWnd
        );
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetClassName(
        IntPtr hWnd,
        [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder lpClassName,
        int nMaxCount
        );
    [DllImport("user32.dll", SetLastError = true)]
    public static extern uint GetWindowThreadProcessId(
        IntPtr hWnd,
        out int lpdwProcessId
        );
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr OpenProcess(
        uint processAccess,
        [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle,
        int processId
        );
    [DllImport("psapi.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumProcessModules(
        IntPtr hProcess,
        out IntPtr lphModule,
        uint cb,
        [MarshalAs(UnmanagedType.U4)] out uint lpcbNeeded
        );
    [DllImport("psapi.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern uint GetModuleFileNameEx(
        IntPtr hProcess,
        IntPtr hModule,
        [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder lpBaseName,
        int nSize
        );
    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool CloseHandle(
        IntPtr hObject
        );

    /// <summary>
    /// ウィンドウイベント
    /// </summary>
    private readonly FreeEcho.FEWindowEvent.WindowEvent WindowEvent = new();

    public MainWindow()
    {
        InitializeComponent();

        try
        {
            WindowEvent.WindowEventOccurrence += WindowEvent_WindowEventOccurrence;
            WindowEvent.Hook(
                FreeEcho.FEWindowEvent.HookWindowEventType.Create
                | FreeEcho.FEWindowEvent.HookWindowEventType.Destroy
                | FreeEcho.FEWindowEvent.HookWindowEventType.Foreground
                | FreeEcho.FEWindowEvent.HookWindowEventType.Hide
                | FreeEcho.FEWindowEvent.HookWindowEventType.LocationChange
                | FreeEcho.FEWindowEvent.HookWindowEventType.MinimizeEnd
                | FreeEcho.FEWindowEvent.HookWindowEventType.MinimizeStart
                | FreeEcho.FEWindowEvent.HookWindowEventType.MoveSizeEnd
                | FreeEcho.FEWindowEvent.HookWindowEventType.MoveSizeStart
                | FreeEcho.FEWindowEvent.HookWindowEventType.NameChange
                | FreeEcho.FEWindowEvent.HookWindowEventType.Show
                );

            Closed += MainWindow_Closed;
        }
        catch
        {
        }
    }

    /// <summary>
    /// ウィンドウの「Closed」イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void MainWindow_Closed(
        object sender,
        System.EventArgs e
        )
    {
        try
        {
            if (WindowEvent != null)
            {
                WindowEvent.Unhook();
            }
        }
        catch
        {
        }
    }

    /// <summary>
    /// 「WindowEventOccurrence」イベント
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void WindowEvent_WindowEventOccurrence(
        object sender,
        FreeEcho.FEWindowEvent.WindowEventArgs e
        )
    {
        try
        {
            string titleName = "";
            string className = "";
            string fileName = "";

            // タイトル名取得
            try
            {
                StringBuilder getString;
                int length = GetWindowTextLength(e.Hwnd) + 1;
                getString = new(length);
                GetWindowText(e.Hwnd, getString, getString.Capacity);
                titleName = getString.ToString();
            }
            catch
            {
            }
            // クラス名取得
            try
            {
                StringBuilder getString;
                getString = new(256);
                GetClassName(e.Hwnd, getString, getString.Capacity);
                className = getString.ToString();
            }
            catch
            {
            }

            // ファイル名取得
            try
            {
                GetWindowThreadProcessId(e.Hwnd, out int id);       // プロセスID
                IntPtr process = OpenProcess(0x00000400 | 0x00000010, false, id);
                if (process != IntPtr.Zero)
                {
                    if (EnumProcessModules(process, out IntPtr pmodules, (uint)Marshal.SizeOf(typeof(IntPtr)), out _))
                    {
                        StringBuilder getString;
                        getString = new(256);
                        GetModuleFileNameEx(process, pmodules, getString, getString.Capacity);
                        fileName = getString.ToString();
                    }
                    CloseHandle(process);
                }
            }
            catch
            {
            }

            switch (e.WindowEventType)
            {
                case FreeEcho.FEWindowEvent.WindowEventType.Foreground:
                    System.Diagnostics.Debug.WriteLine("Foreground - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.MoveSizeStart:
                    System.Diagnostics.Debug.WriteLine("MoveSizeStart - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.MoveSizeEnd:
                    System.Diagnostics.Debug.WriteLine("MoveSizeEnd - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.MinimizeStart:
                    System.Diagnostics.Debug.WriteLine("MinimizeStart - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.MinimizeEnd:
                    System.Diagnostics.Debug.WriteLine("MinimizeEnd - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.Create:
                    System.Diagnostics.Debug.WriteLine("Create - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.Destroy:
                    System.Diagnostics.Debug.WriteLine("Destroy - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.Show:
                    System.Diagnostics.Debug.WriteLine("Show - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.Hide:
                    System.Diagnostics.Debug.WriteLine("Hide - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.LocationChange:
                    System.Diagnostics.Debug.WriteLine("LocationChange - " + titleName + " - " + className + " - " + fileName);
                    break;
                case FreeEcho.FEWindowEvent.WindowEventType.NameChange:
                    System.Diagnostics.Debug.WriteLine("NameChange - " + titleName + " - " + className + " - " + fileName);
                    break;
            }
        }
        catch
        {
        }
    }
}

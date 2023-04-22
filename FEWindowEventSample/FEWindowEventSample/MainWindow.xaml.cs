using System.Runtime.InteropServices;
using System.Text;
using System;

namespace FEWindowEventSample;

public partial class MainWindow : System.Windows.Window
{
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
        EventArgs e
        )
    {
        try
        {
            WindowEvent?.Unhook();
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
            IntPtr hwnd = e.Hwnd;
            // ウィンドウのハンドルではない場合があるので、
            //  GetWindowHwndでウィンドウのハンドルを取得している。
            // ウィンドウのハンドルではなくても良い場合はこの処理は不要。
            hwnd = FreeEcho.FEWindowEvent.WindowEvent.GetWindowHwnd(e.Hwnd, e.EventType);
            // ウィンドウが表示されているかを判定するにはConfirmWindowVisibleを使用する。
            if (FreeEcho.FEWindowEvent.WindowEvent.ConfirmWindowVisible(hwnd, e.EventType) == false)
            {
                return;
            }

            string titleName = "";
            string className = "";
            string fileName = "";

            // タイトル名取得
            try
            {
                StringBuilder getString;
                int length = NativeMethods.GetWindowTextLength(e.Hwnd) + 1;
                getString = new(length);
                _ = NativeMethods.GetWindowText(e.Hwnd, getString, getString.Capacity);
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
                _ = NativeMethods.GetClassName(e.Hwnd, getString, getString.Capacity);
                className = getString.ToString();
            }
            catch
            {
            }

            // ファイル名取得
            try
            {
                _ = NativeMethods.GetWindowThreadProcessId(e.Hwnd, out int id);       // プロセスID
                IntPtr process = NativeMethods.OpenProcess(0x00000400 | 0x00000010, false, id);
                if (process != IntPtr.Zero)
                {
                    if (NativeMethods.EnumProcessModules(process, out IntPtr pmodules, (uint)Marshal.SizeOf(typeof(IntPtr)), out _))
                    {
                        StringBuilder getString;
                        getString = new(256);
                        _ = NativeMethods.GetModuleFileNameEx(process, pmodules, getString, getString.Capacity);
                        fileName = getString.ToString();
                    }
                    NativeMethods.CloseHandle(process);
                }
            }
            catch
            {
            }

            string writeString = " - " + titleName + " - " + className + " - " + fileName;
            switch (e.EventType)
            {
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_SYSTEM_FOREGROUND:
                    System.Diagnostics.Debug.WriteLine("Foreground" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_SYSTEM_MOVESIZESTART:
                    System.Diagnostics.Debug.WriteLine("MoveSizeStart" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_SYSTEM_MOVESIZEEND:
                    System.Diagnostics.Debug.WriteLine("MoveSizeEnd" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_SYSTEM_MINIMIZESTART:
                    System.Diagnostics.Debug.WriteLine("MinimizeStart" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_SYSTEM_MINIMIZEEND:
                    System.Diagnostics.Debug.WriteLine("MinimizeEnd" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_OBJECT_CREATE:
                    System.Diagnostics.Debug.WriteLine("Create" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_OBJECT_DESTROY:
                    System.Diagnostics.Debug.WriteLine("Destroy" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_OBJECT_SHOW:
                    System.Diagnostics.Debug.WriteLine("Show" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_OBJECT_HIDE:
                    System.Diagnostics.Debug.WriteLine("Hide" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_OBJECT_LOCATIONCHANGE:
                    System.Diagnostics.Debug.WriteLine("LocationChange" + writeString);
                    break;
                case FreeEcho.FEWindowEvent.EVENT_CONSTANTS.EVENT_OBJECT_NAMECHANGE:
                    System.Diagnostics.Debug.WriteLine("NameChange" + writeString);
                    break;
            }
        }
        catch
        {
        }
    }
}

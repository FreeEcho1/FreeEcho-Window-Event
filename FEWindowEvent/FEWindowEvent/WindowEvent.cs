using FEWindowEvent;

namespace FreeEcho.FEWindowEvent;

/// <summary>
/// ウィンドウイベント
/// </summary>
public class WindowEvent : System.IDisposable
{
    /// <summary>
    /// Disposeが呼ばれたかの値 (いいえ「false」/はい「true」)
    /// </summary>
    private bool Disposed;
    /// <summary>
    /// フックハンドル
    /// </summary>
    private System.Collections.Generic.List<System.IntPtr> Hhook;
    /// <summary>
    /// Windowsイベントのプロシージャのデリゲート
    /// </summary>
    private NativeMethodsDelegate.WinEventDelegate WindowsEventProcedureDelegate;
    /// <summary>
    /// ウィンドウイベント発生のイベント
    /// </summary>
    public event System.EventHandler<WindowEventArgs> WindowEventOccurrence;
    /// <summary>
    /// ウィンドウイベント発生のイベントを実行
    /// </summary>
    public virtual void DoWindowEventOccurrence(
        WindowEventArgs e
        )
    {
        WindowEventOccurrence?.Invoke(this, e);
    }

    /// <summary>
    /// デストラクタ
    /// </summary>
    ~WindowEvent()
    {
        Dispose(false);
    }

    /// <summary>
    /// Dispose
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        System.GC.SuppressFinalize(this);
    }

    /// <summary>
    /// 非公開Dispose
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(
        bool disposing
        )
    {
        if (Disposed)
        {
            return;
        }
        if (disposing)
        {
            Unhook();
        }
        Disposed = true;
    }

    /// <summary>
    /// フック開始
    /// 「HookWindowEventType」の全て。
    /// </summary>
    public void Hook()
    {
        Hook(HookWindowEventType.Foreground | HookWindowEventType.MoveSizeStart | HookWindowEventType.MoveSizeEnd
            | HookWindowEventType.MinimizeStart | HookWindowEventType.MinimizeEnd | HookWindowEventType.Create
            | HookWindowEventType.Destroy | HookWindowEventType.Show | HookWindowEventType.Hide
            | HookWindowEventType.LocationChange | HookWindowEventType.NameChange);
    }

    /// <summary>
    /// フック開始
    /// </summary>
    /// <param name="type">フックするウィンドウイベントの種類</param>
    public void Hook(
        HookWindowEventType type
        )
    {
        if (WindowsEventProcedureDelegate == null)
        {
            WindowsEventProcedureDelegate = new NativeMethodsDelegate.WinEventDelegate(WinEventProc);
        }
        if (Hhook == null)
        {
            Hhook = new();
            if ((type & HookWindowEventType.Foreground) == HookWindowEventType.Foreground)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_SYSTEM_FOREGROUND, (uint)HOOK_EVENT.EVENT_SYSTEM_FOREGROUND, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.MoveSizeStart) == HookWindowEventType.MoveSizeStart)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_SYSTEM_MOVESIZESTART, (uint)HOOK_EVENT.EVENT_SYSTEM_MOVESIZESTART, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.MoveSizeEnd) == HookWindowEventType.MoveSizeEnd)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_SYSTEM_MOVESIZEEND, (uint)HOOK_EVENT.EVENT_SYSTEM_MOVESIZEEND, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.MinimizeStart) == HookWindowEventType.MinimizeStart)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_SYSTEM_MINIMIZESTART, (uint)HOOK_EVENT.EVENT_SYSTEM_MINIMIZESTART, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.MinimizeEnd) == HookWindowEventType.MinimizeEnd)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_SYSTEM_MINIMIZEEND, (uint)HOOK_EVENT.EVENT_SYSTEM_MINIMIZEEND, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.Create) == HookWindowEventType.Create)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_OBJECT_CREATE, (uint)HOOK_EVENT.EVENT_OBJECT_CREATE, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.Destroy) == HookWindowEventType.Destroy)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_OBJECT_DESTROY, (uint)HOOK_EVENT.EVENT_OBJECT_DESTROY, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.Show) == HookWindowEventType.Show)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_OBJECT_SHOW, (uint)HOOK_EVENT.EVENT_OBJECT_SHOW, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.Hide) == HookWindowEventType.Hide)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_OBJECT_HIDE, (uint)HOOK_EVENT.EVENT_OBJECT_HIDE, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.LocationChange) == HookWindowEventType.LocationChange)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_OBJECT_LOCATIONCHANGE, (uint)HOOK_EVENT.EVENT_OBJECT_LOCATIONCHANGE, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
            if ((type & HookWindowEventType.NameChange) == HookWindowEventType.NameChange)
            {
                Hhook.Add(NativeMethods.SetWinEventHook((uint)HOOK_EVENT.EVENT_OBJECT_NAMECHANGE, (uint)HOOK_EVENT.EVENT_OBJECT_NAMECHANGE, System.IntPtr.Zero, WindowsEventProcedureDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
            }
        }
    }

    /// <summary>
    /// フック終了
    /// </summary>
    public void Unhook()
    {
        WindowsEventProcedureDelegate = null;
        if (Hhook != null)
        {
            foreach (System.IntPtr nowHhook in Hhook)
            {
                NativeMethods.UnhookWinEvent(nowHhook);
            }
            Hhook = null;
        }
    }

    /// <summary>
    /// Windowsイベントのプロシージャ
    /// </summary>
    /// <param name="hWinEventHook"></param>
    /// <param name="eventType"></param>
    /// <param name="hwnd"></param>
    /// <param name="idObject"></param>
    /// <param name="idChild"></param>
    /// <param name="dwEventThread"></param>
    /// <param name="dwmsEventTime"></param>
    public void WinEventProc(
        System.IntPtr hWinEventHook,
        uint eventType,
        System.IntPtr hwnd,
        long idObject,
        long idChild,
        uint dwEventThread,
        uint dwmsEventTime
        )
    {
        // ウィンドウではない場合は除外する
        if (idObject != (long)OBJID.OBJID_WINDOW)
        {
            return;
        }

        // 判定できる場合だけ判定する
        switch (eventType)
        {
            case (uint)HOOK_EVENT.EVENT_OBJECT_DESTROY:
                if (NativeMethods.IsWindow(hwnd) == false)
                {
                    return;
                }
                if ((NativeMethods.GetWindowLongPtr(hwnd, (int)GWL.GWL_EXSTYLE) & (int)WS_EX.WS_EX_TOOLWINDOW) != 0)
                {
                    return;
                }
                break;
            default:
                if (NativeMethods.IsWindowVisible(hwnd) == false
                    && NativeMethods.IsWindow(hwnd) == false)
                {
                    return;
                }
                if ((NativeMethods.GetWindowLongPtr(hwnd, (int)GWL.GWL_STYLE) & (int)WS.WS_VISIBLE) == 0)
                {
                    return;
                }
                if ((NativeMethods.GetWindowLongPtr(hwnd, (int)GWL.GWL_EXSTYLE) & (int)WS_EX.WS_EX_TOOLWINDOW) != 0)
                {
                    return;
                }
                // ウィンドウのないUWPアプリかを判定
                bool isInvisibleUwpApp;
                NativeMethods.DwmGetWindowAttribute(hwnd, (uint)DWMWINDOWATTRIBUTE.Cloaked, out isInvisibleUwpApp, System.Runtime.InteropServices.Marshal.SizeOf(typeof(bool)));
                if (isInvisibleUwpApp)
                {
                    return;
                }
                break;
        }
        
        WindowEventArgs windowEventArgs = new()
        {
            Hwnd = hwnd
        };
        switch (eventType)
        {
            case (uint)HOOK_EVENT.EVENT_SYSTEM_FOREGROUND:
                windowEventArgs.WindowEventType = WindowEventType.Foreground;
                break;
            case (uint)HOOK_EVENT.EVENT_SYSTEM_MOVESIZESTART:
                windowEventArgs.WindowEventType = WindowEventType.MoveSizeStart;
                break;
            case (uint)HOOK_EVENT.EVENT_SYSTEM_MOVESIZEEND:
                windowEventArgs.WindowEventType = WindowEventType.MoveSizeEnd;
                break;
            case (uint)HOOK_EVENT.EVENT_SYSTEM_MINIMIZESTART:
                windowEventArgs.WindowEventType = WindowEventType.MinimizeStart;
                break;
            case (uint)HOOK_EVENT.EVENT_SYSTEM_MINIMIZEEND:
                windowEventArgs.WindowEventType = WindowEventType.MinimizeEnd;
                break;
            case (uint)HOOK_EVENT.EVENT_OBJECT_CREATE:
                windowEventArgs.WindowEventType = WindowEventType.Create;
                break;
            case (uint)HOOK_EVENT.EVENT_OBJECT_DESTROY:
                windowEventArgs.WindowEventType = WindowEventType.Destroy;
                break;
            case (uint)HOOK_EVENT.EVENT_OBJECT_SHOW:
                windowEventArgs.WindowEventType = WindowEventType.Show;
                break;
            case (uint)HOOK_EVENT.EVENT_OBJECT_HIDE:
                windowEventArgs.WindowEventType = WindowEventType.Hide;
                break;
            case (uint)HOOK_EVENT.EVENT_OBJECT_LOCATIONCHANGE:
                windowEventArgs.WindowEventType = WindowEventType.LocationChange;
                break;
            case (uint)HOOK_EVENT.EVENT_OBJECT_NAMECHANGE:
                windowEventArgs.WindowEventType = WindowEventType.NameChange;
                break;
            default:
                return;
        }
        DoWindowEventOccurrence(windowEventArgs);
    }
}

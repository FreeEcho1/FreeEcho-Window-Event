using System;
using System.Collections.Generic;

namespace FreeEcho.FEWindowEvent;

/// <summary>
/// ウィンドウイベント
/// </summary>
public class WindowEvent : IDisposable
{
    /// <summary>
    /// Disposeが呼ばれたかの値 (いいえ「false」/はい「true」)
    /// </summary>
    private bool Disposed;
    /// <summary>
    /// フックハンドル
    /// </summary>
    private readonly System.Collections.Generic.List<IntPtr> Hhook;
    /// <summary>
    /// WinEventProcのデリゲート
    /// </summary>
    private readonly NativeMethodsDelegate.WinEventProcDelegate WinEventProcDelegate;
    /// <summary>
    /// イベント発生のイベント
    /// </summary>
    public event EventHandler<WindowEventArgs> WindowEventOccurrence;
    /// <summary>
    /// イベント発生のイベントを実行
    /// </summary>
    public virtual void DoWindowEventOccurrence(
        WindowEventArgs e
        )
    {
        WindowEventOccurrence?.Invoke(this, e);
    }

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public WindowEvent()
    {
        Hhook = new();
        WinEventProcDelegate = new NativeMethodsDelegate.WinEventProcDelegate(WinEventProc);
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
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// 非公開Dispose
    /// </summary>
    /// <param name="disposing">disposing</param>
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
    /// <param name="type">フックするイベントの種類</param>
    public void Hook(
        HookWindowEventType type
        )
    {
        Unhook();

        if ((type & HookWindowEventType.Foreground) == HookWindowEventType.Foreground)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_SYSTEM_FOREGROUND, EVENT_CONSTANTS.EVENT_SYSTEM_FOREGROUND, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.MoveSizeStart) == HookWindowEventType.MoveSizeStart)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_SYSTEM_MOVESIZESTART, EVENT_CONSTANTS.EVENT_SYSTEM_MOVESIZESTART, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.MoveSizeEnd) == HookWindowEventType.MoveSizeEnd)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_SYSTEM_MOVESIZEEND, EVENT_CONSTANTS.EVENT_SYSTEM_MOVESIZEEND, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.MinimizeStart) == HookWindowEventType.MinimizeStart)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_SYSTEM_MINIMIZESTART, EVENT_CONSTANTS.EVENT_SYSTEM_MINIMIZESTART, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.MinimizeEnd) == HookWindowEventType.MinimizeEnd)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_SYSTEM_MINIMIZEEND, EVENT_CONSTANTS.EVENT_SYSTEM_MINIMIZEEND, System.IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.Create) == HookWindowEventType.Create)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_OBJECT_CREATE, EVENT_CONSTANTS.EVENT_OBJECT_CREATE, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.Destroy) == HookWindowEventType.Destroy)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_OBJECT_DESTROY, EVENT_CONSTANTS.EVENT_OBJECT_DESTROY, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.Show) == HookWindowEventType.Show)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_OBJECT_SHOW, EVENT_CONSTANTS.EVENT_OBJECT_SHOW, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.Hide) == HookWindowEventType.Hide)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_OBJECT_HIDE, EVENT_CONSTANTS.EVENT_OBJECT_HIDE, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.LocationChange) == HookWindowEventType.LocationChange)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_OBJECT_LOCATIONCHANGE, EVENT_CONSTANTS.EVENT_OBJECT_LOCATIONCHANGE, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
        if ((type & HookWindowEventType.NameChange) == HookWindowEventType.NameChange)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(EVENT_CONSTANTS.EVENT_OBJECT_NAMECHANGE, EVENT_CONSTANTS.EVENT_OBJECT_NAMECHANGE, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
    }

    /// <summary>
    /// フック開始
    /// </summary>
    /// <param name="eventMin">イベント範囲の最小値</param>
    /// <param name="eventMax">イベント範囲の最大値</param>
    public void Hook(
        uint eventMin,
        uint eventMax
        )
    {
        Hhook.Add(NativeMethods.SetWinEventHook(eventMin, eventMax, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
    }

    /// <summary>
    /// フック開始
    /// </summary>
    /// <param name="settingsEventInformation">設定するイベント情報</param>
    public void Hook(
        List<SettingsEventInformation> settingsEventInformation
        )
    {
        foreach (SettingsEventInformation nowSettingsEventInformation in settingsEventInformation)
        {
            Hhook.Add(NativeMethods.SetWinEventHook(nowSettingsEventInformation.EventMin, nowSettingsEventInformation.EventMax, IntPtr.Zero, WinEventProcDelegate, 0, 0, (uint)WINEVENT.WINEVENT_OUTOFCONTEXT));
        }
    }

    /// <summary>
    /// フック終了
    /// </summary>
    public void Unhook()
    {
        foreach (IntPtr nowHhook in Hhook)
        {
            NativeMethods.UnhookWinEvent(nowHhook);
        }
        Hhook.Clear();
    }

    /// <summary>
    /// イベントのプロシージャ
    /// </summary>
    /// <param name="hWinEventHook"></param>
    /// <param name="eventType"></param>
    /// <param name="hwnd"></param>
    /// <param name="idObject"></param>
    /// <param name="idChild"></param>
    /// <param name="dwEventThread"></param>
    /// <param name="dwmsEventTime"></param>
    public void WinEventProc(
        IntPtr hWinEventHook,
        uint eventType,
        IntPtr hwnd,
        long idObject,
        long idChild,
        uint dwEventThread,
        uint dwmsEventTime
        )
    {
        // 除外
        if (idObject != (long)OBJID.OBJID_WINDOW)
        {
            return;
        }

        WindowEventArgs windowEventArgs = new()
        {
            Hwnd = hwnd,
            EventType = eventType
        };
        DoWindowEventOccurrence(windowEventArgs);
    }

    /// <summary>
    /// ウィンドウのハンドルではない場合はウィンドウのハンドルを探して取得
    /// </summary>
    /// <param name="hwnd">ウィンドウハンドル</param>
    /// <param name="eventType">イベント定数</param>
    /// <returns>ウィンドウのハンドル</returns>
    public static IntPtr GetWindowHwnd(
        IntPtr hwnd,
        uint eventType
        )
    {
        switch (eventType)
        {
            case EVENT_CONSTANTS.EVENT_OBJECT_SHOW:
                return NativeMethods.GetAncestor(hwnd, GetAncestorFlags.GA_ROOT);
            default:
                return hwnd;
        }
    }

    /// <summary>
    /// ウィンドウが表示されているか確認
    /// </summary>
    /// <param name="hwnd">ウィンドウハンドル</param>
    /// <param name="eventType">イベント定数</param>
    /// <returns>ウィンドウが表示されているかの値 (表示されていない「false」/表示されている「true」)</returns>
    public static bool ConfirmWindowVisible(
        IntPtr hwnd,
        uint eventType
        )
    {
        switch (eventType)
        {
            case EVENT_CONSTANTS.EVENT_OBJECT_CREATE:
            case EVENT_CONSTANTS.EVENT_OBJECT_DESTROY:
                break;
            case EVENT_CONSTANTS.EVENT_OBJECT_SHOW:
                if (NativeMethods.IsWindowVisible(hwnd) == false
                    && NativeMethods.IsWindow(hwnd) == false)
                {
                    return false;
                }
                if ((NativeMethods.GetWindowLongPtr(hwnd, (int)GWL.GWL_EXSTYLE) & (int)WS_EX.WS_EX_TOOLWINDOW) == (int)WS_EX.WS_EX_TOOLWINDOW)
                {
                    return false;
                }
                break;
            default:
                if (NativeMethods.IsWindowVisible(hwnd) == false
                    && NativeMethods.IsWindow(hwnd) == false)
                {
                    return false;
                }
                if ((NativeMethods.GetWindowLongPtr(hwnd, (int)GWL.GWL_EXSTYLE) & (int)WS_EX.WS_EX_TOOLWINDOW) == (int)WS_EX.WS_EX_TOOLWINDOW)
                {
                    return false;
                }
                // ウィンドウのないUWPアプリかを判定
                bool isInvisibleUwpApp;
                _ = NativeMethods.DwmGetWindowAttribute(hwnd, (uint)DWMWINDOWATTRIBUTE.Cloaked, out isInvisibleUwpApp, System.Runtime.InteropServices.Marshal.SizeOf(typeof(bool)));
                if (isInvisibleUwpApp)
                {
                    return false;
                }
                break;
        }

        return true;
    }
}

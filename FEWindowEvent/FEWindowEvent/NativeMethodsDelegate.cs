namespace FreeEcho.FEWindowEvent;

internal static class NativeMethodsDelegate
{
    public delegate void WinEventProcDelegate(
        System.IntPtr hWinEventHook,
        uint eventType,
        System.IntPtr hwnd,
        long idObject,
        long idChild,
        uint dwEventThread,
        uint dwmsEventTime
        );
}

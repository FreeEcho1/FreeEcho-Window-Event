namespace FEWindowEventSample;

internal static class NativeMethodsDelegate
{
    public delegate void WinEventDelegate(
        System.IntPtr hWinEventHook,
        uint eventType,
        System.IntPtr hwnd,
        long idObject,
        long idChild,
        uint dwEventThread,
        uint dwmsEventTime
        );
}

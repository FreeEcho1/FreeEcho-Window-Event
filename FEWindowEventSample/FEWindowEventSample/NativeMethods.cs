namespace FEWindowEventSample;

internal static class NativeMethods
{
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern System.IntPtr SetWinEventHook(
        uint eventMin,
        uint eventMax,
        System.IntPtr hmodWinEventProc,
        NativeMethodsDelegate.WinEventDelegate lpfnWinEventProc,
        uint idProcess,
        uint idThread,
        uint dwFlags
        );
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    public static extern bool UnhookWinEvent(
        System.IntPtr hWinEventHook
        );
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    public static extern bool IsWindow(
        System.IntPtr hWnd
        );
    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    private static extern int GetWindowLong32(
        System.IntPtr hWnd,
        int nIndex
        );
    [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
    private static extern System.IntPtr GetWindowLongPtr64(
        System.IntPtr hWnd,
        int nIndex
        );
    public static long GetWindowLongPtr(
        System.IntPtr hWnd,
        int nIndex
        )
    {
        if (System.IntPtr.Size == 8)
        {
            return ((long)GetWindowLongPtr64(hWnd, nIndex));
        }
        else
        {
            return (GetWindowLong32(hWnd, nIndex));
        }
    }
    [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
    public static extern int DwmGetWindowAttribute(
        System.IntPtr hWnd,
        uint dwAttribute,
        out bool pvAttribute,
        int cbAttribute
        );
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    public static extern bool IsWindowVisible(System.IntPtr hWnd);
    [System.Runtime.InteropServices.DllImport("user32.dll", ExactSpelling = true)]
    public static extern System.IntPtr GetAncestor(System.IntPtr hwnd, GetAncestorFlags flags);
}

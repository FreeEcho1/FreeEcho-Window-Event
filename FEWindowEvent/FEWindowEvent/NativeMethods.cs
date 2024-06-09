using System;
using System.Runtime.InteropServices;

namespace FreeEcho.FEWindowEvent;

internal static class NativeMethods
{
    [DllImport("user32.dll")]
    public static extern IntPtr SetWinEventHook(
        uint eventMin,
        uint eventMax,
        IntPtr hmodWinEventProc,
        NativeMethodsDelegate.WinEventProcDelegate lpfnWinEventProc,
        uint idProcess,
        uint idThread,
        uint dwFlags
        );
    [DllImport("user32.dll")]
    public static extern bool UnhookWinEvent(
        IntPtr hWinEventHook
        );
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWindow(
        IntPtr hWnd
        );
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public extern static bool IsWindowEnabled(IntPtr hWnd);
    [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
    private static extern int GetWindowLong32(
        IntPtr hWnd,
        int nIndex
        );
    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
    private static extern IntPtr GetWindowLongPtr64(
        IntPtr hWnd,
        int nIndex
        );
    public static long GetWindowLongPtr(
        IntPtr hWnd,
        int nIndex
        )
    {
        if (IntPtr.Size == 8)
        {
            return (GetWindowLongPtr64(hWnd, nIndex));
        }
        else
        {
            return (GetWindowLong32(hWnd, nIndex));
        }
    }
    [DllImport("dwmapi.dll")]
    public static extern int DwmGetWindowAttribute(
        IntPtr hWnd,
        uint dwAttribute,
        out bool pvAttribute,
        int cbAttribute
        );
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool IsWindowVisible(IntPtr hWnd);
    [DllImport("user32.dll", ExactSpelling = true)]
    public static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestorFlags flags);
}

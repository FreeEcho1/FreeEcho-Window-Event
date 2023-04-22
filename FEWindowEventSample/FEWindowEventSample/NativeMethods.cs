using System.Runtime.InteropServices;
using System.Text;
using System;

namespace FEWindowEventSample;

internal static class NativeMethods
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
}

namespace FreeEcho.FEWindowEvent;

/// <summary>
/// ウィンドウイベントのデータ
/// </summary>
public class WindowEventArgs
{
    /// <summary>
    /// ウィンドウハンドル
    /// </summary>
    public System.IntPtr Hwnd;
    /// <summary>
    /// イベントの種類
    /// </summary>
    public uint EventType;
}

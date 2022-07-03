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
    /// ウィンドウイベントの種類
    /// </summary>
    public WindowEventType WindowEventType;
}

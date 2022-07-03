namespace FreeEcho.FEWindowEvent;

/// <summary>
/// フックするウィンドウイベントの種類
/// </summary>
public enum HookWindowEventType
{
    /// <summary>
    /// EVENT_SYSTEM_FOREGROUND
    /// </summary>
    Foreground = 1,
    /// <summary>
    /// EVENT_SYSTEM_MOVESIZESTART
    /// </summary>
    MoveSizeStart = 2,
    /// <summary>
    /// EVENT_SYSTEM_MOVESIZEEND
    /// </summary>
    MoveSizeEnd = 4,
    /// <summary>
    /// EVENT_SYSTEM_MINIMIZESTART
    /// </summary>
    MinimizeStart = 8,
    /// <summary>
    /// EVENT_SYSTEM_MINIMIZEEND
    /// </summary>
    MinimizeEnd = 16,
    /// <summary>
    /// EVENT_OBJECT_CREATE
    /// </summary>
    Create = 32,
    /// <summary>
    /// EVENT_OBJECT_DESTROY
    /// </summary>
    Destroy = 64,
    /// <summary>
    /// EVENT_OBJECT_SHOW
    /// </summary>
    Show = 128,
    /// <summary>
    /// EVENT_OBJECT_HIDE
    /// </summary>
    Hide = 256,
    /// <summary>
    /// EVENT_OBJECT_LOCATIONCHANGE
    /// </summary>
    LocationChange = 512,
    /// <summary>
    /// EVENT_OBJECT_NAMECHANGE
    /// </summary>
    NameChange = 1024
}

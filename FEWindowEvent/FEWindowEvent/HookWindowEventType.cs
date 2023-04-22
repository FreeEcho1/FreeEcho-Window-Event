namespace FreeEcho.FEWindowEvent;

/// <summary>
/// フックするウィンドウイベントの種類
/// </summary>
public enum HookWindowEventType
{
    /// <summary>
    /// EVENT_SYSTEM_FOREGROUND
    /// </summary>
    Foreground = 0x1,
    /// <summary>
    /// EVENT_SYSTEM_MOVESIZESTART
    /// </summary>
    MoveSizeStart = 0x2,
    /// <summary>
    /// EVENT_SYSTEM_MOVESIZEEND
    /// </summary>
    MoveSizeEnd = 0x4,
    /// <summary>
    /// EVENT_SYSTEM_MINIMIZESTART
    /// </summary>
    MinimizeStart = 0x8,
    /// <summary>
    /// EVENT_SYSTEM_MINIMIZEEND
    /// </summary>
    MinimizeEnd = 0x10,
    /// <summary>
    /// EVENT_OBJECT_CREATE
    /// </summary>
    Create = 0x20,
    /// <summary>
    /// EVENT_OBJECT_DESTROY
    /// </summary>
    Destroy = 0x40,
    /// <summary>
    /// EVENT_OBJECT_SHOW
    /// </summary>
    Show = 0x80,
    /// <summary>
    /// EVENT_OBJECT_HIDE
    /// </summary>
    Hide = 0x100,
    /// <summary>
    /// EVENT_OBJECT_LOCATIONCHANGE
    /// </summary>
    LocationChange = 0x200,
    /// <summary>
    /// EVENT_OBJECT_NAMECHANGE
    /// </summary>
    NameChange = 0x400,
}

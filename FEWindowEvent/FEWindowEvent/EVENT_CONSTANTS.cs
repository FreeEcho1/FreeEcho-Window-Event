namespace FreeEcho.FEWindowEvent;

/// <summary>
/// イベント定数
/// </summary>
public static class EVENT_CONSTANTS
{
    /// <summary>
    /// EVENT_MIN
    /// </summary>
    public const uint EVENT_MIN = 0x00000001;
    /// <summary>
    /// EVENT_SYSTEM_FOREGROUND
    /// </summary>
    public const uint EVENT_SYSTEM_FOREGROUND = 0x00000003;
    //EVENT_SYSTEM_MENUSTART = 0x00000004,
    //EVENT_SYSTEM_MENUEND = 0x00000005,
    //EVENT_SYSTEM_MENUPOPUPSTART = 0x00000006,
    //EVENT_SYSTEM_MENUPOPUPEND = 0x00000007,
    /// <summary>
    /// EVENT_SYSTEM_MOVESIZESTART
    /// </summary>
    public const uint EVENT_SYSTEM_MOVESIZESTART = 0x0000000a;
    /// <summary>
    /// EVENT_SYSTEM_MOVESIZEEND
    /// </summary>
    public const uint EVENT_SYSTEM_MOVESIZEEND = 0x0000000b;
    //EVENT_SYSTEM_CONTEXTHELPSTART = 0x0000000c,
    //EVENT_SYSTEM_CONTEXTHELPEND = 0x0000000d,
    //EVENT_SYSTEM_DIALOGSTART = 0x00000010,
    //EVENT_SYSTEM_DIALOGEND = 0x00000011,
    /// <summary>
    /// EVENT_SYSTEM_MINIMIZESTART
    /// </summary>
    public const uint EVENT_SYSTEM_MINIMIZESTART = 0x00000016;
    /// <summary>
    /// EVENT_SYSTEM_MINIMIZEEND
    /// </summary>
    public const uint EVENT_SYSTEM_MINIMIZEEND = 0x00000017;
    /// <summary>
    /// EVENT_OBJECT_CREATE
    /// </summary>
    public const uint EVENT_OBJECT_CREATE = 0x00008000;
    /// <summary>
    /// EVENT_OBJECT_DESTROY
    /// </summary>
    public const uint EVENT_OBJECT_DESTROY = 0x00008001;
    /// <summary>
    /// EVENT_OBJECT_SHOW
    /// </summary>
    public const uint EVENT_OBJECT_SHOW = 0x00008002;
    /// <summary>
    /// EVENT_OBJECT_HIDE
    /// </summary>
    public const uint EVENT_OBJECT_HIDE = 0x00008003;
    //EVENT_OBJECT_FOCUS = 0x00008005,
    //EVENT_OBJECT_STATECHANGE = 0x0000800a,
    /// <summary>
    /// EVENT_OBJECT_LOCATIONCHANGE
    /// </summary>
    public const uint EVENT_OBJECT_LOCATIONCHANGE = 0x0000800b;
    /// <summary>
    /// EVENT_OBJECT_NAMECHANGE
    /// </summary>
    public const uint EVENT_OBJECT_NAMECHANGE = 0x0000800c;
    /// <summary>
    /// EVENT_MAX
    /// </summary>
    public const uint EVENT_MAX = 0x7fffffff;
}

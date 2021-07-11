﻿namespace FreeEcho
{
    namespace FEWindowEvent
    {
        internal enum HOOK_EVENT : uint
        {
            EVENT_MIN = 0x00000001,
            EVENT_SYSTEM_FOREGROUND = 0x00000003,
            //EVENT_SYSTEM_MENUSTART = 0x00000004,
            //EVENT_SYSTEM_MENUEND = 0x00000005,
            //EVENT_SYSTEM_MENUPOPUPSTART = 0x00000006,
            //EVENT_SYSTEM_MENUPOPUPEND = 0x00000007,
            EVENT_SYSTEM_MOVESIZESTART = 0x0000000a,
            EVENT_SYSTEM_MOVESIZEEND = 0x0000000b,
            //EVENT_SYSTEM_CONTEXTHELPSTART = 0x0000000c,
            //EVENT_SYSTEM_CONTEXTHELPEND = 0x0000000d,
            //EVENT_SYSTEM_DIALOGSTART = 0x00000010,
            //EVENT_SYSTEM_DIALOGEND = 0x00000011,
            EVENT_SYSTEM_MINIMIZESTART = 0x00000016,
            EVENT_SYSTEM_MINIMIZEEND = 0x00000017,
            EVENT_OBJECT_CREATE = 0x00008000,
            EVENT_OBJECT_DESTROY = 0x00008001,
            EVENT_OBJECT_SHOW = 0x00008002,
            EVENT_OBJECT_HIDE = 0x00008003,
            //EVENT_OBJECT_FOCUS = 0x00008005,
            //EVENT_OBJECT_STATECHANGE = 0x0000800a,
            EVENT_OBJECT_LOCATIONCHANGE = 0x0000800b,
            EVENT_OBJECT_NAMECHANGE = 0x0000800c,
            EVENT_MAX = 0x7fffffff,
        }
    }
}
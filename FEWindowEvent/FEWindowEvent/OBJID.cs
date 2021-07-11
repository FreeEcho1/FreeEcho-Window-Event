﻿namespace FreeEcho
{
    namespace FEWindowEvent
    {
        internal enum OBJID : long
        {
            OBJID_WINDOW = 0x00000000,
            OBJID_SYSMENU = 0xFFFFFFFF,
            OBJID_TITLEBAR = 0xFFFFFFFE,
            OBJID_MENU = 0xFFFFFFFD,
            OBJID_CLIENT = 0xFFFFFFFC,
            OBJID_VSCROLL = 0xFFFFFFFB,
            OBJID_HSCROLL = 0xFFFFFFFA,
            OBJID_SIZEGRIP = 0xFFFFFFF9,
            OBJID_CARET = 0xFFFFFFF8,
            OBJID_CURSOR = 0xFFFFFFF7,
            OBJID_ALERT = 0xFFFFFFF6,
            OBJID_SOUND = 0xFFFFFFF5,
        }
    }
}

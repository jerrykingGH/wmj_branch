using System;
using UnityEngine;

namespace ET
{
    public static class MouseEventExtends
    {
        public static void AddEventListener(this GameObject self, string mouseEventType, Action handle, bool limit = false)
        {
            GSMouseEventTrigger trigger = self.GetComponent<GSMouseEventTrigger>();
            if (!trigger)
            {
                trigger = self.AddComponent<GSMouseEventTrigger>();
            }

            if (limit)
            {
                trigger.Limit = limit;
            }

            trigger.AddEvent(mouseEventType, handle);
        }
    }
}

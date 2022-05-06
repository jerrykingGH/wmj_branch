using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace ET
{
    public class GSMouseData
    {
        public static GameObject LastObjectMatched;
        public static GameObject LastObjectClicked;
        public static bool Enable = true;
    }

    public class GSMouseEventTrigger : MonoBehaviour
    {
        public bool Limit;
        public Dictionary<string, Action> Handles = new Dictionary<string, Action>();
        public EventTrigger Trigger;

        public void Awake()
        {
            Trigger = this.gameObject.GetComponent<EventTrigger>();

            if (Trigger == null)
            {
                Trigger = this.gameObject.AddComponent<EventTrigger>();
            }

            UnityAction<BaseEventData> MouseOverAction = new UnityAction<BaseEventData>(OnMouseOver);
            EventTrigger.Entry MouseOverEntry = new EventTrigger.Entry();
            MouseOverEntry.eventID = EventTriggerType.PointerEnter;
            MouseOverEntry.callback.AddListener(MouseOverAction);
            Trigger.triggers.Add(MouseOverEntry);

            UnityAction<BaseEventData> MouseOutAction = new UnityAction<BaseEventData>(OnMouseOut);
            EventTrigger.Entry MouseOutEntry = new EventTrigger.Entry();
            MouseOutEntry.eventID = EventTriggerType.PointerExit;
            MouseOutEntry.callback.AddListener(MouseOutAction);
            Trigger.triggers.Add(MouseOutEntry);

            UnityAction<BaseEventData> MouseClickAction = new UnityAction<BaseEventData>(OnMouseClick);
            EventTrigger.Entry MouseClickEntry = new EventTrigger.Entry();
            MouseClickEntry.eventID = EventTriggerType.PointerClick;
            MouseClickEntry.callback.AddListener(MouseClickAction);
            Trigger.triggers.Add(MouseClickEntry);

            UnityAction<BaseEventData> MouseUpAction = new UnityAction<BaseEventData>(OnMouseUp);
            EventTrigger.Entry MouseUpEntry = new EventTrigger.Entry();
            MouseUpEntry.eventID = EventTriggerType.PointerUp;
            MouseUpEntry.callback.AddListener(MouseUpAction);
            Trigger.triggers.Add(MouseUpEntry);

            UnityAction<BaseEventData> MouseDownAction = new UnityAction<BaseEventData>(OnMouseDown);
            EventTrigger.Entry MouseDownEntry = new EventTrigger.Entry();
            MouseDownEntry.eventID = EventTriggerType.PointerDown;
            MouseDownEntry.callback.AddListener(MouseDownAction);
            Trigger.triggers.Add(MouseDownEntry);

        }


        public void AddEvent(string mouseEventType, Action handle)
        {
            Handles.Add(mouseEventType, handle);
        }

        public void OnMouseOver(BaseEventData e)
        {            
            if (Handles.ContainsKey("Mouse_Over"))
            {
                
                if (this.Limit == true)
                {
                    if (GSMouseData.Enable)
                    {
                        GSMouseData.LastObjectMatched = this.gameObject;
                        Handles["Mouse_Over"].Invoke();
                    }
                }
                else
                {
                    GSMouseData.LastObjectMatched = this.gameObject;
                    Handles["Mouse_Over"].Invoke();
                }                
            }
        }

        public void OnMouseOut(BaseEventData e)
        {
            if (Handles.ContainsKey("Mouse_Out"))
            {
                if (this.Limit == true)
                {
                    if (GSMouseData.Enable)
                    {
                        GSMouseData.LastObjectMatched = this.gameObject;
                        Handles["Mouse_Out"].Invoke();
                    }
                }
                else
                {
                    GSMouseData.LastObjectMatched = this.gameObject;
                    Handles["Mouse_Out"].Invoke();
                }                
            }
        }
        public void OnMouseClick(BaseEventData e)
        {
            if (Handles.ContainsKey("Mouse_Click"))
            {
                if (this.Limit == true)
                {
                    if (GSMouseData.Enable)
                    {
                        GSMouseData.LastObjectMatched = this.gameObject;
                        GSMouseData.LastObjectClicked = this.gameObject;
                        Handles["Mouse_Click"].Invoke();
                    }
                }
                else
                {
                    GSMouseData.LastObjectMatched = this.gameObject;
                    GSMouseData.LastObjectClicked = this.gameObject;
                    Handles["Mouse_Click"].Invoke();
                }                
            }
        }
        public void OnMouseUp(BaseEventData e)
        {
            if (Handles.ContainsKey("Mouse_Up"))
            {
                if (this.Limit == true)
                {
                    if (GSMouseData.Enable)
                    {
                        GSMouseData.LastObjectMatched = this.gameObject;
                        Handles["Mouse_Up"].Invoke();
                    }
                }
                else
                {
                    GSMouseData.LastObjectMatched = this.gameObject;
                    Handles["Mouse_Up"].Invoke();
                }                
            }
        }
        public void OnMouseDown(BaseEventData e)
        {
            if (Handles.ContainsKey("Mouse_Down"))
            {
                if (this.Limit == true)
                {
                    if (GSMouseData.Enable)
                    {
                        GSMouseData.LastObjectMatched = this.gameObject;
                        GSMouseData.LastObjectClicked = this.gameObject;
                        Handles["Mouse_Down"].Invoke();
                    }
                }
                else
                {
                    GSMouseData.LastObjectMatched = this.gameObject;
                    GSMouseData.LastObjectClicked = this.gameObject;
                    Handles["Mouse_Down"].Invoke();
                }                
            }
        }
    }
}


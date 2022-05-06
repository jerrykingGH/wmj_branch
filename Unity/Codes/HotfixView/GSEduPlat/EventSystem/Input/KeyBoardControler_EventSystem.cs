using UnityEngine;
using System;

namespace ET
{
    [ObjectSystem]
    public class KeyBoardControler_AwakeEventSystem : AwakeSystem<KeyBoardControler_Component>
    {
        public override void AwakeAsync(KeyBoardControler_Component self)
        {
            self.Clear();
        }
    }

    [ObjectSystem]
    public class KeyBoardControler_UpdateEventSystem : UpdateSystem<KeyBoardControler_Component>
    {
        public override void Update(KeyBoardControler_Component self)
        {
            self.GetKeyCode();
            self.DealTimer();
            self.DealKeyBoardInfo();
        }
    }

    public static class KeyBoardControler_Extends
    {
        /* ===================================================================================
         *                  GetKeyCode 方法, 根据键盘操作组合tempCode;
         * ===================================================================================*/
        public static void GetKeyCode(this KeyBoardControler_Component self)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.PageUp))
                {
                    self.StartTimer();
                    self.tempCode += "Up ";
                }

                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.PageDown))
                {
                    self.StartTimer();
                    self.tempCode += "Dn ";
                }
            }
        }

        /* ===================================================================================
         *                  StartTimer 方法,根据DELAY_TIME开始计时
         * ===================================================================================*/

        public static void StartTimer(this KeyBoardControler_Component self)
        {
            if (self.tempCode == string.Empty)
            {
                self.currentDelay = KeyBoardControler_Component.DELAY_TIME;
                self.timerOn = true;
            }
        }

        /* ===================================================================================
         *                              计时器处理方法
         * ===================================================================================*/
        public static void DealTimer(this KeyBoardControler_Component self)
        {
            if (self.timerOn)
            {
                if (self.currentDelay <= 0f)
                {
                    // 超时
                    self.timerOn = false;
                    self.currentDelay = KeyBoardControler_Component.DELAY_TIME;
                }
                else
                {
                    // 未超时
                    self.currentDelay -= Time.deltaTime;
                }
            }
        }

        /* ===================================================================================
         *                              处理键盘输入信息
         * ===================================================================================*/
        public static void DealKeyBoardInfo(this KeyBoardControler_Component self)
        {
            if (self.tempCode.Length == 3)
            {
                if (self.timerOn == false)
                {
                    if (self.tempCode == "Up ")
                    {
                        KeyBoardControler_Component.KEYBOARD_EVENT = "Single Click Up";                        
                        
                        if (self.Handles.ContainsKey(GSKeyBoardEventType.Single_Click_Up))
                        {
                            self.Handles[GSKeyBoardEventType.Single_Click_Up].Invoke();
                        }
                    }

                    if (self.tempCode == "Dn ")
                    {
                        KeyBoardControler_Component.KEYBOARD_EVENT = "Single Click Down";
                        
                        if (self.Handles.ContainsKey(GSKeyBoardEventType.Single_Click_Down))
                        {
                            self.Handles[GSKeyBoardEventType.Single_Click_Down].Invoke();
                        }                        
                    }
                    self.tempCode = "";
                }
            }

            if (self.tempCode.Length == 6)
            {
                self.timerOn = false;

                if (self.tempCode == "Up Up ")
                {
                    KeyBoardControler_Component.KEYBOARD_EVENT = "Double Click Up";                    
                    
                    if (self.Handles.ContainsKey(GSKeyBoardEventType.Double_Click_Up))
                    {
                        self.Handles[GSKeyBoardEventType.Double_Click_Up].Invoke();
                    }
                }

                if (self.tempCode == "Dn Dn ")
                {
                    KeyBoardControler_Component.KEYBOARD_EVENT = "Double Click Down";                    
                    
                    if (self.Handles.ContainsKey(GSKeyBoardEventType.Double_Click_Down))
                    {
                        self.Handles[GSKeyBoardEventType.Double_Click_Down].Invoke();
                    }
                }

                self.tempCode = "";
            }
        }

        public static void AddEventListener(this KeyBoardControler_Component self, string keyboardevent, Action handle)
        {            
            if (self.Handles.ContainsKey(keyboardevent) == false)
            {
                self.Handles.Add(keyboardevent, handle);
            }
            else
            {
                Log.Error($"键盘交互 {keyboardevent} 已存在，请检查代码");
            }
        }

        public static void Clear(this KeyBoardControler_Component self)
        {
            self.tempCode = "";
            KeyBoardControler_Component.KEYBOARD_EVENT = "";
        }
    }
}

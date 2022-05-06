using System;
using System.Collections.Generic;

namespace ET
{    
    public class KeyBoardControler_Component : Entity,IAwake,IUpdate
    {
        public static string KEYBOARD_EVENT = "";        

        public string tempCode = "";

        public const float DELAY_TIME = 0.2F;
        public float currentDelay = 0;
        public bool timerOn = false;

        public Dictionary<string,Action> Handles = new Dictionary<string,Action>();
    }
}

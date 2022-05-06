using BM;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class MainPageScene_Component : Entity, IAwake,IDestroy
    {
        public LoadHandler loadHandler;
        public List<LoadHandler> Cell_LoadHandler = new List<LoadHandler> ();
        public string CurrentContentType = "";

        public GameObject
                LeftContainer,
                TopContainer,
                BottomContainer,
                MainContainer,

                Left,
                Top,
                Bottom,
                Main;

        public UI
                UI_Left,
                UI_Top,
                UI_Bottom,
                UI_Main;
    }
}

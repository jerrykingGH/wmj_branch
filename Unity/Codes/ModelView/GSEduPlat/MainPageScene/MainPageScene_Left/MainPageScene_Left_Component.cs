using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class MainPageScene_Left_Component : Entity, IAwake
    {
        public MainPageScene_Component ParentComponent;

        public Text IdText;
        public Text UserNameText;
        public Text ContentTitle;
        public Text TimerText;

        public List<GameObject> BtnGroup;
        public List<GameObject> BtnTexture;
        public List<GameObject> BtnText;
        public List<GameObject> BtnTouchArea;
    }
}

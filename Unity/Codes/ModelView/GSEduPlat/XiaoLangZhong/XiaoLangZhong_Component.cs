using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using BM;

namespace ET
{
    public struct XueWei
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public string Efficacy { get; set; }
        public Vector3[] PointPosition { get; set; }
    }

    public class XiaoLangZhong_Component:Entity,IAwake,IUpdate,IDestroy
    {
        public LoadHandler MainHandler;
        public List<LoadHandler> loadHandlers = new List<LoadHandler>();
        public string AssetBundleName;

        public int BackLessonSelectedIndex;        

        #region XiaoLangZhong1 变量;
        public List<XueWei> XueWeiInfo;
        public float InfoWidth;
        public bool InfoIsOn = false;

        public Animator animator;
        public Text LeftAnimInfo;
        public Text RightAnimInfo;
        public GameObject CenterContainer;
        public GameObject Center;
        public GameObject LeftContainer;
        public GameObject Left;
        public GameObject RightContainer;
        public GameObject Right;
        public GameObject InfoGO;
        public RectTransform InfoRT;
        public GameObject TitleClick;
        public Text InfoText;
        public Text EfficacyText;
        public Text TitleText;
        public Text TitleShadowText;
        public string AnimationInfo1;
        public string AnimationInfo2;
        public string AnimationInfo3;
        public string AnimationInfo4;
        public int CurrentXueWei = 0;

        public GameObject NextBtn;
        public GameObject PrevBtn;
        public GameObject QuitBtn;
        #endregion

    }
}

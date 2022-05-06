using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.UI;
using BM;

namespace ET
{
    [ObjectSystem]
    public class Lesson_001_2_AwakeSystem : AwakeSystem<Lesson_001_2>
    {
        public override void AwakeAsync(Lesson_001_2 self)
        {
            // 此课有粒子，需要改变ui渲染方式，记得用完复原;
            self.GetParent<UI>().GameObject.GetComponentInParent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
            self.GetParent<UI>().GameObject.GetComponentInParent<Canvas>().worldCamera = GlobalComponent.Instance.Global.Find("UICamera").gameObject.GetComponent<Camera>();

            // 添加键盘控制组件
            KeyBoardControler_Component kb = self.AddComponent<KeyBoardControler_Component>();
            kb.AddEventListener(GSKeyBoardEventType.Single_Click_Up, self.OnSingleClickUp);
            kb.AddEventListener(GSKeyBoardEventType.Single_Click_Down, self.OnSingleClickDown);
            kb.AddEventListener(GSKeyBoardEventType.Double_Click_Up, self.OnDoubleClickUp);
            kb.AddEventListener(GSKeyBoardEventType.Double_Click_Down, self.OnDoubleClickDown);

            // 获取rc
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self._animator = rc.Get<Animator>("BG");

            self.PanZiGroup1 = rc.Get<CanvasGroup>("PanziRoot1");
            self.PanZiGroup2 = rc.Get<CanvasGroup>("PanziRoot2");

            self.PanZi1 = rc.Get<GameObject>("panzi1");
            self.PanZi2 = rc.Get<GameObject>("panzi2");

            self.InfoContent1 = rc.Get<GameObject>("Content_1");
            self.InfoContent2 = rc.Get<GameObject>("Content_2");

            self.ContentImg1 = self.InfoContent1.transform.Find("ContentImg").gameObject;
            self.ContentImg2 = self.InfoContent2.transform.Find("ContentImg").gameObject;

            self.RenShenInfo1 = rc.Get<GameObject>("TextCover1").transform.Find("TextBG").gameObject;
            self.RenShenInfo2 = rc.Get<GameObject>("TextCover2").transform.Find("TextBG").gameObject;


            // 盘子1添加鼠标交互
            self.PanZi1.AddEventListener(GSMouseEventType.MouseOver, self.OnMouseOver, true);
            self.PanZi1.AddEventListener(GSMouseEventType.MouseOut, self.OnMouseOut, true);
            self.PanZi1.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick, true);

            // 盘子2添加鼠标交互
            self.PanZi2.AddEventListener(GSMouseEventType.MouseOver, self.OnMouseOver, true);
            self.PanZi2.AddEventListener(GSMouseEventType.MouseOut, self.OnMouseOut, true);
            self.PanZi2.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick, true);

            // 详情1添加鼠标交互
            self.InfoContent1.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick, true);
            self.ContentImg1.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick,true);

            // 详情2添加鼠标交互
            self.InfoContent2.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick, true);
            self.ContentImg2.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick, true);

            // 退出按钮添加鼠标交互
            self.QuitBtn = rc.Get<GameObject>("BackButton");
            self.QuitBtn.AddEventListener(GSMouseEventType.MouseClick, self.Quit);            

            self.HandleStr = "Ready";
        }
    }

    [ObjectSystem]
    public class Lesson_001_2_UpdateSystem : UpdateSystem<Lesson_001_2>
    {
        public override void Update(Lesson_001_2 self)
        {
            if (self.HandleStr != "")
            {
                switch (self.HandleStr)
                {
                    case "Ready":
                        self.HandleStr = "Start";                        
                        break;
                    case "Start":
                        self.PlayAnimation("RenShen_PanZiIn");
                        self.HandleStr = "";
                        break;                    
                }                
            }            
        }
    }
    [ObjectSystem]
    public class Lesson_001_2_DestroySystem : DestroySystem<Lesson_001_2>
    {
        public override void Destroy(Lesson_001_2 self)
        {
            self.loadHandler.UnLoad();
            AssetComponent.UnLoadPackageAssets("Lesson_001_2");
        }
    }
}

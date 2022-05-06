using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [ObjectSystem]
    public class MainPage_Left_AwakeEventSystem : AwakeSystem<MainPageScene_Left_Component>
    {
        public override void AwakeAsync(MainPageScene_Left_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.TimerText = rc.Get<Text>("TimerText");
            self.IdText = rc.Get<Text>("ID");
            self.UserNameText = rc.Get<Text>("UserName");
            self.ContentTitle = rc.Get<Text>("Text");

            self.TimerText.text = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日";

            self.ContentTitle.text = "首页";

            #region 按钮初始化
            self.BtnGroup = new List<GameObject>();
            self.BtnTexture = new List<GameObject>();
            self.BtnText = new List<GameObject>();
            self.BtnTouchArea = new List<GameObject>();

            self.BtnGroup.Add(rc.Get<GameObject>("FirstPageBtn"));
            self.BtnGroup.Add(rc.Get<GameObject>("XiaoLangZhongBtn"));
            self.BtnGroup.Add(rc.Get<GameObject>("KeJianBtn"));

            for (int i = 0; i < self.BtnGroup.Count; i++)
            {
                self.BtnTexture.Add(self.BtnGroup[i].transform.Find("Texture/BtnTexture1").gameObject);
                self.BtnTexture.Add(self.BtnGroup[i].transform.Find("Texture/BtnTexture2").gameObject);
                self.BtnText.Add(self.BtnGroup[i].transform.Find("Text/Text1").gameObject);
                self.BtnText.Add(self.BtnGroup[i].transform.Find("Text/Text2").gameObject);
                self.BtnTouchArea.Add(self.BtnGroup[i].transform.Find("BtnCover").gameObject);
            }

            self.BackAllButton();
            self.SelectOneButton(0);

            for (int i = 0; i < self.BtnTouchArea.Count; i++)
            {
                self.BtnTouchArea[i].AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick);
            }

            #endregion
        }
    }
}

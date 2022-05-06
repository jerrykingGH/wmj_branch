using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public class ListCell_AwakeEventSystem : AwakeSystem<ListCell_Component>
    {
        public override void AwakeAsync(ListCell_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.PicDataBase = rc.Get<GameObject>("ImageDataBase").GetComponent<ReferenceCollector>();
            rc.Get<GameObject>("LoadFengmianBtn").GetComponent<Button>().onClick.AddListener(self.OnClickIcon);
            rc.Get<GameObject>("DownloadBtn").GetComponent<Button>().onClick.AddListener(self.OnClickDownLoad);

            self.ProgressCircle = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>().Get<Image>("DownloadProgress");
            self.ProgressIcon = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>().Get<Image>("DownLoadIcon");

            self.Start = true;            
        }
    }

    public class ListCell_UpdateEventSystem : UpdateSystem<ListCell_Component>
    {
        public override void Update(ListCell_Component self)
        {
            if (self.Start)
            {
                // 等待ID赋值
                if (self.LessonID != 0)
                {
                    self.Start = false;
                    self.Refreshing = true;
                }
            }

            #region 初始化刷新图标
            if (self.Refreshing)
            {
                self.Refreshing = false;

                ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();                

                Contents_Config ContentData = Contents_ConfigCategory.Instance.Get(self.LessonID);

                // 设置图片                
                rc.Get<Image>("BG").overrideSprite = self.PicDataBase.Get<Sprite>("FengMian_" + (self.LessonID - 1001));

                // 设置文字

                string lessonName = ContentData.Name;
                int grade = ContentData.Grade;
                int term = ContentData.Term;                

                rc.Get<Text>("LessonName").text = "《" + lessonName + "》";

                string tempText = "";
                switch (grade)
                {
                    case 1:
                        tempText += "一年级";
                        break;
                    case 2:
                        tempText += "二年级";
                        break;
                    case 3:
                        tempText += "三年级";
                        break;
                    case 4:
                        tempText += "四年级";
                        break;
                    case 5:
                        tempText += "五年级";
                        break;
                    case 6:
                        tempText += "六年级";
                        break;
                    case 7:
                        tempText += "七年级";
                        break;
                    case 8:
                        tempText += "八年级";
                        break;
                }

                tempText += "  ";

                switch (term)
                {
                    case 1:
                        tempText += "(上)";
                        break;
                    case 2:
                        tempText += "(下)";
                        break;
                }

                tempText += "  ";

                tempText += "第" + ContentData.Num + "课";

                rc.Get<Text>("LessonIndex").text = tempText;


                // 设置斜标
                string typeName = ContentData.TypeName;
                switch (typeName)
                {
                    case "整体观念":
                        rc.Get<Image>("Type").overrideSprite = self.PicDataBase.Get<Sprite>("Main_3");
                        break;
                    case "辨证论治":
                        rc.Get<Image>("Type").overrideSprite = self.PicDataBase.Get<Sprite>("Main_5");
                        break;
                    case "治未病":
                        rc.Get<Image>("Type").overrideSprite = self.PicDataBase.Get<Sprite>("Main_1");
                        break;
                    case "君臣佐使":
                        rc.Get<Image>("Type").overrideSprite = self.PicDataBase.Get<Sprite>("Main_0");
                        break;
                    case "药食同源":
                        rc.Get<Image>("Type").overrideSprite = self.PicDataBase.Get<Sprite>("Main_4");
                        break;
                    case "阴阳五行":
                        rc.Get<Image>("Type").overrideSprite = self.PicDataBase.Get<Sprite>("Main_2");
                        break;
                }

                // Loading图标去掉
                rc.Get<GameObject>("DefaultIcon").SetActive(false);

                // 根据存档显示可用图标
                string developed = GSRunningData.LessonDeveloped;
                string save = GSRunningData.LessonDownLoaded;
                string permit = GSRunningData.Permit;

                //Log.Info($"save = {save.Substring(self.LessonID - 1001, 1)}; permit={permit.Substring(self.LessonID - 1001, 1)}");                

                if ( permit.Substring(self.LessonID - 1001, 1) == "1" && save.Substring(self.LessonID - 1001, 1) == "1")
                {
                    self.SetActive();
                }               
            }
            #endregion

            #region 下载进度刷新
            if (self.DownLoading)
            {
                self.ProgressCircle.fillAmount = self.updateBundleDataInfo.Progress / 100;
                self.ProgressIcon.fillAmount = self.updateBundleDataInfo.Progress / 100;
                
                if (self.updateBundleDataInfo.Progress >= 100)
                {
                    self.DownLoading = false;
                    self.SetActive();
                }
            }
            #endregion
        }
    }
}

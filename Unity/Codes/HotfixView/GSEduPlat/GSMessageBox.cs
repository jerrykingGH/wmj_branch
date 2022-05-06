using BM;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class GSMessageBox
    {
        public static async ETTask<GSMessageBoxResultType> Show(GSMessageBoxType messageType,string ContentInfo,GSMessageBoxResultType[] BtnGroup = null)
        {
            //GameObject temp = (GameObject)ResourcesComponent.Instance.GetAsset("Common".StringToAB(), "UIMessageBox");
            GameObject temp = AssetComponent.Load<GameObject>(out GSRunningData.MsgBoxHandler, "Assets/Res/GSEduPlat/Common/MessageBox/UIMessageBox.prefab", "Common");
            GameObject messageBox = GameObject.Instantiate(temp, GlobalComponent.Instance.UI.Find("High"));
            messageBox.name = "MessageBox";

            #region 设置--------------------
            ReferenceCollector rc = messageBox.GetComponent<ReferenceCollector>();
            rc.Get<GameObject>("MessageBox").transform.localScale = new Vector3(Screen.width / 2134f, Screen.width / 2134f, 1);            

            ReferenceCollector IconRC = messageBox.GetComponent<ReferenceCollector>().Get<GameObject>("IconDataBase").GetComponent<ReferenceCollector>();

            string tempStr = "";
            for (int i = 0; i < ContentInfo.Length; i++)
            {
                tempStr += ContentInfo.Substring(i, 1) + " ";
            }

            switch (messageType)
            {
                case GSMessageBoxType.Warning:
                    rc.Get<GameObject>("IconShadow").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 0));
                    rc.Get<GameObject>("Icon").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 0));
                    rc.Get<Text>("HeadText").text = "警告";
                    rc.Get<Text>("TypeText").text = "系 统 警 告";
                    rc.Get<Text>("InfoText").text ="\u3000\u3000 "+ tempStr;                    
                    break;
                case GSMessageBoxType.Help:
                    rc.Get<GameObject>("IconShadow").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 1));
                    rc.Get<GameObject>("Icon").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 1));
                    rc.Get<Text>("HeadText").text = "帮助";
                    rc.Get<Text>("TypeText").text = "帮 助 提 示";
                    rc.Get<Text>("InfoText").text = "\u3000\u3000 " + tempStr;
                    break;
                case GSMessageBoxType.Error:
                    rc.Get<GameObject>("IconShadow").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 2));
                    rc.Get<GameObject>("Icon").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 2));
                    rc.Get<Text>("HeadText").text = "错误";
                    rc.Get<Text>("TypeText").text = "系 统 错 误";
                    rc.Get<Text>("InfoText").text = "\u3000\u3000 " + tempStr;
                    break;
                case GSMessageBoxType.Update:
                    rc.Get<GameObject>("IconShadow").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 3));
                    rc.Get<GameObject>("Icon").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 3));
                    rc.Get<Text>("HeadText").text = "更新";
                    rc.Get<Text>("TypeText").text = "更 新 提 示";
                    rc.Get<Text>("InfoText").text = "\u3000\u3000 " + tempStr;
                    break;
                case GSMessageBoxType.Notice:
                    rc.Get<GameObject>("IconShadow").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 4));
                    rc.Get<GameObject>("Icon").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 4));
                    rc.Get<Text>("HeadText").text = "提醒";
                    rc.Get<Text>("TypeText").text = "系 统 提 醒";
                    rc.Get<Text>("InfoText").text = "\u3000\u3000 " + tempStr;
                    break;
                case GSMessageBoxType.Information:
                    rc.Get<GameObject>("IconShadow").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 5));
                    rc.Get<GameObject>("Icon").GetComponent<Image>().overrideSprite = IconRC.Get<Sprite>("MessageBox_Asset_" + (3 + 5));
                    rc.Get<Text>("HeadText").text = "消息";
                    rc.Get<Text>("TypeText").text = "系 统 消 息";
                    rc.Get<Text>("InfoText").text = "\u3000\u3000 " + tempStr;
                    break;
            }

            rc.Get<GameObject>("CloseButton").AddEventListener(GSMouseEventType.MouseClick,GSMessageBox.Comfirm_Cancel);

            Dictionary<GSMessageBoxResultType, string> ResultToText = new Dictionary<GSMessageBoxResultType, string>();
            ResultToText.Add(GSMessageBoxResultType.Yes,        "是");
            ResultToText.Add(GSMessageBoxResultType.Cancel,     "取  消");
            ResultToText.Add(GSMessageBoxResultType.Quit,       "退  出");
            ResultToText.Add(GSMessageBoxResultType.No,         "否");
            ResultToText.Add(GSMessageBoxResultType.Confirm,    "确  定");            

            if (BtnGroup != null)
            {
                for (int i = 0; i < BtnGroup.Length; i++)
                {
                    rc.Get<GameObject>("Btn" + i).SetActive(true);
                    rc.Get<GameObject>("Btn"+i).transform.Find("BtnImg/Text").GetComponent<Text>().text = ResultToText[BtnGroup[i]];
                    switch (BtnGroup[i])
                    {
                        case GSMessageBoxResultType.Yes:
                            rc.Get<GameObject>("Btn" + i).transform.Find("BtnImg").gameObject.AddEventListener(GSMouseEventType.MouseClick, GSMessageBox.Comfirm_Yes);
                            break;
                        case GSMessageBoxResultType.No:
                            rc.Get<GameObject>("Btn" + i).transform.Find("BtnImg").gameObject.AddEventListener(GSMouseEventType.MouseClick, GSMessageBox.Comfirm_No);
                            break;
                        case GSMessageBoxResultType.Quit:
                            rc.Get<GameObject>("Btn" + i).transform.Find("BtnImg").gameObject.AddEventListener(GSMouseEventType.MouseClick, GSMessageBox.Comfirm_Quit);
                            break;
                        case GSMessageBoxResultType.Cancel:
                            rc.Get<GameObject>("Btn" + i).transform.Find("BtnImg").gameObject.AddEventListener(GSMouseEventType.MouseClick, GSMessageBox.Comfirm_Cancel);
                            break;
                        case GSMessageBoxResultType.Confirm:
                            rc.Get<GameObject>("Btn" + i).transform.Find("BtnImg").gameObject.AddEventListener(GSMouseEventType.MouseClick, GSMessageBox.Comfirm_Comfirm);
                            break;
                    }
                    
                }
            }
            else
            {
                rc.Get<GameObject>("Btn0").transform.Find("BtnImg/Text").GetComponent<Text>().text = "确  定";
                rc.Get<GameObject>("Btn0").transform.Find("BtnImg").gameObject.AddEventListener(GSMouseEventType.MouseClick, GSMessageBox.Comfirm_Comfirm);
            }

            #endregion            

            GSMessageBoxResultType result = GSMessageBoxResultType.None;

            while (true)
            {
                await TimerComponent.Instance.WaitAsync(1);
                if (GSRunningData.MessageBoxComfirm != GSMessageBoxResultType.None)
                {
                    result = GSRunningData.MessageBoxComfirm;
                    GSRunningData.MessageBoxComfirm = GSMessageBoxResultType.None;
                    GameObject.Destroy(messageBox);
                    GSRunningData.MsgBoxHandler.UnLoad();
                    break;
                }
            }
            await TimerComponent.Instance.WaitAsync(500);
            return result;
        }

        public static void Comfirm_Yes()
        {
            GSRunningData.MessageBoxComfirm = GSMessageBoxResultType.Yes;
        }

        public static void Comfirm_Cancel()
        {
            GSRunningData.MessageBoxComfirm = GSMessageBoxResultType.Cancel;
        }

        public static void Comfirm_Quit()
        {
            GSRunningData.MessageBoxComfirm = GSMessageBoxResultType.Quit;
        }

        public static void Comfirm_No()
        {
            GSRunningData.MessageBoxComfirm = GSMessageBoxResultType.No;
        }

        public static void Comfirm_Comfirm()
        {
            GSRunningData.MessageBoxComfirm = GSMessageBoxResultType.Confirm;
        }
    }
}

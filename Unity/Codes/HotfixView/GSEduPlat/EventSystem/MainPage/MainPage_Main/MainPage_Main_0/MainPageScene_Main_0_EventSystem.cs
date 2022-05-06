using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine.UI;
using BM;

namespace ET
{
    [ObjectSystem]
    public class MainPageScene_Main_0_AwakeEventSystem : AwakeSystem<MainPageScene_Main_0_Component>
    {
        public override void AwakeAsync(MainPageScene_Main_0_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.BannerDisplayContainer = rc.Get<GameObject>("BannerDisplayContainer");
            self.BannerUpContainer = rc.Get<GameObject>("BannerUpContainer");
            self.BannerDownContainer = rc.Get<GameObject>("BannerDownContainer");
            self.BroadCastContainer = rc.Get<GameObject>("BroardCastContainer");

            #region 设置首页广告图-----------------------------------------------------------------------------------------------
            self.AutoDisplayBanner = true;

            self.CurrentShowTime = self.BannerShowTime[0];

            for (int i = 0; i < self.BannerNum; i++)
            {
                self.BannerTemp.Add(AssetComponent.Load<GameObject>(out LoadHandler handler, BPath.UIMainPagePath + "Prefabs/Banner/Banner" + i + ".prefab", "MainPageScene"));
                self.CellHandler.Add(handler);
            }
            
            self.Display = GameObject.Instantiate(self.BannerTemp[0], self.BannerDisplayContainer.transform);
            self.MotionUp = GameObject.Instantiate(self.BannerTemp[0], self.BannerUpContainer.transform);
            
            self.MotionDown = GameObject.Instantiate(self.BannerTemp[1], self.BannerDownContainer.transform);

            for (int i = 0; i < self.BannerNum; i++)
            {
                GameObject tip = rc.Get<GameObject>("Tip" + i);

                self.TipNormal.Add(tip.transform.Find("Tip1_Normal").gameObject);
                self.TipSelect.Add(tip.transform.Find("Tip1_Select").gameObject);

                GameObject touchArea = tip.transform.Find("Tip1_ClickArea").gameObject;
                touchArea.AddEventListener(GSMouseEventType.MouseOver, self.Tip_OnMouseOver);
                touchArea.AddEventListener(GSMouseEventType.MouseOut, self.Tip_OnMouseOut);                

                tip.SetActive(true);
            }

            self.BackAllTip();
            self.SelectOneTip(0);
            #endregion ----------------------------------------------------------------------------------------------------------


            #region 跑马灯效果---------------------------------------------------------------------------------------------------
            self.BroadCast = new List<GameObject>();        // 记录广播GO
            self.BroadCastCanMove = new List<bool>();       // 广播移动开关
            self.BroadCastWidth = new List<float>();        // 记录广播的宽度
            self.BroadCastContainerWidth = self.BroadCastContainer.GetComponent<RectTransform>().rect.width; // 记录广播运动的宽度

            // 创建跑马灯内容
            for (int i = 0; i < self.BroadCastNum; i++)
            {
                self.BroadCastTemp.Add(AssetComponent.Load<GameObject>(out LoadHandler handler, BPath.UIMainPagePath + "Prefabs/BroadCast/BroadCast" + i + ".prefab", "MainPageScene"));
                self.CellHandler.Add(handler);
                
                GameObject paomadeng = GameObject.Instantiate(self.BroadCastTemp[i], self.BroadCastContainer.transform);

                self.BroadCast.Add(paomadeng);
                self.BroadCastCanMove.Add(false);
                self.BroadCastWidth.Add(paomadeng.GetComponent<RectTransform>().rect.width);

                paomadeng.transform.localPosition = new Vector3(self.BroadCastContainerWidth / 2, 0, 0);
            }
            // 第一个开始移动
            self.BroadCastCanMove[0] = true;
            #endregion           
            
        }
    }
    [ObjectSystem]
    public class MainPageScene_Main_0_UpdateEventSystem : UpdateSystem<MainPageScene_Main_0_Component>
    {
        public override void Update(MainPageScene_Main_0_Component self)
        {
            #region Banner自动滚屏
            if (self.AutoDisplayBanner == true)
            {
                if (self.CurrentShowTime <= 0f)
                {
                    #region 复制Display到Up
                    GameObject.Destroy(self.BannerUpContainer.transform.GetChild(0).gameObject);                                   
                    self.MotionUp = GameObject.Instantiate(self.BannerTemp[self.BannerIndex], self.BannerUpContainer.transform);
                    self.BannerUpContainer.GetComponent<CanvasGroup>().alpha = 1;
                    self.BannerUpContainer.SetActive(true);
                    #endregion

                    #region 确定需要显示的BannerIndex
                    self.BannerIndex += 1;
                    if (self.BannerIndex >= self.BannerNum)
                    {
                        self.BannerIndex = 0;
                    }
                    #endregion

                    #region 复制需要显示Banner的到Down
                    GameObject.Destroy(self.BannerDownContainer.transform.GetChild(0).gameObject);                    
                    self.MotionDown = GameObject.Instantiate(self.BannerTemp[self.BannerIndex], self.BannerDownContainer.transform);
                    self.BannerDownContainer.GetComponent<CanvasGroup>().alpha = 1;
                    //self.BannerDownContainer.SetActive(true);
                    #endregion

                    #region 消失Display
                    self.BannerDisplayContainer.SetActive(false);
                    #endregion

                    #region 开始动效
                    self.CurrentShowTime = self.BannerShowTime[self.BannerIndex];
                    self.BackAllTip();
                    self.SelectOneTip(self.BannerIndex);

                    self.BannerUpContainer.GetComponent<CanvasGroup>()
                        .DOFade(0f, self.TransTime)
                        .OnComplete(() =>
                        {
                            GameObject.Destroy(self.BannerDisplayContainer.transform.GetChild(0).gameObject);
                            self.Display = GameObject.Instantiate(self.BannerTemp[self.BannerIndex], self.BannerDisplayContainer.transform);
                            self.BannerDisplayContainer.SetActive(true);
                        });
                    #endregion                    
                }
                self.CurrentShowTime -= Time.deltaTime;
            }
            #endregion

            #region 跑马灯
            for (int i = 0; i < self.BroadCastNum; i++)
            {
                if (self.BroadCastCanMove[i])
                {

                    if (self.BroadCast[i].transform.localPosition.x <= self.BroadCastContainerWidth / 2 - self.BroadCastStep - self.BroadCastWidth[i])
                    {
                        if (i == self.BroadCastNum - 1)
                        {
                            self.BroadCastCanMove[0] = true;
                        }
                        else
                        {
                            self.BroadCastCanMove[i + 1] = true;
                        }
                    }

                    if (self.BroadCast[i].transform.localPosition.x <= -self.BroadCastContainerWidth / 2f - self.BroadCastWidth[i])
                    {
                        self.BroadCastCanMove[i] = false;
                        self.BroadCast[i].transform.localPosition = new Vector3(self.BroadCastContainerWidth / 2, 0, 0);
                    }
                    else
                    {
                        self.BroadCast[i].transform.localPosition += Vector3.left * self.BroadCastSpeed;
                    }
                }
            }
            #endregion
        }
    }

    [ObjectSystem]
    public class MainPageScene_Main_0_DestroyEventSystem : DestroySystem<MainPageScene_Main_0_Component>
    {
        public override void Destroy(MainPageScene_Main_0_Component self)
        {
            self.DomainScene().GetComponent<UIComponent>().UIs.Remove("MainPage_Index");

            for (int i = 0; i < self.CellHandler.Count; i++)
            {
                self.CellHandler[i].UnLoad();                
            }

            self.loadHandler.UnLoad();
        }
    }

}

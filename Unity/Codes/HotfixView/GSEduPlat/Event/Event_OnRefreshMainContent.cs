using ET;
using UnityEngine;
using System.Collections.Generic;
using BM;

namespace ET
{
    public class Event_OnRefreshMainContent : AEvent<GSEventType.RefreshMainPageContent>
    {
        protected override async ETTask Run(GSEventType.RefreshMainPageContent args)
        {
            Log.Warning($"【 主界面 主显示部分刷新内容 开始】");

            #region 接收参数 ==========================================================

            // 判断需要创建的主区域预制体
            string CreateUIType = args.MainContentType;
            
            Log.Info("接收参数结束。。。");

            #endregion


            #region 删除之前选项卡UI，并回收内存;======================================
            string hisContentType = ((MainPageScene_Component)args.MainPageScrip).CurrentContentType;

            if (hisContentType == args.MainContentType)
            {
                return;
            }
            else
            {
                if (hisContentType != "")
                {
                    args.ZoneScene.GetComponent<UIComponent>().UIs[hisContentType].Dispose();
                    args.ZoneScene.GetComponent<UIComponent>().UIs.Remove(hisContentType);
                    args.MainPageScrip.GetParent<UI>().Remove(hisContentType);
                }
            }                                             
            Log.Info("删除旧选项卡内容完成。。。");

            #endregion


            #region 根据类型创建主界面主要显示区的UI;==================================
            GameObject temp = null;
            switch (args.MainContentType)
            {
                case "MainPage_Index":
                    temp = AssetComponent.Load<GameObject>(out LoadHandler handler_Index,BPath.UIMainPagePath + "Prefabs/MainPage_Main_0.prefab", "MainPageScene");
                    GameObject indexGO = GameObject.Instantiate(temp, ((MainPageScene_Component)args.MainPageScrip).MainContainer.transform);
                    UI indexUI = args.ZoneScene.GetComponent<UIComponent>().AddChild<UI, string, GameObject>(args.MainContentType, indexGO);
                    args.MainPageScrip.GetParent<UI>().Add(indexUI);                    
                    args.ZoneScene.GetComponent<UIComponent>().UIs.Add(args.MainContentType, indexUI);
                    indexUI.AddComponent<MainPageScene_Main_0_Component>().loadHandler = handler_Index;
                    ((MainPageScene_Component)args.MainPageScrip).CurrentContentType = args.MainContentType;
                    break;
                case "MainPage_LessonList":                    
                    temp = AssetComponent.Load<GameObject>(out LoadHandler handler_LessonList,BPath.UIMainPagePath + "Prefabs/MainPage_Main_1.prefab", "MainPageScene");
                    GameObject listGO = GameObject.Instantiate(temp, ((MainPageScene_Component)args.MainPageScrip).MainContainer.transform);
                    UI listUI = args.ZoneScene.GetComponent<UIComponent>().AddChild<UI, string, GameObject>(args.MainContentType, listGO);
                    args.MainPageScrip.GetParent<UI>().Add(listUI);                    
                    args.ZoneScene.GetComponent<UIComponent>().UIs.Add(args.MainContentType, listUI);
                    listUI.AddComponent<MainPageScene_Main_1_Component>().loadHandler = handler_LessonList;
                    ((MainPageScene_Component)args.MainPageScrip).CurrentContentType = args.MainContentType;
                    break;
                default:
                    Log.Error("在主界面主要显示区域的显示中，输入了无效的参数");
                    break;
            }
            #endregion

            Log.Warning($"【 主界面 主显示部分刷新内容 结束】");

            await ETTask.CompletedTask;
        }
    }
}

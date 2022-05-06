namespace ET
{
    public class Event_OnCreateLoading : AEvent<GSEventType.CreateLoading>
    {
        protected override async ETTask Run(GSEventType.CreateLoading args)
        {
            Log.Error("你来到了不该来的地方");
            // 创建LoadingUI
            UI ui = await GSUIHelper.Create(args.ZoneScene, GSUIType.UILoadingScene, UILayer.High);
            ui.AddComponent<LoadingScene_Component>();


            #region 删除或隐藏之前显示的UI内容
            //if (GSRunningData.HisTargetNeedRemove.Count > 0)
            //{                
            //    foreach (var target in GSRunningData.HisTargetNeedRemove)
            //    {
            //        if (target.Value == null)
            //        {
            //            await GSUIHelper.Remove(args.ZoneScene, target.Key);
            //        }
            //        else
            //        {
            //            target.Value.transform.SetParent(GlobalComponent.Instance.UI.Find("Hidden"));
            //        }

            //    }
            //    GSRunningData.HisTargetNeedRemove.Clear();
            //}
            #endregion


            #region 创建新的显示UI内容

            //UI ui;
            //switch (GSRunningData.Target)
            //{
            //    case GSUIType.UIMainPageScene:
            //        await GSUIHelper.Create(args.ZoneScene, GSUIType.UIMainPageScene, UILayer.Mid);
            //        break;
            //    case GSUIType.UILessonScene:
            //        await GSUIHelper.Create(args.ZoneScene, GSUIType.UILessonScene, UILayer.Mid);
            //        break;
            //    case GSUIType.UIXiaoLangZhongScene:
            //        await GSUIHelper.Create(args.ZoneScene, GSUIType.UIXiaoLangZhongScene, UILayer.Mid);
            //        break;
            //    case GSUIType.UIYinShiYuJianKangScene:
            //        await GSUIHelper.Create(args.ZoneScene, GSUIType.UIYinShiYuJianKangScene, UILayer.Mid);
            //        break;
            //    case GSUIType.UIMovieScene:
            //        await GSUIHelper.Create(args.ZoneScene, GSUIType.UIMovieScene, UILayer.Mid);
            //        break;
            //}

            #endregion


            //LoadingScene_Component LoadingData = null;
            //LoadingData = GlobalComponent.Instance.GetComponent<LoadingScene_Component>();
            //if(LoadingData == null)
            //{
            //    LoadingData = GlobalComponent.Instance.AddComponent<LoadingScene_Component>();
            //}            

            //if (GSRunningData.HisTarget == GSUIType.UIMovieScene)
            //{
            //    await GSUIHelper.Remove(args.ZoneScene, GSUIType.UIMovieScene);
            //    LoadingData.UIInHidden.GameObject.transform.SetParent(GlobalComponent.Instance.UI.Find("Mid"));
            //    LoadingData.UIInMid = LoadingData.UIInHidden;
            //    LoadingData.UIInHidden = null;
            //}
            //else
            //{
            //    if (GSRunningData.Target != GSUIType.UIMovieScene)
            //    {                    
            //        await GSUIHelper.Remove(args.ZoneScene, GSRunningData.HisTarget);
            //        for (int i = 0; i < GSRunningData.UnUseABList.Count; i++)
            //        {                        
            //            ResourcesComponent.Instance.UnloadBundle(GSRunningData.UnUseABList[i].StringToAB());
            //        }                    
            //        GSRunningData.UnUseABList.Clear();
            //    }                

            //    UI ui;
            //    switch (GSRunningData.Target)
            //    {
            //        case GSUIType.UIMainPageScene:
            //            await GSUIHelper.Create(args.ZoneScene, GSUIType.UIMainPageScene, UILayer.Mid);
            //            break;
            //        case GSUIType.UILessonScene:
            //            ui = await GSUIHelper.Create(args.ZoneScene, GSUIType.UILessonScene, UILayer.Mid);
            //            LoadingData.UIInMid = ui;
            //            break;                    
            //        case GSUIType.UIXiaoLangZhongScene:
            //            await GSUIHelper.Create(args.ZoneScene, GSUIType.UIXiaoLangZhongScene, UILayer.Mid);
            //            break;
            //        case GSUIType.UIYinShiYuJianKangScene:
            //            await GSUIHelper.Create(args.ZoneScene, GSUIType.UIYinShiYuJianKangScene, UILayer.Mid);
            //            break;
            //        case GSUIType.UIMovieScene:

            //            LoadingData.UIInHidden = LoadingData.UIInMid;
            //            LoadingData.UIInHidden.GameObject.transform.SetParent(GlobalComponent.Instance.UI.Find("Hidden"));
            //            LoadingData.UIInMid = null;                        
            //            await GSUIHelper.Create(args.ZoneScene, GSUIType.UIMovieScene, UILayer.Mid);                        
            //            break;
            //    }
            //}            

            //await TimerComponent.Instance.WaitAsync(500);

            // 检测内存
            //GSDebug_Helper.Show_UIComponent_UIs(args.ZoneScene);
            //GSDebug_Helper.Show_ABInfo_In_Memory();

            //await GSUIHelper.Remove(args.ZoneScene, GSUIType.UILoadingScene);

        }
    }
}

using BM;
using UnityEngine;

namespace ET
{
    [UIEvent(GSUIType.UIMainPageScene)]
    public class UIEvent_MainPage : AUIEvent
    {        
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {            
            AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
            AssetComponentConfig.DefaultBundlePackageName = "MainPageScene";
            // 初始化MainPageScene包
            await AssetComponent.Initialize("MainPageScene", GSPassWord.MainPage);
            GameObject MainPagePrefab = await AssetComponent.LoadAsync<GameObject>(out LoadHandler handler,BPath.UIMainPagePath + "UIMainPage.prefab", "MainPageScene");
            // 添加包名到资源删除列表列表
            GSRunningData.HistTaget.Add(GSUIType.UIMainPageScene, true);

            GameObject MainPage = GameObject.Instantiate(MainPagePrefab, UIEventComponent.Instance.UILayers[(int)uiLayer]);
            UI ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UILoadingScene, MainPage);

            ui.AddComponent<MainPageScene_Component>().loadHandler = handler;
            
            return ui;            
        }

        public override void OnRemoveAsync(UIComponent uiComponent)
        {
            
        }
    }
}

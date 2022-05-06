using UnityEngine;
using BM;
namespace ET
{
    [UIEvent(GSUIType.UILoadingScene)]
    public class UIEvent_Loading : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {            
            GameObject LoadingPrefab = await AssetComponent.LoadAsync<GameObject>(out LoadHandler handler,"Assets/Res/GSEduPlat/Common/Loading/UILoading.prefab","Common");            
            GameObject Loading = GameObject.Instantiate(LoadingPrefab, UIEventComponent.Instance.UILayers[(int)uiLayer]);
            UI ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UILoadingScene, Loading);
            ui.AddComponent<LoadingScene_Component>().handler = handler;
            return ui;            
        }

        public override void OnRemoveAsync(UIComponent uiComponent)
        {           
            //Log.Warning("在Loading结束后检测=======================================");            
            GSDebug_Helper.Show_UIComponent_UIs(uiComponent);
            //Log.Warning("以上为检测结果============================================");
        }
    }    
}

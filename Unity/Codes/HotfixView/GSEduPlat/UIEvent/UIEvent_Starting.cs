using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    [UIEvent(GSUIType.UIStartingScene)]
    public class UIEvent_Starting : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ResourcesComponent.Instance.LoadBundleAsync(GSUIType.UIStartingScene.ToLower().StringToAB());
            GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset(GSUIType.UIStartingScene.ToLower().StringToAB(), GSUIType.UIStartingScene);            
            GameObject gameObject = GameObject.Instantiate(bundleGameObject, UIEventComponent.Instance.UILayers[(int)uiLayer]);
            UI ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UIStartingScene, gameObject);
            ui.AddComponent<StartingScene_Component>();
            return ui;
        }

        public override void OnRemoveAsync(UIComponent uiComponent)
        {
            ResourcesComponent.Instance.UnloadBundle(GSUIType.UIStartingScene.StringToAB());
        }
    }
}

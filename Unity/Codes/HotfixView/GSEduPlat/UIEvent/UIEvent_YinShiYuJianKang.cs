using UnityEngine;
using BM;
namespace ET
{
    [UIEvent(GSUIType.UIYinShiYuJianKangScene)]
    public class UIEvent_YinShiYuJianKang : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            string mainBundleName = "YinShiYuJianKang";
            await AssetComponent.Initialize(mainBundleName,GSPassWord.YinShiYuJianKang);
            GameObject mainGameObjectTemp = AssetComponent.Load<GameObject>(out LoadHandler handler,"Assets/Res/GSEduPlat/YinShiYuJianKang/YinShiYuJianKang.prefab", mainBundleName);
            GameObject main = GameObject.Instantiate(mainGameObjectTemp, UIEventComponent.Instance.UILayers[(int)uiLayer]);
            UI ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UIYinShiYuJianKangScene, main);
            YinShiYuJianKang_Component ysyjk_Script = ui.AddComponent<YinShiYuJianKang_Component>();
            ysyjk_Script.mainHandler = handler;
            ysyjk_Script.BackLessonSelectedIndex = GSRunningData.Lesson_SelectedIndex;

            //string uiBundleName = "YinShiYuJianKang";
            //await ResourcesComponent.Instance.LoadBundleAsync(uiBundleName.StringToAB());
            ////GSRunningData.UnUseABList.Add(uiBundleName);

            //GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset(uiBundleName.StringToAB(), uiBundleName);
            //GameObject gameObject = GameObject.Instantiate(bundleGameObject, UIEventComponent.Instance.UILayers[(int)uiLayer]);
            //UI ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UIYinShiYuJianKangScene, gameObject);
            //ui.AddComponent<YinShiYuJianKang_Component>();
            return ui;
        }

        public override void OnRemoveAsync(UIComponent uiComponent)
        {

        }
    }
}


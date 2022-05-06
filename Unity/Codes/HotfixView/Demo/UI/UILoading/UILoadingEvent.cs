using System;
using UnityEngine;

namespace ET
{
	//[UIEvent(UIType.UILoading)]
 //   public class UILoadingEvent: AUIEvent
 //   {
 //       public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
 //       {
	//		Log.Warning("注意了，这里调用了Demo里面的UILoading代码");
	//        try
	//        {
	//	        await ETTask.CompletedTask;
	//			GameObject bundleGameObject = ((GameObject)Resources.Load("KV")).Get<GameObject>(UIType.UILoading);
	//			GameObject go = UnityEngine.Object.Instantiate(bundleGameObject);
	//			go.layer = LayerMask.NameToLayer(LayerNames.UI);
	//			UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.UILoading, go);

	//			ui.AddComponent<UILoadingComponent>();
	//			return ui;
	//        }
	//        catch (Exception e)
	//        {
	//			Log.Error(e);
	//	        return null;
	//        }
	//	}

 //       public override void OnRemove(UIComponent uiComponent)
 //       {
 //       }
 //   }
}
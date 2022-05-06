using UnityEngine;
using UnityEngine.UI;
namespace ET
{
    [ObjectSystem]
    public class StartingScene_AwakeSystem : AwakeSystem<StartingScene_Component>
    {
        public override void AwakeAsync(StartingScene_Component self)
        {            
            ReferenceCollector rc= self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.NextBtn = rc.Get<GameObject>("Button").GetComponent<Button>();            
            self.NextBtn.onClick.AddListener(self.Test);            
        }
    }

    public static class StartingSceneExtends
    {
        public static async void Test(this StartingScene_Component self)
        {
            // 传入数据
            GSRunningData.Target = GSUIType.UIMainPageScene;
            
            await GSUIHelper.Create(self.DomainScene(),GSUIType.UILoadingScene,UILayer.High);
            await GSUIHelper.Remove(self.DomainScene(), GSUIType.UIStartingScene);            
        }
    }
}

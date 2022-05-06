using UnityEngine.UI;

namespace ET
{
    public class MainPage_Bottom_AwakeEventSystem : AwakeSystem<MainPageScene_Bottom_Component>
    {
        public override void AwakeAsync(MainPageScene_Bottom_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            rc.Get<Text>("CopyRightText").text = self.CopyRightInfo;
            rc.Get<Text>("VersionText").GetComponent<Text>().text = GSRunningData.Version;
        }
    }
}

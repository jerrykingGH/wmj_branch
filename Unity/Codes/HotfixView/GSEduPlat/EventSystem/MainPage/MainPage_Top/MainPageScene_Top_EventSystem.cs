using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class MainPageScene_AwakeEventSystem : AwakeSystem<MainPageScene_Top_Component>
    {
        public override void AwakeAsync(MainPageScene_Top_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            rc.Get<GameObject>("ExitButton").AddEventListener(GSMouseEventType.MouseClick, self.AppQuit);
        }
    }

    public static class MainPageScene_Top_Extend
    {
        public static async void AppQuit(this MainPageScene_Top_Component self)
        {            
            GSMessageBoxResultType result = await GSMessageBox.Show(GSMessageBoxType.Notice, "您即将退出果盛教育课件平台，请确认您的操作。",new GSMessageBoxResultType[]{  GSMessageBoxResultType.Confirm, GSMessageBoxResultType.Cancel});

            if (result == GSMessageBoxResultType.Confirm)
            {
                Application.Quit();
            }            
        }
    }
}

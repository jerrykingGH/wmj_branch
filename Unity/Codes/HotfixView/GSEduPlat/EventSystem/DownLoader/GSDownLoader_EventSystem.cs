using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [ObjectSystem]
    public class GSDownLoader_AwakeEventSystem : AwakeSystem<GSDownLoader_Component>
    {
        public override void AwakeAsync(GSDownLoader_Component self)
        {
            self.Starting_Script = GlobalComponent.Instance.Global.Find("BundleMaster/UIStarting(Clone)").GetComponent<GSStarting>();

            self.rc = GlobalComponent.Instance.Global.Find("BundleMaster/UIStarting(Clone)").GetComponent<ReferenceCollector>();

            //self.Progress = self.rc.Get<GameObject>("FillArea").GetComponent<RectTransform>();            

            self.UpdateInfoText = self.rc.Get<GameObject>("Text").GetComponent<Text>();
        }
    }

    [ObjectSystem]
    public class GSDownLoader_UpdateEventSystem : UpdateSystem<GSDownLoader_Component>
    {
        public override void Update(GSDownLoader_Component self)
        {
            if (self.DownLoadIsProgressing)
            {
                // 刷新更新进度
                self.UpdateInfoText.text = "正 在 下 载 课 件 资 源 包";

                self.Starting_Script.SetProgress(self.updateBundleDataInfo.Progress / 100 * (1f - self.TotalProgressDegree));                

                if (self.updateBundleDataInfo.Progress >= 100)
                {
                    self.DownLoadIsProgressing = false;                    
                }
            }            
        }
    }
}

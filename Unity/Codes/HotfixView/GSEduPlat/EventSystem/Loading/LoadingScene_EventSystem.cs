using System.Collections.Generic;
using UnityEngine;
using BM;

namespace ET
{
    [ObjectSystem]
    public class LoadingScene_AwakeSystem : AwakeSystem<LoadingScene_Component>
    {
        public override async void AwakeAsync(LoadingScene_Component self)
        {
            Log.Warning($"【 Loading转接流程 开始】 当前跳转页面 {GSRunningData.Target}");

            #region 删除之前创建的界面
            if (GSRunningData.HistTaget.Count > 0)
            {
                List<string> removeKey = new List<string>();
                foreach (var ui in GSRunningData.HistTaget)
                {
                    if (ui.Value)
                    {
                        Log.Info($"删除UI界面{ui.Key}");
                        await GSUIHelper.Remove(self.DomainScene(),ui.Key);
                        removeKey.Add(ui.Key);
                        //GSRunningData.HistTaget.Remove(ui.Key);
                    }
                }
                if (removeKey.Count > 0)
                {
                    for (int i = 0; i < removeKey.Count; i++)
                    {
                        GSRunningData.HistTaget.Remove(removeKey[i]);
                    }
                }
            }
            #endregion

            #region 加载界面

            await GSUIHelper.Create(self.DomainScene(), GSRunningData.Target, UILayer.Mid);
            Log.Info("加载新界面完成。。。");

            #endregion

            #region 善后操作
            await TimerComponent.Instance.WaitAsync(500);            
            await GSUIHelper.Remove(self.DomainScene(), GSUIType.UILoadingScene);
            Log.Info("删除Loading界面完成。。。");
            #endregion

            Log.Warning($"【 Loading转接流程 结束】");
        }
    }
    [ObjectSystem]
    public class LoadingScene_DestroySystem : DestroySystem<LoadingScene_Component>
    {
        public override void Destroy(LoadingScene_Component self)
        {
            self.handler.UnLoad();            
        }
    }
}

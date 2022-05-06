using BM;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
    public class GSDownLoader_Component : Entity, IAwake, IUpdate
    {
        public GSStarting Starting_Script;                                                  // 获取Starting的脚本

        public ReferenceCollector rc;                                                       // 获取Starting上的ReferenceCollector        

        public Text UpdateInfoText;                                                         // 获取Starting上的Text组件

        public Dictionary<string, bool> UpdateList = new Dictionary<string, bool>();        // 包体更新列表

        public UpdateBundleDataInfo updateBundleDataInfo;                                   // 包体更新信息

        public bool DownLoadIsProgressing = false;                                          // 开始调整进度开关

        public float TotalProgressDegree = 0.03f;                                           // 总进度条进入时的初始值
    }
}

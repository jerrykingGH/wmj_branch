using BM;
using ET;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class GSLogo : MonoBehaviour
{
    public GSProgramInit ProgramInit_Script;

    // 网络检测
    private System.Net.NetworkInformation.Ping ping;
    private System.Net.NetworkInformation.PingReply pr;
    private bool CheckNetIsOn = false;
    private float CheckNetWaitTime = 3.0f;
    private float CheckNetCurrentTime = 0f;
    public bool NetActive = false;
    public bool CheckNetComplete = false;

    // Logo动画检测
    public bool CheckLogoAnim = false;

    void Start()
    {
        Debug.LogWarning("【 流程 1 开始】 1.播放Logo动画; 2.检查更新Starting资源; 3.前两项做完后，创建Starting界面");
        this.CheckNetState();        
    }

    void Update()
    {
        // 检测网络是否连接
        if (this.CheckNetIsOn)
        {
            if (pr.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                Debug.Log($"当前网络连接正常...");
                this.CheckNetIsOn = false;
                this.NetActive = true;
                this.CheckNetComplete = true;
            }
            else
            {
                // 无响应则增加等待时间
                this.CheckNetCurrentTime += Time.deltaTime;
                // 如在等待时间内无法连接服务器则判定为无网络连接
                if (this.CheckNetCurrentTime>= CheckNetWaitTime)
                {
                    Debug.Log($"当前无网络连接...");
                    this.CheckNetIsOn = false;
                    this.NetActive = false;
                    this.CheckNetComplete = true;
                }                           
            }
        }
        // 网络检测连接结束
        if (this.CheckNetComplete)
        {
            this.CheckNetComplete = false;

            GSSystemConfig.NetEnable = this.NetActive;

            this.CheckStartingStartingAsset();
        }

        // 检测Logo动画是否播放完毕
        if (this.CheckLogoAnim)
        {
            if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                this.CheckLogoAnim = false;
                this.CreateStartingScene();
                Destroy(this.gameObject);
                Debug.LogWarning("【 流程 1（完成）】");
            }                
        }
    }   


    // 检测网络连接，是否可以连到服务器
    private void CheckNetState()
    {
        this.ping = new System.Net.NetworkInformation.Ping();
        try
        {
            this.pr = ping.Send($"124.70.94.18", 3000);
            this.CheckNetIsOn = true;
        }
        catch (System.Exception)
        {
            this.NetActive = false;
            this.CheckNetComplete = true;
        }        
    }

    // 检查Starting界面是否需要更新
    private async void CheckStartingStartingAsset()
    {
        if (GSSystemConfig.NetEnable)
        {
            await this.UpdateStartingAsset();
        }
        // 配置热更下载目录
        AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
        AssetComponentConfig.DefaultBundlePackageName = "StartingScene";
        await AssetComponent.Initialize("StartingScene");

        this.CheckLogoAnim = true;
    }

    // 更新Starting界面资源
    private async ETTask UpdateStartingAsset()
    {
        // 配置资源服务器地址
        AssetComponentConfig.BundleServerUrl = GSSystemConfig.GSBundlePathInServer;
        // 配置热更下载目录
        AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
        // 配置默认热更包名
        AssetComponentConfig.DefaultBundlePackageName = "StartingScene";
        // 建立热更包字典;
        Dictionary<string, bool> updatePackageBundle = new Dictionary<string, bool>()
                {
                    {"StartingScene", false}
                };
        // 检测字典中的包体是否需要更新
        UpdateBundleDataInfo updateBundleDataInfo = await AssetComponent.CheckAllBundlePackageUpdate(updatePackageBundle);
        // 需要更新
        if (updateBundleDataInfo.NeedUpdate)
        {
            // 更新Starting包体
            Debug.LogWarning("Strating需要更新，大小：" + updateBundleDataInfo.NeedUpdateSize);
            await AssetComponent.DownLoadUpdate(updateBundleDataInfo);
        }
    }

    // 创建Starting界面
    private void CreateStartingScene()
    {
        GameObject StartingPrefab = AssetComponent.Load<GameObject>(out LoadHandler handler,BPath.UIStartingPath + "UIStarting.prefab");
        GameObject Starting = GameObject.Instantiate(StartingPrefab, this.gameObject.transform.parent);
        GSStarting GSStarting_Script = Starting.AddComponent<GSStarting>();
        GSStarting_Script.ProgramInit_Script = this.ProgramInit_Script;
        GSStarting_Script.loadHandler = handler;
    }
}

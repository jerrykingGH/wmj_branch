using ET;
using BM;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class GSStarting : MonoBehaviour
{
    public GSProgramInit ProgramInit_Script;

    public LoadHandler loadHandler;

    private List<Image> BGImageList = new List<Image>();
    private int BGChangeIndex1 = 0;
    private int BGChangeIndex2 = 1;    
    private bool BGsChange = false;

    private float time = 0f;    
    private float totalTime = 4f;
    private float alphaDiff = 0.02f;    

    public bool isProgressing = false;
    public bool UpdateCompleted = false;

    public float BaseBundleProgressDegree = 0.03f;

    public RectTransform Progress;
    public Text UpdateInfoText;

    public UpdateBundleDataInfo CodeUpdateBundleDataInfo;

    private void Awake()
    {
        // 设置轮播图
        ReferenceCollector rc = this.GetComponent<ReferenceCollector>();
        Transform bgs = rc.Get<GameObject>("BGs").transform;
        for(int i = 0; i < bgs.childCount; i++)
        {
            this.BGImageList.Add(bgs.GetChild(i).GetComponent<Image>());
        }

        this.Progress = rc.Get<GameObject>("FillArea").GetComponent<RectTransform>();
        this.Progress.sizeDelta = new Vector2(0f, -7f);        

        this.UpdateInfoText = rc.Get<GameObject>("Text").GetComponent<Text>();

        this.BGsChange = true;
    }


    private void Start()
    {
        Debug.LogWarning("【 流程 2 开始】 1.检测更新 Code 和 Config包; 2.启动 ET 框架");

        // 如果有网络连接 则检测更新
        if (GSSystemConfig.NetEnable)
        {            
            this.CheckHotfix().Coroutine();
        }
        else
        {            
            this.isProgressing = false;
            this.UpdateCompleted = true;
        }
    }

    private void Update()
    {
        // 切换背景
        if (this.BGsChange)
        {
            if (this.BGImageList[this.BGChangeIndex1].color.a > 0f)
            {
                this.BGImageList[this.BGChangeIndex1].color += new Color(0, 0, 0, -this.alphaDiff);
            }

            if (this.BGImageList[this.BGChangeIndex2].color.a < 1f)
            {
                this.BGImageList[this.BGChangeIndex2].color += new Color(0, 0, 0, this.alphaDiff);
            }

            this.time += Time.deltaTime;
            if (this.time >= this.totalTime)
            {
                this.time = 0f;

                this.BGChangeIndex1++;
                this.BGChangeIndex2++;

                if (this.BGChangeIndex1 == 5)
                {
                    this.BGChangeIndex1 = 0;
                }
                if (this.BGChangeIndex2 == 5)
                {
                    this.BGChangeIndex2 = 0;
                }
            }
        }

        // 刷新更新进度
        if (this.isProgressing)
        {
            this.UpdateInfoText.text = "正 在 下 载 基 础 控 制 包";
            if (this.CodeUpdateBundleDataInfo.Progress / 100f * 1500f < 45)
            {
                this.SetProgress(0f);
            }
            else
            {
                this.SetProgress(this.CodeUpdateBundleDataInfo.Progress / 100f * this.BaseBundleProgressDegree);                
            }
            
            if (this.CodeUpdateBundleDataInfo.Progress >= 100)
            {
                this.isProgressing = false;
                this.SetProgress(0.03f);
                this.UpdateCompleted = true;
            }
        }

        // 更新完毕
        if (this.UpdateCompleted)
        {
            this.UpdateCompleted = false;
            
            Invoke("Start_ET_FrameWork", 1.5f);
        }
    }

    private void OnDestroy()
    {
        this.loadHandler.UnLoad();
        AssetComponent.UnLoadPackageAssets("StartingScene");
    }


    /// <summary>
    /// 检测并更新代码集
    /// </summary>
    /// <returns></returns>
    private async ETTask CheckHotfix()
    {
        // 重新配置热更路径
        AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
        AssetComponentConfig.DefaultBundlePackageName = "Code";


        // 添加包更新列表 Starting_Bundle之前已经检查过了，此处不再检查更新
        Dictionary<string, bool> updatePackageBundle = new Dictionary<string, bool>()
        {
            // 只检查代码包体
            {"Code", false},
            {"Config",false }
        };
        

        this.CodeUpdateBundleDataInfo = await AssetComponent.CheckAllBundlePackageUpdate(updatePackageBundle);
        if (this.CodeUpdateBundleDataInfo.NeedUpdate)
        {
            Debug.LogError("基础包体需要更新, 大小: " + this.CodeUpdateBundleDataInfo.NeedUpdateSize);
            AssetComponent.DownLoadUpdate(this.CodeUpdateBundleDataInfo).Coroutine();
            this.isProgressing = true;
        }
        else
        {
            this.Progress.sizeDelta = new Vector2(1500f * this.BaseBundleProgressDegree, -7);
            this.isProgressing = false;
            this.UpdateCompleted = true;
        }
    }

    /// <summary>
    /// 启动ET框架
    /// </summary>
    private void Start_ET_FrameWork()
    {
        this.Init_ET_FrameWork().Coroutine();
    }

    private async ETTask Init_ET_FrameWork()
    {
        AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
        AssetComponentConfig.DefaultBundlePackageName = "Code";

        await AssetComponent.Initialize("Code");        
        Debug.LogWarning("【 流程 2 （完成）】");
        this.ProgramInit_Script.gameObject.transform.parent.gameObject.AddComponent<Init>();
    }

    // 设置Loading的进度条
    public void SetProgress(float progress)
    {
        if (progress <= 1f)
        {
            if (progress <= 0.03f)
            {
                this.Progress.sizeDelta = new Vector2(0.03f * 1500f, -7f);
            }
            else
            {
                this.Progress.sizeDelta = new Vector2(progress * 1500f, -7f);
            }            
        }
    }
}

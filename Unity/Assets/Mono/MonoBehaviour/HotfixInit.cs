using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using ET;
using BM;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class HotfixInit : MonoBehaviour
{
    [SerializeField]
    private GameObject global;

    [SerializeField]
    private Animator startAnim;

    private Animator LogoAnim;

    private Slider progress;

    private bool isLoadingDone;

    
    private bool isProgress = false;
    private UpdateBundleDataInfo updateBundleDataInfo;

    void Start()
    {
        // 载入Logo动画
        GameObject LogoGameObject = Resources.Load("LogoAnim/UILogo") as GameObject;
        GameObject Logo = GameObject.Instantiate(LogoGameObject, this.transform);

        this.LogoAnim = Logo.GetComponent<Animator>();

        // Starting界面初始化
        this.StartingInitialization().Coroutine();
    }

    void Update()
    {
        // 刷新AssetsComponent
        AssetComponent.Update();

        if (this.LogoAnim)
        {
            if (this.LogoAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && this.isLoadingDone)
            {
                this.isLoadingDone = false;
                Destroy(this.LogoAnim.gameObject);
                this.InitStarting().Coroutine();
            }
        }

        if (this.isProgress)
        {
            this.progress.value = this.updateBundleDataInfo.Progress;
            if (this.progress.value >= 100)
            {
                this.isProgress = false;
                Invoke("DoInitAll", 0.2f);
            }
        }
    }

    /// <summary>
    /// 开始初始化
    /// </summary>
    /// <returns></returns>
    private async ETTask StartingInitialization()
    {
        await this.CheckStartingHotfix();        
    }

    /// <summary>
    /// 检查Starting界面更新
    /// </summary>
    /// <returns></returns>
    private async ETTask CheckStartingHotfix()
    {
        //重新配置热更路径
        AssetComponentConfig.BundleServerUrl = "http://124.70.94.18/GSEduPlat/";

        AssetComponentConfig.HotfixPath = Application.dataPath + "/../HotfixBundles/";

        AssetComponentConfig.DefaultBundlePackageName = "StartingScene";

        Dictionary<string, bool> updatePackageBundle = new Dictionary<string, bool>()
        {
            {AssetComponentConfig.DefaultBundlePackageName, false}
        };

        UpdateBundleDataInfo updateBundleDataInfo1 = await AssetComponent.CheckAllBundlePackageUpdate(updatePackageBundle);
        if (updateBundleDataInfo1.NeedUpdate)
        {
            Debug.LogError("LoadingPage需要更新, 大小: " + updateBundleDataInfo1.NeedUpdateSize);
            await AssetComponent.DownLoadUpdate(updateBundleDataInfo1);
        }
        await AssetComponent.Initialize("StartingScene", "GS2022@01.StartingScene");
        this.isLoadingDone = true;
    }


    private async ETTask CheckHotfix()
    {
        //重新配置热更路径
        AssetComponentConfig.HotfixPath = Application.dataPath + "/../HotfixBundles/";
        AssetComponentConfig.DefaultBundlePackageName = "Common";
        Dictionary<string, bool> updatePackageBundle = new Dictionary<string, bool>()
        {
            {AssetComponentConfig.DefaultBundlePackageName, false},
            {"Code", false},
            {"Config", false},
            //{"LoadingPage", false},
            {"UIMainpage", false},
            {"UILoading", false},
            //{"Config", false},
        };
        updateBundleDataInfo = await AssetComponent.CheckAllBundlePackageUpdate(updatePackageBundle);
        //UpdateBundleDataInfo updateBundleDataInfo = await AssetComponent.CheckAllBundlePackageUpdate(updatePackageBundle);
        if (updateBundleDataInfo.NeedUpdate)
        {
            Debug.LogError("需要更新, 大小: " + updateBundleDataInfo.NeedUpdateSize);
            AssetComponent.DownLoadUpdate(updateBundleDataInfo).Coroutine();
            this.isProgress = true;
        }else
        {
            this.progress.value = 100;
            Invoke("DoInitAll",0.2f);
            //this.progress.gameObject.SetActive(false);
        }
    }

    private void DoInitAll()
    {
        this.InitAll().Coroutine();
    }
    private async ETTask InitAll()
    {
        this.progress.gameObject.SetActive(false);
        await AssetComponent.Initialize(AssetComponentConfig.DefaultBundlePackageName);
        Debug.LogError("加载:code ");
        await AssetComponent.Initialize("Code");
        
        Debug.LogError("加载:Config ");
        await AssetComponent.Initialize("Config");
        
        Debug.LogError("加载:UILoading ");
        await AssetComponent.Initialize("UILoading");
        
        Debug.LogError("加载:UIMainpage ");
        await AssetComponent.Initialize("UIMainpage");
        
        okBtn.SetActive(true);
    }

    private GameObject okBtn;
    private async ETTask InitStarting()
    {
        Log.Info("???");
        //await CheckHotfix();
        /*
        //异步加载资源
        GameObject loginUIAsset = await AssetComponent.LoadAsync<GameObject>(out LoadHandler loginUIHandler, BPath.assets_res_gseduplat_startingScene_uistarting_prefab);
        GameObject loading = GameObject.Instantiate(loginUIAsset);
        progress = loading.transform.Find("ProcessSlider").GetComponent<Slider>();
        okBtn=loading.transform.Find("DownloadInfo/OKButton").gameObject;
        loading.transform.Find("Unload").GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.LogError("卸载:loading ");
            loginUIHandler.UnLoad();
            //GameObject loginUIAsset1 =  AssetComponent.Load<GameObject>(out LoadHandler loginUIHandler1, BPath.assets_res_gseduplat_loadingpage_loadingpage_prefab);

            Debug.LogError("卸载:loading ");
        });
        
        okBtn.GetComponent<Button>().onClick.AddListener(() =>
        {
            //卸载资源
            GameObject.Destroy(loading);
            loginUIHandler.UnLoad();
            global.SetActive(true);
            //LoadNewScene().Coroutine();
        });
        Destroy(GameObject.Find("Start"));
        await CheckHotfix();
        */
    }

    private async ETTask InitUI()
    {
        //异步加载资源
        GameObject loginUIAsset = await AssetComponent.LoadAsync<GameObject>(out LoadHandler loginUIHandler, BPath.assets_bundles_ui_uilogin_prefab);
        GameObject loginUIObj = UnityEngine.Object.Instantiate(loginUIAsset);
        loginUIObj.transform.Find("Panel/LoginBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            //卸载资源
            GameObject.Destroy(loginUIObj);
            loginUIHandler.UnLoad();
            global.SetActive(true);
            //LoadNewScene().Coroutine();
        });
    }

    private async ETTask LoadNewScene()
    {
        LoadSceneHandler loadSceneHandler = await AssetComponent.LoadSceneAsync(BPath.Assets_Scenes_Game__unity);
        //如果需要获取场景加载进度, 用这种加载方式 loadSceneHandler2.GetProgress() , 注意进度不是线性的
        // ETTask loadSceneHandlerTask = AssetComponent.LoadSceneAsync(out LoadSceneHandler loadSceneHandler2, "Assets/Scenes/Game.unity");
        // await loadSceneHandlerTask;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Game");
        operation.completed += asyncOperation =>
        {
            //同步加载资源(加载分包内的资源)
            //GameObject gameObjectAsset = AssetComponent.Load<GameObject>(BPath.Assets_Bundles_SubBundleAssets_mister91jiao__prefab, "SubBundle");
            BundleRuntimeInfo bundleRuntimeInfo = AssetComponent.GetBundleRuntimeInfo("SubBundle");
            GameObject gameObjectAsset = bundleRuntimeInfo.Load<GameObject>(BPath.Assets_Bundles_SubBundleAssets_mister91jiao__prefab);
            GameObject obj = UnityEngine.Object.Instantiate(gameObjectAsset);
            
            GameObject gameObjectAsset1 = AssetComponent.Load<GameObject>(BPath.Assets_Bundles_SubBundleAssets_mister91jiao__prefab);
            GameObject obj1 = UnityEngine.Object.Instantiate(gameObjectAsset1);
            
            //ResetUI().Coroutine();
        };
    }
    
}

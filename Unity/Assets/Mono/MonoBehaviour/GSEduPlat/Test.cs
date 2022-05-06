using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BM;
using UnityEngine.Video;

public class Test : MonoBehaviour
{
    public Text info;

    public LoadHandler handler;
    // Start is called before the first frame update
    void Start()
    {
        this.info = this.transform.Find("Text").GetComponent<Text>();

        this.transform.Find("initBundle").gameObject.AddComponent<Button>().onClick.AddListener(this.OnClickInit);
        this.transform.Find("UninitBundle").gameObject.AddComponent<Button>().onClick.AddListener(this.OnClickUnInit);
        this.transform.Find("loadBundle").gameObject.AddComponent<Button>().onClick.AddListener(this.OnClickLoad);
        this.transform.Find("UnloadBundle_Handler").gameObject.AddComponent<Button>().onClick.AddListener(this.OnClickUnload);
        this.transform.Find("UnloadBundle_AssetBundle").gameObject.AddComponent<Button>().onClick.AddListener(this.OnClickUnloadAsset);
        this.transform.Find("UnloadBundle_UnloadAll").gameObject.AddComponent<Button>().onClick.AddListener(this.OnClickUnloadAll);

        AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
        AssetComponentConfig.DefaultBundlePackageName = "MainPageScene";
        
    }

    // Update is called once per frame
    void Update()
    {
        AssetComponent.Update();
    }

    private async void OnClickInit()
    {
        this.info.text = "你点击了初始化";

        // 初始化MainPageScene包
        await AssetComponent.Initialize("Lesson_001_1");
    }

    private void OnClickUnInit()
    {
        this.info.text = "你点击了反初始化";
        AssetComponent.UnInitialize("Lesson_001_1");
    }

    private void OnClickLoad()
    {
        this.info.text = "你点击了加载";
        AssetComponent.Load<Texture2D>(out this.handler, "Assets/Res/GSEduPlat/LessonsScene/Lesson_001/Lesson_001_1/Testpic.png", "Lesson_001_1");
    }

    private void OnClickUnload()
    {
        this.info.text = "你点击了handler卸载";

        this.handler.UnLoad();
    }

    private void OnClickUnloadAsset()
    {
        this.info.text = "你点击了Asset卸载";

        AssetComponent.UnLoadPackageAssets("Lesson_001_1");
    }

    private void OnClickUnloadAll()
    {
        this.info.text = "你点击了All卸载";

        AssetComponent.UnLoadAllAssets();
    }
}

using System;
using System.Net.NetworkInformation;
using BM;
using UnityEngine;

namespace ET
{    
    public class GSAppStart_Init : AEvent<GSEventType.AppStart>
    {       
        protected override async ETTask Run(GSEventType.AppStart args)
        {
            Debug.LogWarning("【 流程 3 开始】 1.ET 框架初始化; 2.载入Code代码库; 3.更新所有资源文件; 4.定义跳转到MainPage的GSRunningData数据; 4.跳转Loading界面");            

            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();

            // 加载配置
            Game.Scene.AddComponent<ResourcesComponent>();

            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();

            Game.Scene.AddComponent<NetThreadComponent>();
            Game.Scene.AddComponent<SessionStreamDispatcher>();
            Game.Scene.AddComponent<ZoneSceneManagerComponent>();
            
            Game.Scene.AddComponent<ConfigComponent>();

            Game.Scene.AddComponent<GlobalComponent>();

            Game.Scene.AddComponent<AIDispatcherComponent>();            

            Scene zoneScene = SceneFactory.CreateZoneScene(1, "Game", Game.Scene);

            // ------------------自定义代码----------------------

            // 初始化环境变量,查询本地存储文件列表,以便获取需要更新的内容   打包前记得修改【GSRunningData.LessonDeveloped LessonDownLoaded】
            string DownLoaded_Save = PlayerPrefs.GetString("LessonDownLoaded");
            DownLoaded_Save = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";    // 初始化本地存储状态
            PlayerPrefs.SetString("LessonDownLoaded", DownLoaded_Save);
            if (string.IsNullOrEmpty(DownLoaded_Save))
            {
                DownLoaded_Save = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
                PlayerPrefs.SetString("LessonDownLoaded", DownLoaded_Save);
            }
            else
            {
                GSRunningData.LessonDownLoaded = DownLoaded_Save;
            }
            GSRunningData.LessonDeveloped = "11000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
            Log.Warning("刚进来: dowloaded = " + GSRunningData.LessonDownLoaded);
            Log.Warning("刚进来: permit = " + GSRunningData.Permit);
            Log.Warning("刚进来: developed = " + GSRunningData.LessonDeveloped);

            // 版本信息初始化 【打包前记得修改】
            GSRunningData.Version = "Version  0.4.021 Alpha";

            // 初始化热更时的下载目录，打包前记得修改【GSSystemConfig.GSFilelocation】
            AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";

            // 初始化Config
            AssetComponentConfig.DefaultBundlePackageName = "Config";
            await AssetComponent.Initialize("Config", GSPassWord.Config);

            await AssetComponent.LoadAsync<TextAsset>(out LoadHandler loginUIHandler1, BPath.ConfigPath + "Lessons_ConfigCategory.bytes", "Config");
            ConfigComponent.Instance.LoadOneConfig(typeof(Lessons_ConfigCategory));
            AssetComponent.UnLoad(loginUIHandler1);
            await AssetComponent.LoadAsync<TextAsset>(out LoadHandler loginUIHandler2, BPath.ConfigPath + "Contents_ConfigCategory.bytes", "Config");
            ConfigComponent.Instance.LoadOneConfig(typeof(Contents_ConfigCategory));
            AssetComponent.UnLoad(loginUIHandler2);            
            //Log.Error(Contents_ConfigCategory.Instance.Get(1001).Name); //配表信息检验完毕无问题
            //
            // 更新所有资源包
            if (GSSystemConfig.NetEnable)
            {
                GSDownLoader_Component downloader = Game.Scene.AddComponent<GSDownLoader_Component>();

                await downloader.UpdateAllBundles();
            }            

            // 初始化Loading所需要用到的包
            AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";            
            AssetComponentConfig.DefaultBundlePackageName = "Common";
            await AssetComponent.Initialize("Common", GSPassWord.Common);

            // 添加需要的其他组件
            //Game.Scene.AddComponent<SoundPlayer_Component>();


            // 初始化GSRunningData------------------------------------
             
            // 初始化选课界面需要显示的课程
            for (int i = 1; i <= 110; i++)
            {
                GSRunningData.LessonList.Add(1000+i);
            }           
            // 初始化进入UI的类型
            GSRunningData.Target = GSUIType.UIMainPageScene;

            // -------------------------------------------------------

            // 跳转Loading界面
            await GSUIHelper.Create(zoneScene, GSUIType.UILoadingScene, UILayer.High);

            // 删除Starting界面
            GameObject.Destroy(GlobalComponent.Instance.Global.Find("BundleMaster/UIStarting(Clone)").gameObject);            

            Debug.LogWarning("【 流程 3 （完成）】");

            Debug.LogWarning("【 进入课件主界面 】");
        }        
    }
}

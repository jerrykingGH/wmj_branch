using BM;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ET
{
    public static class GSDownLoader_Extend
    {
        public static async ETTask UpdateAllBundles(this GSDownLoader_Component self)
        {
            //重新配置热更路径
            
            AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";
            AssetComponentConfig.DefaultBundlePackageName = "Common";

            // 添加包更新列表
            self.Add_CommonBundle();                 // 添加 Common 包
            self.Add_MainPageBundle();               // 添加 MainPage 包
            self.Add_LessonXXXBundle();              // 添加 Lesson主界面 包
            self.Add_MovieBundle();                  // 添加 Movie播放器 包
            self.Add_XiaoLangZhongBundle();          // 添加 小郎中 通用包
            self.Add_YinShiYuJianKangBundle();       // 添加 饮食与健康 通用包            
            self.Add_LessonBundle();                 // 添加 Lesson资源 包

            self.updateBundleDataInfo = await AssetComponent.CheckAllBundlePackageUpdate(self.UpdateList);
            if (self.updateBundleDataInfo.NeedUpdate)
            {
                self.DownLoadIsProgressing = true;
                Debug.LogError("资源包体需要更新, 大小: " + self.updateBundleDataInfo.NeedUpdateSize);
                await AssetComponent.DownLoadUpdate(self.updateBundleDataInfo);
            }
            self.Starting_Script.SetProgress(1.0f);

            Log.Warning("资源包更新完毕。");                  
        }        

        // 添加Common的资源列表
        public static void Add_CommonBundle(this GSDownLoader_Component self)
        {
            self.UpdateList.Add("Common", false);            
        }

        // 添加MainPage的资源列表
        public static void Add_MainPageBundle(this GSDownLoader_Component self)
        {
            // 主界面的缩略图数量，测试定义为10，实际总量为110
            int Thumbnails_Num = 10;

            self.UpdateList.Add("MainPageScene", false);

            for (int i = 1; i <= Thumbnails_Num; i++)
            {
                self.UpdateList.Add("MainPage_Thumbnails_Lesson" + string.Format("{0:000}", i), false);
            }            
        }

        // 添加课件的资源列表
        public static void Add_LessonBundle(this GSDownLoader_Component self)
        {
            if(GSRunningData.LessonDownLoaded != "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000")
            {                
                for(int i = 0; i < GSRunningData.LessonDownLoaded.Length; i++)
                {                    
                    if (GSRunningData.LessonDownLoaded.Substring(i,1) == "1")
                    {
                        string lessonName = $"Lesson_{string.Format("{0:000}", i + 1)}";
                        int SectionCount = Contents_ConfigCategory.Instance.Get(1001 + i).Sections[1] - Contents_ConfigCategory.Instance.Get(1001 + i).Sections[0];
                        for (int j = 0; j <= SectionCount; j++)
                        {
                            self.UpdateList.Add(lessonName + "_" + j, false);
                            Log.Info(lessonName + "_" + j);
                        }
                    }
                }
            }
        }

        // 添加课件主界面的资源列表
        public static void Add_LessonXXXBundle(this GSDownLoader_Component self)
        {
            self.UpdateList.Add("Lesson_XXX", false);
        }        

        // 添加Movie播放器的资源列表
        public static void Add_MovieBundle(this GSDownLoader_Component self)
        {
            self.UpdateList.Add("Movie", false);
        }        

        // 添加小郎中的资源列表
        public static void Add_XiaoLangZhongBundle(this GSDownLoader_Component self)
        {
            self.UpdateList.Add("XiaoLangZhong", false);
        }

        // 添加饮食与健康的资源列表
        public static void Add_YinShiYuJianKangBundle(this GSDownLoader_Component self)
        {
            self.UpdateList.Add("YinShiYuJianKang", false);
        }
    }
}

using UnityEngine.UI;
using System.IO;
using UnityEngine;
using BM;
using System.Collections.Generic;

namespace ET
{
    public static class ListCell_Extend
    {
        public static void OnClickIcon(this ListCell_Component self)
        {            
            self.CreateLessonInfoContent();            
        }

        public static void OnClickDownLoad(this ListCell_Component self)
        {
            if (GSRunningData.Permit.Substring(self.LessonID - 1001, 1) == "1")
            {
                if (GSRunningData.LessonDeveloped.Substring(self.LessonID - 1001, 1) == "1")
                {
                    self.DownLoadAssets();
                }
                else
                {
                    self.ShowNoDeveloped();
                }
                    
            }
            else
            {
                self.ShowNoPermit();
            }            
        }

        public static void OnClickDelete(this ListCell_Component self)
        {

        }

        public static async void CreateLessonInfoContent(this ListCell_Component self)
        {
            await self.MainControler.LoadContentAssetBundle(self.LessonID);
            self.MainControler.LessonSelected_ID = self.LessonID;
            self.MainControler.SelectContentInfo(0);
            //GSDebug_Helper.Show_ABInfo_In_Memory();
        }

        public static async void DownLoadAssets(this ListCell_Component self)
        {
            #region BundleMaster方式下载
            GSMessageBoxResultType result = await GSMessageBox.Show(GSMessageBoxType.Information, "您准备下载选择课程的课件，请确认硬盘有足够的空间存储。是否继续下载？", new GSMessageBoxResultType[] { GSMessageBoxResultType.Confirm, GSMessageBoxResultType.Cancel });
            if (result == GSMessageBoxResultType.Confirm)
            {
                AssetComponentConfig.HotfixPath = GSSystemConfig.GSFilelocation + "/../HotfixBundles/";

                string lessonName = $"Lesson_{string.Format("{0:000}", self.LessonID -1000)}";
                int SectionCount = Contents_ConfigCategory.Instance.Get(self.LessonID).Sections[1] - Contents_ConfigCategory.Instance.Get(self.LessonID).Sections[0];

                AssetComponentConfig.DefaultBundlePackageName = Lessons_ConfigCategory.Instance.Get(Contents_ConfigCategory.Instance.Get(self.LessonID).Sections[0]).ABName[0];

                Dictionary<string, bool> DownLoadList = new Dictionary<string, bool>();
                int StartId = Contents_ConfigCategory.Instance.Get(self.LessonID).Sections[0];
                for (int i = 0; i <= SectionCount; i++)
                {                    
                    string[] bundleList = Lessons_ConfigCategory.Instance.Get(StartId+i).ABName;
                    for(int j = 0; j < bundleList.Length; j++)
                    {
                        Log.Warning($"需要下载：{bundleList[j]}");
                        DownLoadList.Add(bundleList[j],false);
                    }
                    //DownLoadList.Add(lessonName + "_" + i, false);
                }                

                self.updateBundleDataInfo = await AssetComponent.CheckAllBundlePackageUpdate(DownLoadList);
                if (self.updateBundleDataInfo.NeedUpdate)
                {
                    self.DownLoading = true;
                    Debug.LogError(lessonName + "资源包体需要更新, 大小: " + self.updateBundleDataInfo.NeedUpdateSize);
                    await AssetComponent.DownLoadUpdate(self.updateBundleDataInfo);
                }

                // 下载完成
                Log.Info("*******************下载完成****************");
                self.SetActive();                
                self.SaveInfo(self.LessonID - 1000);
            }
            #endregion

            #region UnityWebRequestRenewalAsync方式下载课件;

            //GSMessageBoxResultType result = await GSMessageBox.Show(GSMessageBoxType.Information, "您准备下载选择课程的课件，请确认硬盘有足够的空间存储。是否继续下载？", new GSMessageBoxResultType[] { GSMessageBoxResultType.Confirm, GSMessageBoxResultType.Cancel });
            //if (result == GSMessageBoxResultType.Confirm)
            //{
            //    string[] DownLoadList = Contents_ConfigCategory.Instance.Get(self.LessonID).ABBundles;
            //    string LessonName = "Lesson_" + string.Format("{0:000}", self.LessonID - 1000);
            //    if (!Directory.Exists(PathHelper.AppResPath + "/" + LessonName)) Directory.CreateDirectory(PathHelper.AppResPath + "/" + LessonName);

            //    Image ProgressCircle = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>().Get<Image>("DownloadProgress");
            //    Image ProgressIcon = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>().Get<Image>("DownLoadIcon");
            //    if (DownLoadList != null)
            //    {
            //        for (int i = 0; i < DownLoadList.Length; i++)
            //        {
            //            string BundleName = DownLoadList[i].StringToAB().ToLower();
            //            UnityWebRequestRenewalAsync unityWebRequestRenewalAsync = self.AddComponent<UnityWebRequestRenewalAsync>();
            //            unityWebRequestRenewalAsync.DownloadAsync(self.Assets_URL + LessonName + "/" + BundleName, PathHelper.AppResPath + $"/{LessonName}/" + BundleName).Coroutine();
            //            while (true)
            //            {
            //                await TimerComponent.Instance.WaitAsync(1);
            //                ProgressCircle.fillAmount = unityWebRequestRenewalAsync.Progress * (1f / DownLoadList.Length) + (1f / DownLoadList.Length) * i;
            //                ProgressIcon.fillAmount = unityWebRequestRenewalAsync.Progress * (1f / DownLoadList.Length) + (1f / DownLoadList.Length) * i;
            //                if (unityWebRequestRenewalAsync.Progress >= 1.0f)
            //                {
            //                    if (unityWebRequestRenewalAsync.totalBytes == unityWebRequestRenewalAsync.byteWrites)
            //                    {
            //                        break;
            //                    }
            //                }
            //            }
            //            unityWebRequestRenewalAsync.Dispose();
            //        }

            //        // 下载完成
            //        Log.Info("*******************下载完成****************");
            //        self.SetActive();
            //        self.SaveInfo(self.LessonID - 1000);
            //    }
            //}
            #endregion

            self.OnClickIcon();
        }

        public static async void ShowNoPermit(this ListCell_Component self)
        {
            GSMessageBoxResultType result = await GSMessageBox.Show(GSMessageBoxType.Error, "您所拥有的账号不具备下载此课程课件的权限，请确认您的U-Key应用范围。", new GSMessageBoxResultType[] { GSMessageBoxResultType.Confirm });
        }

        public static async void ShowNoDeveloped(this ListCell_Component self)
        {
            GSMessageBoxResultType result = await GSMessageBox.Show(GSMessageBoxType.Error, "对不起，您所要下载的课件正在开发中。。。", new GSMessageBoxResultType[] { GSMessageBoxResultType.Confirm });
        }

        public static void SetActive(this ListCell_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            rc.Get<GameObject>("DownLoadLabelBG").SetActive(false);
            rc.Get<GameObject>("DownLoadBtn").SetActive(false);
            
            rc.Get<GameObject>("LoadFengmianBtn").GetComponent<Image>().color = new Color(0f, 0f, 0f, 1 / 255f); ;
            rc.Get<GameObject>("RecycleBtn").SetActive(true);

            rc.Get<Image>("DownloadProgress").fillAmount = 1f;
            rc.Get<Image>("DownLoadIcon").fillAmount = 1f;
        }

        public static void SetDefault(this ListCell_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            rc.Get<GameObject>("DownLoadLabelBG").SetActive(true);
            rc.Get<GameObject>("DownLoadBtn").SetActive(true);

            rc.Get<GameObject>("LoadFengmianBtn").GetComponent<Image>().color = new Color(0f, 0f, 0f, 150 / 255f); ;
            rc.Get<GameObject>("RecycleBtn").SetActive(false);

            rc.Get<Image>("DownloadProgress").fillAmount = 0f;
            rc.Get<Image>("DownLoadIcon").fillAmount = 0f;
        }

        public static void SaveInfo(this ListCell_Component self,int LessonIndex)
        {
            string save = PlayerPrefs.GetString("LessonDownLoaded");
            string font = save.Substring(0, LessonIndex-1);            
            string behind = save.Substring(LessonIndex);            
            save = font + "1" + behind;
            PlayerPrefs.SetString("LessonDownLoaded", save);
            GSRunningData.LessonDownLoaded = save;
        }
    }
}

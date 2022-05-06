using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BM;

namespace ET
{


    public static class MainPageScene_Main_1_Extend
    {
        public static async void Create(this MainPageScene_Main_1_Component self)
        {
            if (GSRunningData.LessonList.Count > 0)
            {
                self.InitLessonList(GSRunningData.LessonList);                
            }
            else
            {
                //self.DeleteLessonList();
                return;
            }

            self.LessonSelected_ID = GSRunningData.LessonList[0];

            await self.LoadContentAssetBundle(self.LessonSelected_ID);

            self.SelectContentInfo(0);

            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            rc.Get<GameObject>("StartBtn").AddEventListener(GSMouseEventType.MouseClick, self.OnClickStart);
        }

        // LessonList 设置
        public static void InitLessonList(this MainPageScene_Main_1_Component self, List<int> lessonList)
        {
            if (self.CellGroup.Count > 0)
            {
                self.DeleteLessonList();
            }

            // 用传入的课程列表开始初始化选课菜单
            for (int i = 0; i < lessonList.Count; i++)
            {
                //GameObject temp = (GameObject)ResourcesComponent.Instance.GetAsset(GSUIType.UIMainPageScene.StringToAB(), "KejianCell");
                GameObject temp = AssetComponent.Load<GameObject>(out LoadHandler handler,BPath.UIMainPagePath + "Prefabs/Cell/KejianCell.prefab", "MainPageScene");
                GameObject cell = GameObject.Instantiate(temp, self.ListContainer.transform);
                cell.name = "Lesson_" + lessonList[i];
                cell.transform.localScale = new Vector3(self.CellScale, self.CellScale, 1);

                // * lessonList内传入的int数组为选择的课程Id *
                self.CellGroup.Add(new MainPageCellButtonStru() { index = lessonList[i], cell = cell, handler = handler });                

                UI ui = self.GetParent<UI>().AddChild<UI, string, GameObject>(cell.name, cell);
                ListCell_Component component = ui.AddComponent<ListCell_Component>();
                component.LessonID = lessonList[i];
                component.MainControler = self;
            }
            self.ListContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 300 * self.CellGroup.Count / 2 * self.CellScale + self.ListGrid.spacing.y * self.CellGroup.Count / 2 - self.ListGrid.spacing.y);
            
        }

        // 删除所有Cell
        public static void DeleteLessonList(this MainPageScene_Main_1_Component self)
        {
            for (int i = 0; i < self.CellGroup.Count; i++)
            {
                GameObject.Destroy(self.CellGroup[i].cell);
                self.CellGroup[i].handler.UnLoad();
            }
            self.CellGroup.Clear();
            self.ListContainer.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        }

        // LessonInfo设置
        public static async ETTask LoadContentAssetBundle(this MainPageScene_Main_1_Component self, int LessonID)
        {            
            //=============================加载AB操作================================
            if (GSRunningData.CurrentThumbnails.Count>0)
            {
                foreach (var item in GSRunningData.CurrentThumbnails)
                {
                    item.Value.UnLoad();
                    AssetComponent.UnLoadPackageAssets(item.Key);
                    AssetComponent.UnInitialize(item.Key);                    
                }
                GSRunningData.CurrentThumbnails.Clear();
            }            
            self.HisThumbnails = "MainPage_Thumbnails_Lesson" + String.Format("{0:000}", LessonID - 1000);
            await AssetComponent.Initialize(self.HisThumbnails, GSPassWord.MainPage_Thumbnails);
            string ThumbnailsDatabasePrefab = "Assets/Res/GSEduPlat/MainPageScene/Thumbnails/Lesson_" + String.Format("{0:000}", LessonID - 1000) + "/SectionShots.prefab";
            self.PicDataBase = AssetComponent.Load<GameObject>(out LoadHandler handler, ThumbnailsDatabasePrefab, self.HisThumbnails);

            GSRunningData.CurrentThumbnails.Add(self.HisThumbnails, handler);
            //=======================================================================
            
            // 根据传入的ID（1001-1100）获取课程的名称(Lesson_001-Lesson_110)
            self.LessonSelected = "Lesson_" + string.Format("{0:000}", LessonID - 1000);            
            // 根据传入的ID获取目录配表内的信息
            Contents_Config config = Contents_ConfigCategory.Instance.Get(LessonID);
            // 得到当前课程对应的Lesson配表内的第一课的信息
            self.SectionSelected_ID = config.Sections[0];
            // 设置缩略图下面的按钮
            self.SetContentButton(config.Sections[1] - config.Sections[0] + 1);
        }

        // 设置缩略图下面的按钮
        public static void SetContentButton(this MainPageScene_Main_1_Component self, int BtnNum)
        {
            // 删除之前设置的按钮
            if (self.SectionBtn.Count > 0)
            {
                for (int i = 0; i < self.SectionBtn.Count; i++)
                {
                    GameObject.Destroy(self.SectionBtn[i]);
                }
                self.SectionBtn.Clear();
                self.ChoiceIndex.Clear();
            }
            // 获取按钮所能展示的宽度，便于均匀间隔排列
            float BtnLineLength = self.StartBtn.transform.parent.GetComponent<RectTransform>().rect.width;
            // 开始复制按钮并添加交互
            for (int i = 0; i < BtnNum; i++)
            {
                GameObject btn = GameObject.Instantiate(self.EndBtn, self.EndBtn.transform.parent);
                btn.name = "SectionBtn" + i;                
                btn.transform.localPosition = new Vector3(-BtnLineLength / 2 + BtnLineLength / (BtnNum-1) * i, 0);
                btn.AddEventListener(GSMouseEventType.MouseClick, self.OnClickSectionButton);

                self.SectionBtn.Add(btn);
                self.ChoiceIndex.Add(btn.name, i);
            }
            // 设置第一个按钮为选中状态
            self.SelectOneSectionBtn(0);
        }

        // 设置所有缩略图下的按钮为未选中状态
        public static void BackAllSectionBtn(this MainPageScene_Main_1_Component self)
        {
            for(int i = 0; i < self.SectionBtn.Count; i++)
            {
                self.SectionBtn[i].GetComponent<Image>().overrideSprite = self.EndBtn.GetComponent<Image>().sprite;
            }
        }

        // 设置一个按钮为选中状态
        public static void SelectOneSectionBtn(this MainPageScene_Main_1_Component self, int SectionIndex)
        {
            self.BackAllSectionBtn();
            self.SectionBtn[SectionIndex].GetComponent<Image>().overrideSprite = self.StartBtn.GetComponent<Image>().sprite;
        }

        // 设置选中的缩略图信息
        public static void SelectContentInfo(this MainPageScene_Main_1_Component self, int SectionIndex)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();            

            ReferenceCollector PicDataBase = self.PicDataBase.GetComponent<ReferenceCollector>();

            rc.Get<Image>("InfoScreen").overrideSprite = PicDataBase.Get<Sprite>(self.LessonSelected + "_" + SectionIndex);
            
            rc.Get<Text>("LessonInfoResume").text = "本节介绍：" + "\r\n\u3000\u3000"+Lessons_ConfigCategory.Instance.Get(self.SectionSelected_ID+SectionIndex).Section_Info;
        }

        // 点击小节节点显示
        public static void OnClickSectionButton(this MainPageScene_Main_1_Component self)
        {
            int SectionIndex = self.ChoiceIndex[GSMouseData.LastObjectClicked.name];    

            self.SelectOneSectionBtn(SectionIndex);

            self.SelectContentInfo(SectionIndex);
        }

        // 点击开始按钮
        public static async void OnClickStart(this MainPageScene_Main_1_Component self)
        {
            Log.Info(self.LessonSelected_ID.ToString());
            GSRunningData.Lesson_SelectedIndex = self.LessonSelected_ID - 1000;            
            Log.Info($"当前Permit={GSRunningData.Permit.Substring(GSRunningData.Lesson_SelectedIndex - 1, 1)};  当前DownLoaded ={GSRunningData.LessonDownLoaded.Substring(GSRunningData.Lesson_SelectedIndex - 1, 1)}");

            // 判断是否可以访问
            if (GSRunningData.Permit.Substring(GSRunningData.Lesson_SelectedIndex - 1, 1) == "1")
            {
                // 判断是否已下载过
                if (GSRunningData.LessonDownLoaded.Substring(GSRunningData.Lesson_SelectedIndex - 1, 1) == "1")
                {
                    GSRunningData.Target = GSUIType.UILessonScene;
                    GSRunningData.Lesson_SelectedIndex = self.LessonSelected_ID - 1000;
                    GSRunningData.Section_SelectedIndex = 0;
                    GSRunningData.PageIndex = 0;
                    GSRunningData.ChoiceIndex = 0;

                    // 添加到资源卸载列表
                    //GSRunningData.BundleNeedRemove.Add(self.HisThumbnails,true);                    
                    
                    // 创建Loading，跳转Lesson界面
                    await GSUIHelper.Create(self.DomainScene(), GSUIType.UILoadingScene, UILayer.High);                    
                    AssetComponent.UnLoadPackageAssets("MainPageScene");
                }
                else
                {
                    // 提示下载课件
                    GSMessageBoxResultType result = await GSMessageBox.Show(GSMessageBoxType.Error, "请先点击下载按钮下载该课件。", new GSMessageBoxResultType[] { GSMessageBoxResultType.Confirm });
                }
            }
            else
            {
                // 提示没有访问权限
                GSMessageBoxResultType result = await GSMessageBox.Show(GSMessageBoxType.Error, "您所拥有的账号不具备使用此课程课件的权限，请确认您的U-Key应用范围。", new GSMessageBoxResultType[] { GSMessageBoxResultType.Confirm });
            }
        }
    }
}

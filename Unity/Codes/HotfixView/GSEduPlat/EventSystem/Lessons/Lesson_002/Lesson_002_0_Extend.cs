﻿using System;

namespace ET
{
    public static class Lesson_002_0_Extend
    {
        public static void OnMouseOver(this Lesson_002_0 self)
        {
            for (int i = 0; i < 4; i++)
            {
                self.BtnGroup[i].ChangeNormal();
            }
            GSMouseData.LastObjectMatched.ChangeSelect();
        }

        public static void OnMouseOut(this Lesson_002_0 self)
        {
            GSMouseData.LastObjectMatched.ChangeNormal();
        }               

        // 键盘交互
        public static void OnSingleClickUp(this Lesson_002_0 self)
        {
            if (GSRunningData.ChoiceIndex < self.BtnGroup.Count)
            {
                GSRunningData.ChoiceIndex += 1;
            }
            else
            {
                GSRunningData.ChoiceIndex = 1;
            }
            self.Select();
        }

        public static void OnSingleClickDown(this Lesson_002_0 self)
        {
            if (GSRunningData.ChoiceIndex == 0)
            {
                GSRunningData.ChoiceIndex = 1;
            }
            else if (GSRunningData.ChoiceIndex == 1)
            {
                GSRunningData.ChoiceIndex = self.BtnGroup.Count;
            }
            else
            {
                GSRunningData.ChoiceIndex -= 1;
            }
            self.Select();
        }        

        public static void OnDoubleClickDown(this Lesson_002_0 self)
        {
            self.Quit();
        }
        // 辅助函数
        public static void Select(this Lesson_002_0 self)
        {
            for (int i = 0; i < self.BtnGroup.Count; i++)
            {
                self.BtnGroup[i].ChangeNormal();
            }
            self.BtnGroup[GSRunningData.ChoiceIndex - 1].ChangeSelect();
        }


        // 需要大量修改的地方
        public static void OnMouseClick(this Lesson_002_0 self)
        {
            int choice;
            Int32.TryParse(GSMouseData.LastObjectClicked.name.Substring(3), out choice);
            self.GotoSection(choice + 1);
        }


        public static void OnDoubleClickUp(this Lesson_002_0 self)
        {
            self.GotoSection(GSRunningData.ChoiceIndex);            
        }

        public static async void GotoSection(this Lesson_002_0 self, int sectionIndex)
        {
            Log.Info(sectionIndex.ToString());
            switch (sectionIndex)
            {
                case 0:
                    // 必须赋值
                    GSRunningData.Target = GSUIType.UILessonScene;
                    GSRunningData.Lesson_SelectedIndex = 2;
                    GSRunningData.Section_SelectedIndex = 1;                    
                    // 操作清空
                    GSRunningData.Limit = false;
                    GSRunningData.PageIndex = 0;
                    GSRunningData.ChoiceIndex = 0;
                    // 流程删除赋值
                    GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);
                    break;
                case 1:
                    // 必须赋值
                    GSRunningData.Target = GSUIType.UILessonScene;
                    GSRunningData.Lesson_SelectedIndex = 2;
                    GSRunningData.Section_SelectedIndex = 1;
                    // 操作清空
                    GSRunningData.Limit = false;
                    GSRunningData.PageIndex = 0;
                    GSRunningData.ChoiceIndex = 0;
                    // 流程删除赋值
                    GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);
                    break;

                case 2:
                    // 必须赋值
                    GSRunningData.Target = GSUIType.UILessonScene;
                    GSRunningData.Lesson_SelectedIndex = 2;
                    GSRunningData.Section_SelectedIndex = 2;
                    // 操作清空
                    GSRunningData.Limit = false;
                    GSRunningData.PageIndex = 0;
                    GSRunningData.ChoiceIndex = 0;
                    // 流程删除赋值
                    GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);
                    break;
                case 3:
                    // 必须赋值
                    GSRunningData.Target = GSUIType.UILessonScene;
                    GSRunningData.Lesson_SelectedIndex = 2;
                    GSRunningData.Section_SelectedIndex = 3;
                    // 操作清空
                    GSRunningData.Limit = false;
                    GSRunningData.PageIndex = 0;
                    GSRunningData.ChoiceIndex = 0;
                    // 流程删除赋值
                    GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);
                    break;
                case 4:
                    // 必须赋值
                    GSRunningData.Target = GSUIType.UIMovieScene;
                    GSRunningData.Lesson_SelectedIndex = 2;
                    GSRunningData.Section_SelectedIndex = 4;
                    // 根据类型赋值
                    GSRunningData.Movie_SelectedIndex = 2;
                    // 操作清空
                    GSRunningData.Limit = false;
                    GSRunningData.PageIndex = 0;
                    GSRunningData.ChoiceIndex = 0;
                    // 流程删除赋值
                    GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);
                    break;
                case 5:
                    // 必须赋值
                    GSRunningData.Target = GSUIType.UIXiaoLangZhongScene;
                    GSRunningData.Lesson_SelectedIndex = 2;
                    GSRunningData.Section_SelectedIndex = 5;
                    // 根据类型赋值
                    GSRunningData.XiaoLangZhong_TypeIndex = 1;
                    GSRunningData.XiaoLangZhong_SelectedIndex = 2;
                    // 操作清空
                    GSRunningData.Limit = false;
                    GSRunningData.PageIndex = 0;
                    GSRunningData.ChoiceIndex = 0;
                    // 流程删除赋值
                    GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);
                    break;
                case 6:
                    // 必须赋值
                    GSRunningData.Target = GSUIType.UIYinShiYuJianKangScene;
                    GSRunningData.Lesson_SelectedIndex = 2;
                    GSRunningData.Section_SelectedIndex = 6;
                    // 根据类型赋值
                    GSRunningData.YinShiYuJianKang_SelectedIndex = 2;
                    // 操作清空                    
                    GSRunningData.Limit = false;
                    GSRunningData.PageIndex = 0;
                    GSRunningData.ChoiceIndex = 0;
                    // 流程删除赋值
                    GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);
                    break;
                default:
                    break;
            }
            await GSUIHelper.Create(self.DomainScene(), GSUIType.UILoadingScene, UILayer.Mid);
        }

        public static async void Quit(this Lesson_002_0 self)
        {
            // 必须赋值
            GSRunningData.Target = GSUIType.UIMainPageScene;
            GSRunningData.Lesson_SelectedIndex = 2;
            GSRunningData.Section_SelectedIndex = 0;
            // 操作清空   
            GSRunningData.Limit = false;
            GSRunningData.PageIndex = 0;
            GSRunningData.ChoiceIndex = 0;
            // 流程删除赋值
            GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);

            await GSUIHelper.Create(self.DomainScene(), GSUIType.UILoadingScene, UILayer.High);
        }
    }
}


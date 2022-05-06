using DG.Tweening;

namespace ET
{
    public static class MainPage_Left_Extend
    {
        public static void BackAllButton(this MainPageScene_Left_Component self)
        {
            for (int i = 0; i < self.BtnGroup.Count; i++)
            {
                self.BtnTexture[i * 2].SetActive(true);
                self.BtnTexture[i * 2 + 1].SetActive(false);
                self.BtnText[i * 2].SetActive(true);
                self.BtnText[i * 2 + 1].SetActive(false);
            }
        }

        public static void SelectOneButton(this MainPageScene_Left_Component self, int index)
        {
            self.BtnTexture[index * 2].SetActive(false);
            self.BtnTexture[index * 2 + 1].SetActive(true);
            self.BtnText[index * 2].SetActive(false);
            self.BtnText[index * 2 + 1].SetActive(true);
        }

        public static void OnMouseClick(this MainPageScene_Left_Component self)
        {
            string clickObjectName = GSMouseData.LastObjectClicked.transform.parent.name;
            DOTween.KillAll();
            switch (clickObjectName)
            {
                case "FirstPageBtn":
                    if (self.ContentTitle.text != "首页")
                    {
                        self.ContentTitle.text = "首页";
                        self.BackAllButton();
                        self.SelectOneButton(0);
                        Game.EventSystem.Publish(new GSEventType.RefreshMainPageContent()
                        {
                            ZoneScene = self.DomainScene(),
                            MainContentType = "MainPage_Index",
                            MainPageScrip = self.ParentComponent
                        });
                    }
                    break;
                case "KeJianBtn":
                    if (self.ContentTitle.text != "中医药文化")
                    {
                        self.ContentTitle.text = "中医药文化";
                        self.BackAllButton();
                        self.SelectOneButton(2);                       
                        
                        Game.EventSystem.Publish(new GSEventType.RefreshMainPageContent()
                        {
                            ZoneScene = self.DomainScene(),                            
                            MainContentType = "MainPage_LessonList",
                            MainPageScrip = self.ParentComponent
                        }) ;
                    }
                    break;
                case "XiaoLangZhongBtn":
                    self.ContentTitle.text = "小郎中";
                    self.BackAllButton();
                    self.SelectOneButton(1);
                    //if (self.ContentTitle.text != "小郎中")
                    //{

                    //}
                    //self.ContentTitle.text = "首页";
                    //self.BackAllButton();
                    //self.SelectOneButton(0);
                    break;
            }
        }
    }
}

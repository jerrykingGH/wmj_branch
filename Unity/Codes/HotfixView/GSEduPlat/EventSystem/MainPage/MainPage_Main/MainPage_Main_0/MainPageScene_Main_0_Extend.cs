using UnityEngine;
using BM;

namespace ET
{
    public static class MainPageScene_Main_0_Extend
    {
        public static void BackAllTip(this MainPageScene_Main_0_Component self)
        {
            for (int i = 0; i < self.BannerNum; i++)
            {
                self.TipNormal[i].SetActive(true);
                self.TipSelect[i].SetActive(false);
            }
        }
        public static void SelectOneTip(this MainPageScene_Main_0_Component self, int tipIndex)
        {
            self.TipNormal[tipIndex].SetActive(false);
            self.TipSelect[tipIndex].SetActive(true);
        }
        public static void Tip_OnMouseOver(this MainPageScene_Main_0_Component self)
        {
            self.AutoDisplayBanner = false;

            GameObject.Destroy(self.BannerUpContainer.transform.GetChild(0).gameObject);
            self.BannerUpContainer.GetComponent<CanvasGroup>().alpha = 1f;
            GameObject.Instantiate(self.Display, self.BannerUpContainer.transform);

            self.BannerDisplayContainer.SetActive(false);

            string GameObjectTouched = GSMouseData.LastObjectMatched.transform.parent.name;

            switch (GameObjectTouched)
            {
                case "Tip0":
                    self.BannerIndex = 0;
                    break;
                case "Tip1":
                    self.BannerIndex = 1;
                    break;
                case "Tip2":
                    self.BannerIndex = 2;
                    break;
                case "Tip3":
                    self.BannerIndex = 3;
                    break;
                case "Tip4":
                    self.BannerIndex = 4;
                    break;
                default:
                    Log.Error("居然有不属于的物体");
                    break;
            }           

            GameObject.Destroy(self.BannerDisplayContainer.transform.GetChild(0).gameObject);
            int TouchIndex;
            System.Int32.TryParse(GameObjectTouched.Substring(3),out TouchIndex);
            self.Display = GameObject.Instantiate(self.BannerTemp[TouchIndex], self.BannerDisplayContainer.transform);

            self.BannerDisplayContainer.SetActive(true);

            self.BackAllTip();
            switch (GameObjectTouched)
            {
                case "Tip0":
                    self.SelectOneTip(0);
                    break;
                case "Tip1":
                    self.SelectOneTip(1);
                    break;
                case "Tip2":
                    self.SelectOneTip(2);
                    break;
                case "Tip3":
                    self.SelectOneTip(3);
                    break;
                case "Tip4":
                    self.SelectOneTip(4);
                    break;

            }
        }
        public static void Tip_OnMouseOut(this MainPageScene_Main_0_Component self)
        {
            self.AutoDisplayBanner = true;
        }        
    }
}

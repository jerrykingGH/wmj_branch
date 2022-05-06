using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    [ObjectSystem]
    public class MainPageScene_Main_1_AwakeEventSystem : AwakeSystem<MainPageScene_Main_1_Component>
    {
        public override void AwakeAsync(MainPageScene_Main_1_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            #region 1.总体布局设置=====================================
            self.Left = rc.Get<GameObject>("Left");
            self.Right = rc.Get<GameObject>("Right");
            self.Top = rc.Get<GameObject>("Top");

            RectTransform rt_Parent = rc.Get<GameObject>("MainPage_Main_1").GetComponent<RectTransform>();
            RectTransform rt_Left = self.Left.GetComponent<RectTransform>();
            RectTransform rt_Right = self.Right.GetComponent<RectTransform>();
            rt_Left.sizeDelta = new Vector2(rt_Parent.rect.width * 0.4f, -95);
            rt_Right.sizeDelta = new Vector2(rt_Parent.rect.width * 0.6f, -95);
            #endregion

            #region 2.左边课件列表设置=================================            
            self.ListContainer = rc.Get<GameObject>("ListContainer");
            self.ListGrid = self.ListContainer.GetComponent<GridLayoutGroup>();

            RectTransform rt_ListContainer = self.ListContainer.GetComponent<RectTransform>();
            float cellWidth = (rt_ListContainer.rect.width - 10) / 2;
            float cellHeight = cellWidth / 4 * 3;
            self.ListGrid.cellSize = new Vector2(cellWidth, cellHeight);
            self.CellScale = cellWidth / 400f;
            #endregion

            #region 3.右边课件缩略图设置===============================            
            self.ThumbnailsScreen = rc.Get<GameObject>("Screen");
            self.ThumbnailsInfo = rc.Get<GameObject>("InformationArea");
            self.ThumbnailsImage = rc.Get<Image>("InfoScreen");
            self.DefaultThumbnails = rc.Get<GameObject>("DefaultIcon");

            RectTransform rt_Screen = self.ThumbnailsScreen.GetComponent<RectTransform>();
            rt_Screen.sizeDelta = new Vector2(-70, rt_Screen.rect.width / 80 * 45f);

            RectTransform rt_ScreenInfo = self.ThumbnailsInfo.GetComponent<RectTransform>();

            rt_ScreenInfo.sizeDelta = new Vector2(-100, rt_Right.rect.height - rt_Screen.rect.height - 150);

            self.StartBtn = rc.Get<GameObject>("Start");
            self.EndBtn = rc.Get<GameObject>("End");
            rc.Get<GameObject>("Start").transform.localPosition += new Vector3(0, 10000, 0);
            rc.Get<GameObject>("End").transform.localPosition += new Vector3(0, 10000, 0);
            #endregion

            #region 4.顶部工具条设置===================================
            #endregion

            #region 5.开始初始化=======================================

            self.Create();

            #endregion
        }
    }

    [ObjectSystem]
    public class MainPageScene_Main_1_DestroyEventSystem : DestroySystem<MainPageScene_Main_1_Component>
    {
        public override void Destroy(MainPageScene_Main_1_Component self)
        {
            self.DomainScene().GetComponent<UIComponent>().UIs.Remove("MainPage_LessonList");
            self.loadHandler.UnLoad();
        }
    }
}

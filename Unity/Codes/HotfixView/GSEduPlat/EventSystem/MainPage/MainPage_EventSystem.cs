using UnityEngine;
using BM;

namespace ET
{    
    [ObjectSystem]
    public class UIMainpageComponentAwakeSystem : AwakeSystem<MainPageScene_Component>
    {        
        public override void AwakeAsync(MainPageScene_Component self)
        {
            Log.Warning($"【 主界面 创建开始】");

            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();            

            // 获取上下左右四大板块的RectTransform;
            self.BottomContainer = rc.Get<GameObject>("BottomContainer");
            self.LeftContainer = rc.Get<GameObject>("LeftContainer");
            self.TopContainer = rc.Get<GameObject>("TopContainer");
            self.MainContainer = rc.Get<GameObject>("MainContainer");


            // ===== 创建Bottom =====
            // 获取Bottom预制体
            GameObject Bottom_Prefab = AssetComponent.Load<GameObject>(out LoadHandler handler_Bottom,BPath.UIMainPagePath + "Prefabs/MainPage_Bottom.prefab", "MainPageScene");
            self.Cell_LoadHandler.Add(handler_Bottom);
            // 复制预制体
            self.Bottom = GameObject.Instantiate(Bottom_Prefab, self.BottomContainer.transform);
            // 转换为ET UI组件
            self.UI_Bottom = self.DomainScene().GetComponent<UIComponent>().AddChild<UI, string, GameObject>("MainPage_Bottom", self.Bottom);
            // 将UI组件挂到主容器上
            self.GetParent<UI>().Add(self.UI_Bottom);            
            // 挂上控制组件
            MainPageScene_Bottom_Component BottomComponent = self.UI_Bottom.AddComponent<MainPageScene_Bottom_Component>();


            // ===== 创建Left =====
            // 获取Left预制体
            GameObject Left_Prefab = AssetComponent.Load<GameObject>(out LoadHandler handler_Left, BPath.UIMainPagePath + "Prefabs/MainPage_Left.prefab", "MainPageScene");
            self.Cell_LoadHandler.Add(handler_Left);
            // 复制预制体
            self.Left = GameObject.Instantiate(Left_Prefab, self.LeftContainer.transform);
            // 转换为ET UI组件
            self.UI_Left = self.DomainScene().GetComponent<UIComponent>().AddChild<UI, string, GameObject>("MainPage_Left", self.Left);
            // 将UI组件挂到主容器上
            self.GetParent<UI>().Add(self.UI_Left);
            // 挂上控制组件
            MainPageScene_Left_Component LeftComponent = self.UI_Left.AddComponent<MainPageScene_Left_Component>();
            LeftComponent.ParentComponent = self;


            // ===== 创建Top =====
            // 获取Top预制体
            GameObject Top_Prefab = AssetComponent.Load<GameObject>(out LoadHandler handler_Top, BPath.UIMainPagePath + "Prefabs/MainPage_Top.prefab", "MainPageScene");
            self.Cell_LoadHandler.Add(handler_Top);
            // 复制预制体
            self.Top = GameObject.Instantiate(Top_Prefab, self.TopContainer.transform);
            // 转换为ET UI组件
            self.UI_Top = self.DomainScene().GetComponent<UIComponent>().AddChild<UI, string, GameObject>("MainPage_Top", self.Top);
            // 将UI组件挂到主容器上
            self.GetParent<UI>().Add(self.UI_Top);
            // 挂上控制组件
            MainPageScene_Top_Component TopComponent = self.UI_Top.AddComponent<MainPageScene_Top_Component>();


            // 刷新主信息区内的界面
            Game.EventSystem.Publish(new GSEventType.RefreshMainPageContent()
            {
                ZoneScene = self.DomainScene(),
                MainContentType = "MainPage_Index",
                MainPageScrip = self
            });

            Log.Warning($"【 主界面 创建结束】");
        }
    }

    [ObjectSystem]
    public class UIMainpageComponentDestroySystem : DestroySystem<MainPageScene_Component>
    {
        public override void Destroy(MainPageScene_Component self)
        {
            self.loadHandler.UnLoad();
            for(int i = 0; i < self.Cell_LoadHandler.Count; i++)
            {
                self.Cell_LoadHandler[i].UnLoad();
            }
            AssetComponent.UnLoadPackageAssets("MainPageScene");
        }
    }
}

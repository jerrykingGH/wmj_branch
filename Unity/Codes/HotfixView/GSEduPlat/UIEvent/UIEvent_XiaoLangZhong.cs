using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BM;

namespace ET
{
    [UIEvent(GSUIType.UIXiaoLangZhongScene)]
    public class UIEvent_XiaoLangZhong : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            string main_BundleName = "";
            string assets_BundleName = "";
            UI ui = null;
            // 初始化小郎中总包
            main_BundleName = "XiaoLangZhong";
            await AssetComponent.Initialize(main_BundleName, GSPassWord.XiaoLangZhong);

            switch (GSRunningData.XiaoLangZhong_TypeIndex)
            {
                case 1:
                    {
                        // 初始化小郎中分包
                        assets_BundleName = "XiaoLangZhong1_" + GSRunningData.XiaoLangZhong_SelectedIndex;
                        await AssetComponent.Initialize("XiaoLangZhong1_" + GSRunningData.XiaoLangZhong_SelectedIndex,GSPassWord.XiaoLangZhong);
                        // 复制总包小郎中穴位预制体
                        GameObject XueWeiTemp = AssetComponent.Load<GameObject>(out LoadHandler MainHandler,"Assets/Res/GSEduPlat/XiaoLangZhongScene/XiaoLangZhong1/XiaoLangZhong1.prefab", "XiaoLangZhong");
                        GameObject XiaoLangZhong_XueWei = GameObject.Instantiate(XueWeiTemp, UIEventComponent.Instance.UILayers[(int)uiLayer]);
                        ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UIXiaoLangZhongScene, XiaoLangZhong_XueWei);

                        ReferenceCollector rc = ui.GameObject.GetComponent<ReferenceCollector>();
                        // 获取分包资源路径
                        string XueWeiAssetPath = BPath.UILesssonPath + "Lesson_" + string.Format("{0:000}", GSRunningData.Lesson_SelectedIndex) + "/";
                        XueWeiAssetPath += "Lesson_" + string.Format("{0:000}", GSRunningData.Lesson_SelectedIndex) + "_" + GSRunningData.Section_SelectedIndex + "/";
                        // 创建穴位预制体，左中右动画
                        LoadHandler CenterHandler,LeftHandler,RightHandler;
                        if (GSRunningData.XiaoLangZhong_SelectedIndex == 15|| GSRunningData.XiaoLangZhong_SelectedIndex == 18)
                        {
                            GameObject centerBundleGO = AssetComponent.Load<GameObject>(out CenterHandler, XueWeiAssetPath+"Center1.prefab", assets_BundleName);
                            GameObject LeftBundleGO = AssetComponent.Load<GameObject>(out LeftHandler, XueWeiAssetPath + "Left1.prefab", assets_BundleName);
                            GameObject RightBundleGO = AssetComponent.Load<GameObject>(out RightHandler, XueWeiAssetPath + "Right1.prefab", assets_BundleName);
                            GameObject Center = GameObject.Instantiate(centerBundleGO, rc.Get<GameObject>("CenterContainer").transform);
                            Center.name = "Center1";
                            GameObject Left = GameObject.Instantiate(LeftBundleGO, rc.Get<GameObject>("LeftContainer").transform);
                            Left.name = "Left1";
                            GameObject Right = GameObject.Instantiate(RightBundleGO, rc.Get<GameObject>("RightContainer").transform);
                            Right.name = "Right1";
                        }
                        else
                        {                                                    
                            GameObject centerBundleGO = AssetComponent.Load<GameObject>(out CenterHandler, XueWeiAssetPath + "Center.prefab", assets_BundleName);
                            GameObject LeftBundleGO = AssetComponent.Load<GameObject>(out LeftHandler, XueWeiAssetPath + "Left.prefab", assets_BundleName);
                            GameObject RightBundleGO = AssetComponent.Load<GameObject>(out RightHandler, XueWeiAssetPath + "Right.prefab", assets_BundleName);
                            GameObject Center = GameObject.Instantiate(centerBundleGO, rc.Get<GameObject>("CenterContainer").transform);
                            Center.name = "Center";
                            GameObject Left = GameObject.Instantiate(LeftBundleGO, rc.Get<GameObject>("LeftContainer").transform);
                            Left.name = "Left";
                            GameObject Right = GameObject.Instantiate(RightBundleGO, rc.Get<GameObject>("RightContainer").transform);
                            Right.name = "Right";
                        }

                        XiaoLangZhong_Component xlz1_Script = ui.AddComponent<XiaoLangZhong_Component>();
                        xlz1_Script.loadHandlers.Add(CenterHandler);
                        xlz1_Script.loadHandlers.Add(LeftHandler);
                        xlz1_Script.loadHandlers.Add(RightHandler);
                        xlz1_Script.MainHandler = MainHandler;
                        xlz1_Script.BackLessonSelectedIndex = GSRunningData.XiaoLangZhong_SelectedIndex;
                    }
                    #region 原来的代码
                    //main_BundleName = "XiaoLangZhong" + GSRunningData.XiaoLangZhong_TypeIndex;
                    //await ResourcesComponent.Instance.LoadBundleAsync(main_BundleName.StringToAB());
                    //GSRunningData.UnUseABList.Add(main_BundleName);

                    //assets_BundleName = "XiaoLangZhong" + GSRunningData.XiaoLangZhong_TypeIndex + "_" + GSRunningData.XiaoLangZhong_SelectedIndex;
                    //await ResourcesComponent.Instance.LoadBundleAsync(assets_BundleName.StringToAB());
                    ////GSRunningData.UnUseABList.Add(assets_BundleName);                    

                    //GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset(main_BundleName.StringToAB(), main_BundleName);
                    //GameObject gameObject = GameObject.Instantiate(bundleGameObject,UIEventComponent.Instance.UILayers[(int)uiLayer]);
                    //ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UIXiaoLangZhongScene, gameObject);

                    //ReferenceCollector rc = ui.GameObject.GetComponent<ReferenceCollector>();

                    //if (GSRunningData.ChoiceIndex == 15 || GSRunningData.ChoiceIndex == 18)
                    //{
                    //    GameObject centerBundleGO = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Center1");                        
                    //    GameObject LeftBundleGO = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Left1");
                    //    GameObject RightBundleGO = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Right1");
                    //    GameObject Center = GameObject.Instantiate(centerBundleGO, rc.Get<GameObject>("CenterContainer").transform);
                    //    Center.name = "Center1";
                    //    GameObject Left = GameObject.Instantiate(LeftBundleGO, rc.Get<GameObject>("LeftContainer").transform);
                    //    Left.name = "Left1";
                    //    GameObject Right = GameObject.Instantiate(RightBundleGO, rc.Get<GameObject>("RightContainer").transform);
                    //    Right.name = "Right1";
                    //} 
                    //else
                    //{
                    //    GameObject centerBundleGO = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Center");
                    //    GameObject LeftBundleGO = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Left");
                    //    GameObject RightBundleGO = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Right");
                    //    GameObject Center = GameObject.Instantiate(centerBundleGO, rc.Get<GameObject>("CenterContainer").transform);
                    //    Center.name = "Center";
                    //    GameObject Left = GameObject.Instantiate(LeftBundleGO, rc.Get<GameObject>("LeftContainer").transform);
                    //    Left.name = "Left";
                    //    GameObject Right = GameObject.Instantiate(RightBundleGO, rc.Get<GameObject>("RightContainer").transform);
                    //    Right.name = "Right";
                    //}
                    #endregion
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
            

            return ui;
        }

        public override void OnRemoveAsync(UIComponent uiComponent)
        {
            
        }
    }
}

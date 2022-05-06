using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using BM;

namespace ET
{
    [UIEvent(GSUIType.UILessonScene)]
    public class UIEvent_Lesson : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            #region 加载所需AB包
            // Target = "Lesson",根据Lesson_SelectedIndex确定需要展示的Lesson的Id
            int ContentsIndex = 1000 + GSRunningData.Lesson_SelectedIndex;
            // 根据Id获取在Contents中的配置
            Contents_Config contentsConfig = Contents_ConfigCategory.Instance.Get(ContentsIndex);
            // 根据SectionIndex确定当前需要展示的小节Id;
            int LessonIndex = contentsConfig.Sections[0] + GSRunningData.Section_SelectedIndex;
            // 根据小节Id获取Lessons中的配置
            Lessons_Config lessonsConfig = Lessons_ConfigCategory.Instance.Get(LessonIndex);
            // 根据Lessons中配置的ABName信息加载需要用到的AB包，并添加到UnUseABList中;
            for(int i = 0; i < lessonsConfig.ABName.Length; i++)
            {                              
                Log.Info($"初始化了 {lessonsConfig.ABName[i]}");
                await AssetComponent.Initialize(lessonsConfig.ABName[i], GSPassWord.Lesson);
            }            
            Log.Info($"当前选择的课程在Contents表中的ID是：{ContentsIndex}  ");
            Log.Info($"当前选择的课程在Lesson表中的ID是：{LessonIndex}  ");

            #endregion


            #region 创建UI

            #region 加载资源包
            string uiBundleName = "Lesson_";
            uiBundleName += string.Format("{0:000}", GSRunningData.Lesson_SelectedIndex) + "_";
            uiBundleName += GSRunningData.Section_SelectedIndex;

            string prefabPath = BPath.UILesssonPath;
            prefabPath += "Lesson_" + string.Format("{0:000}", GSRunningData.Lesson_SelectedIndex)+"/";
            prefabPath += uiBundleName + "/";
            prefabPath += uiBundleName + ".prefab";
            //Log.Info(prefabPath);
            //Log.Info(uiBundleName);
            #endregion

            #region 复制预制体，创建UI
            Log.Info(prefabPath);
            Log.Info(uiBundleName);
            
            GameObject LessonTemp = AssetComponent.Load<GameObject>(out LoadHandler prefabHandler,prefabPath, uiBundleName);
            GameObject gameObject = GameObject.Instantiate(LessonTemp, UIEventComponent.Instance.UILayers[(int)uiLayer]);
            UI ui = uiComponent.AddChild<UI, string, GameObject>(uiBundleName, gameObject);
            #endregion

            LoadHandler lessonXXX_handler = null;
            // 如果为课程主界面则设置按钮
            if (GSRunningData.Section_SelectedIndex == 0)
            {
                // 加载BtnAB包
                await AssetComponent.Initialize("Lesson_XXX", GSPassWord.Lesson);
                GameObject Btn = AssetComponent.Load<GameObject>(out lessonXXX_handler,"Assets/Res/GSEduPlat/LessonsScene/Lesson_XXX/Btn/Btn.prefab", "Lesson_XXX");
                //GameObject Btn = (GameObject)ResourcesComponent.Instance.GetAsset("Lesson_XXX".StringToAB(), "Btn");

                #region 获取并设置Btn样式
                ReferenceCollector rc = Btn.GetComponent<ReferenceCollector>();
                string[] btnStyle = lessonsConfig.BtnStyle;

                ColorUtility.TryParseHtmlString(btnStyle[0], out Color TextNormal);
                rc.Get<Image>("1").color = TextNormal;
                ColorUtility.TryParseHtmlString(btnStyle[1], out Color TextSelect);
                rc.Get<Image>("2").color = TextSelect;
                ColorUtility.TryParseHtmlString(btnStyle[2], out Color PinYinNormal);
                rc.Get<Image>("3").color = PinYinNormal;
                ColorUtility.TryParseHtmlString(btnStyle[3], out Color PinYinSelect);
                rc.Get<Image>("4").color = PinYinSelect;
                ColorUtility.TryParseHtmlString(btnStyle[4], out Color ShadowNormal);
                rc.Get<Image>("5").color = ShadowNormal;
                ColorUtility.TryParseHtmlString(btnStyle[5], out Color ShadowSelect);
                rc.Get<Image>("6").color = ShadowSelect;

                //// Normal 总色调
                //rc.Get<Image>("1").color = new Color(btnStyle[0] / 255f, btnStyle[1] / 255f, btnStyle[2] / 255f, btnStyle[3] / 255f);
                //// 拼音 Normal 色
                //rc.Get<Image>("2").color = new Color(btnStyle[4] / 255f, btnStyle[5] / 255f, btnStyle[6] / 255f, btnStyle[7] / 255f);
                //// 拼音面板阴影 Normal 色
                //rc.Get<Image>("3").color = new Color(btnStyle[8] / 255f, btnStyle[9] / 255f, btnStyle[10] / 255f, btnStyle[11] / 255f);
                //// 选择色
                //rc.Get<Image>("4").color = new Color(btnStyle[12] / 255f, btnStyle[13] / 255f, btnStyle[14] / 255f, btnStyle[15] / 255f);
                #endregion
                //Log.Info("获取按钮样式完成");

                #region 布局Btn开场动画的开始和结束位置 以及缩放比例
                float scale = 1.0f;
                int BtnNum = contentsConfig.Sections[1] - contentsConfig.Sections[0];
                List<Vector3> BtnStartPos = new List<Vector3>();
                List<Vector3> BtnEndPos = new List<Vector3>();
                switch (BtnNum)
                {
                    case 3:
                        break;
                    case 4:
                        BtnEndPos.Add(new Vector3(-400, -200, 0));
                        BtnEndPos.Add(new Vector3(400, -200, 0));
                        BtnEndPos.Add(new Vector3(-400, -400, 0));
                        BtnEndPos.Add(new Vector3(400, -400, 0));

                        BtnStartPos.Add(new Vector3(-400, -200, 0) + new Vector3(2134, 0, 0));
                        BtnStartPos.Add(new Vector3(400, -200, 0) + new Vector3(2134, 0, 0));
                        BtnStartPos.Add(new Vector3(-400, -400, 0) + new Vector3(2134, 0, 0));
                        BtnStartPos.Add(new Vector3(400, -400, 0) + new Vector3(2134, 0, 0));

                        scale = 1.0f;
                        break;
                    case 5:
                        break;
                    case 6:
                        BtnEndPos.Add(new Vector3(-600, -200, 0));
                        BtnEndPos.Add(new Vector3(0, -200, 0));
                        BtnEndPos.Add(new Vector3(600, -200, 0));
                        BtnEndPos.Add(new Vector3(-600, -400, 0));
                        BtnEndPos.Add(new Vector3(0, -400, 0));
                        BtnEndPos.Add(new Vector3(600, -400, 0));

                        BtnStartPos.Add(new Vector3(-600, -200, 0) + new Vector3(2134, 0, 0));
                        BtnStartPos.Add(new Vector3(0, -200, 0) + new Vector3(2134, 0, 0));
                        BtnStartPos.Add(new Vector3(600, -200, 0) + new Vector3(2134, 0, 0));
                        BtnStartPos.Add(new Vector3(-400, -400, 0) + new Vector3(2134, 0, 0));
                        BtnStartPos.Add(new Vector3(0, -400, 0) + new Vector3(2134, 0, 0));
                        BtnStartPos.Add(new Vector3(400, -400, 0) + new Vector3(2134, 0, 0));

                        scale = 0.8f;
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    default:
                        Log.Info("未定义的布局");
                        break;
                }
                #endregion
                //Log.Info("获取按钮布局完成");

                #region 获取按钮文字和拼音
                List<string> BtnText = new List<string>();
                List<string> BtnTextPinyin = new List<string>();
                for (int i = 0; i < BtnNum; i++)
                {
                    string dataInConfig;
                    string data1 = "";
                    dataInConfig = Lessons_ConfigCategory.Instance.Get(contentsConfig.Sections[0] + i + 1).Section_Title;                    
                    string temp = "";
                    string block = " ";
                    // 修改汉字标题的格式
                    switch (dataInConfig.Length)
                    {
                        // 标题为3个字时
                        case 3:
                            for (int j = 0; j < 3; j++)
                            {
                                temp += dataInConfig.Substring(j, 1) + block;
                            }
                            temp = temp.Substring(0, temp.Length - 1);
                            data1 = temp;
                            data1 = data1.Replace(" ", block + block + block);
                            break;
                        // 标题为4个字时
                        case 4:
                            for (int j = 0; j < 4; j++)
                            {
                                temp += dataInConfig.Substring(j, 1) + block;
                            }
                            temp = temp.Substring(0, temp.Length - 1);
                            data1 = temp;
                            data1 = data1.Replace(" ", block + block);
                            break;
                        // 标题为5个字时
                        case 5:
                            for (int j = 0; j < 5; j++)
                            {
                                temp += dataInConfig.Substring(j, 1) + block;
                            }
                            temp = temp.Substring(0, temp.Length - 1);
                            data1 = temp;
                            break;
                        // 标题为6个字时
                        case 6:
                            for (int j = 0; j < 5; j++)
                            {
                                temp += dataInConfig.Substring(j, 1) + block;
                            }
                            temp = temp.Substring(0, temp.Length - 1);
                            data1 = temp;
                            break;
                        // 标题为7个字时
                        case 7:
                            
                            data1 = dataInConfig;
                            break;
                        default:
                            Log.Info($"得到的标题太长了吧: 【{dataInConfig}】");
                            break;
                    }
                    BtnText.Add(data1);

                    string data2;
                    data2 = Lessons_ConfigCategory.Instance.Get(contentsConfig.Sections[0] + i + 1).Section_Title_PinYin;
                    // 修改拼音标题的格式
                    switch (dataInConfig.Length)
                    {
                        case 3:
                            data2 = data2.Replace(" ", block + block + block + block + block);
                            break;
                        case 4:
                            data2 = data2.Replace(" ", block + block + block + block);
                            break;
                        case 5:
                            data2 = data2.Replace(" ", block + block + block);
                            break;
                        case 6:
                            data2 = data2.Replace(" ", block + block);
                            break;
                        case 7:
                            data2 = data2.Replace(" ", block + block);
                            break;
                        default:
                            break;
                    }
                    BtnTextPinyin.Add(data2);
                }
                #endregion
                //Log.Info("获取按钮文字信息完成");

                #region 开始复制按钮

                for (int i = 0; i < BtnNum; i++)
                {
                    // 复制一个按钮
                    GameObject btnCell = UnityEngine.Object.Instantiate(Btn, ui.GameObject.transform);
                    btnCell.name = "Btn" + i;

                    // 获取按钮上的rc组件
                    ReferenceCollector cellRC = btnCell.GetComponent<ReferenceCollector>();

                    // 设置缩放比
                    btnCell.transform.localScale = new Vector3(scale, scale, 1);


                    // 设置序号
                    if (i < 10)
                    {
                        cellRC.Get<Image>("NumImg2").overrideSprite = cellRC.Get<Image>((i + 1).ToString()).sprite;
                    }
                    else
                    {
                        cellRC.Get<Image>("NumImg1").overrideSprite = cellRC.Get<Image>((((i + 1) - (i + 1) % 10) / 10 + 1).ToString()).sprite;
                        cellRC.Get<Image>("NumImg2").overrideSprite = cellRC.Get<Image>(((i + 1) % 10).ToString()).sprite;
                    }

                    // 设置文本                                        
                    cellRC.Get<Text>("Title").text = BtnText[i];

                    // 设置拼音
                    cellRC.Get<Text>("PinYin").text = BtnTextPinyin[i];

                    // 设置颜色
                    cellRC.Get<Image>("NumImg1").color = cellRC.Get<Image>("1").color;
                    cellRC.Get<Image>("NumImg2").color = cellRC.Get<Image>("1").color;
                    cellRC.Get<Image>("LineImg1").color = cellRC.Get<Image>("1").color;
                    cellRC.Get<Image>("LineImg2").color = cellRC.Get<Image>("1").color;
                    cellRC.Get<Image>("LineImg3").color = cellRC.Get<Image>("1").color;
                    cellRC.Get<Image>("LineImg0").color = cellRC.Get<Image>("1").color;
                    cellRC.Get<Text>("Title").color = cellRC.Get<Image>("1").color;
                    cellRC.Get<Text>("PinYin").color = cellRC.Get<Image>("3").color;
                    cellRC.Get<Image>("PinYinBlock").color = cellRC.Get<Image>("1").color;
                    cellRC.Get<Image>("PinYinBlockShadow").color = cellRC.Get<Image>("5").color;

                    // 设置位置                    
                    btnCell.transform.localPosition = BtnEndPos[i];
                }

                #endregion
                //Log.Info("复制按钮完成");
            }

            #endregion            

            //添加UI控制组件            
            GSLesson_Helper.AddControler(ui, LessonIndex,prefabHandler,lessonXXX_handler);
            return ui;
        }

        public override void OnRemoveAsync(UIComponent uiComponent)
        {
            //for (int i = 0; i < GSRunningData.UnUseABList.Count; i++)
            //{
            //    await ResourcesComponent.Instance.UnloadBundleAsync(GSRunningData.UnUseABList[i].StringToAB());
            //}
        }
    }
}

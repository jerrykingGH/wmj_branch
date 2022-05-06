using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using DG.Tweening;
using BM;

namespace ET
{
    public static class Video_Extends
    {
        public static void Init(this Video_Component self)
        {            
            self.InitComponent();
            self.SetComponentProperty();
            self.AddMouseAction();
            self.AddKeyBoardAction();
        }        

        public static void InitComponent(this Video_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            // 获取VideoPlayer组件
            self.VideoPlayer = rc.Get<VideoPlayer>("VideoPlayer");

            // 获取Camara组件
            self.VideoCamera = GlobalComponent.Instance.Global.Find("UICamera").gameObject.GetComponent<Camera>();

            // 获取ScreenShot组件
            self.ScreenShot = rc.Get<Image>("ScreenShot");

            // 获取Controler组件
            self.Controler = rc.Get<GameObject>("Controler");
            self.Controler_Bottom = rc.Get<GameObject>("Controller Obj");

            // 获取所有控制用的组件
            self.ScreenCover = rc.Get<GameObject>("Video Cover");


            self.ScreenAnimator = self.ScreenCover.GetComponent<Animator>();
            self.ControlerAnimator = rc.Get<GameObject>("Controler").GetComponent<Animator>();


            self.ContolerHotArea = rc.Get<GameObject>("ControllerTouchArea");
            self.CurrentTime = rc.Get<Text>("currentTime");
            self.TotalTime = rc.Get<Text>("totalTime");
            self.PlayBtn = rc.Get<GameObject>("playBtn");
            self.Slider = rc.Get<GameObject>("Slider");
            self.SliderComponent = self.Slider.GetComponent<Slider>();
            self.VolumeBtn = rc.Get<GameObject>("VolumeBtn");
            self.VolumeBarBtn = rc.Get<GameObject>("volDisplay");
            self.VolumeOn = rc.Get<GameObject>("volOn");
            self.VolumeOff = rc.Get<GameObject>("volOff");
            self.VolumeIcon = rc.Get<GameObject>("vol1");
            self.VolumeDisplay = self.VolumeIcon.GetComponent<RectTransform>();

            self.MovieNameGO = rc.Get<Text>("MovieName");

            // 获取退出按钮组件
            self.QuitBtn = rc.Get<GameObject>("QuitBtn");

            // 获取信息按钮组件
            self.InfoBtn = rc.Get<GameObject>("InfoBtn");
        }
        public static void SetComponentProperty(this Video_Component self)
        {
            #region 设置VideoPlayer属性
            self.VideoPlayer.playOnAwake = false;
            self.VideoPlayer.isLooping = false;
            self.VideoPlayer.renderMode = VideoRenderMode.CameraFarPlane;            
            self.VideoPlayer.targetCamera = self.VideoCamera;
            self.VideoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
            #endregion

            #region 设置VideoPlayer的ScreenShot
            string videoBundleName = "Movie" + string.Format("{0:00}", GSRunningData.Movie_SelectedIndex);
            self.VideoAssetBundleName = videoBundleName;
            string videoBundlePath = BPath.UILesssonPath;
            videoBundlePath += "Lesson_" + string.Format("{0:000}", GSRunningData.Lesson_SelectedIndex) + "/";
            videoBundlePath += "Lesson_" + string.Format("{0:000}", GSRunningData.Lesson_SelectedIndex) + "_" + GSRunningData.Section_SelectedIndex + "/";
            self.VideoAssetPath = videoBundlePath;
            
            //Log.Info("所选的影片资源路径是= " + videoBundlePath);
            //Log.Info(videoBundlePath + "ScreenShot.png");
            //Log.Info(videoBundleName);
            
            Texture2D texture = AssetComponent.Load<Texture2D>(out self.ScreenShotHandler, self.VideoAssetPath + "ScreenShot.png", videoBundleName);            
            Sprite temp = Sprite.Create(texture, new Rect(0f, 0f, texture.width*1f, texture.height*1f), new Vector2(0f, 0f));            
            self.ScreenShot.GetComponent<Image>().overrideSprite = temp;
            

            //Texture2D texture = (Texture2D)ResourcesComponent.Instance.GetAsset(videoBundleName.StringToAB(), "ScreenShot");
            //Sprite temp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0));
            //self.ScreenShot.GetComponent<Image>().overrideSprite = temp;
            #endregion

            #region 设置VideoClip属性
            VideoClip video = null;
            string videoName = self.SelectFilm(videoBundleName);                        
            self.MovieNameGO.text = "中医药文化故事  — 《"+self.MovieName+"》";
            Log.Info(videoName);
            try
            {
                video = AssetComponent.Load<VideoClip>(out self.VideoHandler, self.VideoAssetPath + videoName, videoBundleName);
                //video = (VideoClip)ResourcesComponent.Instance.GetAsset(videoBundleName.StringToAB(), videoName);                
            }
            catch (Exception e)
            {

                video = null;
                Log.Error("视频文件有误,错误信息 ：" + e.Message);
            }
            if (video == null)
            {
                self.VideoPlayer.source = VideoSource.Url;
                self.VideoPlayer.url = self.VideoDir_URL + videoName;
            }
            else
            {
                self.VideoPlayer.source = VideoSource.VideoClip;
                self.VideoPlayer.clip = video;
            }
            #endregion
        }

        public static void AddMouseAction(this Video_Component self)
        {
            // 添加大屏按钮交互
            self.ScreenCover.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick);
            self.ScreenCover.AddEventListener(GSMouseEventType.MouseOver, self.OnMouseOver);
            // 添加播放按钮交互
            self.PlayBtn.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick);
            // 添加控制条触摸区交互
            self.ContolerHotArea.AddEventListener(GSMouseEventType.MouseOver, self.OnMouseOver);
            // 添加滑块交互
            self.Slider.AddEventListener(GSMouseEventType.MouseDown, self.OnMouseDown);
            self.Slider.AddEventListener(GSMouseEventType.MouseUp, self.OnMouseUp);
            // 添加音量控制交互
            self.VolumeBtn.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick);
            self.VolumeBarBtn.AddEventListener(GSMouseEventType.MouseDown, self.OnMouseDown);
            self.VolumeBarBtn.AddEventListener(GSMouseEventType.MouseUp, self.OnMouseUp);


            // 添加信息按钮交互
            self.InfoBtn.AddEventListener(GSMouseEventType.MouseClick, self.ShowInfo);
            // 添加退出按钮交互
            self.QuitBtn.AddEventListener(GSMouseEventType.MouseClick, self.Quit);
        }

        public static void AddKeyBoardAction(this Video_Component self)
        {
            self.kb = self.AddComponent<KeyBoardControler_Component>();            
            self.kb.AddEventListener(GSKeyBoardEventType.Single_Click_Up, self.OnSingleClickUp);
            //kb.AddEventListener(GSKeyBoardEventType.Single_Click_Down, self.OnSingleClickDown);
            self.kb.AddEventListener(GSKeyBoardEventType.Double_Click_Up, self.OnDoubleClickUp);
            self.kb.AddEventListener(GSKeyBoardEventType.Double_Click_Down, self.OnDoubleClickDown);
        }

        public static void OnSingleClickUp(this Video_Component self)
        {
            if (self.InExtend == false)
            {
                if (self.VideoPlayer.time == 0)
                {
                    self.ScreenAnimator.Play("DisplayVideoWithView", 0, 0);
                    self.ControlerAnimator.Play("ControlerOut", 0, 0);
                    self.PlayBtn.GetComponent<Toggle>().isOn = true;
                    self.VideoPlayer.Play();
                }
                else
                {
                    if (self.VideoPlayer.isPlaying)
                    {
                        self.ScreenAnimator.Play("CoverVideoWithOutView", 0, 0);
                        if (self.ControlerAnimator.gameObject.transform.localPosition.y != 0)
                        {
                            self.ControlerAnimator.Play("ControlerIn", 0, 0);
                        }
                        self.PlayBtn.GetComponent<Toggle>().isOn = false;
                        self.VideoPlayer.Pause();
                    }
                    else
                    {
                        self.ScreenAnimator.Play("DisplayVideoWithOutView", 0, 0);
                        self.ControlerAnimator.Play("ControlerOut", 0, 0);
                        self.PlayBtn.GetComponent<Toggle>().isOn = true;
                        self.VideoPlayer.Play();
                    }
                }
            }
        }

        public static void OnSingleClickDown(this Video_Component self)
        {
            
        }

        public static void OnDoubleClickUp(this Video_Component self)
        {            
            if (self.InExtend == false)
            {
                self.ShowInfo();
            }            
        }

        public static void OnDoubleClickDown(this Video_Component self)
        {
            if (self.InExtend == false)
            {
                self.Quit();
            }            
        }

        public static void OnMouseClick(this Video_Component self)
        {
            Log.Info(GSMouseData.LastObjectClicked.name);
            switch (GSMouseData.LastObjectClicked.name)
            {
                case "Video Cover":
                    if (self.VideoPlayer.time == 0)
                    {
                        self.ScreenAnimator.Play("DisplayVideoWithView", 0, 0);
                        self.ControlerAnimator.Play("ControlerOut", 0, 0);
                        self.PlayBtn.GetComponent<Toggle>().isOn = true;
                        self.VideoPlayer.Play();
                    }
                    else
                    {
                        if (self.VideoPlayer.isPlaying)
                        {
                            self.ScreenAnimator.Play("CoverVideoWithOutView", 0, 0);
                            if (self.ControlerAnimator.gameObject.transform.localPosition.y != 0)
                            {
                                self.ControlerAnimator.Play("ControlerIn", 0, 0);
                            }
                            self.PlayBtn.GetComponent<Toggle>().isOn = false;
                            self.VideoPlayer.Pause();
                        }
                        else
                        {
                            self.ScreenAnimator.Play("DisplayVideoWithOutView", 0, 0);
                            self.ControlerAnimator.Play("ControlerOut", 0, 0);
                            self.PlayBtn.GetComponent<Toggle>().isOn = true;
                            self.VideoPlayer.Play();
                        }
                    }
                    break;
                case "playBtn":
                    if (self.PlayBtn.GetComponent<Toggle>().isOn)
                    {
                        if (self.VideoPlayer.time == 0)
                        {
                            self.ScreenAnimator.Play("DisplayVideoWithView", 0, 0);
                        }
                        else
                        {
                            self.ScreenAnimator.Play("DisplayVideoWithOutView", 0, 0);
                        }
                        self.VideoPlayer.Play();
                    }
                    else
                    {
                        self.ScreenAnimator.Play("CoverVideoWithOutView", 0, 0);
                        self.VideoPlayer.Pause();
                    }
                    break;
                case "VolumeBtn":
                    if (self.volumeActive)
                    {
                        self.volumeActive = false;
                        self.VolumeOn.SetActive(false);
                        self.VolumeOff.SetActive(true);
                        self.VideoPlayer.SetDirectAudioVolume(0, 0);
                        self.VolumeDisplay.sizeDelta = new Vector2(-14 * 15, self.VolumeDisplay.sizeDelta.y);
                    }
                    else
                    {
                        self.volumeActive = true;
                        self.VolumeOn.SetActive(true);
                        self.VolumeOff.SetActive(false);
                        self.VideoPlayer.SetDirectAudioVolume(0, 1);
                        self.VolumeDisplay.sizeDelta = new Vector2(-14, self.VolumeDisplay.sizeDelta.y);
                    }
                    break;
                default:
                    Log.Info($"点击了未注册处理的物体：{GSMouseData.LastObjectClicked.name}");
                    break;
            }
        }

        public static void OnMouseOver(this Video_Component self)
        {

            switch (GSMouseData.LastObjectMatched.name)
            {
                case "ControllerTouchArea":
                    self.ControlerAnimator.Play("ControlerIn", 0, 0);
                    break;
                case "Video Cover":
                    if (self.VideoPlayer.isPlaying)
                    {
                        if (self.Controler_Bottom.gameObject.transform.localPosition.y == 0)
                        {
                            self.ControlerAnimator.Play("ControlerOut", 0, 0);
                            self.seekNow = false;
                            self.setVolume = false;
                            GSMouseData.LastObjectClicked = null;
                        }
                    }
                    break;
            }
        }

        public static void OnMouseDown(this Video_Component self)
        {
            switch (GSMouseData.LastObjectClicked.name)
            {
                case "Slider":
                    if (self.VideoPlayer.time > 0)
                    {
                        self.seekNow = true;
                        self.hisStatus_IsPlaying = self.VideoPlayer.isPlaying;
                    }
                    break;
                case "volDisplay":
                    self.setVolume = true;
                    break;
                default:
                    break;
            }

        }

        public static void OnMouseUp(this Video_Component self)
        {
            if (GSMouseData.LastObjectClicked != null)
            {
                switch (GSMouseData.LastObjectClicked.name)
                {
                    case "Slider":
                        if (self.seekNow && GSMouseData.LastObjectClicked.name == "Slider")
                        {
                            self.seekNow = false;
                            float x = self.SliderComponent.value;
                            self.VideoPlayer.time = x * self.VideoPlayer.length;
                            if (self.hisStatus_IsPlaying)
                            {
                                self.VideoPlayer.Play();
                                self.hisStatus_IsPlaying = false;
                            }
                        }
                        break;
                    case "volDisplay":
                        if (self.setVolume)
                        {
                            self.volumeActive = true;
                            self.VolumeOn.SetActive(true);
                            self.VolumeOff.SetActive(false);
                            self.VolumeDisplay.sizeDelta = new Vector2(-14 + 14 * (int)((Input.mousePosition.x - self.VolumeIcon.transform.position.x - 192) / 192 * 14), self.VolumeDisplay.sizeDelta.y);
                            float VolumeValue = (14 - (int)(-(Input.mousePosition.x - self.VolumeIcon.transform.position.x - 192) / 192f * 14f)) / 14f;

                            self.VideoPlayer.SetDirectAudioVolume(0, VolumeValue);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static string SelectFilm(this Video_Component self, string filmABName)
        {
            string videoName = "";
            switch (filmABName)
            {
                case "Movie01":
                    videoName = "10001_renshendegushi.webm";
                    self.MovieName = "人参的故事";
                    self.HasExtend = true;
                    self.BackLessonSelectedIndex = 1;
                    self.BackSectionSelectedIndex = 0;                    
                    break;
                case "Movie02":
                    videoName = "10002_shennongyuchaye.webm";
                    self.MovieName = "神农与茶叶";
                    break;
                case "Movie03":
                    videoName = "10003_LiShiZhenStory.webm";
                    self.MovieName = "李时珍的故事";
                    break;
                case "Movie04":
                    videoName = "10007_lingzhidegushi.webm";
                    self.MovieName = "灵芝的故事";
                    break;
                case "Movie05":
                    videoName = "10008_xinglindegushi.webm";
                    self.MovieName = "杏林的故事";
                    break;
                case "Movie06":
                    videoName = "10010_zhongqiujiechuanshuo.webm";
                    self.MovieName = "中秋节的传说";
                    break;
                case "Movie07":
                    videoName = "10011_dongzhi.webm";
                    self.MovieName = "冬至";
                    break;
                case "Movie08":
                    videoName = "10012_fulinggaodegushi.webm";
                    self.MovieName = "茯苓糕的故事";
                    break;
                case "Movie09":
                    videoName = "10013_ejiao.webm";
                    self.MovieName = "阿胶的故事";
                    break;
                case "Movie10":
                    videoName = "10014_qingnangshu.webm";
                    self.MovieName = "青囊书的故事";
                    break;
                case "Movie11":
                    videoName = "10016_beigongsheying.webm";
                    self.MovieName = "杯弓蛇影";
                    break;
                case "Movie12":
                    videoName = "10019_lianoudegushi.webm";
                    self.MovieName = "莲藕的故事";
                    break;
                case "Movie13":
                    videoName = "10026_dayuyukuaizi.webm";
                    self.MovieName = "大禹与筷子";
                    break;
                case "Movie14":
                    videoName = "10031_qianyi.webm";
                    self.MovieName = "钱乙的故事";
                    break;
                case "Movie15":
                    videoName = "10036_zhangzihe.webm";
                    self.MovieName = "张子和治病献三笑";
                    break;
                case "Movie16":
                    videoName = "10038_fanjinzhongju.webm";
                    self.MovieName = "范进中举";
                    break;
                case "Movie17":
                    videoName = "10040_sanqianlaifuzi.webm";
                    self.MovieName = "三千莱菔子换个红顶子";
                    break;
                case "Movie18":
                    videoName = "10049_gouqizi.webm";
                    self.MovieName = "枸杞子的故事";
                    break;
                case "Movie19":
                    videoName = "10052_ruyichangshengjiu.webm";
                    self.MovieName = "如意长生酒的故事";
                    break;
                case "Movie20":
                    videoName = "10057_wenjiqiwu.webm";
                    self.MovieName = "闻鸡起舞";
                    break;
                case "Movie21":
                    videoName = "10058_yiyindegushi.webm";
                    self.MovieName = "伊尹的故事";
                    break;
                case "Movie22":
                    videoName = "10060_hualongdianjing.webm";
                    self.MovieName = "画龙点睛";
                    break;
                case "Movie23":
                    videoName = "10061_bingtanghulu.webm";
                    self.MovieName = "冰糖葫芦的故事";
                    break;
                case "Movie24":
                    videoName = "10063_guaaicaodexisu.webm";
                    self.MovieName = "挂艾草的习俗";
                    break;
                case "Movie25":
                    videoName = "10064_mafancao.webm";
                    self.MovieName = "麻烦草的故事";
                    break;
                case "Movie26":
                    videoName = "10068_shanyaodegushi.webm";
                    self.MovieName = "山药的故事";
                    break;
            }

            return videoName;
        }

        public static void SelectExtend(this Video_Component self, string filmABName)
        {
            switch (filmABName)
            {
                case "Movie01":
                    self.ExtendUI.AddComponent<Movie01_Extend>();                    
                    break;
                case "Movie02":
                    
                    break;
                case "Movie03":
                    
                    break;
                case "Movie04":
                    
                    break;
                case "Movie05":
                    
                    break;
                case "Movie06":
                    
                    break;
                case "Movie07":
                    
                    break;
                case "Movie08":
                    
                    break;
                case "Movie09":
                    
                    break;
                case "Movie10":
                    
                    break;
                case "Movie11":
                    
                    break;
                case "Movie12":
                    
                case "Movie13":
                    
                    break;
                case "Movie14":
                    
                    break;
                case "Movie15":
                    
                    break;
                case "Movie16":
                    
                    break;
                case "Movie17":
                    
                    break;
                case "Movie18":
                    
                    break;
                case "Movie19":
                    
                    break;
                case "Movie20":
                    
                    break;
                case "Movie21":
                    
                    break;
                case "Movie22":
                    
                    break;
                case "Movie23":
                    
                    break;
                case "Movie24":
                    
                    break;
                case "Movie25":
                    
                    break;
                case "Movie26":
                    
                    break;
            }
        }
        
        public static async void Quit(this Video_Component self)
        {
            // 必须赋值
            GSRunningData.Target = GSUIType.UILessonScene;
            GSRunningData.Lesson_SelectedIndex = self.BackLessonSelectedIndex;
            GSRunningData.Section_SelectedIndex = self.BackSectionSelectedIndex;
            // 根据类型赋值
            GSRunningData.Movie_SelectedIndex = 0;
            // 操作清空
            GSRunningData.Limit = false;
            GSRunningData.PageIndex = 0;
            GSRunningData.ChoiceIndex = 0;
            // 流程删除赋值
            GSRunningData.HistTaget.Add(GSUIType.UIMovieScene, true);            

            if (self.HasExtend)
            {
                if (self.DomainScene().GetComponent<UIComponent>().UIs.ContainsKey("MovieExtend"))
                {
                    self.DomainScene().GetComponent<UIComponent>().UIs["MovieExtend"].Dispose();
                    self.DomainScene().GetComponent<UIComponent>().UIs.Remove("MovieExtend");
                }                
            }

            await GSUIHelper.Create(self.DomainScene(), GSUIType.UILoadingScene, UILayer.High);
        }

        public static void ShowInfo(this Video_Component self)
        {
            
            if (self.HasExtend)
            {
                Log.Info(self.InExtend.ToString());
                if (self.InExtend == false)
                {
                    if (self.VideoPlayer.isPlaying)
                    {
                        self.ScreenAnimator.Play("CoverVideoWithOutView", 0, 0);
                        if (self.ControlerAnimator.gameObject.transform.localPosition.y != 0)
                        {
                            self.ControlerAnimator.Play("ControlerIn", 0, 0);
                        }
                        self.PlayBtn.GetComponent<Toggle>().isOn = false;                        
                    }
                    self.PlayBtn.GetComponent<Toggle>().isOn = false;
                    self.VideoPlayer.Pause();
                    self.InExtend = true;

                    GameObject extendGameObject = AssetComponent.Load<GameObject>(out LoadHandler handler, self.VideoAssetPath + "Extend.prefab", self.VideoAssetBundleName);
                    self.ExtendHandlers.Add(handler);
                    //GameObject extendGameObject = (GameObject)ResourcesComponent.Instance.GetAsset(("Movie" + string.Format("{0:00}", GSRunningData.Movie_SelectedIndex)).ToLower().StringToAB(), "Extend");
                    GameObject extend = GameObject.Instantiate(extendGameObject, self.GetParent<UI>().GameObject.transform);
                    self.ExtendUI = self.DomainScene().GetComponent<UIComponent>().AddChild<UI, string, GameObject>("MovieExtend", extend);
                    self.DomainScene().GetComponent<UIComponent>().UIs.Add("MovieExtend", self.ExtendUI);
                    self.GetParent<UI>().AddChild(self.ExtendUI);
                    string videoBundleName = "Movie" + string.Format("{0:00}", GSRunningData.Movie_SelectedIndex);
                    self.SelectExtend(videoBundleName);

                    extend.transform.localScale = new Vector3(0f, 0f, 1f);
                    extend.transform.localPosition = new Vector3(0f, 0f,0f);
                    extend.transform.DOScale(1f, 0.5f).SetEase(Ease.InBounce);
                }
            }
        }
    }
}

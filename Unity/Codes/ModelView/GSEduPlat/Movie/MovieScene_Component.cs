using BM;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace ET
{
    public class Video_Component : Entity, IAwake, IUpdate, IDestroy
    {
        public LoadHandler PlayerHandler;
        public LoadHandler ScreenShotHandler;
        public LoadHandler VideoHandler;
        public List<LoadHandler> ExtendHandlers = new List<LoadHandler>();

        public string VideoAssetBundleName;
        public string VideoAssetPath;

        public int BackLessonSelectedIndex = 0;
        public int BackSectionSelectedIndex = 0;

        public VideoPlayer VideoPlayer;

        public KeyBoardControler_Component kb;

        public GameObject Controler,Controler_Bottom;

        public readonly string VideoDir_URL = "https://list.gsjyvip.com/public/video/";

        public Image ScreenShot;

        public Camera VideoCamera;

        public GameObject ScreenCover;
        public GameObject CoverBtn;
        public GameObject ContolerHotArea;
        public Animator ScreenAnimator;
        public Animator ControlerAnimator;
        public Text CurrentTime;
        public Text TotalTime;        

        public GameObject PlayBtn;
        public GameObject Slider;
        public Slider SliderComponent;
        public GameObject VolumeBtn;
        public GameObject VolumeBarBtn;
        public GameObject VolumeOn;
        public GameObject VolumeOff;


        public bool seekNow = false;
        public bool hisStatus_IsPlaying = false;
        public bool volumeActive = true;
        public bool setVolume = false;
        public GameObject VolumeIcon;
        public RectTransform VolumeDisplay;

        public GameObject InfoBtn;
        public GameObject QuitBtn;

        public bool HasExtend = false;
        public string MovieName = "";
        public Text MovieNameGO;
        public UI ExtendUI;
        public bool InExtend = false;
    }
}




//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Android;
//using UnityEngine.UI;
//using UnityEngine.Video;
//using DG.Tweening;

//public class VideoPlayerScript : MonoBehaviour
//{
//    VideoPlayer _videoPlayer;

//    public RawImage rawImage;
//    public RectTransform volumeRT;
//    public RectTransform volumeParentRT;
//    public Image volumeOn;
//    public Image volumeOff;
//    private readonly float volume = 145f;

//    public Text currentTime;
//    public Text totalTime;

//    public Toggle playToggle;
//    public Slider seekSlider;
//    private bool isPlayed;
//    private bool isMoved;

//    public GameObject coverObj;
//    public GameObject buttonMask;
//    public CanvasGroup canvasGroup;

//    Vector2 localPos;

//    public Action ExitAction;
//    private KeyBoardActionControler keyBoardActionControler;

//    float time;
//    /// <summary>
//    /// 超过等待时间，视频操作条隐藏
//    /// </summary>
//    private readonly float waitTime = 2f;
//    string URL;
//    public Image videoView;
//    //private readonly string URL = $"https://total.gsjyvip.com/public/video/20200316/";
//    //private readonly string URL = $"https://total.gsjyvip.com/public/vod/20210120/";

//    void Awake()
//    {
//        URL = Application.streamingAssetsPath + "/";
//        _videoPlayer = this.GetComponent<VideoPlayer>();
//        VideoInit();
//    }
//    private void VideoInit()
//    {
//        //_videoPlayer.source = VideoSource.Url;
//        _videoPlayer.source = VideoSource.VideoClip;
//        _videoPlayer.renderMode = VideoRenderMode.RenderTexture;

//        _videoPlayer.isLooping = false;
//        _videoPlayer.playOnAwake = false;

//        _videoPlayer.prepareCompleted += OnPrepareCompleted;
//        _videoPlayer.loopPointReached += OnVideoEnd;
//        _videoPlayer.frameReady += OnFrameReady;

//        this.ExitAction = null;
//        keyBoardActionControler = this.GetComponent<KeyBoardActionControler>();
//    }
//    public void OnFrameReady(VideoPlayer videoPlayer, long frame)
//    {
//        Debug.Log("OnFrameReady");
//    }


//    public void OnPrepareCompleted(VideoPlayer videoPlayer)
//    {
//        rawImage.texture = _videoPlayer.texture;
//        _videoPlayer.Play();
//        Play();
//        time = 0;
//    }
//    private void OnVideoEnd(VideoPlayer videoPlayer)
//    {
//        Debug.Log("over");

//        coverObj.SetActive(true);
//        playToggle.isOn = false;
//        _videoPlayer.time = 0;
//        seekSlider.value = 0;
//        currentTime.text = "00:00";
//        videoView.gameObject.SetActive(true);
//        // TODO 播放完毕 显示动画预览图
//        //  videoView.overrideSprite = Resources.Load<Sprite>("杏林的故事.mp4") as Sprite;

//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        if (isPlayed)
//        {
//            if (_videoPlayer.texture == null || _videoPlayer == null)
//            {
//                return;
//            }
//            rawImage.texture = _videoPlayer.texture;

//            UpdateVideoTime();
//            UpdateVideoSlider();

//            time += Time.deltaTime;
//            if (time >= waitTime)
//            {
//                StartCoroutine(DoChangeCanvasGroup(0.1f));
//                time = 0;
//            }
//        }
//    }
//    IEnumerator DoChangeCanvasGroup(float a)
//    {
//        buttonMask.SetActive(true);
//        while (true)
//        {
//            yield return new WaitForSeconds(a);
//            canvasGroup.alpha -= a;

//            if (canvasGroup.alpha <= 0)
//            {
//                yield break;
//            }
//        }
//    }
//    private void UpdateVideoTime()
//    {
//        totalTime.text = GetTimeString(_videoPlayer.length);
//        currentTime.text = GetTimeString(_videoPlayer.time);
//    }
//    private void UpdateVideoSlider()
//    {
//        if (!isMoved)
//        {
//            seekSlider.value = (float)_videoPlayer.time / (float)_videoPlayer.length;
//        }
//    }
//    //[AVProVideo] Error: Loading failed.  File not found, codec not supported, video resolution too high or insufficient system resources.
//    /// <summary>
//    /// TODO  视频播放调用
//    /// </summary>
//    public void StartPlay(string url)
//    {
//        _videoPlayer.source = VideoSource.Url;
//        _videoPlayer.url = string.Format($"https://list.gsjyvip.com/public/video/{url}.mp4");
//        // _videoPlayer.url = string.Format( url);
//        _videoPlayer.Prepare();
//        playToggle.isOn = true;
//        time = 0;
//    }

//    //通过ab资源播放视频调用
//    public void StartPlayByAB(VideoClip videoClip)
//    {
//        this._videoPlayer.source = VideoSource.VideoClip;
//        this._videoPlayer.clip = videoClip;
//        this._videoPlayer.Prepare();
//        this.playToggle.isOn = true;
//        this.time = 0;
//    }

//    public void ShowButton()
//    {
//        buttonMask.SetActive(false);
//        canvasGroup.alpha = 1;
//        time = 0;

//    }

//    #region 视频进度调整
//    /// 移动视频进度条  
//    public void OnDragSlider()
//    {
//        if (!isPlayed)
//            return;
//        _videoPlayer.time = seekSlider.value * (float)_videoPlayer.length;
//    }

//    // 按下视频进度条  
//    public void OnPoniterDownSlider()
//    {
//        if (!isPlayed)
//            return;
//        isMoved = true;
//        _videoPlayer.Pause();
//    }

//    /// 弹起视频进度条  
//    public void OnPoniterUpSlider()
//    {
//        if (!isPlayed)
//            return;
//        isMoved = false;
//        time = 0;
//        _videoPlayer.time = seekSlider.value * (float)_videoPlayer.length;
//        _videoPlayer.Play();
//    }
//    #endregion

//    public void CenterPlayClick()
//    {
//        playToggle.isOn = !playToggle.isOn;
//        Play();
//    }


//    public void Play()
//    {
//        videoView.gameObject.SetActive(false);
//        isPlayed = true;
//        if (playToggle.isOn)
//        {
//            DoPlay();
//        }
//        else
//        {
//            DoPause();
//        }
//        time = 0;
//    }



//    public void PlayMethod()
//    {
//        playToggle.isOn = true;
//        if (_videoPlayer == null)
//        {
//            return;
//        }
//        _videoPlayer.Play();
//        coverObj.SetActive(false);
//    }

//    public void DoPlay()
//    {
//        if (_videoPlayer == null)
//        {
//            return;
//        }
//        _videoPlayer.Play();
//        coverObj.SetActive(false);
//    }
//    public void DoPause()
//    {
//        if (_videoPlayer == null)
//        {
//            return;
//        }
//        _videoPlayer.Pause();
//        coverObj.SetActive(true);
//        this.isPlayed = false;
//    }

//    /// <summary>
//    /// 时间格式转换
//    /// </summary>
//    /// <param name="timeSeconds"></param>
//    /// <param name="showMilliseconds"></param>
//    /// <returns></returns>
//    public string GetTimeString(double timeSeconds, bool showMilliseconds = false)
//    {
//        float totalSeconds = (float)timeSeconds;
//        int hours = Mathf.FloorToInt(totalSeconds / (60f * 60f));
//        float usedSeconds = hours * 60f * 60f;

//        int minutes = Mathf.FloorToInt((totalSeconds - usedSeconds) / 60f);
//        usedSeconds += minutes * 60f;

//        int seconds = Mathf.FloorToInt(totalSeconds - usedSeconds);

//        string result;
//        if (hours <= 0)
//        {
//            if (showMilliseconds)
//            {
//                int milliSeconds = (int)((totalSeconds - Mathf.Floor(totalSeconds)) * 1000f);
//                result = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
//            }
//            else
//            {
//                result = string.Format("{0:00}:{1:00}", minutes, seconds);
//            }
//        }
//        else
//        {
//            if (showMilliseconds)
//            {
//                int milliSeconds = (int)((totalSeconds - Mathf.Floor(totalSeconds)) * 1000f);
//                result = string.Format("{2}:{0:00}:{1:00}:{3:000}", minutes, seconds, hours, milliSeconds);
//            }
//            else
//            {
//                result = string.Format("{2}:{0:00}:{1:00}", minutes, seconds, hours);
//            }
//        }

//        return result;
//    }
//    /// <summary>
//    /// 音量开关
//    /// </summary>
//    public void OnVolumeOn()
//    {
//        //音量开关切换
//        volumeOff.color = new Color(1, 1, 1, 1);
//        volumeOn.color = new Color(1, 1, 1, 0);
//        volumeOff.raycastTarget = true;
//        //静音
//        _videoPlayer.SetDirectAudioMute(0, true);

//        time = 0;
//    }
//    public void OnVolumeOff()
//    {
//        volumeOff.raycastTarget = false;

//        volumeOff.color = new Color(1, 1, 1, 0);
//        volumeOn.color = new Color(1, 1, 1, 1);
//        _videoPlayer.SetDirectAudioMute(0, false);

//        time = 0;
//    }
//    /// <summary>
//    /// 音量滑动条
//    /// </summary>
//    public void OnVolumeChanged()
//    {
//        OnVolumeOff();
//        //-72.5  
//        RectTransformUtility.ScreenPointToLocalPointInRectangle(volumeParentRT, Input.mousePosition, Camera.main, out localPos);

//        volumeRT.sizeDelta = new Vector2(localPos.x + 72.5f, volumeRT.sizeDelta.y);
//        volumeRT.sizeDelta = new Vector2(Mathf.Clamp(volumeRT.sizeDelta.x, 0, volume), volumeRT.sizeDelta.y);

//        //音量
//        _videoPlayer.SetDirectAudioVolume(0, volumeRT.sizeDelta.x / volume);

//        if (volumeRT.sizeDelta.x <= 0)
//        {
//            OnVolumeOn();
//        }
//        time = 0;
//    }

//    public void Exit()
//    {
//        time = 0;
//        _videoPlayer.Stop();
//        this.ExitAction?.Invoke();
//    }

//    // 键盘交互： 上下单击 播放/暂停  双击下退出    完毕后 上下 播放

//    private void Update()
//    {
//        if (this.keyBoardActionControler.KEYBOARD_EVENT == "")
//        {
//            return;
//        }

//        switch (this.keyBoardActionControler.KEYBOARD_EVENT)
//        {

//            case "Single Click Up":
//                if (this.keyBoardActionControler.ShareData.pageIndex == 0)
//                {
//                    if (this.isPlayed)
//                    {
//                        //播放状态 按上  暂停
//                        //   this.Pause();
//                        playToggle.isOn = false;
//                    }
//                    else
//                    {
//                        //暂停状态按上 播放 
//                        playToggle.isOn = true;
//                    }

//                    this.keyBoardActionControler.KEYBOARD_EVENT = "";
//                }
//                break;
//            case "Single Click Down":
//                if (this.keyBoardActionControler.ShareData.pageIndex == 0)
//                {

//                    if (this.isPlayed)
//                    {
//                        //播放状态 按上  暂停
//                        playToggle.isOn = false;
//                    }
//                    else
//                    {
//                        //暂停状态按上 播放
//                        playToggle.isOn = true;
//                    }
//                    this.keyBoardActionControler.KEYBOARD_EVENT = "";
//                }
//                break;
//            case "Double Click Down":
//                if (this.keyBoardActionControler.ShareData.pageIndex == 0)
//                {
//                    Exit();
//                    this.keyBoardActionControler.KEYBOARD_EVENT = "";
//                }
//                break;
//        }
//    }
//}

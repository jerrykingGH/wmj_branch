using System.Collections.Generic;
using UnityEngine;
using BM;
namespace ET
{
    public class MainPageScene_Main_0_Component : Entity, IAwake, IUpdate,IDestroy
    {
        public LoadHandler loadHandler;

        // Banner的数量
        public int BannerNum = 3;

        // 跑马灯的数量     
        public int BroadCastNum = 3;                 

        // 此界面下所有加载预制体的Handler
        public List<LoadHandler> CellHandler = new List<LoadHandler> ();

        // 此界面下所有Banner预制体的内存镜像
        public List<GameObject> BannerTemp = new List<GameObject> ();

        // 此界面下所有BroadCast预制体的内存镜像
        public List<GameObject> BroadCastTemp = new List<GameObject> ();

        public GameObject BannerDisplayContainer;
        public GameObject BannerUpContainer;
        public GameObject BannerDownContainer;
        public GameObject BroadCastContainer;

        public GameObject Display;
        public GameObject MotionUp;
        public GameObject MotionDown;

        // Banner展示相关-----------------------------------------------

        // 自动切换Banner的开关
        public bool AutoDisplayBanner = false;

        // 当前Banner的展示时间
        public float CurrentShowTime = 0f;

        // 每个Banner的展示时间
        public List<float> BannerShowTime = new List<float>
            {
                5f, // 第一个Banner展示时间
                5f, // 第二个Banner展示时间
                5f  // 第三个Banner展示时间
            };
        public List<GameObject> TipNormal = new List<GameObject>();
        public List<GameObject> TipSelect = new List<GameObject>();
        public List<GameObject> TipTouchArea = new List<GameObject>();
        
        // 当前Banner的序号
        public int BannerIndex = 0;        
        
        // Banner DoTween的出现时间
        public float TransTime = 0.5f;

        // -----------------------------------------------------------







        // 跑马灯展示相关---------------------------------------------

        public List<GameObject> BroadCast;
        public List<bool> BroadCastCanMove;
        public List<float> BroadCastWidth;
        public float BroadCastContainerWidth = 0f;
        public float BroadCastSpeed = 2f;
        public float BroadCastStep = 300f;

        //-----------------------------------------------------------
    }
}

using BM;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public struct YaoShiTongYuan
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public List<string> PicInfo { get; set; }
    }


    public class YinShiYuJianKang_Component : Entity, IAwake, IUpdate, IDestroy
    {
        public LoadHandler mainHandler;
        public LoadHandler picDatabaseHandler;
        public string AssetBundleName;

        public int BackLessonSelectedIndex;
        

        public YaoShiTongYuan InfoStru;

        public List<Image> Point;
        public bool PointDoTweenIsPlaying = false;
        public float PointFlashTime = 1.0f;

        // 粒子
        public GameObject ParticleContainer;
        public GameObject PCell;
        public int ParticleNum = 15;
        public int ParticleCreateStep = 0;
        public List<GameObject> ParticleGO = new List<GameObject>();
        public List<int> ParticleMotionTime = new List<int>();
        public List<Vector3> ParticlePostion = new List<Vector3>();
        public List<bool> ParticleRefresh = new List<bool>();

        // 图片资源
        //public List<Vector2> PicCutPositon = new List<Vector2>();
        public List<Sprite> DetailPicSprite = new List<Sprite>();
        public List<Image> IdlePic = new List<Image>();
        public List<Image> MotionPic = new List<Image>();
        public Image MainItemContainer;
        public GameObject IdlePicGroup;
        public GameObject MotionPicGroup;

        public int FontPicIndex = 0;


        // 文本资源
        public Text Title_Inpart1;
        public Text Title_Inpart2;
        public Text Content_Inpart1;

        // 动画
        public Animator SceneChange;
        public Animator DetailMotion;

        // 按钮
        public GameObject PrevBtn;
        public GameObject NextBtn;
        public GameObject QuitBtn;
    }
}

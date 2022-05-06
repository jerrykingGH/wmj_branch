using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BM;

namespace ET
{
    public struct MainPageCellButtonStru
    {
        public int index { get; set; }
        public GameObject cell { get; set; }
        public LoadHandler handler { get; set; }
    }

    public class MainPageScene_Main_1_Component : Entity, IAwake,IDestroy
    {
        public LoadHandler loadHandler;        

        public GameObject
            ParentGO,
            Top,
            Left,
            Right;

        // Right
        public GameObject
            ThumbnailsScreen,
            ThumbnailsInfo,
            DefaultThumbnails,
            PicDataBase;
        
        public Image ThumbnailsImage;

        public List<GameObject> SectionBtn = new List<GameObject>();

        public GameObject StartBtn, EndBtn;

        public Dictionary<string, int> ChoiceIndex = new Dictionary<string, int>();

        public string HisThumbnails = "";

        public LoadHandler HisThumbLoadHandler;
        //public Dictionary<string, LoadHandler> HisThumbnails = new Dictionary<string, LoadHandler>();

        //public string HisThumbnails_ABName = "";


        // Left
        public GameObject
            ListContainer;

        public GridLayoutGroup ListGrid;
        public float CellScale = 1f;

        public List<MainPageCellButtonStru> CellGroup = new List<MainPageCellButtonStru>();


        // 运行所需传递变量
        public string LessonSelected = "";
        public int LessonSelected_ID = 1001;
        public int SectionSelected_ID = 0;       
    }
}

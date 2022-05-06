using BM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace ET
{
    public class ListCell_Component:Entity,IAwake,IUpdate
    {
        public string Assets_URL = "http://124.70.94.18:8879/test/";
        public int LessonID = 0;
        public bool Start = false;
        public ReferenceCollector PicDataBase;
        public MainPageScene_Main_1_Component MainControler;

        public bool Refreshing = false;
        public bool DownLoading = false;

        public string LocalServerURL = "127.0.0.1";

        public string Saving = "";

        public UpdateBundleDataInfo updateBundleDataInfo;
        public Image ProgressCircle;
        public Image ProgressIcon;
    }
}

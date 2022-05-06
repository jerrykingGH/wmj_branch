using System.Collections.Generic;
using UnityEngine;
using BM;

namespace ET
{
    // 消息框的类型
    public enum GSMessageBoxType
    {
        Warning,
        Help,
        Error,
        Update,
        Notice,
        Information
    }
    // 消息框返回类型
    public enum GSMessageBoxResultType
    {
        None,
        Yes,
        No,
        Cancel,
        Quit,
        Confirm
    }          

    public static class GSRunningData
    {
        #region 后台相关

        // 网络是否连接
        public static bool NetEnable = false;

        // 已下载过的课程目录
        public static string LessonDownLoaded = "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

        // 许可证允许访问的课程目录
        public static string Permit =           "11000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

        // 开发完成的课程目录
        public static string LessonDeveloped =  "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";

        // 记录版本信息  格式 = Version__年版本号(2022年为0,2023年为1,以此类推).月版本号.日版本号(00)_版本属性(Alpha:内测,Beta:外测,Release:最终)
        public static string Version;




        // 记录需要卸载的资源信息
        public static Dictionary<string,bool> BundleNeedRemove = new Dictionary<string, bool>();        

        #endregion

        #region 主界面相关

        // 记录需要显示的课程列表;
        public static List<int> LessonList = new List<int>();

        // 记录当前显示的缩略图包名
        public static Dictionary<string, LoadHandler> CurrentThumbnails = new Dictionary<string, LoadHandler>();

        #endregion

        #region Loading相关

        // 需要跳转目标的类型
        // 取值范围：    1."MainPage";
        //               2."Lesson";
        //               3."XiaoLangZhong";
        //               6."YinShiYuJianKang";
        //               7."XiaoLangZhong3D";
        //               8."QuestionGame";
        //               9."Movie"
        public static string Target;

        public static Dictionary<string,bool> HistTaget = new Dictionary<string, bool>();

        // 选择的课程序号(1-110)
        public static int Lesson_SelectedIndex;
        // 跳转章节的序号(1-10)依据课程而定
        public static int Section_SelectedIndex;
        // 选择的影片序号(1-26)
        public static int Movie_SelectedIndex;
        // 小郎中的类型序号(1-4)
        public static int XiaoLangZhong_TypeIndex;
        // 小郎中选择的序号(1-All)
        public static int XiaoLangZhong_SelectedIndex;
        // 饮食与健康选择的序号(1-All)
        public static int YinShiYuJianKang_SelectedIndex;

        #endregion        

        #region 课件操作相关

        // 页面的序号
        public static int PageIndex;

        // 选择的序号
        public static int ChoiceIndex;

        // 按钮总开关
        public static bool Limit = false;

        #endregion

        #region MessageBox相关
        // MessageBox传递的值
        public static GSMessageBoxResultType MessageBoxComfirm = GSMessageBoxResultType.None;

        // MessageBox的LoadHandler
        public static LoadHandler MsgBoxHandler;
        #endregion





        //public static Scene ZoneScene;

        //public static string TestStr = "你大爷";

        // 保存之前使用的UI类型
        //public static Dictionary<string, GameObject> HisTargetNeedRemove = new Dictionary<string, GameObject>();        

        // 已经加载的AB包
        //public static List<string> UnUseABList = new List<string>();        

        // 当前场景使用中的组件列表
        //public static Dictionary<string, Entity> CurrentComponentInScene = new Dictionary<string, Entity>();

        #region 考虑不用的属性

        //public static string HisTarget;

        // 跳转目标所属的序号
        //public static int TargetIndex;

        //// 跳转章节的序号
        //public static int SectionIndex;

        #endregion
        
    }
}


using BM;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class GSLesson_Helper
    {
        public static void AddControler(UI ui, int Lesson_Index, LoadHandler typeHander, LoadHandler extendHandler = null)
        {
            
            switch (Lesson_Index)
            {
                // Lesson001
                case 10001:
                    {
                        Lesson_001_0 TempScript = ui.AddComponent<Lesson_001_0>();
                        TempScript.loadHandler = typeHander;
                        TempScript.LessonXXX_loadHandler = extendHandler;
                    }
                    break;                
                case 10003:
                    {
                        Lesson_001_2 TempScript = ui.AddComponent<Lesson_001_2>();
                        TempScript.loadHandler = typeHander;
                    }                    
                    break;

                // Lesson002
                case 10007:
                    {
                        Lesson_002_0 TempScript = ui.AddComponent<Lesson_002_0>();
                        TempScript.loadHandler = typeHander;
                        TempScript.LessonXXX_loadHandler = extendHandler;
                    }
                    break;
                case 10008:
                    break;
                case 10009:
                    break;
                case 10010:
                    break;
                //case 10005:
                //    ui.AddComponent<OneButtonScene>();
                //    break;
                default:
                    Log.Error("未录入的组件");
                    break;
            }
        }

        public static void ChangeNormal(this GameObject self)
        {
            ReferenceCollector rc = self.GetComponent<ReferenceCollector>();
            //Log.Info(rc.Get<Image>("1").color.ToString());
            rc.Get<Image>("NumImg1").color = rc.Get<Image>("1").color;
            rc.Get<Image>("NumImg2").color = rc.Get<Image>("1").color;
            rc.Get<Image>("LineImg1").color = rc.Get<Image>("1").color;
            rc.Get<Image>("LineImg2").color = rc.Get<Image>("1").color;
            rc.Get<Image>("LineImg3").color = rc.Get<Image>("1").color;
            rc.Get<Image>("LineImg0").color = rc.Get<Image>("1").color;
            rc.Get<Text>("Title").color = rc.Get<Image>("1").color;
            rc.Get<Text>("PinYin").color = rc.Get<Image>("3").color;
            rc.Get<Image>("PinYinBlock").color = rc.Get<Image>("1").color;
            rc.Get<Image>("PinYinBlockShadow").color = rc.Get<Image>("5").color;
        }

        public static void ChangeSelect(this GameObject self)
        {
            ReferenceCollector rc = self.GetComponent<ReferenceCollector>();
            //Log.Info(rc.Get<Image>("2").color.ToString());
            rc.Get<Image>("NumImg1").color = rc.Get<Image>("2").color;
            rc.Get<Image>("NumImg2").color = rc.Get<Image>("2").color;
            rc.Get<Image>("LineImg1").color = rc.Get<Image>("2").color;
            rc.Get<Image>("LineImg2").color = rc.Get<Image>("2").color;
            rc.Get<Image>("LineImg3").color = rc.Get<Image>("2").color;
            rc.Get<Image>("LineImg0").color = rc.Get<Image>("2").color;
            rc.Get<Text>("Title").color = rc.Get<Image>("2").color;
            rc.Get<Text>("PinYin").color = rc.Get<Image>("4").color;
            rc.Get<Image>("PinYinBlock").color = rc.Get<Image>("2").color;
            rc.Get<Image>("PinYinBlockShadow").color = rc.Get<Image>("6").color;
        }
    }
}

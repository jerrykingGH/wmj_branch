using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BM;

namespace ET
{
    [ObjectSystem]
    public class Lesson_002_0_AwakeEventSystem : AwakeSystem<Lesson_002_0>
    {
        public override void AwakeAsync(Lesson_002_0 self)
        {
            // 添加键盘交互
            KeyBoardControler_Component kb = self.AddComponent<KeyBoardControler_Component>();
            kb.AddEventListener(GSKeyBoardEventType.Single_Click_Up, self.OnSingleClickUp);
            kb.AddEventListener(GSKeyBoardEventType.Single_Click_Down, self.OnSingleClickDown);
            kb.AddEventListener(GSKeyBoardEventType.Double_Click_Up, self.OnDoubleClickUp);
            kb.AddEventListener(GSKeyBoardEventType.Double_Click_Down, self.OnDoubleClickDown);

            self.BtnGroup = new List<GameObject>();
            for (int i = 0; i < 6; i++)
            {
                self.BtnGroup.Add(self.GetParent<UI>().GameObject.transform.Find("Btn" + i).gameObject);

                self.BtnGroup[i].AddEventListener(GSMouseEventType.MouseOver, self.OnMouseOver);
                self.BtnGroup[i].AddEventListener(GSMouseEventType.MouseOut, self.OnMouseOut);
                self.BtnGroup[i].AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick);
            }
            self.GetParent<UI>().GameObject.transform.Find("QuitButton").gameObject.AddEventListener(GSMouseEventType.MouseClick, self.Quit);
        }
    }

    [ObjectSystem]
    public class Lesson_002_0_DestroyEventSystem : DestroySystem<Lesson_002_0>
    {
        public override void Destroy(Lesson_002_0 self)
        {
            self.loadHandler.UnLoad();
            self.LessonXXX_loadHandler.UnLoad();
            AssetComponent.UnLoadPackageAssets("Lesson_XXX");
            AssetComponent.UnLoadPackageAssets("Lesson_002_0");
        }
    }
}

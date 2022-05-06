using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class Movie01_Extend_AwakeEventSystem : AwakeSystem<Movie01_Extend>
    {
        public override void AwakeAsync(Movie01_Extend self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.QuitBtn = rc.Get<GameObject>("QuitBtn");

            self.ParentComponent = self.GetParent<UI>().Parent.GetComponent<Video_Component>();            

            KeyBoardControler_Component kb = self.AddComponent<KeyBoardControler_Component>();
            kb.AddEventListener(GSKeyBoardEventType.Double_Click_Up, self.Back);
            kb.AddEventListener(GSKeyBoardEventType.Double_Click_Down, self.Quit);

            self.QuitBtn.AddEventListener(GSMouseEventType.MouseClick, self.Back);
        }
    }

    public static class Movie01_Extend_Handle
    {
        public static void Back(this Movie01_Extend self)
        {
            if (self.ParentComponent.InExtend)
            {
                self.ParentComponent.InExtend = false;
                self.DomainScene().GetComponent<UIComponent>().UIs.Remove("MovieExtend");
                self.GetParent<UI>().Dispose();
            }
        }

        public static void Quit(this Movie01_Extend self)
        {
            if (self.ParentComponent.InExtend)
            {
                self.ParentComponent.Quit();
            }
        }
    }
}

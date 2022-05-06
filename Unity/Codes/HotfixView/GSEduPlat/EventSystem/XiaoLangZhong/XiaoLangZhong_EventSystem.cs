using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class XiaoLangZhong_AwakeEventSystem : AwakeSystem<XiaoLangZhong_Component>
    {
        public override void AwakeAsync(XiaoLangZhong_Component self)
        {
            switch (GSRunningData.XiaoLangZhong_TypeIndex)
            {
                case 1:
                    KeyBoardControler_Component kb = self.GetParent<UI>().AddComponent<KeyBoardControler_Component>();
                    kb.AddEventListener(GSKeyBoardEventType.Double_Click_Up, self.OnDoubleClickUp_In_XiaoLangZhong1);
                    kb.AddEventListener(GSKeyBoardEventType.Double_Click_Down, self.OnDoubleClickDown_In_XiaoLangZhong1);
                    kb.AddEventListener(GSKeyBoardEventType.Single_Click_Up, self.OnSingleClickUp_In_XiaoLangZhong1);
                    kb.AddEventListener(GSKeyBoardEventType.Single_Click_Down, self.OnSingleClickDown_In_XiaoLangZhong1);

                    self.XiaoLangZhong1_XueWei_Init();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Log.Info("不会有这个操作吧");
                    break;
            }
        }
    }
    [ObjectSystem]
    public class XiaoLangZhong_UpdateEventSystem : UpdateSystem<XiaoLangZhong_Component>
    {
        public override void Update(XiaoLangZhong_Component self)
        {
            switch (GSRunningData.XiaoLangZhong_TypeIndex)
            {
                case 1:
                    if (GSRunningData.PageIndex == 1 && self.XueWeiInfo.Count > 1)
                    {
                        AnimatorStateInfo info = self.animator.GetCurrentAnimatorStateInfo(0);
                        if (info.IsName("Change") || info.IsName("ChangeWithInfo"))
                        {
                            if (info.normalizedTime >= 1)
                            {
                                self.RefreshInfo_In_XiaoLangZhong1();
                                self.animator.Play("In");
                            }
                        }
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    Log.Info("不会有这个操作吧");
                    break;
            }
        }
    }
    [ObjectSystem]
    public class XiaoLangZhong_DestroyEventSystem : DestroySystem<XiaoLangZhong_Component>
    {
        public override void Destroy(XiaoLangZhong_Component self)
        {
            for(int i = 0; i < self.loadHandlers.Count; i++)
            {
                self.loadHandlers[i].UnLoad();
            }
            self.MainHandler.UnLoad();
        }
    }
}

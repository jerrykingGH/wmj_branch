using System.Collections.Generic;

namespace ET
{
    public static class GSDebug_Helper
    {
        public static void Show_ABInfo_In_Memory()
        {
            string temp = "";
            foreach (var item in ResourcesComponent.Instance.resourceCache)
            {
                temp += item.Key + ", \r\n";
            }
            temp = $"当前在内存中的AB包有{ResourcesComponent.Instance.resourceCache.Count}个：\r\n" + temp;
            Log.Warning(temp);
        }        

        public static void Show_ComponentInfo_In_RunningData()
        {
            //string temp = "";

            //foreach (var item in GSRunningData.CurrentComponentInScene)
            //{
            //    temp += item.Key + ", \r\n";
            //}
            //temp = $"在RunningData中记录的当前场景有的Component有{GSRunningData.CurrentComponentInScene.Count}个：\r\n" + temp;
            //Log.Warning(temp);
            //for (int i = 0; i < GSRunningData.CurrentComponentInScene.Count; i++)
            //{
            //    temp += GSRunningData.UnUseABList[i] + ", \r\n";
            //}
            //temp = $"在RunningData中的AB包有{GSRunningData.UnUseABList.Count}个：\r\n" + temp;
            //Log.Warning(temp);
        }

        public static void Show_UIComponent_UIs(Scene zoneScene)
        {
            Dictionary<string,UI> uiList = zoneScene.GetComponent<UIComponent>().UIs;
            string temp = "";
            foreach (var item in uiList)
            {
                temp += item.Key +", ";
            }
            temp = $"在UIComponent中的UI有{uiList.Count}个：" + temp;
            Log.Warning(temp);
        }

        public static void Show_UIComponent_UIs(UIComponent uiComponent)
        {
            Dictionary<string, UI> uiList = uiComponent.UIs;
            string temp = "";
            foreach (var item in uiList)
            {
                temp += item.Key + ", ";
            }
            temp = $"在UIComponent中的UI有{uiList.Count}个：" + temp;
            Log.Warning(temp);
        }        
    }
}

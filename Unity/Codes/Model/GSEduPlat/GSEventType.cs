using UnityEngine;
namespace ET
{
    namespace GSEventType
    {
        public struct AppStart
        {
        }
        public struct AppStartInitFinish
        {
            public Scene ZoneScene;
        }

        public struct CreateLoading
        {
            public Scene ZoneScene;
        }

        public struct OnCreateLoading
        {
            public Scene ZoneScene;
            public string TargetType;
            public int TargetIndex;
        }

        public struct RefreshMainPageContent
        {
            public Scene ZoneScene;            
            public string MainContentType;
            public Entity MainPageScrip;
        }        
    }
}
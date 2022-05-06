using UnityEngine;
using BM;

namespace ET
{
    [UIEvent(GSUIType.UIMovieScene)]
    public class UIEvent_Movie : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            // 加载所需基础AB包            
            
            await AssetComponent.Initialize("Movie",GSPassWord.Movie);
            GameObject playerTemp = AssetComponent.Load<GameObject>(out LoadHandler playerHandler, "Assets/Res/GSEduPlat/Movie/VideoPlayer.prefab", "Movie");
            GameObject videoPlayer = GameObject.Instantiate(playerTemp, UIEventComponent.Instance.UILayers[(int)uiLayer]);
            UI ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UIMovieScene, videoPlayer);

            //string uiBundleName = "Movie";
            //await ResourcesComponent.Instance.LoadBundleAsync(uiBundleName.StringToAB());  
            //GSRunningData.UnUseABList.Add(uiBundleName);            
            //GameObject bundleGameObject = (GameObject)ResourcesComponent.Instance.GetAsset(uiBundleName.StringToAB(), "VideoPlayer");            
            //GameObject gameObject = GameObject.Instantiate(bundleGameObject, UIEventComponent.Instance.UILayers[(int)uiLayer]);
            //UI ui = uiComponent.AddChild<UI, string, GameObject>(GSUIType.UIMovieScene, gameObject);

            // 加载影片AB包
            string videoBundleName = "Movie" + string.Format("{0:00}", GSRunningData.Movie_SelectedIndex);
            await AssetComponent.Initialize(videoBundleName,GSPassWord.Movie);
            //await ResourcesComponent.Instance.LoadBundleAsync(videoBundleName.StringToAB());  // 此处加载影片AB包，速度会很慢
            //GSRunningData.UnUseABList.Add(videoBundleName);

            ui.AddComponent<Video_Component>().PlayerHandler = playerHandler;
            
            return ui;
        }

        public override void OnRemoveAsync(UIComponent uiComponent)
        {
            
        }
    }
}


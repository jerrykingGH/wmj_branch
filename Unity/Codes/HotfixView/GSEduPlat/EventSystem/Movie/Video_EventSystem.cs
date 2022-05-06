using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using BM;

namespace ET
{
    [ObjectSystem]
    public class Video_AwakeSystem : AwakeSystem<Video_Component>
    {
        public override void AwakeAsync(Video_Component self)
        {            
            self.Init();            
        }
    }

    [ObjectSystem]
    public class Video_UpdateSystem : UpdateSystem<Video_Component>
    {
        public override void Update(Video_Component self)
        {
            if (self.VideoPlayer.clip != null)
            {
                if (self.VideoPlayer.source == VideoSource.VideoClip)
                {
                    // 刷新时间
                    string tempTime = string.Format("{0:00}", (self.VideoPlayer.time - self.VideoPlayer.time % 60) / 60);
                    tempTime += ":" + string.Format("{0:00}", self.VideoPlayer.time % 60);
                    self.CurrentTime.text = tempTime;
                    tempTime = string.Format("{0:00}", (self.VideoPlayer.clip.length - self.VideoPlayer.clip.length % 60) / 60);
                    tempTime += ":" + string.Format("{0:00}", self.VideoPlayer.clip.length % 60);
                    self.TotalTime.text = tempTime;

                    if (self.seekNow == false)
                    {
                        self.SliderComponent.value = (float)(self.VideoPlayer.time / self.VideoPlayer.clip.length);
                    }

                    // 当视频播放完毕
                    if (self.VideoPlayer.time >= self.VideoPlayer.clip.length - 2)
                    {
                        self.ScreenAnimator.Play("CoverVideoWithView", 0, 0);
                        self.ControlerAnimator.Play("ContolerIn", 0, 0);
                        self.VideoPlayer.Stop();
                        self.PlayBtn.GetComponent<Toggle>().isOn = false;
                        self.VideoPlayer.time = 0;
                    }
                }
                else
                {
                    Log.Info("播放网络视频未处理");
                }                
            }            
        }
    }

    [ObjectSystem]
    public class Video_DestroySystem : DestroySystem<Video_Component>
    {
        public override void Destroy(Video_Component self)
        {
            self.ScreenShotHandler.UnLoad();
            self.VideoHandler.UnLoad();
            if (self.ExtendHandlers.Count > 0)
            {
                for (int i = 0; i < self.ExtendHandlers.Count; i++)
                {
                    self.ExtendHandlers[i].UnLoad();
                }
            }            

            self.PlayerHandler.UnLoad();

            AssetComponent.UnLoadPackageAssets("Movie");
            AssetComponent.UnLoadPackageAssets(self.VideoAssetBundleName);
            
        }
    }
}
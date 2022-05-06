using UnityEngine;
using System.Collections.Generic;
namespace ET
{
    [ObjectSystem]
    public class SoundPlayerComponent_AwakeSystem : AwakeSystem<SoundPlayer_Component>
    {
        public override void AwakeAsync(SoundPlayer_Component self)
        {
            self.audioSource = new List<AudioSource>();
        }
    }


    public static class SoundPlayer_Extend
    {

        public static void Play(this SoundPlayer_Component self, string soundName)
        {
            AudioClip audioClip = (AudioClip)ResourcesComponent.Instance.GetAsset("Common".StringToAB(), soundName);
            //self.audioSource.clip = audioClip;
            //self.audioSource.Play();
        }

        public static void Pause(this SoundPlayer_Component self, string soundName)
        {
            //if (self.audioSource.isPlaying)
            //{
            //    self.audioSource.Pause();
            //}
            //else
            //{
            //    self.audioSource.Play();
            //}
        }

        public static void Stop(this SoundPlayer_Component self, string soundName)
        {
            //self.audioSource.Stop();
        }

        //public AudioSource audioSource;
        //public static SoundPlayer_EventSystem Instance { get; set; }

        //public void Awake(SoundPlayer_EventSystem self)
        //{
        //    Instance = this;
        //    ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
        //    audioSource = rc.transform.GetComponent<AudioSource>();
        //    audioSource.volume = 1.0f;
        //    audioSource.playOnAwake = true;
        //    //PlaySounds("ZhongQiu_BanZou");
        //}
        ///// <summary>
        ///// 播放声音
        ///// </summary>
        ///// <param name="name">想要播放的音乐名字</param>
        //public void PlaySounds(string name)
        //{
        //    ResourcesComponent.Instance.LoadBundle(name.StringToAB());
        //    AudioClip audioClip = (AudioClip)ResourcesComponent.Instance.GetAsset(name.StringToAB(), name);
        //    audioSource.clip = audioClip;
        //    audioSource.Play();
        //}
        ///// <summary>
        ///// 添加播放器
        ///// </summary>
        ///// <param name="obj">添加的对象</param>
        ///// <param name="audioClip">音效</param>
        ///// <param name="loop">是否循环播放</param>
        ///// <param name="volume">声音大小</param>
        //public void AddSounds(GameObject obj, AudioClip audioClip, bool loop, float volume)
        //{
        //    AudioSource audioSources = obj.AddComponent<AudioSource>();
        //    audioSources.clip = audioClip;
        //    audioSources.loop = loop;
        //    audioSources.volume = volume;
        //    audioSources.Play();
        //}
        ///// <summary>
        ///// 删除播放器
        ///// </summary>
        ///// <param name="audioSources">要删除的播放器</param>
        //public void RemoveSounds(AudioSource audioSources)
        //{
        //    GameObject.Destroy(audioSources);
        //}
        ///// <summary>
        ///// 停止播放声音
        ///// </summary>
        //public void StopPlaySounds(string name)
        //{
        //    audioSource.Stop();
        //}

        //public override void Dispose()
        //{
        //    if (this.IsDisposed)
        //    {
        //        return;
        //    }
        //    base.Dispose();
        //    Instance = null;
        //}

    }
}

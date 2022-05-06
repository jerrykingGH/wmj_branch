using BM;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class Lesson_001_2 : Entity, IAwake,IUpdate,IDestroy
    {
        public LoadHandler loadHandler;

        public Animator _animator;

        public CanvasGroup PanZiGroup1, PanZiGroup2;

        public GameObject PanZi1, PanZi2;

        public GameObject InfoContent1, InfoContent2;

        public GameObject ContentImg1,ContentImg2;

        public GameObject RenShenInfo1, RenShenInfo2;

        // 以下暂时不用

        public List<GameObject> BtnGroup;

        public Dictionary<string, Animator> AnimationInfo = new Dictionary<string, Animator>();

        public GameObject QuitBtn;

        public string HandleStr = "";

        public Animator animator;

        

        public bool AnimatorIsPlaying = false;
    }
}

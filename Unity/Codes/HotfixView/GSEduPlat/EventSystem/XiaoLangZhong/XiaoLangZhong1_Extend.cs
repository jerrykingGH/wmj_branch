using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    public static class XiaoLangZhong1_Extend
    {
        public static void XiaoLangZhong1_XueWei_Init(this XiaoLangZhong_Component self)
        {
            self.SelectXueWei();
            self.SetComponentProperty_In_XiaoLangZhong1();
            self.AddAction_In_XiaoLangZhong1();

            self.animator.Play("In", 0, 0);
        }

        public static void SelectXueWei(this XiaoLangZhong_Component self)
        {
            self.XueWeiInfo = new List<XueWei>();
            XueWei xuewei = new XueWei();            
            
            #region 穴位定义
            switch (GSRunningData.XiaoLangZhong_SelectedIndex)
            {
                case 1: // 涌泉穴
                    {
                        xuewei.Name = "涌  泉  穴";
                        xuewei.Info = "● 足底，屈足蜷趾时，足心最凹陷处。";
                        xuewei.Efficacy = "● 缓解头晕、头痛。常揉搓可以强身健体，帮助降血压。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "艾  灸";

                        self.InfoWidth = 1000f;
                    }
                    break;
                case 2: // 迎香穴
                    {
                        xuewei.Name = "迎  香  穴";
                        xuewei.Info = "● 面部，鼻翼外缘中点旁，在鼻唇沟中。";
                        xuewei.Efficacy = "● 开鼻窍，缓解鼻塞。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "缓解鼻塞";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 800f;
                    }
                    break;
                case 3: // 攒竹穴
                    {
                        xuewei.Name = "攒  竹  穴";
                        xuewei.Info = "● 面部，两侧眉头下方凹陷中。";
                        xuewei.Efficacy = "● 缓解打嗝，视物不清。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 4: // 印堂穴
                    {
                        xuewei.Name = "印  堂  穴";
                        xuewei.Info = "● 面部，两眉头连线中点。";
                        xuewei.Efficacy = "● 治疗头痛、失眠、鼻炎。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "艾  灸";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 5: // 大椎穴
                    {
                        xuewei.Name = "大  椎  穴";
                        xuewei.Info = "● 项部，第七颈椎棘突下凹陷处，后正中线上。";
                        xuewei.Efficacy = "● 退热，缓解脖子疼痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "艾  灸";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 6: // 百会穴
                    {
                        xuewei.Name = "百  会  穴";
                        xuewei.Info = "● 头顶正中线与两耳尖直上连线的交叉处。";
                        xuewei.Efficacy = "● 醒脑，急救。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "艾  灸";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 800f;
                    }
                    break;
                case 7: // 神阙穴
                    {
                        xuewei.Name = "神  阙  穴";
                        xuewei.Info = "● 腹部，肚脐中。";
                        xuewei.Efficacy = "● 对腹泻有防治作用。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "艾  灸";
                        self.AnimationInfo2 = "禁止点按";

                        self.InfoWidth = 600f;
                    }
                    break;
                case 8: // 足三里穴
                    {
                        xuewei.Name = "足 三 里 穴";
                        xuewei.Info = "● 小腿部，外膝眼下三寸，胫骨前嵴旁开一恒指处。";
                        xuewei.Efficacy = "● 健脾和胃。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "健脾胃";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 1000f;
                    }
                    break;
                case 9: // 水沟穴
                    {
                        xuewei.Name = "水  沟  穴";
                        xuewei.Info = "● 面部，人中沟的上三分之一与中三分之一交点处。";
                        xuewei.Efficacy = "● 醒脑开窍，清热息风。可用于昏迷、癫狂等急症治疗。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "急症治疗";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 1100f;
                    }
                    break;
                case 10: // 委中穴
                    {
                        xuewei.Name = "委  中  穴";
                        xuewei.Info = "● 腿部，腘横纹中点处。";
                        xuewei.Efficacy = "● 缓解腰背疼痛、膝关节疼痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "艾  灸";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 11: // 太阳穴
                    {
                        xuewei.Name = "太  阳  穴";
                        xuewei.Info = "● 头部，外眼角和眉梢连线中点向后一寸处。";
                        xuewei.Efficacy = "● 醒脑提神，止头痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 12:
                    {
                        xuewei.Name = "极  泉  穴";
                        xuewei.Info = "● 腋窝正中，腋动脉搏动处。";
                        xuewei.Efficacy = "● 缓解肩臂疼痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 13:
                    {
                        xuewei.Name = "听  宫  穴";
                        xuewei.Info = "● 头部，耳屏前方凹陷处。";
                        xuewei.Efficacy = "● 提高听力，缓解牙痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 14:
                    {
                        xuewei.Name = "太  冲  穴";
                        xuewei.Info = "● 足背，第一、二跖骨底结合部前方凹陷中。";
                        xuewei.Efficacy = "● 提高听力，缓解牙痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 15:
                    {
                        xuewei.Name = "阴 陵 泉 穴";
                        xuewei.Info = "● 小腿部，胫骨内侧脚髁下方凹陷中。";
                        xuewei.Efficacy = "● 治疗膝痛。";
                        self.XueWeiInfo.Add(xuewei);

                        xuewei.Name = "阳 陵 泉 穴";
                        xuewei.Info = "● 小腿部，腓骨小头前下方凹陷中。";
                        xuewei.Efficacy = "● 治疗膝关节疾病，缓解口苦、呕吐。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "治疗膝痛";
                        self.AnimationInfo3 = "缓解呕吐";
                        self.AnimationInfo4 = "按摩方法";

                        self.InfoWidth = 800f;
                    }
                    break;
                case 16:
                    {
                        xuewei.Name = "肩  井  穴";
                        xuewei.Info = "● 肩部，第七颈椎下凹陷处与肩峰连线的中点。";
                        xuewei.Efficacy = "● 缓解颈肩疼痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 17:
                    {
                        xuewei.Name = "四 神 聪 穴";
                        xuewei.Info = "● 两耳尖直上连线中点前后左右各一寸处。";
                        xuewei.Efficacy = "● 缓解头痛、眩晕、失眠、醒脑。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 18:
                    {
                        xuewei.Name = "内  关  穴";
                        xuewei.Info = "● 手臂上，腕掌侧远端横纹上两寸，两筋之间。";
                        xuewei.Efficacy = "● 醒脑，缓解头痛、眩晕、失眠。";
                        self.XueWeiInfo.Add(xuewei);

                        xuewei.Name = "外  关  穴";
                        xuewei.Info = "● 手臂上，腕背侧远端横纹上两寸，两骨之间。";
                        xuewei.Efficacy = "● 缓解耳聋、耳鸣，调理上肢疾病。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "缓解眩晕";
                        self.AnimationInfo3 = "缓解耳鸣";
                        self.AnimationInfo4 = "按摩方法";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 19:
                    {
                        xuewei.Name = "颊  车  穴";
                        xuewei.Info = "● 面部，咬肌最高点。";
                        xuewei.Efficacy = "● 止牙痛，疗面瘫。";
                        self.XueWeiInfo.Add(xuewei);


                        self.AnimationInfo1 = "治疗牙痛";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 600f;
                    }
                    break;
                case 20:
                    {
                        xuewei.Name = "气  海  穴";
                        xuewei.Info = "● 前正中线上，脐下1.5寸。";
                        xuewei.Efficacy = "● 提高人体正气，增强抗病能力。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 21:
                    {
                        xuewei.Name = "后  溪  穴";
                        xuewei.Info = "● 在手外侧，第五掌指关节尺侧近端赤白肉际凹陷中。";
                        xuewei.Efficacy = "● 缓解头项强痛、腰背痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "艾 灸";

                        self.InfoWidth = 1000f;
                    }
                    break;
                case 22:
                    {
                        xuewei.Name = "耳  门  穴";
                        xuewei.Info = "● 头部，耳屏前上方。";
                        xuewei.Efficacy = "● 缓解耳鸣、耳聋、齿痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "缓解耳鸣";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 23:
                    {
                        xuewei.Name = "劳  宫  穴";
                        xuewei.Info = "● 掌心，握拳中指指尖下。";
                        xuewei.Efficacy = "● 经常按压可增强人体正气，还可用于急救。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 800f;
                    }
                    break;
                case 24:
                    {
                        xuewei.Name = "睛  明  穴";
                        xuewei.Info = "● 面部，内眼角稍上方凹陷处。";
                        xuewei.Efficacy = "● 保护视力。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 600f;
                    }
                    break;
                case 25:
                    {
                        xuewei.Name = "天  枢  穴";
                        xuewei.Info = "● 腹部，肚脐左右各2寸处。";
                        xuewei.Efficacy = "● 治疗便秘、腹泻。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "治疗便秘";
                        self.AnimationInfo2 = "治疗腹泻";

                        self.InfoWidth = 600f;
                    }
                    break;
                case 26:
                    {
                        xuewei.Name = "十  宣  穴";
                        xuewei.Info = "● 手部，十指尖端。";
                        xuewei.Efficacy = "● 开窍醒神，可用于昏迷时急救。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "开窍醒神";
                        self.AnimationInfo2 = "用于急救";

                        self.InfoWidth = 700f;

                        //xuewei.Name = "中  冲  穴";
                        //xuewei.Info = "● 手部，中指末端最高点。";
                        //xuewei.Efficacy = "● 开窍醒神，可用于昏迷时急救。";
                        //self.XueWeiInfo.Add(xuewei);

                        //self.AnimationInfo1 = "开窍醒神";
                        //self.AnimationInfo2 = "用于急救";

                        //self.InfoWidth = 700f;
                    }
                    break;
                case 27:
                    {
                        xuewei.Name = "合  谷  穴";
                        xuewei.Info = "● 手背部，第一、二掌骨间，第二掌骨中点拇指侧。";
                        xuewei.Efficacy = "● 缓解牙痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "缓解牙痛";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 28:
                    {
                        xuewei.Name = "外 劳 宫 穴";
                        xuewei.Info = "● 手背部，第二、三掌骨间，掌指关节后约0.5寸处。";
                        xuewei.Efficacy = "● 缓解落枕、手臂肿痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 29:
                    {
                        xuewei.Name = "鱼  际  穴";
                        xuewei.Info = "● 手部，拇指本节后凹陷处，约在第一掌骨中点桡侧赤白肉际处。";
                        xuewei.Efficacy = "● 缓解咽喉肿痛、咳嗽。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 1100f;
                    }
                    break;
                case 30:
                    {
                        xuewei.Name = "牵  正  穴";
                        xuewei.Info = "● 面部，耳垂前0.5~1寸处。";
                        xuewei.Efficacy = "● 祛风清热，通经活络。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "艾 灸";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 31:
                    {
                        xuewei.Name = "角  孙  穴";
                        xuewei.Info = "● 头部，折耳郭向前，当耳尖直上入发际处。";
                        xuewei.Efficacy = "● 缓解头痛、牙痛。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "按摩方法";

                        self.InfoWidth = 900f;
                    }
                    break;
                case 32:
                    {
                        xuewei.Name = "上  脘  穴";
                        xuewei.Info = "● 腹部，前正中线上，脐中上五寸。";
                        xuewei.Efficacy = "● 缓解胃痛、呕吐、腹胀。";
                        self.XueWeiInfo.Add(xuewei);

                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "艾灸";

                        self.InfoWidth = 700f;
                    }
                    break;
                case 33:
                    {
                        xuewei.Name = "腰 痛 点 穴";
                        xuewei.Info = "● 手背部，在第二、三掌骨及第四、五掌骨间，腕横纹与掌指关节中点处。";
                        xuewei.Efficacy = "● 缓解急性腰扭伤。";
                        self.XueWeiInfo.Add(xuewei);


                        self.AnimationInfo1 = "按摩方法";
                        self.AnimationInfo2 = "缓解腰伤";

                        self.InfoWidth = 1300f;
                    }
                    break;
            }
            #endregion
        }

        public static void SetComponentProperty_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.animator = rc.Get<Animator>("XiaoLangZhong1");
            self.LeftAnimInfo = rc.Get<Text>("LeftText");
            self.RightAnimInfo = rc.Get<Text>("RightText");
            self.CenterContainer = rc.Get<GameObject>("CenterContainer");
            self.RightContainer = rc.Get<GameObject>("RightContainer");
            self.LeftContainer = rc.Get<GameObject>("LeftContainer");
            self.InfoText = rc.Get<Text>("PointText");
            self.EfficacyText = rc.Get<Text>("EffectText");
            self.TitleText = rc.Get<Text>("TitleText");
            self.TitleShadowText = rc.Get<Text>("TitleTextShadow");

            self.NextBtn = rc.Get<GameObject>("NextBtn");
            self.PrevBtn = rc.Get<GameObject>("PrevBtn");
            self.QuitBtn = rc.Get<GameObject>("QuitBtn");

            self.InfoGO = rc.Get<GameObject>("Info");
            self.InfoRT = self.InfoGO.GetComponent<RectTransform>();
            self.TitleClick = rc.Get<GameObject>("Name");

            self.LeftAnimInfo.text = self.AnimationInfo1;
            self.RightAnimInfo.text = self.AnimationInfo2;
            self.TitleText.text = self.XueWeiInfo[0].Name;
            self.TitleShadowText.text = self.XueWeiInfo[0].Name;
            self.InfoText.text = self.XueWeiInfo[0].Info;
            self.EfficacyText.text = self.XueWeiInfo[0].Efficacy;
            self.InfoRT.sizeDelta = new Vector2(self.InfoWidth, 350);

            if (GSRunningData.XiaoLangZhong_SelectedIndex == 15 || GSRunningData.XiaoLangZhong_SelectedIndex == 18)
            {
                self.Center = self.CenterContainer.transform.Find("Center1").gameObject;
                self.Left = self.LeftContainer.transform.Find("Left1").gameObject;
                self.Right = self.RightContainer.transform.Find("Right1").gameObject;
            }
            else
            {
                self.Center = self.CenterContainer.transform.Find("Center").gameObject;
                self.Left = self.LeftContainer.transform.Find("Left").gameObject;
                self.Right = self.RightContainer.transform.Find("Right").gameObject;
            }

        }


        public static void AddAction_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            if (self.XueWeiInfo.Count == 1)
            {
                self.TitleClick.AddEventListener(GSMouseEventType.MouseClick, self.OnClick_In_XiaoLangZhong1);
                self.InfoGO.AddEventListener(GSMouseEventType.MouseClick, self.OnClick_In_XiaoLangZhong1);
                self.QuitBtn.AddEventListener(GSMouseEventType.MouseClick, self.OnClick_In_XiaoLangZhong1);
            }
            else if (self.XueWeiInfo.Count == 2)
            {
                self.CurrentXueWei = 1;                

                self.NextBtn.SetActive(true);
                self.NextBtn.AddEventListener(GSMouseEventType.MouseClick, self.OnClick_In_XiaoLangZhong1);
                self.PrevBtn.AddEventListener(GSMouseEventType.MouseClick, self.OnClick_In_XiaoLangZhong1);

                self.TitleClick.AddEventListener(GSMouseEventType.MouseClick, self.OnClick_In_XiaoLangZhong1);
                self.InfoGO.AddEventListener(GSMouseEventType.MouseClick, self.OnClick_In_XiaoLangZhong1);
                self.QuitBtn.AddEventListener(GSMouseEventType.MouseClick, self.OnClick_In_XiaoLangZhong1);
            }
        }

        public static void OnClick_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            switch (GSMouseData.LastObjectClicked.name)
            {
                case "Name":
                    self.ShowOrHideInfo_In_XiaoLangZhong1();
                    break;
                case "Info":
                    self.ShowOrHideInfo_In_XiaoLangZhong1();
                    break;
                case "NextBtn":
                    self.NextBtn.SetActive(false);
                    self.Change_In_XiaoLangZhong1();
                    break;
                case "PrevBtn":
                    self.PrevBtn.SetActive(false);
                    self.Change_In_XiaoLangZhong1();
                    break;
                case "QuitBtn":
                    self.XiaoLangZhong1_Quit();
                    break;
            }
        }

        public static void ShowOrHideInfo_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            if (self.InfoIsOn)
            {
                self.InfoIsOn = false;
                self.animator.Play("BackInfo", 0, 0);
            }
            else
            {
                self.InfoIsOn = true;
                self.animator.Play("ShowInfo", 0, 0);
            }
        }

        public static void Change_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            if (self.InfoIsOn)
            {
                self.animator.Play("ChangeWithInfo", 0, 0);
            }
            else
            {
                self.animator.Play("Change", 0, 0);
            }
            self.InfoIsOn = false;
        }

        public static void RefreshInfo_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            if (self.CurrentXueWei == 1)
            {
                self.LeftAnimInfo.text = self.AnimationInfo3;
                self.RightAnimInfo.text = self.AnimationInfo4;
                self.PrevBtn.SetActive(true);
                self.CurrentXueWei = 2;
            }
            else
            {
                self.LeftAnimInfo.text = self.AnimationInfo1;
                self.RightAnimInfo.text = self.AnimationInfo2;
                self.NextBtn.SetActive(true);
                self.CurrentXueWei = 1;
            }

            self.TitleText.text = self.XueWeiInfo[self.CurrentXueWei - 1].Name;
            self.TitleShadowText.text = self.XueWeiInfo[self.CurrentXueWei - 1].Name;
            self.InfoText.text = self.XueWeiInfo[self.CurrentXueWei - 1].Info;
            self.EfficacyText.text = self.XueWeiInfo[self.CurrentXueWei - 1].Efficacy;

            switch (GSRunningData.XiaoLangZhong_SelectedIndex)
            {
                case 15://阴阳陵泉 设置Info宽度
                    {
                        if (self.CurrentXueWei == 1)
                        {
                            self.InfoRT.sizeDelta = new Vector2(800f, 350f);
                        }
                        else
                        {
                            self.InfoRT.sizeDelta = new Vector2(800f, 350f);
                        }
                    }
                    break;
                case 18://阴阳陵泉 设置Info宽度
                    {
                        if (self.CurrentXueWei == 1)
                        {
                            self.InfoRT.sizeDelta = new Vector2(900f, 350f);
                        }
                        else
                        {
                            self.InfoRT.sizeDelta = new Vector2(900f, 350f);
                        }
                    }
                    break;
                default:
                    break;
            }

            GameObject.Destroy(self.Center);
            GameObject.Destroy(self.Left);
            GameObject.Destroy(self.Right);
            
            string assets_BundleName = "XiaoLangZhong" + GSRunningData.XiaoLangZhong_TypeIndex + "_" + GSRunningData.XiaoLangZhong_SelectedIndex;
            GameObject CenterPrefab = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Center" + self.CurrentXueWei);
            self.Center = UnityEngine.GameObject.Instantiate(CenterPrefab, self.CenterContainer.transform);
            GameObject LeftPrefab = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Left" + self.CurrentXueWei);
            self.Left = UnityEngine.GameObject.Instantiate(LeftPrefab, self.LeftContainer.transform);
            GameObject RightPrefab = (GameObject)ResourcesComponent.Instance.GetAsset(assets_BundleName.StringToAB(), "Right" + self.CurrentXueWei);
            self.Right = UnityEngine.GameObject.Instantiate(RightPrefab, self.RightContainer.transform);
        }

        public static void OnSingleClickUp_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            if (GSRunningData.XiaoLangZhong_SelectedIndex == 15 || GSRunningData.XiaoLangZhong_SelectedIndex == 18)
            {
                if (self.CurrentXueWei == 1)
                {
                    self.NextBtn.SetActive(false);
                }
                else
                {
                    self.PrevBtn.SetActive(false);
                }
                self.Change_In_XiaoLangZhong1();
            }
        }

        public static void OnSingleClickDown_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            if (GSRunningData.XiaoLangZhong_SelectedIndex == 15 || GSRunningData.XiaoLangZhong_SelectedIndex == 18)
            {
                if (self.CurrentXueWei == 1)
                {
                    self.NextBtn.SetActive(false);
                }
                else
                {
                    self.PrevBtn.SetActive(false);
                }
                self.Change_In_XiaoLangZhong1();
            }
        }

        public static void OnDoubleClickUp_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            self.ShowOrHideInfo_In_XiaoLangZhong1();
        }

        public static void OnDoubleClickDown_In_XiaoLangZhong1(this XiaoLangZhong_Component self)
        {
            self.XiaoLangZhong1_Quit();
        }

        public static async void XiaoLangZhong1_Quit(this XiaoLangZhong_Component self)
        {
            // 必须赋值
            GSRunningData.Target = GSUIType.UILessonScene;
            GSRunningData.Lesson_SelectedIndex = self.BackLessonSelectedIndex;
            GSRunningData.Section_SelectedIndex = 0;
            // 根据类型赋值
            GSRunningData.Movie_SelectedIndex = 0;
            // 操作清空
            GSRunningData.Limit = false;
            GSRunningData.PageIndex = 0;
            GSRunningData.ChoiceIndex = 0;
            // 流程删除赋值
            GSRunningData.HistTaget.Add(GSUIType.UIXiaoLangZhongScene, true);            

            await GSUIHelper.Create(self.DomainScene(), GSUIType.UILoadingScene, UILayer.High);

        }

    }    
}

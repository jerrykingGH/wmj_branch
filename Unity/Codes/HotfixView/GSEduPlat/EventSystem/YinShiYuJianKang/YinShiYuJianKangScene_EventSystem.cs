using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BM;


namespace ET
{
    public class YinShiYuJianKang_AwakeEventSystem : AwakeSystem<YinShiYuJianKang_Component>
    {
        public override async void AwakeAsync(YinShiYuJianKang_Component self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();            

            #region 设置运行变量
            self.InitData();
            #endregion

            #region 设置闪烁变色小点
            self.Point = new List<Image>();
            for (int i = 0; i <= 11; i++)
            {
                self.Point.Add(rc.Get<Image>("Point" + i));
            }

            for (int i = 0; i <= 11; i++)
            {
                self.Point[i].color = new Color(UnityEngine.Random.Range(0, 255) / 255f, UnityEngine.Random.Range(0, 255) / 255f, UnityEngine.Random.Range(0, 255) / 255f);
            }
            #endregion

            #region 设置圈圈粒子系统
            self.ParticleContainer = rc.Get<GameObject>("ParticleContainer");
            self.PCell = rc.Get<GameObject>("Pcell");
            #endregion

            #region 设置动画
            self.SceneChange = rc.Get<Animator>("YinShiYuJianKang");
            self.DetailMotion = rc.Get<Animator>("Detail");

            //Log.Info($"{self.DetailMotion == null}");
            #endregion

            #region 设置图片
            string picBundleName = "YinShiYuJianKang"  + string.Format("{0:000}", GSRunningData.YinShiYuJianKang_SelectedIndex);
            self.AssetBundleName = picBundleName;
            await AssetComponent.Initialize(picBundleName,GSPassWord.YinShiYuJianKang);

            //await ResourcesComponent.Instance.LoadBundleAsync(picBundleName.StringToAB());            

            self.MainItemContainer = rc.Get<Image>("ItemContainer");

            string picDatabasePath = BPath.UILesssonPath;
            //"Assets/Res/GSEduPlat/LessonsScene/Lesson_001/Lesson_001_4/PicDataBase.prefab"
            picDatabasePath += "Lesson_" + string.Format("{0:000}", GSRunningData.Lesson_SelectedIndex)+"/";
            picDatabasePath += "Lesson_" + string.Format("{0:000}", GSRunningData.Lesson_SelectedIndex)+"_"+GSRunningData.Section_SelectedIndex + "/";
            GameObject PicDatabase = AssetComponent.Load<GameObject>(out self.picDatabaseHandler, picDatabasePath+ "PicDataBase.prefab", picBundleName);
            ReferenceCollector data = PicDatabase.GetComponent<ReferenceCollector>();
            self.MainItemContainer.overrideSprite = data.Get<Sprite>("Pic_3");
            self.DetailPicSprite.Add(data.Get<Sprite>("Pic_2"));
            self.DetailPicSprite.Add(data.Get<Sprite>("Pic_0"));
            self.DetailPicSprite.Add(data.Get<Sprite>("Pic_1"));
            //Texture2D pic = (Texture2D)ResourcesComponent.Instance.GetAsset(picBundleName.StringToAB(), "Pic");

            //Sprite temp;
            //temp = Sprite.Create(pic, new Rect(2048 - 800, 0, 800, 800), new Vector2(0, 0));
            //self.MainItemContainer.overrideSprite = temp;
            //temp = Sprite.Create(pic, new Rect(0, 0, 972, 722), new Vector2(0, 0));
            //self.DetailPicSprite.Add(temp);
            //temp = Sprite.Create(pic, new Rect(0, 2048 - 722, 972, 722), new Vector2(0, 0));
            //self.DetailPicSprite.Add(temp);
            //temp = Sprite.Create(pic, new Rect(2048 - 972, 2048 - 722, 972, 722), new Vector2(0, 0));
            //self.DetailPicSprite.Add(temp);

            for (int i = 0; i < 3; i++)
            {
                self.IdlePic.Add(rc.Get<Image>("IdleItem" + i));
            }

            for (int i = 0; i < 3; i++)
            {
                self.IdlePic[i].overrideSprite = self.DetailPicSprite[i];
            }


            for (int i = 0; i < 4; i++)
            {
                self.MotionPic.Add(rc.Get<Image>("Pic" + i));
            }

            for (int i = 0; i < 3; i++)
            {
                self.MotionPic[i].overrideSprite = self.DetailPicSprite[i];
            }
            self.MotionPic[3].overrideSprite = self.DetailPicSprite[0];

            self.IdlePicGroup = rc.Get<GameObject>("Idle");
            self.MotionPicGroup = rc.Get<GameObject>("Motion");

            #endregion

            #region 设置文本
            self.Title_Inpart1 = rc.Get<Text>("Name");
            self.Title_Inpart2 = rc.Get<Text>("DetailText");
            self.Content_Inpart1 = rc.Get<Text>("Info");

            self.Title_Inpart1.text = "饮食与健康 — " + self.InfoStru.Name;
            self.Content_Inpart1.text = "\u3000\u3000" + self.InfoStru.Info;
            self.Title_Inpart2.text = self.InfoStru.PicInfo[0];
            #endregion

            #region 添加交互
            KeyBoardControler_Component kb = self.AddComponent<KeyBoardControler_Component>();
            kb.AddEventListener(GSKeyBoardEventType.Single_Click_Up, self.OnSingleClickUp);
            kb.AddEventListener(GSKeyBoardEventType.Single_Click_Down, self.OnSingleClickDown);
            kb.AddEventListener(GSKeyBoardEventType.Double_Click_Up, self.OnDoubleClickUp);
            kb.AddEventListener(GSKeyBoardEventType.Double_Click_Down, self.OnDoubleClickDown);


            self.PrevBtn = rc.Get<GameObject>("PrevBtn");
            self.NextBtn = rc.Get<GameObject>("NextBtn");
            self.QuitBtn = rc.Get<GameObject>("QuitBtn");

            self.PrevBtn.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick);
            self.NextBtn.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick);
            self.QuitBtn.AddEventListener(GSMouseEventType.MouseClick, self.Quit);

            self.IdlePic[0].gameObject.AddEventListener(GSMouseEventType.MouseClick, self.OnMouseClick);

            self.PrevBtn.SetActive(false);
            #endregion

        }
    }

    public class YinShiYuJianKang_UpdateEventSystem : UpdateSystem<YinShiYuJianKang_Component>
    {
        public override void Update(YinShiYuJianKang_Component self)
        {
            #region ================== 点闪烁效果 ==================

            if (self.PointDoTweenIsPlaying == false && self.Point.Count == 12)
            {
                self.PointDoTweenIsPlaying = true;
                this.RefreshPoint(self).Coroutine();
                for (int i = 0; i < self.Point.Count; i++)
                {
                    Color color = new Color(UnityEngine.Random.Range(0, 255) / 255f, UnityEngine.Random.Range(0, 255) / 255f, UnityEngine.Random.Range(0, 255) / 255f);
                    if (i == self.Point.Count - 1 || i == 0)
                    {
                        self.Point[i].DOColor(color, self.PointFlashTime)
                            .SetEase(Ease.Linear)
                            .WaitForCompletion();
                    }
                    else
                    {
                        self.Point[i].DOColor(color, self.PointFlashTime)
                            .SetEase(Ease.Linear);
                    }
                }
            }
            #endregion

            #region =================== 圈圈粒子 ===================

            // 当粒子数量不够时，间隔随机时间创建粒子
            if (self.ParticleGO.Count < self.ParticleNum)
            {
                if (self.ParticleCreateStep <= 0)
                {
                    CreateParticle(self);

                    self.ParticleCreateStep = RandomHelper.RandomNumber(200, 400);
                }
                else
                {
                    self.ParticleCreateStep -= 1;
                }
            }

            // 当有粒子存在时
            if (self.ParticleGO.Count > 0)
            {
                for (int i = 0; i < self.ParticleGO.Count; i++)
                {
                    //Log.Info($"粒子序号 {i} 的值为{self.ParticleRefresh[i]}");
                    if (self.ParticleRefresh[i] == true)
                    {
                        self.ParticleRefresh[i] = false;
                        int ParticleIndex = i;

                        // 确定要移动到的位置
                        Vector3 aimpos = new Vector3(RandomHelper.RandomNumber(-300, 300), RandomHelper.RandomNumber(-300, 300), 0);
                        float aimx = (aimpos + self.ParticleGO[ParticleIndex].transform.localPosition).x;
                        float aimy = (aimpos + self.ParticleGO[ParticleIndex].transform.localPosition).y;
                        if (aimx <= -2334 / 2f)
                        {
                            aimx = -2334 / 2 - self.ParticleGO[ParticleIndex].transform.localPosition.x;
                            aimpos.x = aimx;
                        }
                        if (aimx >= 2334 / 2f)
                        {
                            aimx = 2334 / 2 - self.ParticleGO[ParticleIndex].transform.localPosition.x;
                            aimpos.x = aimx;
                        }
                        if (aimy <= -1400 / 2f)
                        {
                            aimy = -1400 / 2 - self.ParticleGO[ParticleIndex].transform.localPosition.y;
                            aimpos.y = aimy;
                        }
                        if (aimy >= 1400 / 2f)
                        {
                            aimy = 1400 / 2 - self.ParticleGO[ParticleIndex].transform.localPosition.y;
                            aimpos.y = aimy;
                        }

                        self.ParticlePostion[ParticleIndex] = aimpos;

                        self.ParticleMotionTime[ParticleIndex] = RandomHelper.RandomNumber(3000, 10000);

                        self.ParticleGO[i].transform
                            .DOLocalMove(self.ParticleGO[i].transform.localPosition + self.ParticlePostion[i], self.ParticleMotionTime[i] / 1000f)
                            .SetEase(Ease.Linear);

                        this.RefreshCircle(self, i).Coroutine();
                    }
                }
            }
            #endregion            

            #region =================== 动画交互 ===================
            
            if (self.MotionPicGroup != null && self.MotionPicGroup.activeSelf)
            {
                AnimatorStateInfo info = self.DetailMotion.GetCurrentAnimatorStateInfo(0);
                if (info.IsName("Detail_Motion"))
                {
                    if (info.normalizedTime >= 1)
                    {
                        self.IdlePicGroup.SetActive(true);
                        self.MotionPicGroup.SetActive(false);
                        self.DetailMotion.Play("Detail_Idle", 0, 0);
                    }
                }
            }

            if (self.FontPicIndex != 0)
            {
                AnimatorStateInfo info = self.SceneChange.GetCurrentAnimatorStateInfo(0);
                if (info.IsName("SceneChange1") && info.normalizedTime >= 1)
                {
                    self.BackPart2();
                }
            }

            #endregion


            //Log.Info($"获取的随机数为：{RandomHelper.RandomNumber(-300, 300)}");
            //RefreshCircle(self, RandomHelper.RandInt32()).Coroutine();
        }

        public async ETTask RefreshPoint(YinShiYuJianKang_Component self)
        {
            await TimerComponent.Instance.WaitAsync(1000);
            self.PointDoTweenIsPlaying = false;
        }

        public async ETTask RefreshCircle(YinShiYuJianKang_Component self, int CircleIndex)
        {
            await TimerComponent.Instance.WaitAsync(self.ParticleMotionTime[CircleIndex]);
            self.ParticleRefresh[CircleIndex] = true;
        }

        public void CreateParticle(YinShiYuJianKang_Component self)
        {
            GameObject circleParticle = GameObject.Instantiate(self.PCell, self.ParticleContainer.transform);
            self.ParticleGO.Add(circleParticle);

            Vector3 currentpos = new Vector3(RandomHelper.RandomNumber(-600, 600) * 1.0f, RandomHelper.RandomNumber(-600, 600) * 1.0f, 1f);
            circleParticle.transform.localPosition = currentpos;

            Vector3 aimpos = new Vector3(0f, 0f, 0f);
            self.ParticlePostion.Add(aimpos);

            int mtime = RandomHelper.RandomNumber(3000, 10000);
            self.ParticleMotionTime.Add(mtime);

            self.ParticleRefresh.Add(true);
        }
    }

    public class YinShiYuJianKang_DestroyEventSystem : DestroySystem<YinShiYuJianKang_Component>
    {
        public override void Destroy(YinShiYuJianKang_Component self)
        {            
            self.picDatabaseHandler.UnLoad();
            self.mainHandler.UnLoad();

            AssetComponent.UnLoadPackageAssets(self.AssetBundleName);
            AssetComponent.UnLoadPackageAssets("YinShiYuJianKang");
        }
    }
}











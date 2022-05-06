using DG.Tweening;
using UnityEngine;
namespace ET
{
    public static class Lesson_001_2_Extend
    {
        public static void PlayAnimation(this Lesson_001_2 self, string AnimationStr)
        {            
            self._animator.Play(AnimationStr, 0, 0);
        }

        public static void OnMouseOver(this Lesson_001_2 self)
        {            
            if (GSMouseData.LastObjectMatched.name == "panzi1")
            {
                self.PanZi1.transform.DOKill();
                self.PanZi2.transform.DOKill();
                self.PanZi1.transform.DOLocalRotate(new Vector3(0, 0, 360), 15f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
            }
            if (GSMouseData.LastObjectMatched.name == "panzi2")
            {
                self.PanZi1.transform.DOKill();
                self.PanZi2.transform.DOKill();
                self.PanZi2.transform.DOLocalRotate(new Vector3(0, 0, 360), 15f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
            }
        }

        public static void OnMouseOut(this Lesson_001_2 self)
        {
            self.PanZi1.transform.DOKill();
            self.PanZi2.transform.DOKill();
        }

        public static void OnMouseClick(this Lesson_001_2 self)
        {
            Log.Info(GSMouseData.LastObjectClicked.name);
            if (GSRunningData.PageIndex == 0)
            {
                if (GSMouseData.LastObjectClicked.name == "panzi1")
                {
                    GSRunningData.ChoiceIndex = 1;
                    GSRunningData.PageIndex = 1;
                    
                    GSMouseData.Enable = false;

                    // 显示动画
                    self.InfoContent1.SetActive(true);
                    self.InfoContent1.GetComponent<CanvasGroup>().alpha = 0;
                    self.PanZiGroup2.alpha = 1;
                    self.PanZiGroup2.DOFade(0f, 0.5f);
                    self.InfoContent1.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).OnComplete(()=>{ GSMouseData.Enable = true; });

                }
                if (GSMouseData.LastObjectClicked.name == "panzi2")
                {
                    GSRunningData.ChoiceIndex = 2;
                    GSRunningData.PageIndex = 1;
                    
                    GSMouseData.Enable = false;

                    // 显示动画
                    self.InfoContent2.SetActive(true);
                    self.InfoContent2.GetComponent<CanvasGroup>().alpha = 0;
                    self.PanZiGroup1.alpha = 1;
                    self.PanZiGroup1.DOFade(0f, 0.5f);
                    self.InfoContent2.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).OnComplete(() => { GSMouseData.Enable = true; });
                }
            }
            else if (GSRunningData.PageIndex == 1)
            {

                if (GSMouseData.LastObjectClicked.name == "ContentImg")
                {
                    if (GSRunningData.ChoiceIndex == 1)
                    {                        
                        GSMouseData.Enable = false;
                        self.RenShenInfo1.transform.DOLocalMoveY(0, 0.3f).OnComplete(() => { GSMouseData.Enable = true; });
                    }
                    if (GSRunningData.ChoiceIndex == 2)
                    {                     
                        GSMouseData.Enable = false;
                        self.RenShenInfo2.transform.DOLocalMoveY(0, 0.3f).OnComplete(() => { GSMouseData.Enable = true; });
                    }
                    
                }
                if (GSMouseData.LastObjectClicked.name == "Content_1")
                {
                    GSMouseData.Enable = false;
                    self.InfoContent1.SetActive(true);
                    self.InfoContent1.GetComponent<CanvasGroup>().alpha = 1;
                    self.PanZiGroup2.alpha = 0;
                    self.PanZiGroup2.DOFade(1f, 0.5f);
                    self.InfoContent1.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete(() => {
                        self.InfoContent1.SetActive(false);
                        self.RenShenInfo1.transform.DOLocalMoveY(-180f, 0f);                        
                        GSRunningData.PageIndex =0; 
                        GSMouseData.Enable = true; 
                    });
                }

                if (GSMouseData.LastObjectClicked.name == "Content_2")
                {
                    GSMouseData.Enable = false;
                    self.InfoContent2.SetActive(true);
                    self.InfoContent2.GetComponent<CanvasGroup>().alpha = 1;
                    self.PanZiGroup1.alpha = 0;
                    self.PanZiGroup1.DOFade(1f, 0.5f);
                    self.InfoContent2.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete(() => { 
                        self.InfoContent2.SetActive(false);
                        self.RenShenInfo2.transform.DOLocalMoveY(-180f, 0f);
                        GSRunningData.PageIndex = 0;
                        GSMouseData.Enable = true; 
                    });
                }
            }            
        }

        public static void OnSingleClickUp(this Lesson_001_2 self)
        {
            if (GSRunningData.PageIndex == 0)
            {
                if (GSRunningData.ChoiceIndex == 0)
                {
                    GSRunningData.ChoiceIndex = 1;
                    self.PanZi1.transform.DOKill();
                    self.PanZi2.transform.DOKill();
                    self.PanZi1.transform.DOLocalRotate(new Vector3(0, 0, 360), 15f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
                }
                else if (GSRunningData.ChoiceIndex == 1)
                {
                    GSRunningData.ChoiceIndex = 2;
                    self.PanZi1.transform.DOKill();
                    self.PanZi2.transform.DOKill();
                    self.PanZi2.transform.DOLocalRotate(new Vector3(0, 0, 360), 15f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
                }
                else if (GSRunningData.ChoiceIndex == 2)
                {
                    GSRunningData.ChoiceIndex = 1;
                    self.PanZi1.transform.DOKill();
                    self.PanZi2.transform.DOKill();
                    self.PanZi1.transform.DOLocalRotate(new Vector3(0, 0, 360), 15f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
                }                
            }
        }

        public static void OnSingleClickDown(this Lesson_001_2 self)
        {
            if (GSRunningData.PageIndex == 0)
            {
                if (GSRunningData.ChoiceIndex == 0)
                {                    
                    GSRunningData.ChoiceIndex = 1;
                    self.PanZi1.transform.DOKill();
                    self.PanZi2.transform.DOKill();
                    self.PanZi1.transform.DOLocalRotate(new Vector3(0, 0, 360), 15f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
                }
                else if (GSRunningData.ChoiceIndex == 1)
                {
                    GSRunningData.ChoiceIndex = 2;
                    self.PanZi1.transform.DOKill();
                    self.PanZi2.transform.DOKill();
                    self.PanZi2.transform.DOLocalRotate(new Vector3(0, 0, 360), 15f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
                }
                else if (GSRunningData.ChoiceIndex == 2)
                {
                    GSRunningData.ChoiceIndex = 1;
                    self.PanZi1.transform.DOKill();
                    self.PanZi2.transform.DOKill();
                    self.PanZi1.transform.DOLocalRotate(new Vector3(0, 0, 360), 15f, RotateMode.WorldAxisAdd).SetEase(Ease.Linear).SetLoops(-1);
                }                
            }
        }

        public static void OnDoubleClickUp(this Lesson_001_2 self)
        {
            if (GSRunningData.PageIndex == 0)
            {
                if (GSRunningData.ChoiceIndex == 1 || GSRunningData.ChoiceIndex == 0)
                {
                    GSRunningData.ChoiceIndex = 1;

                    GSRunningData.PageIndex = 1;

                    // 显示动画
                    GSMouseData.Enable = false;

                    self.InfoContent1.SetActive(true);
                    self.InfoContent1.GetComponent<CanvasGroup>().alpha = 0;
                    self.PanZiGroup2.alpha = 1;
                    self.PanZiGroup2.DOFade(0f, 0.5f);
                    self.InfoContent1.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).OnComplete(() => { GSMouseData.Enable = true; });
                }
                if (GSRunningData.ChoiceIndex == 2)
                {
                    GSRunningData.PageIndex = 1;

                    // 显示动画
                    GSMouseData.Enable = false;

                    self.InfoContent2.SetActive(true);
                    self.InfoContent2.GetComponent<CanvasGroup>().alpha = 0;
                    self.PanZiGroup1.alpha = 1;
                    self.PanZiGroup1.DOFade(0f, 0.5f);
                    self.InfoContent2.GetComponent<CanvasGroup>().DOFade(1f, 0.5f).OnComplete(() => { GSMouseData.Enable = true; });
                }                
            }else if (GSRunningData.PageIndex == 1)
            {
                if (GSRunningData.ChoiceIndex == 1)
                {
                    GSMouseData.Enable = false;
                    self.RenShenInfo1.transform.DOLocalMoveY(0, 0.3f).OnComplete(() => { GSMouseData.Enable = true; });
                }
                if (GSRunningData.ChoiceIndex == 2)
                {
                    GSMouseData.Enable = false;
                    self.RenShenInfo2.transform.DOLocalMoveY(0, 0.3f).OnComplete(() => { GSMouseData.Enable = true; });
                }                
            }
        }

        public static void OnDoubleClickDown(this Lesson_001_2 self)
        {
            if (GSRunningData.PageIndex == 1)
            {
                if (GSRunningData.ChoiceIndex == 1)
                {
                    GSMouseData.Enable = false;
                    self.InfoContent1.SetActive(true);
                    self.InfoContent1.GetComponent<CanvasGroup>().alpha = 1;
                    self.PanZiGroup2.alpha = 0;
                    self.PanZiGroup2.DOFade(1f, 0.5f);
                    self.InfoContent1.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete(() => {
                        self.InfoContent1.SetActive(false);
                        self.RenShenInfo1.transform.DOLocalMoveY(-180f, 0f);
                        GSRunningData.PageIndex = 0;
                        GSMouseData.Enable = true;
                    });
                }
                else if (GSRunningData.ChoiceIndex == 2)
                {
                    GSMouseData.Enable = false;
                    self.InfoContent2.SetActive(true);
                    self.InfoContent2.GetComponent<CanvasGroup>().alpha = 1;
                    self.PanZiGroup1.alpha = 0;
                    self.PanZiGroup1.DOFade(1f, 0.5f);
                    self.InfoContent2.GetComponent<CanvasGroup>().DOFade(0f, 0.5f).OnComplete(() => {
                        self.InfoContent2.SetActive(false);
                        self.RenShenInfo2.transform.DOLocalMoveY(-180f, 0f);
                        GSRunningData.PageIndex = 0;
                        GSMouseData.Enable = true;
                    });
                }                
            }
            else if (GSRunningData.PageIndex == 0)
            {
                self.Quit();
            }
        }

        public static void ShowRenShenInfo(this Lesson_001_2 self,int infoIndex)
        {
            Log.Info("选择是" + infoIndex);
            if(infoIndex == 1)
            {
                self.RenShenInfo1.transform.DOMoveY(0f, 0.3f);
            }
            if (infoIndex == 2)
            {
                self.RenShenInfo2.transform.DOMoveY(0f, 0.3f);
            }
        }

        public static async void Quit(this Lesson_001_2 self)
        {
            self.PanZi1.transform.DOKill();
            self.PanZi2.transform.DOKill();

            // 必须赋值
            GSRunningData.Target = GSUIType.UILessonScene;
            GSRunningData.Lesson_SelectedIndex = 1;
            GSRunningData.Section_SelectedIndex = 0;
            // 操作清空
            GSRunningData.Limit = false;
            GSRunningData.PageIndex = 0;
            GSRunningData.ChoiceIndex = 0;
            // 流程删除赋值
            GSRunningData.HistTaget.Add(GSUIType.UILessonScene, true);

            // 此课有粒子，改变了ui渲染方式，现在复原;
            self.GetParent<UI>().GameObject.GetComponentInParent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;

            await GSUIHelper.Create(self.DomainScene(), GSUIType.UILoadingScene, UILayer.High);
            //await Game.EventSystem.PublishAsync(new GSEventType.CreateLoading() { ZoneScene = self.DomainScene() });
        }
    }
}

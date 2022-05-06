
namespace ET
{
	public class Event_OnCreateLogoScene : AEvent<GSEventType.AppStartInitFinish>
	{
		protected override async ETTask Run(GSEventType.AppStartInitFinish args)
		{
			await GSUIHelper.Create(args.ZoneScene, GSUIType.UILogoScene, UILayer.High);
		}
	}
}


using System;

namespace ET
{
	public static class GSEntry
	{
		public static void Start()
		{
			try
			{
                CodeLoader.Instance.Update += Game.Update;
                CodeLoader.Instance.LateUpdate += Game.LateUpdate;
                CodeLoader.Instance.OnApplicationQuit += Game.Close;                

                Game.EventSystem.Add(CodeLoader.Instance.GetTypes());
                
                Game.EventSystem.Publish(new GSEventType.AppStart());                
            }
			catch (Exception e)
			{
				Log.Error(e);
			}
		}
	}
}

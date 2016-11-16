using System;

namespace DispCore.Events
{
	public static class EventHandlerTrigger
	{
		public static void TriggerEvent(System.EventHandler handler, object source)
		{
			if (handler != null)
			{
				handler(source, System.EventArgs.Empty);
			}
		}

		public static void TriggerEvent<T>(System.EventHandler<T> handler, object source, T args) where T : System.EventArgs
		{
			if (handler != null)
			{
				handler(source, args);
			}
		}
	}
}

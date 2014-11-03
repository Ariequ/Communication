using UnityEngine;

namespace Communication
{
	public class ClientLog
	{
		private static bool LogSwitch = true;

		public static void LogError (string message)
		{
			if (LogSwitch)
			Debug.LogError (message);
		}

		public static void Log (string message)
		{
			if (LogSwitch)
			Debug.Log (message);
		}

		public static void LogErrorEx (string message)
		{
			if (LogSwitch)
			Debug.Log (message);
		}
	}
}

using System;

namespace DispCore.Services
{
	public enum ANStatus
	{
		IDLE,
		STACK_STARTING,
		STACK_STARTED,
		REGISTERING,
		INSERVICE,
		UNREGISTERING,
		UNREGISTERED,
		STACK_STOPPING
	}
}

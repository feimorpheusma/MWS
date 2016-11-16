using System;

namespace DispCore.Services
{
	public interface ISoundService : IService
	{
		void PlayTone(Tone tone, bool looping, long player);

		void StopPlay(Tone tone, long player);

		void StopPlay(long player);

		void PlayNewEvent();

		void StopNewEvent();
	}
}

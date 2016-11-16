using org.doubango.tinyWRAP;
using System;

namespace DispCore.Models.Cfg
{
	public class PrefVideoSize
	{
		private readonly string text;

		private readonly tmedia_pref_video_size_t value;

		public string Text
		{
			get
			{
				return this.text;
			}
		}

		public tmedia_pref_video_size_t Value
		{
			get
			{
				return this.value;
			}
		}

		public PrefVideoSize(string text, tmedia_pref_video_size_t value)
		{
			this.text = text;
			this.value = value;
		}
	}
}

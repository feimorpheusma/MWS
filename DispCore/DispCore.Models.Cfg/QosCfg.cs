using DispCore.Services;
using org.doubango.tinyWRAP;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DispCore.Models.Cfg
{
	public class QosCfg : INotifyPropertyChanged
	{
		private IConfigurationService configurationService;

		private tmedia_pref_video_size_t prefVideoSize;

		private PrefVideoSize[] prefVideoSizeValues = null;

		private int iVideoFPS;

		public event PropertyChangedEventHandler PropertyChanged;

		public IConfigurationService ConfigurationService
		{
			set
			{
				this.configurationService = value;
				this.iVideoFPS = this.configurationService.Get(Configuration.ConfFolder.QOS, Configuration.ConfEntry.VIDEO_FPS, 30);
			}
		}

		public tmedia_pref_video_size_t PrefVideoSize
		{
			get
			{
				return this.prefVideoSize;
			}
			set
			{
				if (this.prefVideoSize != value)
				{
					this.prefVideoSize = value;
					if (this.configurationService != null)
					{
						this.configurationService.Set(Configuration.ConfFolder.QOS, Configuration.ConfEntry.PREF_VIDEO_SIZE, value.ToString());
						MediaSessionMgr.defaultsSetPrefVideoSize(this.prefVideoSize);
						this.OnPropertyChanged("PrefVideoSizeValues");
					}
				}
			}
		}

		public PrefVideoSize[] PrefVideoSizeValues
		{
			get
			{
				return this.prefVideoSizeValues;
			}
		}

		public int SelectIndex
		{
			get
			{
				return this.PrefVideoSizeValues.ToList<PrefVideoSize>().FindIndex((PrefVideoSize x) => x.Value == this.prefVideoSize);
			}
			set
			{
				if (value >= 0 && value <= this.prefVideoSizeValues.Length)
				{
					PrefVideoSize selVideoSize = this.prefVideoSizeValues[value];
					this.PrefVideoSize = selVideoSize.Value;
				}
			}
		}

		public string VideoFPS
		{
			get
			{
				return string.Format("{0}", this.iVideoFPS);
			}
			set
			{
				if (value != null)
				{
					Regex reg = new Regex("^[0-9]+$");
					Match mat = reg.Match(value);
					if (!mat.Success)
					{
						MessageBox.Show("请输入1～30的数字");
					}
					else
					{
						this.iVideoFPS = int.Parse(value);
						if (this.iVideoFPS <= 0 || this.iVideoFPS > 30)
						{
							MessageBox.Show("请输入1～30的数字");
						}
						else if (this.configurationService != null)
						{
							this.configurationService.Set(Configuration.ConfFolder.QOS, Configuration.ConfEntry.VIDEO_FPS, value);
							MediaSessionMgr.defaultsSetVideoFps(this.iVideoFPS);
							this.OnPropertyChanged("VideoFPS");
						}
					}
				}
			}
		}

		public QosCfg(tmedia_pref_video_size_t prefVideoSizeIn, int fps)
		{
			this.prefVideoSize = prefVideoSizeIn;
			this.iVideoFPS = fps;
			this.prefVideoSizeValues = new PrefVideoSize[]
			{
				new PrefVideoSize("SQCIF (128 x 98)", tmedia_pref_video_size_t.tmedia_pref_video_size_sqcif),
				new PrefVideoSize("QCIF (176 x 144)", tmedia_pref_video_size_t.tmedia_pref_video_size_qcif),
				new PrefVideoSize("CIF (352 x 288)", tmedia_pref_video_size_t.tmedia_pref_video_size_cif),
				new PrefVideoSize("720P (1280 x 720)", tmedia_pref_video_size_t.tmedia_pref_video_size_720p),
				new PrefVideoSize("16CIF (1408 x 1152)", tmedia_pref_video_size_t.tmedia_pref_video_size_16cif),
				new PrefVideoSize("1080P (1920 x 1080)", tmedia_pref_video_size_t.tmedia_pref_video_size_1080p)
			};
		}

		public void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

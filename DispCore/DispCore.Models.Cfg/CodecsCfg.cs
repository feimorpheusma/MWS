using DispCore.Services;
using org.doubango.tinyWRAP;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DispCore.Models.Cfg
{
	public class CodecsCfg : INotifyPropertyChanged
	{
		public class Codec : INotifyPropertyChanged
		{
			private readonly string name;

			private readonly string description;

			private readonly tmedia_codec_id_t id;

			private bool enabled;

			public event PropertyChangedEventHandler PropertyChanged;

			public string Name
			{
				get
				{
					return this.name;
				}
			}

			public string Description
			{
				get
				{
					return this.description;
				}
			}

			public tmedia_codec_id_t Id
			{
				get
				{
					return this.id;
				}
			}

			public bool IsEnabled
			{
				get
				{
					return this.enabled;
				}
				set
				{
					this.enabled = value;
					this.OnPropertyChanged("IsEnabled");
				}
			}

			public string CodecType
			{
				get
				{
					tmedia_codec_id_t tmedia_codec_id_t = this.id;
					if (tmedia_codec_id_t <= tmedia_codec_id_t.tmedia_codec_id_ilbc)
					{
						if (tmedia_codec_id_t <= tmedia_codec_id_t.tmedia_codec_id_gsm)
						{
							if (tmedia_codec_id_t == tmedia_codec_id_t.tmedia_codec_id_red)
							{
								goto IL_A1;
							}
							switch (tmedia_codec_id_t)
							{
							case tmedia_codec_id_t.tmedia_codec_id_amr_nb_oa:
							case tmedia_codec_id_t.tmedia_codec_id_amr_nb_be:
								break;
							default:
								if (tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_gsm)
								{
									goto IL_A9;
								}
								break;
							}
						}
						else if (tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_pcma && tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_pcmu && tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_ilbc)
						{
							goto IL_A9;
						}
					}
					else if (tmedia_codec_id_t <= tmedia_codec_id_t.tmedia_codec_id_speex_uwb)
					{
						if (tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_speex_nb && tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_speex_wb && tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_speex_uwb)
						{
							goto IL_A9;
						}
					}
					else if (tmedia_codec_id_t <= tmedia_codec_id_t.tmedia_codec_id_g729ab)
					{
						if (tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_opus && tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_g729ab)
						{
							goto IL_A9;
						}
					}
					else if (tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_g722)
					{
						if (tmedia_codec_id_t != tmedia_codec_id_t.tmedia_codec_id_t140)
						{
							goto IL_A9;
						}
						goto IL_A1;
					}
					string result = "Audio Codecs";
					return result;
					IL_A1:
					result = "Other Codecs";
					return result;
					IL_A9:
					result = "Video Codecs";
					return result;
				}
			}

			internal Codec(string name, string description, tmedia_codec_id_t id)
			{
				this.name = name;
				this.description = description;
				this.id = id;
			}

			public void OnPropertyChanged(string propertyName)
			{
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
		}

		private int codecs;

		private System.Collections.Generic.List<CodecsCfg.Codec> supportedCodecs;

		private IConfigurationService configurationService;

		public event PropertyChangedEventHandler PropertyChanged;

		public IConfigurationService ConfigurationService
		{
			set
			{
				this.configurationService = value;
			}
		}

		public int Codecs
		{
			get
			{
				return this.codecs;
			}
			set
			{
				if (this.codecs != value)
				{
					this.codecs = value;
					this.configurationService.Set(Configuration.ConfFolder.MEDIA, Configuration.ConfEntry.CODECS, value);
					this.OnPropertyChanged("Codecs");
				}
			}
		}

		public System.Collections.Generic.List<CodecsCfg.Codec> SupportedCodecs
		{
			get
			{
				if (this.supportedCodecs == null)
				{
					this.supportedCodecs = new System.Collections.Generic.List<CodecsCfg.Codec>();
					this.supportedCodecs.Add(new CodecsCfg.Codec("PCMA", "PCMA (8 KHz)", tmedia_codec_id_t.tmedia_codec_id_pcma));
					this.supportedCodecs.Add(new CodecsCfg.Codec("PCMU", "PCMU (8 KHz)", tmedia_codec_id_t.tmedia_codec_id_pcmu));
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_gsm))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("GSM", "GSM (8 KHz)", tmedia_codec_id_t.tmedia_codec_id_gsm));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_amr_nb_oa))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("AMR-NB-OA", "AMR Narrow Band Octet Aligned (8 KHz)", tmedia_codec_id_t.tmedia_codec_id_amr_nb_oa));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_amr_nb_be))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("AMR-NB-BE", "AMR Narrow Band Bandwidth Efficient (8 KHz)", tmedia_codec_id_t.tmedia_codec_id_amr_nb_be));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_amr_wb_oa))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("AMR-WB-OA", "AMR Wide Band Octet Aligned (8 KHz)", tmedia_codec_id_t.tmedia_codec_id_amr_wb_oa));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_amr_wb_be))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("AMR-WB-BE", "AMR Wide Band Bandwidth Efficient (8 KHz)", tmedia_codec_id_t.tmedia_codec_id_amr_wb_be));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_ilbc))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("iLBC", "internet Low Bitrate Codec (8 KHz)", tmedia_codec_id_t.tmedia_codec_id_ilbc));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_h264_bp))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("H264-BP", "H.264 Base Profile", tmedia_codec_id_t.tmedia_codec_id_h264_bp));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_h264_mp))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("H264-MP", "H.264 Main Profile", tmedia_codec_id_t.tmedia_codec_id_h264_mp));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_h264_hp))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("H264-HP", "H.264 High Profile", tmedia_codec_id_t.tmedia_codec_id_h264_hp));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_mp4ves_es))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("MP4V-ES", "MPEG-4 Part 2", tmedia_codec_id_t.tmedia_codec_id_mp4ves_es));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_h263))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("H.263", "H.263", tmedia_codec_id_t.tmedia_codec_id_h263));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_h263p))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("H.263-1998", "H.263-1998", tmedia_codec_id_t.tmedia_codec_id_h263p));
					}
					if (SipStack.isCodecSupported(tmedia_codec_id_t.tmedia_codec_id_h263pp))
					{
						this.supportedCodecs.Add(new CodecsCfg.Codec("H.263-2000", "H.263-2000", tmedia_codec_id_t.tmedia_codec_id_h263pp));
					}
					this.supportedCodecs.ForEach(delegate(CodecsCfg.Codec x)
					{
						x.IsEnabled = ((x.Id & (tmedia_codec_id_t)this.codecs) == x.Id);
					});
				}
				return this.supportedCodecs;
			}
			set
			{
				tmedia_codec_id_t codecIds = tmedia_codec_id_t.tmedia_codec_id_none;
				this.supportedCodecs.ForEach(delegate(CodecsCfg.Codec x)
				{
					codecIds |= (x.IsEnabled ? x.Id : tmedia_codec_id_t.tmedia_codec_id_none);
				});
				this.Codecs = (int)codecIds;
				this.OnPropertyChanged("SupportedCodecs");
			}
		}

		public CodecsCfg(int codecs)
		{
			this.codecs = codecs;
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

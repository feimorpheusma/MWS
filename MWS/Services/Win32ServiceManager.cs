using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.IO;
using System.Windows.Forms;
using org.doubango.tinyWRAP;
using DispCore.Services.Impl;
using DispCore.Services;
using DispCore.Models.Cfg;
using DispCore.Events.Sip;
using MWS;
using DispCore.Utils;

namespace MWS.Services
{
    public class Win32ServiceManager : ServiceManager
    {
        private static ILog LOG = LogManager.GetLogger(typeof(Win32ServiceManager));

        private static Win32ServiceManager singleton = null;
        private static Boolean initialized = false;
        private const String MULI_INSTANCE_FILE = "./.multiinstance";
        private readonly bool multiInstance;
        private String applicationDataPath;

        private ISoundService soundService;
        private ILogService logService;
        private IConfigurationService configurationService;
        private IStackService stackService;
        private IContactService contactService;
        private IHistoryService historyService;
        private IAccessNetworkService accessNetworkService;
        private IStatusService statusService;
        private IServiceRealizeService serviceRealizeService;
        private IWin32ScreenService screenService;

        /// <summary>
        /// Shared Service manager
        /// </summary>
        public static Win32ServiceManager SharedManager
        {
            get
            {
                if (Win32ServiceManager.singleton == null)
                {
                    Win32ServiceManager.singleton = new Win32ServiceManager();
                    UriUtils.ServiceManager = Win32ServiceManager.singleton;
                }
                return Win32ServiceManager.singleton;
            }
        }

        public Win32ServiceManager()
        {
            this.multiInstance = System.IO.File.Exists(Win32ServiceManager.MULI_INSTANCE_FILE);
            if (!initialized)
            {
                SipStack.initialize();
                initialized = true;
            }
        }

        /// <summary>
        /// Starts the manager
        /// </summary>
        /// <returns></returns>
        public bool Start()
        {
            bool ret = true;

            LOG.Debug("Start Service Manager");

            ret &= this.LogService.Start();
            ret &= this.ConfigurationService.Start();

            ret &= this.StackService.Start();
            ret &= this.ContactService.Start();
            ret &= this.HistoryService.Start();
            ret &= this.AccessNetworkService.Start();
            ret &= this.StatusService.Start();
            ret &= this.SoundService.Start();
            ret &= this.ScreenService.Start();
            ret &= this.ServiceRealizeService.Start();

            MediaSessionMgr.defaultsSetAgcEnabled(true);
            MediaSessionMgr.defaultsSetEchoSuppEnabled(true);
            MediaSessionMgr.defaultsSetEchoTail(100);
            MediaSessionMgr.defaultsSetEchoSkew(0);
            MediaSessionMgr.defaultsSetNoiseSuppEnabled(true);
            MediaSessionMgr.defaultsSetVadEnabled(false);
            MediaSessionMgr.defaultsSetJbMaxLateRate(1);
            MediaSessionMgr.defaultsSetRtcpEnabled(true);
            MediaSessionMgr.defaultsSetRtcpMuxEnabled(true);
            MediaSessionMgr.defaultsSetOpusMaxCaptureRate(16000);   /* Because of WebRTC AEC only 8000 and 16000 are supported */
            MediaSessionMgr.defaultsSetOpusMaxPlaybackRate(48000);
            MediaSessionMgr.defaultsSetAudioChannels(1, 1);         // mono for both
            MediaSessionMgr.defaultsSetAudioPtime(20);
                      // default video FPS. Will be updated using the SDP.
            MediaSessionMgr.defaultsSetAvpfMode(tmedia_mode_t.tmedia_mode_none);
            MediaSessionMgr.defaultsSetBandwidthVideoDownloadMax(-1);
            MediaSessionMgr.defaultsSetBandwidthVideoUploadMax(-1);
            MediaSessionMgr.defaultsSetPrefVideoSize(
               (tmedia_pref_video_size_t)Enum.Parse(typeof(tmedia_pref_video_size_t), this.configurationService.Get(Configuration.ConfFolder.QOS, Configuration.ConfEntry.PREF_VIDEO_SIZE, Configuration.DEFAULT_QOS_PREF_VIDEO_SIZE), true)
               );
            int fps = this.configurationService.Get(Configuration.ConfFolder.QOS, Configuration.ConfEntry.VIDEO_FPS, 12);
            MediaSessionMgr.defaultsSetVideoFps(fps);     
            return ret;
        }

        /// <summary>
        /// Stops the manager
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            bool ret = true;

            ret &= this.AccessNetworkService.Stop();
            ret &= this.StackService.Stop();
             return ret;
        }

        public override String ApplicationDataPath
        {
            get
            {
                if (this.applicationDataPath == null)
                {
                    if (this.multiInstance)
                    {
                        this.applicationDataPath = Path.Combine(Application.StartupPath, "User");
                    }
                    else
                    {
                        String applicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        this.applicationDataPath = Path.Combine(applicationData, "CETC7\\T1Droid");
                    }
                    Directory.CreateDirectory(this.applicationDataPath);
                }
                return this.applicationDataPath;
            }
        }

        public override bool IsMultiInstanceEnabled
        {
            get
            {
                return this.multiInstance;
            }
        }

        public override String BuildStoragePath(String folder)
        {
            return Path.Combine(this.ApplicationDataPath, folder);
        }

        public ILogService LogService
        {
            get
            {
                if (this.logService == null)
                {
                    this.logService = new LogService();
                }
                return this.logService;
            }
        }

        #region ServiceManager
        public override IScreenService ScreenService
        {
            get
            {
                return this.Win32ScreenService;
            }
        }

        public override IStackService StackService
        {
            get
            {
                if (this.stackService == null)
                {
                    this.stackService = new StackService(this);
                    stackService.ConfigXcapStack();
                }
                return this.stackService;
            }
        }

        public override IConfigurationService ConfigurationService
        {
            get
            {
                if (this.configurationService == null)
                {
                    this.configurationService = new ConfigurationService(this);
                }
                return this.configurationService;
            }
        }

        public override IContactService ContactService
        {
            get
            {
                if (this.contactService == null)
                {
                    this.contactService = new ContactService(this);
                }
                return this.contactService;
            }
        }

        public override IHistoryService HistoryService
        {
            get
            {
                if (this.historyService == null)
                {
                    this.historyService = new HistoryService(this);
                }
                return this.historyService;
            }
        }

        public override IAccessNetworkService AccessNetworkService
        {
            get
            {
                if (this.accessNetworkService == null)
                {
                    this.accessNetworkService = new AccessNetworkService(this);
                }
                return this.accessNetworkService;
            }
        }

        public override IStatusService StatusService
        {
            get
            {
                if (this.statusService == null)
                {
                    this.statusService = new StatusService(this);
                }
                return this.statusService;
            }
        }

        public override IServiceRealizeService ServiceRealizeService
        {
            get
            {
                if (this.serviceRealizeService == null)
                {
                    this.serviceRealizeService = new ServiceRealizeService(this);
                }
                return this.serviceRealizeService;
            }
        }

        public override ISoundService SoundService
        {
            get
            {
                if (this.soundService == null)
                {
                    this.soundService = new SoundService(this);
                }
                return this.soundService;
            }
        }

        public IWin32ScreenService Win32ScreenService
        {
            get
            {
                if (this.screenService == null)
                {
                    this.screenService = new ScreenService();
                }
                return this.screenService;
            }
        }
        #endregion
    }
}

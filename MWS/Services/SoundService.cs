using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DispCore.Services;
using DispCore.Services.Impl;
using System.Media;
using log4net;
using System.IO;
using System.Windows.Media;
using MWS.Utils;

namespace MWS.Services
{
    public partial class SoundService : ISoundService
    {
        private static ILog LOG = LogManager.GetLogger(typeof(SoundService));

        private readonly ServiceManager manager;

        private MySoundPlayer[] soundPlayers;
        private SoundPlayer eventPlayer;

        public SoundService(ServiceManager manager)
        {
            this.manager = manager;            
        }

        #region IService

        public bool Start()
        {
            int i = 0;
            try
            {
                this.eventPlayer = new SoundPlayer(MWS.Properties.Resources.newsms);
                soundPlayers = new MySoundPlayer[(int)Tone.TONE_MAX];
                for (Tone tone = Tone.TONE_DTMF_1; tone < Tone.TONE_MAX; tone++)
                {
                    soundPlayers[i++] = new MySoundPlayer(tone);
                }
                    
                return true;
            }
            catch (Exception e)
            {
                LOG.Error("Failed to start sound service", e);
                return false;
            }
        }

        public bool Stop()
        {
            foreach (MySoundPlayer player in soundPlayers)
            {
                player.Stop(MySoundPlayer.ANY_OWNER);
            }
            this.eventPlayer.Stop();
            return true;
        }

        #endregion

        #region ISoundService
        public void PlayTone(Tone tone, bool looping, long player)
        {
            soundPlayers[(int)tone].PlayTone(player, looping);
        }

        public void StopPlay(Tone tone, long player)
        {
            soundPlayers[(int)tone].Stop(player);
        }

        public void StopPlay(long player)
        {
            foreach (MySoundPlayer soundPlayer in soundPlayers)
            {
                soundPlayer.Stop(player);
            }
        }
        public void PlayNewEvent()
        {
            this.eventPlayer.Play();
        }

        public void StopNewEvent()
        {
            this.eventPlayer.Stop();
        }
        #endregion
    }
}

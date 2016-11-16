using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Windows.Media;
using DispCore.Services;

namespace MWS.Utils
{
    public class MySoundPlayer
    {
        public const int ANY_OWNER = 0;
        private static Stream[] soundStreams = 
        {
            MWS.Properties.Resources.dtmf_1,
            MWS.Properties.Resources.dtmf_2,
            MWS.Properties.Resources.dtmf_3,
            MWS.Properties.Resources.dtmf_4,
            MWS.Properties.Resources.dtmf_5,
            MWS.Properties.Resources.dtmf_6,
            MWS.Properties.Resources.dtmf_7,
            MWS.Properties.Resources.dtmf_8,
            MWS.Properties.Resources.dtmf_9,
            MWS.Properties.Resources.dtmf_star,
            MWS.Properties.Resources.dtmf_0,
            MWS.Properties.Resources.dtmf_pound,
            MWS.Properties.Resources.ringtone,
            MWS.Properties.Resources.ringbacktone,
            MWS.Properties.Resources.newsms,
            MWS.Properties.Resources._403,
            MWS.Properties.Resources._404,
            MWS.Properties.Resources._480,
            MWS.Properties.Resources._486,
            MWS.Properties.Resources._488
        };

        private SoundPlayer player;
        private long playerOwner;

        public MySoundPlayer()
        {
            player = new SoundPlayer();
        }

        public MySoundPlayer(Tone tone)
        {
            player = new SoundPlayer(soundStreams[(int)tone]);
        }

        public MySoundPlayer(Stream soundStream)
        {
            player = new SoundPlayer(soundStream);
        }

        public Stream SoundStream
        {
            set
            {
                player.Stream = value;
                player.Load();
            }
        }

        public long PlayerOwner
        {
            set { this.playerOwner = value; }
            get { return this.playerOwner; }
        }

        public void PlayTone(long owner, bool looping)
        {
            //if (player.IsLoadCompleted)
            //{
                if (looping)
                {
                    player.PlayLooping();
                }
                else
                {
                    player.Play();
                }

                this.playerOwner = owner;
            //}
        }

        public void Stop(long owner)
        {
            if ((owner == this.playerOwner) || (owner == ANY_OWNER))
            {
                player.Stop();
            }
        }
    }
}

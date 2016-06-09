using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Media;

namespace SFMLApp
{
    class Sound
    {
        SortedDictionary<string, MediaPlayer> Threads;

        public Sound()
        {
            Threads = new SortedDictionary<string, MediaPlayer>();
        }

        public void Play(string tag)
        {
            Play(tag, tag + ".mp3");
        }

        public long GetTime(string tag)
        {
            MediaPlayer h = Threads[tag];
            if (h.HasAudio)
                return h.NaturalDuration.TimeSpan.Ticks;
            else
                return -1;
        }

        public void Play(string tag, string name)
        {
            if (Threads.ContainsKey(tag))
                Threads[tag].Play();
            else
            {
                Threads.Add(tag, new MediaPlayer());
                Threads[tag].Open(new Uri(name, System.UriKind.Relative));
                Threads[tag].Play();
            }
        }

        public bool ExistTag(string tag)
        {
            return Threads.ContainsKey(tag);
        }

        public void Pause(string tag)
        {
            if (ExistTag(tag))
                Threads[tag].Pause();
        }

        public void Stop(string tag)
        {
            if (ExistTag(tag))
                Threads[tag].Stop();
        }
    }
}

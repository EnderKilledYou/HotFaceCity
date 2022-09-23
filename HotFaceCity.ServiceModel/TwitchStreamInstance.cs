using System;
using ServiceStack.DataAnnotations;

namespace HotFaceCity.ServiceModel
{
    public class TwitchStreamInstance
    {
        public static implicit operator TwitchStreamInstance(TwitchStream twitchStream)
        {
            return new TwitchStreamInstance()
            {
                Delay = twitchStream.Delay,
                Game = twitchStream.Game,
                TwitchId = twitchStream.Id,
                Preview = twitchStream.Preview,
                Viewers = twitchStream.Viewers,
                AverageFps = twitchStream.AverageFps,
                CreatedAt = twitchStream.CreatedAt,
                IsPlaylist = twitchStream.IsPlaylist,
                VideoHeight = twitchStream.VideoHeight,
               
            };
        }

        [PrimaryKey] [AutoIncrement] public long Id { get; set; }

        public long? TwitchId { get; set; }


        public long? AverageFps { get; set; }


        [References(typeof(TwitchChannelInstance))]
        public int TwitchChannelInstanceId { get; set; }
        


        public DateTimeOffset? CreatedAt { get; set; }


        public long? Delay { get; set; }


        public string Game { get; set; }


        public bool? IsPlaylist { get; set; }


        public Preview Preview { get; set; }


        public long? VideoHeight { get; set; }


        public long? Viewers { get; set; }
    }
}
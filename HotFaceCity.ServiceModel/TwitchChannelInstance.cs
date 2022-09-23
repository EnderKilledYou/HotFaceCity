using System;
using ServiceStack.DataAnnotations;

namespace HotFaceCity.ServiceModel
{
    public class TwitchChannelInstance
    {
        public static implicit operator TwitchChannelInstance(Channel channel)
        {
            return new TwitchChannelInstance();
        }
        [PrimaryKey] [AutoIncrement] public long Id { get; set; }


        public long? TwitchChannelId { get; set; }


        public string BroadcasterLanguage { get; set; }


        public DateTimeOffset? CreatedAt { get; set; }


        public string DisplayName { get; set; }


        public long? Followers { get; set; }


        public string Game { get; set; }


        public string Language { get; set; }


        public Uri Logo { get; set; }


        public bool? Mature { get; set; }


        public string Name { get; set; }


        public bool? Partner { get; set; }


        public Uri ProfileBanner { get; set; }


        public object ProfileBannerBackgroundColor { get; set; }


        public string Status { get; set; }


        public DateTimeOffset? UpdatedAt { get; set; }


        public Uri Url { get; set; }


        public Uri VideoBanner { get; set; }


        public long? Views { get; set; }
    }
}
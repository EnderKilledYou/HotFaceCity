//https://app.quicktype.io/?l=csharp

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HotFaceCity.ServiceModel
{
    public class TwitchGetLiveStreamsResponse
    {
        [JsonProperty("streams", NullValueHandling = NullValueHandling.Ignore)]
        public List<TwitchStream> Streams { get; set; }
    }

    public class TwitchStream
    {
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("average_fps", NullValueHandling = NullValueHandling.Ignore)]
        public long? AverageFps { get; set; }

        [JsonProperty("channel", NullValueHandling = NullValueHandling.Ignore)]
        public Channel Channel { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("delay", NullValueHandling = NullValueHandling.Ignore)]
        public long? Delay { get; set; }

        [JsonProperty("game", NullValueHandling = NullValueHandling.Ignore)]
        public string Game { get; set; }

        [JsonProperty("is_playlist", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsPlaylist { get; set; }

        [JsonProperty("preview", NullValueHandling = NullValueHandling.Ignore)]
        public Preview Preview { get; set; }

        [JsonProperty("video_height", NullValueHandling = NullValueHandling.Ignore)]
        public long? VideoHeight { get; set; }

        [JsonProperty("viewers", NullValueHandling = NullValueHandling.Ignore)]
        public long? Viewers { get; set; }
    }

    public class Channel
    {
        [JsonProperty("_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("broadcaster_language", NullValueHandling = NullValueHandling.Ignore)]
        public string BroadcasterLanguage { get; set; }

        [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? CreatedAt { get; set; }

        [JsonProperty("display_name", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [JsonProperty("followers", NullValueHandling = NullValueHandling.Ignore)]
        public long? Followers { get; set; }

        [JsonProperty("game", NullValueHandling = NullValueHandling.Ignore)]
        public string Game { get; set; }

        [JsonProperty("language", NullValueHandling = NullValueHandling.Ignore)]
        public string Language { get; set; }

        [JsonProperty("logo", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Logo { get; set; }

        [JsonProperty("mature", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Mature { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("partner", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Partner { get; set; }

        [JsonProperty("profile_banner", NullValueHandling = NullValueHandling.Ignore)]
        public Uri ProfileBanner { get; set; }

        [JsonProperty("profile_banner_background_color")]
        public object ProfileBannerBackgroundColor { get; set; }

        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("updated_at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? UpdatedAt { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("video_banner", NullValueHandling = NullValueHandling.Ignore)]
        public Uri VideoBanner { get; set; }

        [JsonProperty("views", NullValueHandling = NullValueHandling.Ignore)]
        public long? Views { get; set; }
    }

    public class Preview
    {
        [JsonProperty("large", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Large { get; set; }

        [JsonProperty("medium", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Medium { get; set; }

        [JsonProperty("small", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Small { get; set; }

        [JsonProperty("template", NullValueHandling = NullValueHandling.Ignore)]
        public string Template { get; set; }
    }
}
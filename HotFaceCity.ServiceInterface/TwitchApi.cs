using System;
using System.Net.Http;
using System.Threading.Tasks;
using HotFaceCity.ServiceModel;
using Newtonsoft.Json;
using ServiceStack;
using ServiceStack.Logging;

namespace HotFaceCity.ServiceInterface
{
    public class TwitchApi
    {
        public record ApiMessageResult<T>
        {
            public T Result { get; set; }
            public bool Success { get; set; }
            public Exception Exception { get; set; }
        }


        private readonly HttpClient _httpClient;
        private readonly string _twitchClientId;

        public TwitchApi(string twitchClientId)
        {
            _twitchClientId = twitchClientId;
            
            _httpClient = new HttpClient(); //todo: need to set default headers
        }

        //https://curl.olsh.me/
        public async Task<ApiMessageResult<TwitchGetLiveStreamsResponse>> GetLiveStreamsResponse(string game,
            string language,
            string streamType, int limit, int offset, params string[] channels)
        {
            using var request = new HttpRequestMessage(new HttpMethod("GET"),
                $"https://api.twitch.tv/kraken/streams/?game={{game}}&language={language}&stream_type={streamType}&limit={limit}&offset={offset}&channels={channels.Join()}");
            request.Headers.TryAddWithoutValidation("Accept", "application/vnd.twitchtv.v5+json");
            request.Headers.TryAddWithoutValidation("Client-ID", _twitchClientId);
            try
            {
                var response = await (await _httpClient.SendAsync(request)).Content.ReadAsStringAsync();
                return new ApiMessageResult<TwitchGetLiveStreamsResponse>()
                {
                    Result = JsonConvert.DeserializeObject<TwitchGetLiveStreamsResponse>(response),
                    Success = true
                };
            }
            catch (HttpRequestException httpRequestException)
            {
                return HandleApiError(httpRequestException);
            }
            catch (Exception ex)
            {
                return HandleApiError(ex);
            }
        }

        private static ApiMessageResult<TwitchGetLiveStreamsResponse> HandleApiError(Exception ex)
        {
            LogManager.GetLogger(typeof(TwitchApi)).Error(ex);
            return new ApiMessageResult<TwitchGetLiveStreamsResponse>()
            {
                Exception = ex,
                Result = null,
                Success = false
            };
        }
    }
}
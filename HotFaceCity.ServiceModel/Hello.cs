using System.Collections.Generic;
using ServiceStack;
using ServiceStack.FluentValidation.Results;

namespace HotFaceCity.ServiceModel
{
    [Route("/hello")]
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class ListTwitchByViewersRequest : IReturn<ListTwitchByViewersResponse>
    {
        public long MinViewers { get; set; } = 100;
        public long MaxViewers { get; set; } = 0;
        public bool OrderByDescending { get; set; } = false;
        public string[] OrderByFields { get; set; }
        public string[] Games { get; set; }
    }

    public class ListTwitchByViewsRequest : IReturn<ListTwitchByViewsResponse>
    {
        
    }
    
    public class ListTwitchByViewsResponse
    {
        
    }
    
    public class ListTwitchByViewersResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<ValidationFailure> ValidationErrors { get; set; }
        public List<TwitchStreamInstance> Data { get; set; }
    }
    public class HelloResponse
    {
        public string Result { get; set; }
    }
    
    public class ListTwitchByStatusRequest : IReturn<ListTwitchByStatusResponse>
    {
        
    }
    
    public class ListTwitchByStatusResponse
    {
        
    }
    public class ListTwitchByNameRequest : IReturn<ListTwitchByNameResponse>
    {
        
    }
    public class ListTwitchByNameResponse
    {
        
    }
    public class ListTwitchByStreamLengthRequest : IReturn<ListTwitchByStreamLengthResponse>
    {
        
    }
    public class ListTwitchByStreamLengthResponse
    {
        
    }
    public class ListTwitchByFollowersRequest : IReturn<ListTwitchByFollowersResponse>
    {
        
    }
    
    public class ListTwitchByFollowersResponse
    {
        
    }
}

using System;
using System.Linq;
using HotFaceCity.ServiceModel;
using Microsoft.Extensions.Logging;
using ServiceStack;
using ServiceStack.FluentValidation;
using ServiceStack.Logging;
using ServiceStack.OrmLite;

namespace HotFaceCity.ServiceInterface
{
    public class TwitchIndexService : Service
    {
        private class ListTwitchByViewersRequestValidator : AbstractValidator<ListTwitchByViewersRequest>
        {
            public ListTwitchByViewersRequestValidator()
            {
            }
        }

        public ListTwitchByViewersResponse Get(ListTwitchByViewersRequest request)
        {
            var validator = new ListTwitchByViewersRequestValidator();
            var validation = validator.Validate(request);
            if (!validation.IsValid)
            {
                return new ListTwitchByViewersResponse()
                {
                    Success = false,
                    ValidationErrors = validation.Errors.ToList()
                };
            }

            var sql = Db.From<TwitchStreamInstance>();
            if (request.MinViewers > -1)
            {
                sql = sql.Where(a => a.Viewers >= request.MinViewers);
            }

            if (request.MaxViewers > -1)
            {
                sql = sql.Where(a => a.Viewers <= request.MaxViewers);
            }

            if (request.Games is {Length: > 0})
            {
                sql = sql.Where(a => request.Games.Contains(a.Game));
            }
           
            //too messy to read as coal
            if (request.OrderByDescending)
            {
                sql = sql.OrderByFieldsDescending(request.OrderByFields);
            }
            else
            {
                sql = sql.OrderByFields(request.OrderByFields);
            }

            try
            {
                var result = Db.Select(sql);
                return new ListTwitchByViewersResponse()
                {
                    Success = true,
                    Data = result
                };
            }
            catch (Exception ex)
            {
                LogManager.GetLogger(typeof(ListTwitchByViewersRequest)).Error(ex);
#if DEBUG


                return new ListTwitchByViewersResponse()
                {
                    Success = false,
                    Message = ex.Message + ex.StackTrace
                };
#else
                return new ListTwitchByViewersResponse()
                {
                    Success = false,
Message = "An internal error has occured"
                };
#endif
            }
        }
/*
        public ListTwitchByViewsResponse Get(ListTwitchByViewsRequest request)
        {
        }

        public ListTwitchByFollowersResponse Get(ListTwitchByFollowersRequest request)
        {
        }

        public ListTwitchByStatusResponse Get(ListTwitchByStatusRequest request)
        {
        }

        public ListTwitchByNameResponse Get(ListTwitchByNameRequest request)
        {
        }

        public ListTwitchByStreamLengthResponse Get(ListTwitchByStreamLengthRequest request)
        {
        }
        */
    }
}
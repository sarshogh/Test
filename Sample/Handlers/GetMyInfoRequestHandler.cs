using MediatR;
using Sample.RequestsResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Handlers
{
    public class GetMyInfoRequestHandler : IRequestHandler<GetMyInfoRequest, GetMyInfoResponse>
    {
        public GetMyInfoRequestHandler()
        {

        }

        public Task<GetMyInfoResponse> Handle(GetMyInfoRequest request, CancellationToken cancellationToken)
        {
            var result = new GetMyInfoResponse
            {
                UserName = "ali"
            };
            return Task.FromResult(result);
        }
    }
}

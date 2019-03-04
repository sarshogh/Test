using FluentValidation;
using MediatR;

namespace Sample.RequestsResponses
{
    public class GetMyInfoRequest : IRequest<GetMyInfoResponse>
    {
        public int UserId { get; set; }        
    }

    public class GetMyInfoResponse
    {
        public string UserName { get; set; }
    }

    public class GetMyInfoRequestValidator: AbstractValidator<GetMyInfoRequest>
    {
        public GetMyInfoRequestValidator()
        {
            RuleFor(req => req.UserId).NotEmpty().WithMessage($"provide value for userId");
        }
    }
}
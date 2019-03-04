using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Newtonsoft.Json;
using Sample.RequestsResponses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Middleware
{
    public class RequestHandlerMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;

        public RequestHandlerMiddleware(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(JsonConvert.SerializeObject(failures));
            }

            var response = await next();
            return response;

            //return failures.Any()? Errors(failures) : next();
        }

        //private static Task<TResponse> Errors(IEnumerable<ValidationFailure> failures)
        //{
        //    var response = new Response();

        //    foreach (var failure in failures)
        //    {
        //        response.AddError(failure.ErrorMessage);
        //    }

        //    return Task.FromResult(response as TResponse);
        //}
    }
}
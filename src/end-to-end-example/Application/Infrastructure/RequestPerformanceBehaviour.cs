// <copyright file="RequestPerformanceBehaviour.cs" company="Enterprise Products Partners L.P. (Enterprise)">
// © Copyright 2012 - 2018, Enterprise Products Partners L.P. (Enterprise), All Rights Reserved.
// Permission to use, copy, modify, or distribute this software source code, binaries or
// related documentation, is strictly prohibited, without written consent from Enterprise.
// For inquiries about the software, contact Enterprise: Enterprise Products Company Law
// Department, 1100 Louisiana, 10th Floor, Houston, Texas 77002, phone 713-381-6500.
// </copyright>

using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Microsoft.Extensions.Logging;

namespace Application.Infrastructure
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        private readonly Stopwatch _timer;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;

            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            if (_timer.ElapsedMilliseconds > 500)
            {
                var name = typeof(TRequest).Name;

                _logger.LogWarning(
                    "Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",
                    name,
                    _timer.ElapsedMilliseconds,
                    request);
            }

            return response;
        }
    }
}

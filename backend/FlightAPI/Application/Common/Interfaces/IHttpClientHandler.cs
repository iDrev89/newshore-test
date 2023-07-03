using Application.Common.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TResult>(string clientApi, string url,
          CancellationToken cancellationToken,
          MethodType method = MethodType.Get)
          where TResult : class;
    }
}

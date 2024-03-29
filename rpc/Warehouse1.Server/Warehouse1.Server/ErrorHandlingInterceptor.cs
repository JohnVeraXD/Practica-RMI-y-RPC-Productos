﻿using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Warehouse1.Server
{
    public class ErrorHandlingInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (RpcException)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw new RpcException(new Status(StatusCode.Internal, $"Excepcion de error; {ex.Message}"));
            }

        }    
    }
}

using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse1.Server;
namespace Warehouse1.Client
{
    public class WarehouseClientWrapper
    {
        private readonly  Server.Warehouse.WarehouseClient _client;
        public WarehouseClientWrapper(string address)
        {
            var channel = GrpcChannel.ForAddress(address);
            _client = new Server.Warehouse.WarehouseClient(channel);
        }
        
        public async Task<Product> GetProductByIdAsync(string id)
        {
            try
            {
                var grpcCall = _client.GetProductByIdAsync(new ProductID { Id = id });
                return await CallGrpcServiceAsync(grpcCall);
            }
            catch (RpcException)
            {
                return null;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {

            try
            {
                var grpcCall = _client.GetProductByNameAsync(new ProductName { Name = name });
                return await CallGrpcServiceAsync(grpcCall);
            }
            catch (RpcException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<T> CallGrpcServiceAsync<T>(AsyncUnaryCall<T> grpcCall)
        {
            try
            {
                return await grpcCall.ResponseAsync;
            }
            catch (RpcException ex)
            {
                HandleRpcException(ex);
                throw;
            }
        }

        public async Task<string> AddProductsAsnyc(string id, string name, int quantity)
        {
            try
            {
                var grpcCall = _client.AddProductAsync(new Product { Id = id, Name = name, Quantity = quantity });
                var response = await CallGrpcServiceAsync(grpcCall);
                return response.Id;
            }
            catch (RpcException)
            {
                return null;
            }
            catch (Exception ) 
            {
                throw;
            }
        }

        private void HandleRpcException(RpcException ex)
        {
            switch (ex.StatusCode)
            {
                case StatusCode.NotFound:
                    Console.WriteLine($"Error: {ex.Status.Detail}");
                    break;
                case StatusCode.Unavailable:
                    Console.WriteLine("El servidor no responde, intente mas tarde");
                    break;
                default: 
                    Console.WriteLine($"El error es el siguiente: {ex.Status.Detail}");
                    break;

            }
        }
        public async Task<bool> UpdateProductAsync(string id, string newName, int newQuantity)
        {
            try
            {
                var existingProduct = await GetProductByIdAsync(id);
                if (existingProduct == null)
                {
                    Console.WriteLine("El producto con el ID proporcionado no existe. No se puede actualizar.");
                    return false;
                }
                // Llamar al servicio gRPC para actualizar el producto
                var grpcCall = _client.UpdateProductAsync(new Product { Id = id, Name = newName, Quantity = newQuantity });
                var updatedProduct = await CallGrpcServiceAsync(grpcCall);
                // Devolver true si la operación fue exitosa (si se devuelve un producto actualizado)
                return updatedProduct != null;
            }
            catch (RpcException)
            {
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

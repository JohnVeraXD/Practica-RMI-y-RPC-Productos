// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/warehouse.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Warehouse1.Server {
  public static partial class Warehouse
  {
    static readonly string __ServiceName = "warehouse.Warehouse";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Warehouse1.Server.ProductID> __Marshaller_warehouse_ProductID = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Warehouse1.Server.ProductID.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Warehouse1.Server.Product> __Marshaller_warehouse_Product = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Warehouse1.Server.Product.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::Warehouse1.Server.ProductName> __Marshaller_warehouse_ProductName = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Warehouse1.Server.ProductName.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Warehouse1.Server.ProductID, global::Warehouse1.Server.Product> __Method_GetProductById = new grpc::Method<global::Warehouse1.Server.ProductID, global::Warehouse1.Server.Product>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetProductById",
        __Marshaller_warehouse_ProductID,
        __Marshaller_warehouse_Product);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Warehouse1.Server.ProductName, global::Warehouse1.Server.Product> __Method_GetProductByName = new grpc::Method<global::Warehouse1.Server.ProductName, global::Warehouse1.Server.Product>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetProductByName",
        __Marshaller_warehouse_ProductName,
        __Marshaller_warehouse_Product);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Warehouse1.Server.Product, global::Warehouse1.Server.ProductID> __Method_AddProduct = new grpc::Method<global::Warehouse1.Server.Product, global::Warehouse1.Server.ProductID>(
        grpc::MethodType.Unary,
        __ServiceName,
        "AddProduct",
        __Marshaller_warehouse_Product,
        __Marshaller_warehouse_ProductID);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::Warehouse1.Server.Product, global::Warehouse1.Server.Product> __Method_UpdateProduct = new grpc::Method<global::Warehouse1.Server.Product, global::Warehouse1.Server.Product>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UpdateProduct",
        __Marshaller_warehouse_Product,
        __Marshaller_warehouse_Product);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Warehouse1.Server.WarehouseReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of Warehouse</summary>
    [grpc::BindServiceMethod(typeof(Warehouse), "BindService")]
    public abstract partial class WarehouseBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Warehouse1.Server.Product> GetProductById(global::Warehouse1.Server.ProductID request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Warehouse1.Server.Product> GetProductByName(global::Warehouse1.Server.ProductName request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Warehouse1.Server.ProductID> AddProduct(global::Warehouse1.Server.Product request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::Warehouse1.Server.Product> UpdateProduct(global::Warehouse1.Server.Product request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(WarehouseBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetProductById, serviceImpl.GetProductById)
          .AddMethod(__Method_GetProductByName, serviceImpl.GetProductByName)
          .AddMethod(__Method_AddProduct, serviceImpl.AddProduct)
          .AddMethod(__Method_UpdateProduct, serviceImpl.UpdateProduct).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, WarehouseBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetProductById, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Warehouse1.Server.ProductID, global::Warehouse1.Server.Product>(serviceImpl.GetProductById));
      serviceBinder.AddMethod(__Method_GetProductByName, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Warehouse1.Server.ProductName, global::Warehouse1.Server.Product>(serviceImpl.GetProductByName));
      serviceBinder.AddMethod(__Method_AddProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Warehouse1.Server.Product, global::Warehouse1.Server.ProductID>(serviceImpl.AddProduct));
      serviceBinder.AddMethod(__Method_UpdateProduct, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Warehouse1.Server.Product, global::Warehouse1.Server.Product>(serviceImpl.UpdateProduct));
    }

  }
}
#endregion

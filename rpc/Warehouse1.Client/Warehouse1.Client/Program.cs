using Warehouse1.Client;


var clientWrapper = new WarehouseClientWrapper("https://localhost:7026");

while (true)
{
    Console.WriteLine("Seleccione una opción:");
    Console.WriteLine("1. Ingresar nuevo producto");
    Console.WriteLine("2. Consultar producto");
    Console.WriteLine("3. Modificar producto");
    Console.WriteLine("4. Salir");
    string option = Console.ReadLine();
    switch (option)
    {
        case "1":
            Console.WriteLine("\nIngrese los detalles del nuevo producto:");
            Console.Write("ID: ");
            string productId = Console.ReadLine();
            Console.Write("Nombre: ");
            string productName = Console.ReadLine();
            Console.Write("Cantidad: ");
            int quantity = int.Parse(Console.ReadLine());
            var newProductID = await clientWrapper.AddProductsAsnyc(productId, productName, quantity);
            if (!string.IsNullOrEmpty(newProductID))
            {
                Console.WriteLine($"Nuevo producto agregado con el ID: {newProductID}");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error y el producto no fue agregado");
            }
            break;

        case "2":
            Console.Write("\nIngrese el ID del producto a consultar: ");
            string productIdToSearch = Console.ReadLine();

            var searchedProduct = await clientWrapper.GetProductByIdAsync(productIdToSearch);
            if (searchedProduct != null)
            {
                Console.WriteLine($"Producto encontrado: {searchedProduct.Name}, Cantidad: {searchedProduct.Quantity}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado o ha ocurrido un error");
            }
            break;

        case "3":
            Console.Write("\nIngrese el ID del producto a modificar: ");
            string productIdToModify = Console.ReadLine();

            var existingProduct = await clientWrapper.GetProductByIdAsync(productIdToModify);
            if (existingProduct != null)
            {
                Console.WriteLine($"Producto encontrado: {existingProduct.Name}, Cantidad: {existingProduct.Quantity}");

                Console.WriteLine("\nIngrese los nuevos detalles del producto:");
                Console.Write("Nuevo Nombre: ");
                string newProductName = Console.ReadLine();
                Console.Write("Nueva Cantidad: ");
                int newQuantity = int.Parse(Console.ReadLine());

                // Llamada para modificar el producto existente
                bool success = await clientWrapper.UpdateProductAsync(productIdToModify, newProductName, newQuantity);

                if (success)
                {
                    Console.WriteLine($"Producto modificado con éxito");
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error y el producto no fue modificado");
                }
            }
            else
            {
                Console.WriteLine("Producto no encontrado. No se puede modificar.");
            }
            break;

        case "4":
            Console.WriteLine("Saliendo del programa...");
            return;

        default:
            Console.WriteLine("Opción no válida. Intente de nuevo.");
            break;
    }
}


import Interface.ProductServer;

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import Class.ImplProductServer;
import Class.ImplProduct;

import javax.swing.*;

public class ServerMain {
    public static void main(String[] args) {
        try {
                ImplProduct Product = new ImplProduct();
                Registry registry = LocateRegistry.createRegistry(8000);
                registry.rebind("Product", Product);
                System.out.println("Server iniciado en el puerto 8000 ......");
                JOptionPane.showMessageDialog(null, "Server iniciado en el puerto 8000");

        }catch (Exception e){
            JOptionPane.showMessageDialog(null, "Falla al iniciar el servidor");
            e.printStackTrace();
        }
    }
}
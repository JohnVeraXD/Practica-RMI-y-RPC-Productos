import Interface.Product;
import Interface.ProductServer;

import javax.swing.*;
import java.rmi.Naming;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

public class ClientMain {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        try {
            Registry registry = LocateRegistry.getRegistry("localhost", 8000);
            Product product = (Product) registry.lookup("Product");

            while (true) {
                String menu = JOptionPane.showInputDialog("RMI Crud de Productos \n Ingresa los comandos \n"
                        + "Ingresa lis --> Listar \n"
                        + "Ingresa cre --> Crear \n"
                        + "Ingresa eli --> Eliminar \n"
                        + "Ingresa mod --> Actualizar \n");
                switch (menu) {
                    case "lis": {
                        Op1();
                        break;
                    }
                    case "cre": {
                        Op2();
                        break;
                    }
                    case "eli": {
                        Op3();
                        break;
                    }
                    case "mod": {
                        Op4();
                        break;
                    }
                }
            }


        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, "El servidor no esta activo");
            System.out.println("Servidor no conectado" + e);
            e.printStackTrace();
        }
    }

    //metodos para los casos
    //lis
    public static void Op1() {

        try {
            Registry registry = LocateRegistry.getRegistry("localhost", 8000);
            Product product = (Product) registry.lookup("Product");
            List<Map<String, Object>> Resultado = product.consulta();
            JOptionPane.showMessageDialog(null, "Mira los resultados en la consola");

            //recorrer la lista para ver los resultados por consola
            for (Map<String, Object> fila : Resultado) {
                System.out.println("------------------------------------------");

                for (Map.Entry<String, Object> entry : fila.entrySet()) {
                    String nombreColumna = entry.getKey();
                    Object valorColumna = entry.getValue();
                    System.out.println(nombreColumna + ": " + valorColumna);
                }
            }

        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, "Levanta primero el server");
            System.out.println("Servidor no conectado" + e);
        }
    }
    //cre
    public static void Op2(){
        try {
            Registry registry = LocateRegistry.getRegistry("localhost", 8000);
            Product product = (Product) registry.lookup("Product");
            String nombre =  JOptionPane.showInputDialog("Nombre");
            String descripcion =  JOptionPane.showInputDialog("Descripcion");
            String tipo =  JOptionPane.showInputDialog("Tipo");
            Integer cantidad = Integer.valueOf(JOptionPane.showInputDialog("Cantidad"));
            Double price = Double.valueOf(JOptionPane.showInputDialog("Precio"));
            product.insertarDatos(nombre, descripcion, tipo, cantidad,price);
            Op1();
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, "Levanta primero el server");
            System.out.println("Servidor no conectado" + e);
        }
    }
    //eli
    public static void Op3(){
        try {
            Registry registry = LocateRegistry.getRegistry("localhost", 8000);
            Product product = (Product) registry.lookup("Product");
            int id_producto = Integer.parseInt(JOptionPane.showInputDialog("ID del producto a eliminar"));
            product.eliminar(id_producto);
            Op1();
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, "Levanta primero el server");
            System.out.println("Servidor no conectado" + e);
        }
    }
    //mod
    public static void Op4(){
        try {
            Registry registry = LocateRegistry.getRegistry("localhost", 8000);
            Product product = (Product) registry.lookup("Product");
            int id_producto = Integer.parseInt(JOptionPane.showInputDialog("ID del producto a actualizar"));
            String nombre =  JOptionPane.showInputDialog("Nombre");
            String descripcion =  JOptionPane.showInputDialog("Descripcion");
            String tipo =  JOptionPane.showInputDialog("Tipo");
            Integer cantidad = Integer.valueOf(JOptionPane.showInputDialog("Cantidad"));
            Double price = Double.valueOf(JOptionPane.showInputDialog("Precio"));
            product.actualizar(id_producto,nombre, descripcion, tipo, cantidad,price);
            Op1();
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, "Levanta primero el server");
            System.out.println("Servidor no conectado" + e);
        }
    }
}
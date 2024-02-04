package Class;

import Interface.Product;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.sql.*;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.logging.Level;
import java.util.logging.Logger;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ImplProduct extends UnicastRemoteObject implements Product {

    private String name;
    private String description;
    private String tipo;
    private Integer cantidad;
    private double price;



    public ImplProduct(String name, String description, String tipo, Integer cantidad, Double price) throws RemoteException {
        this.name = name;
        this.description = description;
        this.tipo = tipo;
        this.cantidad = cantidad;
        this.price = price;
    }

    public ImplProduct() throws RemoteException  {
    }


    @Override
    public String getName() throws RemoteException {
        return name;
    }
    @Override
    public String getDescription() throws RemoteException {
        return description;
    }
    @Override
    public double getPrice() throws RemoteException {
        return price;
    }
    @Override
    public String getTipo() throws RemoteException {
        return tipo;
    }
    @Override
    public Integer getCantidad() throws RemoteException {
        return cantidad;
    }

    @Override
    // lista de producto a la BD
    public List<Map<String, Object>> consulta() throws RemoteException {
        List<Map<String, Object>> listaResultados = new ArrayList<>();

        // Abrir la conexión a la BD
        String cadenaConexion = String.format("jdbc:postgresql://localhost:%s/%s", 5432, "Productos_RMI");
        String query = "select id_producto ,nombre ,descripcion ,tipo ,cantidad ,precio  from productos";

        try {
            Connection conexion = DriverManager.getConnection(cadenaConexion, "postgres", "12345");
            Statement stmt = conexion.createStatement();
            ResultSet rs = stmt.executeQuery(query);
            ResultSetMetaData metaData = rs.getMetaData();
            int columnCount = metaData.getColumnCount();
            while (rs.next()) {
                Map<String, Object> fila = new HashMap<>();
                for (int i = 1; i <= columnCount; i++) {
                    String columnName = metaData.getColumnName(i);
                    Object value = rs.getObject(i);
                    fila.put(columnName, value);
                }
                listaResultados.add(fila);
            }
        } catch (SQLException ex) {
            Logger.getLogger(ImplProduct.class.getName()).log(Level.SEVERE, null, ex);
        }
        return listaResultados;
    }

    //para registrar
    @Override
    public void insertarDatos(String nombre, String descripcion, String tipo, Integer cantidad, Double price) throws RemoteException {
        // Abrir la conexión a la BD
        String cadenaConexion = String.format("jdbc:postgresql://localhost:%s/%s", 5432, "Productos_RMI");

        try {
            Connection conexion = DriverManager.getConnection(cadenaConexion, "postgres", "12345");
            conexion.setAutoCommit(false);
            // Llamada al procedimiento almacenado de inserción
            String procedimientoInsercion = "CALL insertar_producto(?,?,?,?,?)";
            try (CallableStatement cs = conexion.prepareCall(procedimientoInsercion)) {
                // Configuración de parámetros para el procedimiento almacenado de inserción
                cs.setString(1, nombre);
                cs.setString(2, descripcion);
                cs.setString(3,tipo);
                cs.setInt(4, cantidad);
                cs.setDouble(5, price);
                // Ejecución del procedimiento almacenado de inserción
                cs.execute();
                conexion.commit();
            }
        } catch (SQLException ex) {
            Logger.getLogger(ImplProduct.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    //metodo para eliminar
    @Override
    public void eliminar(int id_producto) throws RemoteException {
        // Abrir la conexión a la BD
        String cadenaConexion = String.format("jdbc:postgresql://localhost:%s/%s", 5432, "Productos_RMI");

        try {
            Connection conexion = DriverManager.getConnection(cadenaConexion, "postgres", "12345");
            conexion.setAutoCommit(false);
            // Llamada al procedimiento almacenado de inserción
            String procedimientoInsercion = "CALL eliminar_producto(?)";
            try (CallableStatement cs = conexion.prepareCall(procedimientoInsercion)) {
                // Configuración de parámetros para el procedimiento almacenado de eliminar
                cs.setInt(1, id_producto);
                // Ejecución del procedimiento almacenado de delete
                cs.execute();
                conexion.commit();
            }
        } catch (SQLException ex) {
            Logger.getLogger(ImplProduct.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    //metodo para actualizar
    @Override
    public void actualizar(int id_producto, String nombre, String descripcion, String tipo, Integer cantidad, Double price) throws RemoteException {
        // Abrir la conexión a la BD
        String cadenaConexion = String.format("jdbc:postgresql://localhost:%s/%s", 5432, "Productos_RMI");

        try {
            Connection conexion = DriverManager.getConnection(cadenaConexion, "postgres", "12345");
            conexion.setAutoCommit(false);
            // Llamada al procedimiento almacenado de inserción
            String procedimientoInsercion = "CALL modificar_producto(?,?,?,?,?,?)";
            try (CallableStatement cs = conexion.prepareCall(procedimientoInsercion)) {
                // Configuración de parámetros para el procedimiento almacenado de inserción
                cs.setInt(1, id_producto);
                cs.setString(2, nombre);
                cs.setString(3, descripcion);
                cs.setString(4,tipo);
                cs.setInt(5, cantidad);
                cs.setDouble(6, price);
                // Ejecución del procedimiento almacenado de inserción
                cs.execute();
                conexion.commit();
            }
        } catch (SQLException ex) {
            Logger.getLogger(ImplProduct.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
}

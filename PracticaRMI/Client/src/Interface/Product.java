package Interface;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;
import java.util.Map;

public interface Product extends Remote {
    String getName() throws RemoteException;
    String getDescription() throws RemoteException;
    double getPrice() throws RemoteException;

    String getTipo() throws RemoteException;

    Integer getCantidad() throws RemoteException;

    // lista de producto a la BD
    List<Map<String, Object>> consulta() throws RemoteException;

    //para registrar
    void insertarDatos(String nombre, String descripcion, String tipo, Integer cantidad, Double price) throws RemoteException;

    //metodo para eliminar
    void eliminar(int id_persona) throws RemoteException;

    //metodo para actualizar
    void actualizar(int id_producto, String nombre, String descripcion, String tipo, Integer cantidad, Double price) throws RemoteException;
}

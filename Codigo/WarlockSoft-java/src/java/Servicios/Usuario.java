
package Servicios;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;

/**
 *
 * @author Eddy
 */
@WebService(serviceName = "Usuario")
public class Usuario {

    @WebMethod(operationName = "validarUsuario")
    public boolean validarUsuario(@WebParam(name = "nickname") String nickname,
                                  @WebParam(name = "password") String password) {
        Conexion conexion = new Conexion();
        try {
            return conexion.validarUsuario(nickname, password);
        } catch (SQLException ex) {
            System.err.println("Error en el servicio");
            System.err.println(ex.getMessage());
            System.err.println(ex.getLocalizedMessage());
            return false;
        }
    }
    
    @WebMethod(operationName="agregarUsuario")
    public boolean agregarUsuario(@WebParam(name = "nombre") String nombre,
                                  @WebParam(name = "correo") String correo,
                                  @WebParam(name = "dia") int dia,
                                  @WebParam(name = "mes") int mes,
                                  @WebParam(name = "ano") int ano,
                                  @WebParam(name = "password") String password,
                                  @WebParam(name = "nickname") String nickname){
    
    Conexion conexion = new Conexion();
        try {
            return conexion.registrarUsuario(nombre, correo, dia, mes, ano, password, nickname);
        } catch (SQLException ex) {
            System.err.println("Error en el servicio");
            System.err.println(ex.getMessage());
            System.err.println(ex.getMessage());
            return false;
        }
    }
    
    @WebMethod(operationName="obtenerUsuario")
    public String[] obtenerUsuario(@WebParam(name="id_usuario") int id_usuario){
        Conexion con = new Conexion();
        try {
            return con.obtenerUsuario(id_usuario);
        } catch (SQLException ex) {
            Logger.getLogger(Usuario.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
    
    @WebMethod(operationName="obtenerDatosUsuario")
    public String[] obtenerDatosUsuario(@WebParam(name="nickname") String nickname,
                                   @WebParam(name="password") String password){
        Conexion con = new Conexion();
        try {
            return con.obtenerUsuario(nickname, password);
        } catch (SQLException ex) {
            Logger.getLogger(Usuario.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }
}

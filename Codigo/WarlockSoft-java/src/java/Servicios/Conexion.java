
package Servicios;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
public class Conexion {

    public Connection conectar() {
        try {
            Class.forName("org.mariadb.jdbc.Driver");
            Connection conexion = DriverManager.getConnection("jdbc:mysql://localhost/warlocksoft?user=root&password=12326");
            return conexion;
        } catch (ClassNotFoundException | SQLException e) {
             System.err.println("Lo siento... algo ha fallado");
            System.err.println(e.getMessage());
            System.err.println(e.getLocalizedMessage());
            return null;
        }
    }

    public boolean validarUsuario(String nickname, String password) throws SQLException {
        String consulta = "SELECT nickname, password FROM usuario "
                + "WHERE nickname = ? AND  password = ?";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setString(1, nickname);
            sentencia.setString(2, password);
            ResultSet tabla = sentencia.executeQuery();
            conexion.close();
            return tabla.next();
        } catch (SQLException ex) {
            System.err.println("Lo siento... algo ha fallado");
            System.err.println(ex.getMessage());
            System.err.println(ex.getLocalizedMessage());
            return false;
        } finally {
            if (null != conexion) {
                conexion.close();
            }
            if (null != sentencia) {
                sentencia.close();
            }
        }
    }
    
    public boolean registrarUsuario(String nombre, String correo, int dia, int mes, int ano, String password, String nickname) throws SQLException{
        String consulta = "INSERT INTO Usuario VALUES(null,?,?,?,?,?)";
        PreparedStatement sentencia = null;
        Connection conexion = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setString(1, nombre);
            sentencia.setString(2, correo);
            sentencia.setDate(3, new Date(ano, mes, dia));
            sentencia.setString(4, password);
            sentencia.setString(5, nickname);
            sentencia.executeUpdate();
            sentencia.close();
            return true;
        } catch (SQLException e) {
            System.err.println("Lo siento... algo fallo");
            System.err.println(e.getMessage());
            System.err.println(e.getLocalizedMessage());
            return false;
        } finally {
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public boolean agregarConcimientoNecesario(String[] conocimientos, int id_tarea) throws SQLException {
        for (String conocimiento : conocimientos) {
            String consulta = "INSERT INTO ConocimientoNecesario (id_conocimiento, id_tarea) "
                    + "SELECT C.id_conocimiento, T.id_tarea FROM Tarea T, Conocimiento C "
                    + "WHERE T.id_tarea = ? AND C.nombre = ?";
            Connection conexion = null;
            PreparedStatement sentencia = null;
            try {
                conexion = conectar();
                sentencia = conexion.prepareStatement(consulta);
                sentencia.setInt(1, id_tarea);
                sentencia.setString(2, conocimiento);
                sentencia.executeUpdate();
                conexion.close();
            } catch (SQLException e) {
                System.err.println("Lo siento... algo ha fallado");
                System.err.println(e.getMessage());
                System.err.println(e.getLocalizedMessage());
                return false;
            } finally {
                if(conexion != null){
                    conexion.close();
                }
                if(sentencia != null){
                    sentencia.close();
                }
            }
        }
        return true;
    }

    public boolean agregarTarea(String nombre, String descripcion, int diaIni, int mesIni, int anoIni, double precio, int tiempoEstimado, int cantMax, String estado, int id_usuario, String[] conocimientos) throws SQLException {
        String consulta = "INSERT INTO Tarea VALUES (null,?,?,?,?,?,?,?,?)";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            //Guardar datos en la tabla Tarea
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setString(1, nombre);
            sentencia.setString(2, descripcion);
            sentencia.setDate(3, new Date(anoIni, mesIni, diaIni));
            sentencia.setDouble(4, precio);
            sentencia.setInt(5, tiempoEstimado);
            sentencia.setInt(6, cantMax);
            sentencia.setString(7, estado);
            sentencia.setInt(8, id_usuario);
            sentencia.executeUpdate();
            conexion.close();
            //Guardar datos en la tabla conocimientoNecesario
            consulta = "SELECT Max(id_tarea) FROM Tarea";
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            ResultSet id_tarea = sentencia.executeQuery();
            conexion.close();
            if(id_tarea.next()){
                agregarConcimientoNecesario(conocimientos, id_tarea.getInt(1));
            }
            return true;
        } catch (SQLException ex) {
            System.err.println("Lo siento... algo ha fallado");
            System.err.println(ex.getMessage());
            System.err.println(ex.getLocalizedMessage());
            return false;
        } finally {
            if (conexion != null) {
                conexion.close();
            }
            if (sentencia != null) {
                sentencia.close();
            }
        }
    }
    
    public boolean agregarProyecto(String nombre, int diaIni, int mesIni, int anoIni, int diaFin, int mesFin, int anoFin, String estado, double salario, String modoPago, int id_usuario) throws SQLException{
        String consulta = "INSERT INTO Proyecto VALUES (null,?,?,?,?,?,?,?)";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            //Guardar los datos en 'proyecto'
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setString(1, nombre);
            sentencia.setDate(2, new Date(anoIni, mesIni, diaIni));
            sentencia.setDate(3, new Date(anoFin, mesFin, diaFin));
            sentencia.setString(4, estado);
            sentencia.setDouble(5, salario);
            sentencia.setString(6, modoPago);
            sentencia.setInt(7, id_usuario);
            sentencia.executeUpdate();
            sentencia.close();
            return true;
        } catch (SQLException ex) {
            System.err.println("Lo siento... algo ha fallado");
            System.err.println(ex.getMessage());
            System.err.println(ex.getLocalizedMessage());
            return false;
        } finally {
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public boolean agregarTareaAlProyecto(int id_proyecto) throws  SQLException{
        //Obtener el id de la ultima tareas ingresadas
        String consulta = "SELECT Max(id_tarea) FROM Tarea";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            ResultSet rs = sentencia.executeQuery();
            conexion.close();
            if(rs.next()){
                //Guardar la tarea dentro del proyecto
                consulta = "INSERT INTO TareasPorProyecto "
                         + "VALUES (null,?,?)";
                conexion = conectar();
                sentencia = conexion.prepareStatement(consulta);
                sentencia.setInt(1, rs.getInt(1));
                sentencia.setInt(2, id_proyecto);
                sentencia.executeUpdate();
                conexion.close();
            }
            return true;
        } catch (SQLException ex) {
            System.err.println("Lo siento... algo ha fallado");
            System.err.println(ex.getMessage());
            System.err.println(ex.getLocalizedMessage());
            return false;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerConocimientos() throws SQLException{
        String consulta = "SELECT nombre FROM Conocimiento";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            ResultSet rs = sentencia.executeQuery();
            ArrayList<String> conocimientos = new ArrayList();
            while(rs.next()){
                conocimientos.add(rs.getString(1));
            }
            conexion.close();
            return conocimientos.toArray(new String[conocimientos.size()]);
        } catch (SQLException ex) {
            Logger.getLogger(Conexion.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        } finally{
            if(conexion!= null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerTareasPorProyecto(int id_proyecto) throws SQLException{
        String consulta = "SELECT t.id_tarea, t.nombre  FROM Tarea t, TareasPorProyecto tpp "
                        + "WHERE tpp.id_tarea = t.id_tarea "
                        + "AND tpp.id_proyecto = ? ";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setInt(1, id_proyecto);
            ResultSet rs = sentencia.executeQuery();
            ArrayList<String> temp = new ArrayList();
            while(rs.next()){
                int id_tarea = rs.getInt(1);
                String nombre = rs.getString(2);
                String tarea = Integer.toString(id_tarea)+";"+ nombre;
                temp.add(tarea);
            }
            conexion.close();
            return temp.toArray(new String[temp.size()]);
        } catch (SQLException ex) {
            Logger.getLogger(Conexion.class.getName()).log(Level.SEVERE, null, ex);
            return null;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerTareasIndividuales() throws SQLException{
        String consulta = "SELECT T.* FROM Tarea T "
                        + "WHERE T.estado = 'Activa' "
                        + "AND T.id_tarea NOT IN "
                        + "(SELECT id_tarea FROM TareasPorProyecto)";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            ArrayList<String> array = new ArrayList();
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            ResultSet rs = sentencia.executeQuery();
            while(rs.next()){
                String id_tarea = Integer.toString(rs.getInt(1));
                String nombre = rs.getString(2);
                String descripcion = rs.getString(3);
                String fecha_ini = rs.getDate(4).toString();
                String precio = Double.toString(rs.getDouble(5));
                String tiempoEstimado = Integer.toString(rs.getInt(6));
                String cantParticipantes = Integer.toString(rs.getInt(7));
                String estado = rs.getString(8);
                String id_usuario = Integer.toString(rs.getInt(9));
                String t = id_tarea+";"+nombre+";"+descripcion+";"+fecha_ini+";"+precio+";"+tiempoEstimado+";"+cantParticipantes+";"+estado+";"+id_usuario;
                array.add(t);
            }
            conexion.close();
            return array.toArray(new String[array.size()]);
        } catch (SQLException e) {
            System.out.println(e.getMessage());
            System.out.println(e.getLocalizedMessage());
            return null;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerProyectos() throws SQLException{
        String consulta= "SELECT * FROM PROYECTO WHERE estado = 'Activo'";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            ArrayList<String> array = new ArrayList();
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            ResultSet rs = sentencia.executeQuery();
            while(rs.next()){
                String id_proyecto = Integer.toString(rs.getInt(1));
                String nombre = rs.getString(2);
                String fecha_ini = rs.getDate(3).toString();
                String fecha_fin = rs.getDate(4).toString();
                String estado = rs.getString(5);
                String salario = Double.toString(rs.getDouble(6));
                String modoPago = rs.getString(7);
                String id_usuario = Integer.toString(rs.getInt(8));
                String t = id_proyecto+";"+nombre+";"+fecha_ini+";"+fecha_fin+";"+estado+";"+salario+";"+modoPago+";"+id_usuario;
                array.add(t);
            }
            conexion.close();
            return array.toArray(new String[array.size()]);
        } catch (SQLException e) {
            System.err.println(e.getMessage());
            System.err.println(e.getLocalizedMessage());
            return null;
        }finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerConocimientos(int id_usuario) throws SQLException{
        String consulta = "select h.nombre, c.nombre " +
                          "from usuario u, conocimiento c, habilidad h, conocimientosporusuario cpp " +
                          "where u.id_usuario = cpp.id_usuario " +
                          "and c.id_conocimiento = cpp.id_conocimiento " +
                          "and h.id_habilidad = c.id_habilidad "+
                          "and u.id_usuario = ? "+
                          "order by h.nombre";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setInt(1, id_usuario);
            ResultSet rs = sentencia.executeQuery();
            ArrayList<String> hab_con= new ArrayList();
            if(rs.next()){
                String habilidad = rs.getString(1);
                String temp = habilidad;
                do {                    
                    if(habilidad.equals(rs.getString(1))){
                        //La misma habilidad que la iteracion anterior
                        temp += ";"+rs.getString(2);
                    } else {
                        //Cambio la habilidad de la iteracion anterior
                        hab_con.add(temp);
                        temp = rs.getString(1);
                    }
                    habilidad = rs.getString(1);
                } while (rs.next());
                hab_con.add(temp);
            }
            conexion.close();
            return hab_con.toArray(new String[hab_con.size()]);
        } catch (SQLException e) {
            System.err.println(e.getMessage());
            System.err.println(e.getLocalizedMessage());
            return null;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerUsuario(int id_usuario) throws SQLException{
        String consulta = "SELECT * FROM Usuario WHERE id_usuario = ?";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setInt(1,id_usuario);
            ResultSet rs = sentencia.executeQuery();
            String[] usuario = new String[6];
            if(rs.next()){
                usuario[0] = Integer.toString(rs.getInt(1));
                usuario[1] = rs.getString(2);
                usuario[2] = rs.getString(3);
                usuario[3] = rs.getDate(4).toString();
                usuario[4] = rs.getString(5);
                usuario[5] = rs.getString(6);
            }
            conexion.close();
            return usuario;
        } catch (SQLException e) {
            System.err.println(e.getMessage());
            System.err.println(e.getLocalizedMessage());
            return null;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerUsuario(String nick, String pass) throws SQLException{
        String consulta = "SELECT * FROM Usuario WHERE nickname = ? AND password = ?";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setString(1,nick);
            sentencia.setString(2,pass);
            ResultSet rs = sentencia.executeQuery();
            String[] usuario = new String[6];
            if(rs.next()){
                usuario[0] = Integer.toString(rs.getInt(1));
                usuario[1] = rs.getString(2);
                usuario[2] = rs.getString(3);
                usuario[3] = rs.getDate(4).toString();
                usuario[4] = rs.getString(5);
                usuario[5] = rs.getString(6);
            }
            conexion.close();
            return usuario;
        } catch (SQLException e) {
            System.err.println(e.getMessage());
            System.err.println(e.getLocalizedMessage());
            return null;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerMisTareasIndividuales(int id_usuario) throws SQLException{
        String consulta = "SELECT T.* FROM Tarea T "
                        + "WHERE T.id_usuario = ? "
                        + "AND T.id_tarea NOT IN "
                        + "(SELECT tpp.id_tarea FROM tareasporproyecto tpp)";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            ArrayList<String> array = new ArrayList();
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setInt(1,id_usuario);
            ResultSet rs = sentencia.executeQuery();
            while(rs.next()){
                String id_tarea = Integer.toString(rs.getInt(1));
                String nombre = rs.getString(2);
                String descripcion = rs.getString(3);
                String fecha_ini = rs.getDate(4).toString();
                String precio = Double.toString(rs.getDouble(5));
                String tiempoEstimado = Integer.toString(rs.getInt(6));
                String cantParticipantes = Integer.toString(rs.getInt(7));
                String estado = rs.getString(8);
                String id_user = Integer.toString(rs.getInt(9));
                String t = id_tarea+";"+nombre+";"+descripcion+";"+fecha_ini+";"+precio+";"+tiempoEstimado+";"+cantParticipantes+";"+estado+";"+id_user;
                array.add(t);
            }
            conexion.close();
            return array.toArray(new String[array.size()]);
        } catch (SQLException e) {
            System.out.println(e.getMessage());
            System.out.println(e.getLocalizedMessage());
            return null;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerMisProyectos(int id_usuario) throws SQLException{
        String consulta= "SELECT * FROM PROYECTO WHERE id_usuario = ?";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            ArrayList<String> array = new ArrayList();
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setInt(1,id_usuario);
            ResultSet rs = sentencia.executeQuery();
            while(rs.next()){
                String id_proyecto = Integer.toString(rs.getInt(1));
                String nombre = rs.getString(2);
                String fecha_ini = rs.getDate(3).toString();
                String fecha_fin = rs.getDate(4).toString();
                String estado = rs.getString(5);
                String salario = Double.toString(rs.getDouble(6));
                String modoPago = rs.getString(7);
                String id_user = Integer.toString(rs.getInt(8));
                String t = id_proyecto+";"+nombre+";"+fecha_ini+";"+fecha_fin+";"+estado+";"+salario+";"+modoPago+";"+id_user;
                array.add(t);
            }
            conexion.close();
            return array.toArray(new String[array.size()]);
        } catch (SQLException e) {
            System.err.println(e.getMessage());
            System.err.println(e.getLocalizedMessage());
            return null;
        }finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerProyecto(int id_proyecto) throws SQLException{
        String consulta = "SELECT * FROM proyecto WHERE id_proyecto = ?";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setInt(1,id_proyecto);
            ResultSet rs = sentencia.executeQuery();
            String[] p = new String[8];
            if(rs.next()){
                String id_proyect = Integer.toString(rs.getInt(1));
                String nombre = rs.getString(2);
                String fecha_ini = rs.getDate(3).toString();
                String fecha_fin = rs.getDate(4).toString();
                String estado = rs.getString(5);
                String salario = Double.toString(rs.getDouble(6));
                String modoPago = rs.getString(7);
                String id_user = Integer.toString(rs.getInt(8));
                p[0] = id_proyect;
                p[1] = nombre;
                p[2] = fecha_ini;
                p[3] = fecha_fin;
                p[4] = estado;
                p[5] = salario;
                p[6] = modoPago;
                p[7] = id_user;                
            }
            conexion.close();
            return p;
        } catch (SQLException e) {
            return null;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public String[] obtenerTarea(int id_tarea) throws SQLException{
        String consulta = "SELECT * FROM Tarea WHERE id_tarea = ?";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setInt(1,id_tarea);
            ResultSet rs = sentencia.executeQuery();
            String[] p = new String[9];
            if(rs.next()){
                String id_t = Integer.toString(rs.getInt(1));
                String nombre = rs.getString(2);
                String descripcion= rs.getString(3);
                String fecha_ini = rs.getDate(4).toString();
                String precio = Double.toString(rs.getDouble(5));
                String tiempoEstimado = Integer.toString(rs.getInt(6));
                String cantParti = Integer.toString(rs.getInt(7));
                String estado = rs.getString(8);
                String id_user = Integer.toString(rs.getInt(9));
                p[0] = id_t;
                p[1] = nombre;
                p[2] = descripcion;
                p[3] = fecha_ini;
                p[4] = precio;
                p[5] = tiempoEstimado;
                p[6] = cantParti;
                p[7] = estado; 
                p[8] = id_user;
            }
            conexion.close();
            return p;
        } catch (SQLException e) {
            return null;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public boolean cambiarEstadoProyecto(int id_proyecto, String estado) throws SQLException{
        String consulta = "UPDATE Proyecto SET estado = _ WHERE id_proyecto = ?";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setString(1, estado);
            sentencia.setInt(2, id_proyecto);
            sentencia.executeUpdate();
            conexion.close();
            return true;
        }catch(SQLException e){
            return false;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
     
    public boolean cambiarEstadoTarea(int id_tarea, String estado) throws SQLException{
        String consulta = "UPDATE Tarea SET estado = ? WHERE id_tarea = ?";
        Connection conexion = null;
        PreparedStatement sentencia = null;
        try {
            conexion = conectar();
            sentencia = conexion.prepareStatement(consulta);
            sentencia.setString(1, estado);
            sentencia.setInt(2, id_tarea);
            sentencia.executeUpdate();
            conexion.close();
            return true;
        }catch(SQLException e){
            return false;
        } finally{
            if(conexion != null){
                conexion.close();
            }
            if(sentencia != null){
                sentencia.close();
            }
        }
    }
    
    public static void main(String args[]){
        Conexion c = new Conexion();
        try {
            String[] v = c.obtenerMisTareasIndividuales(1);
            for (int i = 0; i < v.length; i++) {
                System.out.println(v[i]);
            }
        } catch (SQLException ex) {
            Logger.getLogger(Conexion.class.getName()).log(Level.SEVERE, null, ex);
        }
        
    }
}

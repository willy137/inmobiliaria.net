namespace mvc.Models;
using MySql.Data.MySqlClient;


public class RepositorioUsuario : RepositorioBase,IRepositorioUsuario{

    public RepositorioUsuario(IConfiguration configuracion):base(configuracion){
        
    }

    public IList<Usuario> GetObtenerTodos(){
        List<Usuario> users= new List<Usuario>();
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            var query= @"SELECT UsuarioId, nombre, apellido, Password, Correo, rol, Avatar FROM usuario";
            using(var command= new MySqlCommand(query,connetion))
            {
                connetion.Open();
                using (var reader= command.ExecuteReader())
                {
                    while(reader.Read()){
                        Usuario usuario = new Usuario
                        {
                            UsuarioId=reader.GetInt32(nameof(Usuario.UsuarioId)),
                            Nombre=reader.GetString(nameof(Usuario.Nombre)),
                            Apellido=reader.GetString(nameof(Usuario.Apellido)),
                            Password=reader.GetString(nameof(Usuario.Password)),
                            Correo=reader.GetString(nameof(Usuario.Correo)),
                            Rol=reader.GetInt32(nameof(Usuario.Rol)),
                            Avatar=reader.GetString(nameof(Usuario.Avatar))
                        };
                        users.Add(usuario);
                    }
                }
            }
            connetion.Close();
        }
        return users;
    }

    public int Create(Usuario user){
        int result;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"INSERT INTO usuario(Nombre, Apellido, Password, Correo, Rol, Avatar) 
            VALUES (@nom,@apell,@contrase,@correo,@rol,@avatar);
            SELECT LAST_INSERT_ID();";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@nom",user.Nombre);
                command.Parameters.AddWithValue("@apell",user.Apellido);
                command.Parameters.AddWithValue("@contrase",user.Password);
                command.Parameters.AddWithValue("@correo",user.Correo);
                command.Parameters.AddWithValue("@rol",user.Rol);
                command.Parameters.AddWithValue("@avatar",user.Avatar);
                connetion.Open();
                result= Convert.ToInt32(command.ExecuteScalar());
                user.UsuarioId=result;
                connetion.Close();
            }
        }
        return result;
    }

    public int Edit(Usuario user){
        int result;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"UPDATE usuario
             SET Nombre=@nom ,Apellido=@apell,Password=@contrase,Correo=@correo,Rol=@rol,Avatar=@avatar WHERE UsuarioId=@id";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@nom",user.Nombre);
                command.Parameters.AddWithValue("@apell",user.Apellido);
                command.Parameters.AddWithValue("@contrase",user.Password);
                command.Parameters.AddWithValue("@correo",user.Correo);
                command.Parameters.AddWithValue("@rol",user.Rol);
                command.Parameters.AddWithValue("@avatar",user.Avatar);
                command.Parameters.AddWithValue("@id",user.UsuarioId);
                connetion.Open();
                result= Convert.ToInt32(command.ExecuteScalar());
                connetion.Close();
            }
        }
        return result;
    }
    public int Delete(int UsuarioId){
        int res=-1;
        using(MySqlConnection connection= new MySqlConnection(connectionString)){
            string query= @"DELETE FROM usuario WHERE UsuarioId = @id;";
            using(var command= new MySqlCommand(query,connection)){
                command.Parameters.AddWithValue("@id",UsuarioId);
                connection.Open();
                res= command.ExecuteNonQuery();
                connection.Close();
            }
        }
        return res;
    }
    public Usuario ObtenerCorreo(String correo){
        Usuario users= new Usuario();
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            var query= @"SELECT UsuarioId, nombre, apellido, Password, Correo, rol, Avatar FROM usuario WHERE Correo=@correo";
            using(var command= new MySqlCommand(query,connetion))
            {
                command.Parameters.AddWithValue("@correo",correo);
                connetion.Open();
                var reader= command.ExecuteReader();
                    if(reader.Read()){
                        users = new Usuario
                        {
                            UsuarioId=reader.GetInt32(nameof(Usuario.UsuarioId)),
                            Nombre=reader.GetString(nameof(Usuario.Nombre)),
                            Apellido=reader.GetString(nameof(Usuario.Apellido)),
                            Password=reader.GetString(nameof(Usuario.Password)),
                            Correo=reader.GetString(nameof(Usuario.Correo)),
                            Rol=reader.GetInt32(nameof(Usuario.Rol)),
                            Avatar=reader.GetString(nameof(Usuario.Avatar))
                        };
                    }
            }
            connetion.Close();
        }
        return users;
    }
      public Usuario Obtener(int id){
        Usuario user=new Usuario();
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"SELECT UsuarioId, nombre, apellido, Password, Correo, rol, Avatar FROM usuario WHERE UsuarioId=@id";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@id",id);
                connetion.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
					{
					    user = new Usuario
						{
							UsuarioId = reader.GetInt32(nameof(Usuario.UsuarioId) ),
							Nombre = reader.GetString(nameof(Usuario.Nombre) ),
							Apellido = reader.GetString(nameof(Usuario.Apellido) ),
                            Password=reader.GetString(nameof(Usuario.Password)),
							Correo = reader.GetString(nameof(Usuario.Correo) ),
							Avatar = reader.GetString(nameof(Usuario.Avatar) ),
							Rol = reader.GetInt32(nameof(Usuario.Rol) ),
						};
					}
                connetion.Close();
            }
        }
        return user;
    }
}
namespace mvc.Models;
using MySql.Data.MySqlClient;

public class RepositorioPropietario : Propietario
{
    string connectionString="Server=localhost;User=root;Password=;Database=inmo;SslMode=";

    public RepositorioPropietario(){

    }
    public List<Propietario> GetPropietario(){
        List<Propietario> propietarios= new List<Propietario>(){};
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            var query=@"SELECT PropId, nombre, apellido, direccion, telefono, dni FROM propietario";
            using(var command= new MySqlCommand(query,connetion))
            {
                connetion.Open();
                using (var reader= command.ExecuteReader())
                {
                    while(reader.Read()){
                        Propietario propietario = new Propietario
                        {
                            PropId=reader.GetInt32(nameof(Propietario.PropId)),//"Id"
                            Nombre=reader.GetString(nameof(Propietario.Nombre)),
                            Apellido=reader.GetString(nameof(Propietario.Apellido)),
                            Direccion=reader.GetString(nameof(Propietario.Direccion)),
                            Telefono=reader.GetString(nameof(Propietario.Telefono)),
                            Dni=reader.GetString(nameof(Propietario.Dni))
                        };
                        propietarios.Add(propietario);
                    }
                }
            }
            connetion.Close();
        }
        return propietarios;
    }

    public int Create(Propietario prop){
        int result;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"INSERT INTO propietario (nombre, apellido, direccion, telefono, dni) 
            VALUES ( @nombre,@apellido, @direccion,@telefono,@dni);
            SELECT LAST_INSERT_ID();";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@nombre",prop.Nombre);
                command.Parameters.AddWithValue("@apellido",prop.Apellido);
                command.Parameters.AddWithValue("@direccion",prop.Direccion);
                command.Parameters.AddWithValue("@telefono",prop.Telefono);
                command.Parameters.AddWithValue("@dni",prop.Dni);
                connetion.Open();
                result= Convert.ToInt32(command.ExecuteScalar());
                prop.PropId=result;
                connetion.Close();
            }
        }
        return result;
    }
     
    public int Edit(Propietario prop){
        int result;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"UPDATE propietario
             SET Nombre=@nombre ,Apellido=@apellido,Direccion=@direccion,Telefono=@telefono,Dni=@dni WHERE PropId=@id";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@nombre",prop.Nombre);
                command.Parameters.AddWithValue("@apellido",prop.Apellido);
                command.Parameters.AddWithValue("@direccion",prop.Direccion);
                command.Parameters.AddWithValue("@telefono",prop.Telefono);
                command.Parameters.AddWithValue("@dni",prop.Dni);
                command.Parameters.AddWithValue("@id",prop.PropId);
                connetion.Open();
                result= command.ExecuteNonQuery();
                connetion.Close();
            }
        }
        return result;
    }


    public Propietario Obtener(int id){
        Propietario prop=new Propietario();
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"SELECT PropId, nombre, apellido, direccion, telefono, dni FROM propietario WHERE PropId=@id";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@id",id);
                connetion.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
					{
					    prop = new Propietario
						{
							PropId = reader.GetInt32(nameof(Propietario.PropId) ),
							Nombre = reader.GetString("Nombre"),
							Apellido = reader.GetString("Apellido"),
							Direccion = reader.GetString("Direccion"),
							Telefono = reader.GetString("Telefono"),
							Dni = reader.GetString("Dni"),
						};
					}
                connetion.Close();
            }
        }
        return prop;
    }
    public List<Propietario> BuscarNom(String nombre){
        List<Propietario> props=new List<Propietario>();
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"SELECT PropId, nombre, apellido, direccion, telefono, dni FROM propietario WHERE Nombre=@nombre";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@nombre",nombre);
                connetion.Open();
                var reader = command.ExecuteReader();
                    while(reader.Read()){
                        Propietario propietario = new Propietario
                        {
                            PropId=reader.GetInt32(nameof(Propietario.PropId)),//"Id"
                            Nombre=reader.GetString(nameof(Propietario.Nombre)),
                            Apellido=reader.GetString(nameof(Propietario.Apellido)),
                            Direccion=reader.GetString(nameof(Propietario.Direccion)),
                            Telefono=reader.GetString(nameof(Propietario.Telefono)),
                            Dni=reader.GetString(nameof(Propietario.Dni))
                        };
                        props.Add(propietario);
                    }
                connetion.Close();
            }
        }
        return props;
    }
    public int Delete(int PropId){
        int res=-1;
        using(MySqlConnection connection= new MySqlConnection(connectionString)){
            string query= @"DELETE FROM propietario WHERE PropId = @id;";
            using(var command= new MySqlCommand(query,connection)){
                command.Parameters.AddWithValue("@id",PropId);
                connection.Open();
                res= command.ExecuteNonQuery();
                connection.Close();
            }
        }
        return res;
    }

}

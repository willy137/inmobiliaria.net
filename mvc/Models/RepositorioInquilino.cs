namespace mvc.Models;

using MySql.Data.MySqlClient;

public class RepositorioInquilino : Inquilino
{
    string connectionString="Server=localhost;User=root;Password=;Database=inmo;SslMode=";

    public RepositorioInquilino (){

    }
    public List<Inquilino> GetInquilino(){
        List<Inquilino> inquilinos= new List<Inquilino>(){};
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            var query=@"SELECT id_inqui, nombre, apellido, dni, domicilio,telefono FROM inquilino";
            using(var command= new MySqlCommand(query,connetion))
            {
                connetion.Open();
                using (var reader= command.ExecuteReader())
                {
                    while(reader.Read()){
                        Inquilino inquilino = new Inquilino
                        {
                            Id_inqui=reader.GetInt32(nameof(Inquilino.Id_inqui)),
                            Nombre=reader.GetString(nameof(Inquilino.Nombre)),
                            Apellido=reader.GetString(nameof(Inquilino.Apellido)),
                            Dni=reader.GetString(nameof(Inquilino.Dni)),
                            Domicilio=reader.GetString(nameof(Inquilino.Domicilio)),
                            Telefono=reader.GetString(nameof(Inquilino.Telefono)),

                        };
                        inquilinos.Add(inquilino);
                    }
                }
            }
            connetion.Close();
        }
        return inquilinos;
    }

    public Inquilino ObtenerInqui(int id){
        Inquilino inqui= new Inquilino();
            using (MySqlConnection connetion = new MySqlConnection(connectionString)){
                var query=@"SELECT id_inqui, nombre, apellido, dni, domicilio,telefono FROM inquilino WHERE id_inqui=@id;";
                using(var command= new MySqlCommand(query,connetion)){
                    command.Parameters.AddWithValue("@id",id);
                    connetion.Open();
                    var reader = command.ExecuteReader();
                    if(reader.Read()){
                        inqui =new Inquilino{
                        Id_inqui=reader.GetInt32(nameof(Inquilino.Id_inqui)),
                        Nombre = reader.GetString("Nombre"),
                        Apellido = reader.GetString("Apellido"),
                        Dni = reader.GetString("Dni"),
                        Domicilio = reader.GetString("Domicilio"),
                        Telefono = reader.GetString("Telefono"),
                        };
                    }
                    connetion.Close();
                }
            }
        return inqui;
    }

    public int Create(Inquilino inqui){
        int resul;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"INSERT INTO inquilino (nombre, apellido, dni, domicilio, telefono) 
            VALUES ( @nombre,@apellido,@dni, @domicilio,@telefono);
            SELECT LAST_INSERT_ID();";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@nombre",inqui.Nombre);
                command.Parameters.AddWithValue("@apellido",inqui.Apellido);
                command.Parameters.AddWithValue("@dni",inqui.Dni);
                command.Parameters.AddWithValue("@domicilio",inqui.Domicilio);
                command.Parameters.AddWithValue("@telefono",inqui.Telefono);
                connetion.Open();
                resul= Convert.ToInt32(command.ExecuteScalar());
                inqui.Id_inqui=resul;
                connetion.Close();
            }
        }
        return resul;
    } 

    public int EditI(Inquilino inqui){
        int resul=-1;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"UPDATE inquilino
             SET Nombre=@nombre ,Apellido=@apellido,Dni=@dni,Domicilio=@domicilio,Telefono=@telefono WHERE Id_inqui=@id";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@nombre",inqui.Nombre);
                command.Parameters.AddWithValue("@apellido",inqui.Apellido);
                command.Parameters.AddWithValue("@dni",inqui.Dni);
                command.Parameters.AddWithValue("@domicilio",inqui.Domicilio);
                command.Parameters.AddWithValue("@telefono",inqui.Telefono);
                command.Parameters.AddWithValue("@id",inqui.Id_inqui);
                connetion.Open();
                resul= command.ExecuteNonQuery();
                connetion.Close();
            }
        }
        return resul;
    }
    public int Delete(int id){
        int res=-1;
        using(MySqlConnection connection= new MySqlConnection(connectionString)){
            string query= @"DELETE FROM inquilino WHERE Id_inqui=@id;";
            using(var command= new MySqlCommand(query,connection)){
                command.Parameters.AddWithValue("@id",id);
                connection.Open();
                res= command.ExecuteNonQuery();
                connection.Close();
            }
        }
        return res;
    }

}
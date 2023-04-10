namespace mvc.Models;

using MySql.Data.MySqlClient;

public class RepositorioInmueble : Inmueble
{
    string connectionString="Server=localhost;User=root;Password=;Database=inmo;SslMode=";

    public RepositorioInmueble (){

    }
    public List<Inmueble> GetInmuebles(){
        List<Inmueble> inmuebles= new List<Inmueble>(){};
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            var query=@"SELECT InmuId, i.PropId, i.Direccion, UsoComercial, TipoLocal,CantidadAmbientes,Latitud,Longitud,Precio , p.Nombre,p.Apellido 
            FROM Inmueble i INNER JOIN Propietario p ON i.PropId=p.PropId";
            using(var command= new MySqlCommand(query,connetion))
            {
                connetion.Open();
                using (var reader= command.ExecuteReader())
                {
                    while(reader.Read()){
                        Inmueble inmueble = new Inmueble
                        {
                            InmuId=reader.GetInt32(nameof(Inmueble.InmuId)),
                            PropId=reader.GetString(nameof(Inmueble.PropId)),
                            Direccion=reader.GetString(nameof(Inmueble.Direccion)),
                            UsoComercial=reader.GetString(nameof(Inmueble.UsoComercial)),
                            TipoLocal=reader.GetString(nameof(Inmueble.TipoLocal)),
                            CantidadAmbientes=reader.GetInt32(nameof(Inmueble.CantidadAmbientes)),
                            Latitud=reader.GetInt32(nameof(Inmueble.Latitud)),
                            Longitud=reader.GetInt32(nameof(Inmueble.Longitud)),
                            Precio=reader.GetDecimal(nameof(Inmueble.Precio)),
                            Duenio=new Propietario{
                                PropId=reader.GetInt32(nameof(Inmueble.PropId)),
                                Nombre=reader.GetString(nameof(Propietario.Nombre)),
                                Apellido=reader.GetString(nameof(Propietario.Apellido))
                            }

                        };
                        inmuebles.Add(inmueble);
                    }
                }
            }
            connetion.Close();
        }
        return inmuebles;
    }
//            var query=@"SELECT InmuId, PropId, Direccion, UsoComercial, TipoLocal,CantidadAmbientes,Latitud,Longitud,Precio ,p.Nombre,p.Apellido 
            //FROM Inmueble i JOIN Propietario p ON i.PropId = P.PropId WHERE PropId=@idProp";
    public Inmueble ObtenerInmu(int id){
        Inmueble inmu= new Inmueble();
            using (MySqlConnection connetion = new MySqlConnection(connectionString)){
                var query=@"SELECT InmuId, i.PropId, i.Direccion, UsoComercial, TipoLocal,CantidadAmbientes,Latitud,Longitud,Precio , p.Nombre,p.Apellido 
                FROM Inmueble i INNER JOIN Propietario p ON i.PropId=p.PropId 
                WHERE i.InmuId=@id;";
                using(var command= new MySqlCommand(query,connetion)){
                    command.Parameters.AddWithValue("@id",id);
                    connetion.Open();
                    var reader = command.ExecuteReader();
                    if(reader.Read()){
                        inmu=new Inmueble{
                            InmuId=reader.GetInt32(nameof(Inmueble.InmuId)),
                            PropId=reader.GetString(nameof(Inmueble.PropId)),
                            Direccion=reader.GetString(nameof(Inmueble.Direccion)),
                            UsoComercial=reader.GetString(nameof(Inmueble.UsoComercial)),
                            TipoLocal=reader.GetString(nameof(Inmueble.TipoLocal)),
                            CantidadAmbientes=reader.GetInt32(nameof(Inmueble.CantidadAmbientes)),
                            Latitud=reader.GetInt32(nameof(Inmueble.Latitud)),
                            Longitud=reader.GetInt32(nameof(Inmueble.Longitud)),
                            Precio=reader.GetDecimal(nameof(Inmueble.Precio)),
                            Duenio=new Propietario{
                                PropId=reader.GetInt32(nameof(Inmueble.PropId)),
                                Nombre=reader.GetString(nameof(Propietario.Nombre)),
                                Apellido=reader.GetString(nameof(Propietario.Apellido))
                            }
                        };
                    }
                    connetion.Close();
                }
            }
        return inmu;
    }

    public int Create(Inmueble inmu){
        int resul;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"INSERT INTO Inmueble 
					(PropId,Direccion, UsoComercial, TipoLocal, CantidadAmbientes,Latitud, Longitud, Precio)
					VALUES (@PropId, @Direccion, @UsoComercial, @TipoLocal, @CantidadAmbientes, @Latitud, @Longitud, @Precio);
					SELECT LAST_INSERT_ID();";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@PropId",inmu.PropId);
                command.Parameters.AddWithValue("@Direccion",inmu.Direccion);
                command.Parameters.AddWithValue("@UsoComercial",inmu.UsoComercial);
                command.Parameters.AddWithValue("@TipoLocal",inmu.TipoLocal);
                command.Parameters.AddWithValue("@CantidadAmbientes",inmu.CantidadAmbientes);
                command.Parameters.AddWithValue("@Latitud",inmu.Latitud);
                command.Parameters.AddWithValue("@Longitud",inmu.Longitud);
                command.Parameters.AddWithValue("@Precio",inmu.Precio);
                connetion.Open();
                resul= Convert.ToInt32(command.ExecuteScalar());
                inmu.InmuId=resul;
                connetion.Close();
            }
        }
        return resul;
    } 

    public int Edit(Inmueble inmu){
        int resul=-1;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"UPDATE inmueble 
            SET PropId=@Propid,Direccion=@dire,UsoComercial=@uso,TipoLocal=@tipo,CantidadAmbientes=@ambi,Latitud=@lati,Longitud=@longi,Precio=@precio
             WHERE InmuId=@id;";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@Propid",inmu.PropId);
                command.Parameters.AddWithValue("@dire",inmu.Direccion);
                command.Parameters.AddWithValue("@uso",inmu.UsoComercial);
                command.Parameters.AddWithValue("@tipo",inmu.TipoLocal);
                command.Parameters.AddWithValue("@ambi",inmu.CantidadAmbientes);
                command.Parameters.AddWithValue("@lati",inmu.Latitud);
                command.Parameters.AddWithValue("@longi",inmu.Longitud);
                command.Parameters.AddWithValue("@precio",inmu.Precio);
                command.Parameters.AddWithValue("@id",inmu.InmuId);
                connetion.Open();
                resul= command.ExecuteNonQuery();
                connetion.Close();
            }
        }
        return resul;
    }
    public int Delete(int InmuId){
        int res=-1;
        using(MySqlConnection connection= new MySqlConnection(connectionString)){
            string query= @"DELETE FROM inmueble WHERE InmuId=@id;";
            using(var command= new MySqlCommand(query,connection)){
                command.Parameters.AddWithValue("@id",InmuId);
                connection.Open();
                res= command.ExecuteNonQuery();
                connection.Close();
            }
        }
        return res;
    }

}
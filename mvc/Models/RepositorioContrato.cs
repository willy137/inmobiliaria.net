namespace mvc.Models;
using MySql.Data.MySqlClient;

public class RepositorioContrato : Contrato
{
    string connectionString="Server=localhost;User=root;Password=;Database=inmo;SslMode=";

    public RepositorioContrato(){

    }
    public List<Contrato> GetContratos(){
        List<Contrato> contratos= new List<Contrato>(){};
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            var query=@"SELECT ContratoId, c.InmuId, c.InquiId, FechaInicio, FechaFinal, MontoAlquiler, i.Nombre,i.Apellido ,inm.Direccion 
            FROM contrato c INNER JOIN inquilino i INNER JOIN inmueble inm 
            ON c.InmuId=inm.InmuId AND c.InquiId=i.InquiId;";
            using(var command= new MySqlCommand(query,connetion))
            {
                connetion.Open();
                using (var reader= command.ExecuteReader())
                {
                    while(reader.Read()){
                        Contrato contrato = new Contrato
                        {
                            ContratoId=reader.GetInt32(nameof(Contrato.ContratoId)),//"Id"
                            InmuId=reader.GetInt32(nameof(Contrato.InmuId)),
                            InquiId=reader.GetInt32(nameof(Contrato.InquiId)),
                            FechaInicio=reader.GetDateTime(nameof(Contrato.FechaInicio)),
                            FechaFinal=reader.GetDateTime(nameof(Contrato.FechaFinal)),
                            MontoAlquiler=reader.GetDecimal(nameof(Contrato.MontoAlquiler)),
                            inquilino=new Inquilino{
                                InquiId=reader.GetInt32(nameof(Contrato.InquiId)),
                                Nombre=reader.GetString(nameof(Inquilino.Nombre)),
                                Apellido=reader.GetString(nameof(Inquilino.Apellido))
                            },
                            inmueble=new Inmueble{
                                InmuId=reader.GetInt32(nameof(Contrato.InmuId)),
                                Direccion=reader.GetString(nameof(Inmueble.Direccion)),
                            }
                        };
                        contratos.Add(contrato);
                    }
                }
            }
            connetion.Close();
        }
        return contratos;
    }

    public int Create(Contrato contra){
        int result;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"INSERT INTO contrato( InmuId, InquiId, FechaInicio, FechaFinal, MontoAlquiler) 
            VALUES (@inmu, @inqui,@fechaI,@fechaF,@monto);
            SELECT LAST_INSERT_ID();";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@inmu",contra.InmuId);
                command.Parameters.AddWithValue("@inqui",contra.InquiId);
                command.Parameters.AddWithValue("@fechaI",contra.FechaInicio);
                command.Parameters.AddWithValue("@fechaF",contra.FechaFinal);
                command.Parameters.AddWithValue("@monto",contra.MontoAlquiler);
                connetion.Open();
                result= Convert.ToInt32(command.ExecuteScalar());
                contra.ContratoId=result;
                connetion.Close();
            }
        }
        return result;
    }
  
   public int Edit(Contrato contra){
        int resul=-1;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"UPDATE contrato SET InmuId=@inmu,InquiId=@inqui,FechaInicio=@fechaI,FechaFinal=@fechaF,MontoAlquiler=@monto WHERE ContratoId=@id;";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@inmu",contra.InmuId);
                command.Parameters.AddWithValue("@inqui",contra.InquiId);
                command.Parameters.AddWithValue("@fechaI",contra.FechaInicio);
                command.Parameters.AddWithValue("@fechaF",contra.FechaFinal);
                command.Parameters.AddWithValue("@monto",contra.MontoAlquiler);
                command.Parameters.AddWithValue("@id",contra.ContratoId);
                connetion.Open();
                resul= command.ExecuteNonQuery();
                connetion.Close();
            }
        }
        return resul;
    }


    public Contrato ObtenerContrato(int id){
        Contrato contra=new Contrato();
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"SELECT ContratoId, c.InmuId, c.InquiId, FechaInicio, FechaFinal, MontoAlquiler, i.Nombre,i.Apellido ,inm.Direccion 
            FROM contrato c INNER JOIN inquilino i INNER JOIN inmueble inm 
            ON c.InmuId=inm.InmuId AND c.InquiId=i.InquiId 
            WHERE ContratoId=@id;";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@id",id);
                connetion.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
					{
					    contra = new Contrato
						{
							ContratoId = reader.GetInt32(nameof(Contrato.ContratoId) ),
							InmuId = reader.GetInt32(nameof(Contrato.InmuId) ),
							InquiId = reader.GetInt32(nameof(Contrato.InquiId) ),
							FechaInicio = reader.GetDateTime(nameof(Contrato.FechaInicio) ),
							FechaFinal = reader.GetDateTime(nameof(Contrato.FechaFinal)),
							MontoAlquiler = reader.GetDecimal(nameof(Contrato.MontoAlquiler)),
                            inquilino=new Inquilino{
                                InquiId=reader.GetInt32(nameof(Contrato.InquiId)),
                                Nombre=reader.GetString(nameof(Inquilino.Nombre)),
                                Apellido=reader.GetString(nameof(Inquilino.Apellido))
                            },
                            inmueble=new Inmueble{
                                InmuId=reader.GetInt32(nameof(Contrato.InmuId)),
                                Direccion=reader.GetString(nameof(Inmueble.Direccion)),
                            }
						};
					}
                connetion.Close();
            }
        }
        return contra;
    }

    public int Delete(int ContratoId){
        int res=-1;
        using(MySqlConnection connection= new MySqlConnection(connectionString)){
            string query= @"DELETE FROM contrato WHERE ContratoId = @id;";
            using(var command= new MySqlCommand(query,connection)){
                command.Parameters.AddWithValue("@id",ContratoId);
                connection.Open();
                res= command.ExecuteNonQuery();
                connection.Close();
            }
        }
        return res;
    }

}

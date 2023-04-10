namespace mvc.Models;
using MySql.Data.MySqlClient;

public class RepositorioPago : Pago
{
    string connectionString="Server=localhost;User=root;Password=;Database=inmo;SslMode=";

    public RepositorioPago(){

    }
    public List<Pago> GetPagos(){
        List<Pago> pagos= new List<Pago>(){};
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            var query=@"SELECT PagoId, p.ContratoId, NumeroPago, FechaPago, Importe, c.InquiId,c.InmuId , inq.InquiId,inq.Nombre , inq.Dni,inmu.InmuId, inmu.Direccion,inmu.TipoLocal 
            FROM Pago p INNER JOIN Contrato c INNER JOIN inquilino inq INNER JOIN inmueble inmu 
            ON p.ContratoId=c.ContratoId AND c.InquiId=inq.InquiId AND c.InmuId=inmu.InmuId";
            using(var command= new MySqlCommand(query,connetion))
            {
                connetion.Open();
                using (var reader= command.ExecuteReader())
                {
                    while(reader.Read()){
                        Pago pago = new Pago
                        {
                            PagoId=reader.GetInt32(nameof(Pago.PagoId)),//"Id"
                            ContratoId=reader.GetInt32(nameof(Pago.ContratoId)),
                            NumeroPago=reader.GetInt32(nameof(Pago.NumeroPago)),
                            FechaPago=reader.GetDateTime(nameof(Pago.FechaPago)),
                            Importe=reader.GetDecimal(nameof(Pago.Importe)),
                            contrato=new Contrato{
                                ContratoId=reader.GetInt32(nameof(Pago.ContratoId)),
                                InquiId=reader.GetInt32(nameof(Contrato.InquiId)),
                                InmuId=reader.GetInt32(nameof(Contrato.InmuId))
                            },
                            inmueble=new Inmueble{
                                InmuId=reader.GetInt32(nameof(Contrato.InmuId)),
                                Direccion=reader.GetString(nameof(Inmueble.Direccion)),
                                TipoLocal=reader.GetString(nameof(Inmueble.TipoLocal))
                            },
                            inquilino=new Inquilino{
                                InquiId=reader.GetInt32(nameof(Contrato.InquiId)),
                                Nombre=reader.GetString(nameof(Inquilino.Nombre)),
                                Dni=reader.GetString(nameof(Inquilino.Dni))
                            },
                        };
                        pagos.Add(pago);
                    }
                }
            }
            connetion.Close();
        }
        return pagos;
    }

    public int Create(Pago pago){
        int result;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"INSERT INTO pago( ContratoId, NumeroPago, FechaPago,Importe) 
            VALUES (@contra, @numPago,@fechaP,@monto);
            SELECT LAST_INSERT_ID();";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@contra",pago.ContratoId);
                command.Parameters.AddWithValue("@numPago",pago.NumeroPago);
                command.Parameters.AddWithValue("@fechaP",pago.FechaPago);
                command.Parameters.AddWithValue("@Importe",pago.Importe);
                connetion.Open();
                result= Convert.ToInt32(command.ExecuteScalar());
                pago.PagoId=result;
                connetion.Close();
            }
        }
        return result;
    }
  
   public int Edit(Pago pago){
        int resul=-1;
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"UPDATE pago SET ContratoId=@contra,NumeroPago=@numP,FechaPago=@fechaP,Importe=@monto WHERE PagoId=@id;";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@contra",pago.ContratoId);
                command.Parameters.AddWithValue("@numP",pago.NumeroPago);
                command.Parameters.AddWithValue("@fechaP",pago.FechaPago);
                command.Parameters.AddWithValue("@monto",pago.Importe);
                command.Parameters.AddWithValue("@id",pago.PagoId);
                connetion.Open();
                resul= command.ExecuteNonQuery();
                connetion.Close();
            }
        }
        return resul;
    }


    public Pago ObtenerPago(int id){
        Pago pago=new Pago();
        using (MySqlConnection connetion = new MySqlConnection(connectionString)){
            string query= @"SELECT PagoId, p.ContratoId, NumeroPago, FechaPago, Importe, c.InquiId,c.InmuId , inq.InquiId,inq.Nombre , inq.Dni,inmu.InmuId, inmu.Direccion,inmu.TipoLocal 
            FROM Pago p INNER JOIN Contrato c INNER JOIN inquilino inq INNER JOIN inmueble inmu 
            ON p.ContratoId=c.ContratoId AND c.InquiId=inq.InquiId AND c.InmuId=inmu.InmuId
            WHERE PagoId=@id;";
            using(var command= new MySqlCommand(query,connetion)){
                command.Parameters.AddWithValue("@id",id);
                connetion.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
					{
                         pago = new Pago
                        {
                            PagoId=reader.GetInt32(nameof(Pago.PagoId)),//"Id"
                            ContratoId=reader.GetInt32(nameof(Pago.ContratoId)),
                            NumeroPago=reader.GetInt32(nameof(Pago.NumeroPago)),
                            FechaPago=reader.GetDateTime(nameof(Pago.FechaPago)),
                            Importe=reader.GetDecimal(nameof(Pago.Importe)),
                            contrato=new Contrato{
                                ContratoId=reader.GetInt32(nameof(Pago.ContratoId)),
                                InquiId=reader.GetInt32(nameof(Contrato.InquiId)),
                                InmuId=reader.GetInt32(nameof(Contrato.InmuId))
                            },
                            inmueble=new Inmueble{
                                InmuId=reader.GetInt32(nameof(Contrato.InmuId)),
                                Direccion=reader.GetString(nameof(Inmueble.Direccion)),
                                TipoLocal=reader.GetString(nameof(Inmueble.TipoLocal))
                            },
                            inquilino=new Inquilino{
                                InquiId=reader.GetInt32(nameof(Contrato.InquiId)),
                                Nombre=reader.GetString(nameof(Inquilino.Nombre)),
                                Dni=reader.GetString(nameof(Inquilino.Dni))
                            },
                        };
					}
                connetion.Close();
            }
        }
        return pago;
    }

    public int Delete(int ContratoId){
        int res=-1;
        using(MySqlConnection connection= new MySqlConnection(connectionString)){
            string query= @"DELETE FROM pago WHERE PagoId = @id;";
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

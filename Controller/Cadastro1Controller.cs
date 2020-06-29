using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppTeste.Controller
{
  public class Cadastro1Controller : ApiController
  {
    // GET: api/Cadastro1
    public HttpResponseMessage Get()
    {
      SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
      con.Open();
      SqlCommand cmd = new SqlCommand("CarregaMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      SqlDataReader dr = cmd.ExecuteReader();

      List<string> campo1 = new List<string>();
      while (dr.Read())
      {
        campo1.Add(dr["cpf"].ToString());
        campo1.Add(dr["nome"].ToString());
        campo1.Add(dr["sexo"].ToString());
        campo1.Add(dr["idade"].ToString());
        campo1.Add(dr["ativo"].ToString());
      }

      return Request.CreateResponse(HttpStatusCode.Created, campo1);

    }

    // GET: api/Cadastro1/5
    public HttpResponseMessage Get(int id)
    {
      SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
      con.Open();
      SqlCommand cmd = new SqlCommand("getMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@codigo", id);
      SqlDataReader dr = cmd.ExecuteReader();
      List<string> campo1 = new List<string>();

      if (dr.Read())
      {
        campo1.Add(dr["cpf"].ToString());
        campo1.Add(dr["nome"].ToString());
        campo1.Add(dr["sexo"].ToString());
        campo1.Add(dr["idade"].ToString());
        campo1.Add(dr["ativo"].ToString());

      }
      return Request.CreateResponse(HttpStatusCode.Created, campo1);

    }

    // POST: api/Cadastro1
    public void Post([FromBody]Moto_Model motorista)
    {
      SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
      con.Open();
      SqlCommand cmd = new SqlCommand("InserirMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@cpf", motorista.Cpf);
      cmd.Parameters.AddWithValue("@nome", motorista.Nome);
      cmd.Parameters.AddWithValue("@sexo", motorista.Sexo);
      cmd.Parameters.AddWithValue("@idade", motorista.Idade);
      cmd.Parameters.AddWithValue("@ativo", motorista.Ativo);
      cmd.ExecuteNonQuery();

    }

    // PUT: api/Cadastro1/5
    public void Put(int codigo, [FromBody]Moto_Model motorista)
    {
      SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);

      con.Open();
      SqlCommand cmd = new SqlCommand("AtualizarMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@codigo", codigo);
      cmd.Parameters.AddWithValue("@cpf", motorista.Cpf);
      cmd.Parameters.AddWithValue("@nome", motorista.Nome);
      cmd.Parameters.AddWithValue("@sexo", motorista.Sexo);
      cmd.Parameters.AddWithValue("@idade", motorista.Idade);
      cmd.Parameters.AddWithValue("@ativo", motorista.Ativo);
      cmd.ExecuteNonQuery();

    }

    // DELETE: api/Cadastro1/5
    public void Delete(int codigo)
    {
      SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);

      con.Open();
      SqlCommand cmd = new SqlCommand("DeletarMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@codigo", codigo);
      cmd.ExecuteNonQuery();
    }

  }
}

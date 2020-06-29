using System;
using System.Data.SqlClient;
using System.Data;
using AppTeste.Models;

public class MotoristaDAL
{
  public static DataSet GetMotoristas()
  {
    SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
    SqlDataAdapter da = new SqlDataAdapter("CarregaMotorista", con);
    da.SelectCommand.CommandType = CommandType.StoredProcedure;
    DataSet ds = new DataSet();
    try
    {
      da.Fill(ds, "motoristas");
    }
    catch (Exception ex)
    {
      throw ex;
    }
    return ds;
  }
  public static Moto_Model GetMotorista(int codigo)
  {
    
    SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
    try
    {
      con.Open();
      SqlCommand cmd = new SqlCommand("getMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@codigo", codigo);
      SqlDataReader dr = cmd.ExecuteReader();
      if (dr.Read())
      {
        Moto_Model ct = new Moto_Model();
        ct.Cpf = dr["cpf"].ToString();
        ct.Nome = dr["nome"].ToString();
        ct.Sexo = dr["sexo"].ToString();
        ct.Idade = Int32.Parse(dr["idade"].ToString());
        ct.Ativo = dr["ativo"].ToString();
        return ct;
      }
      else
      {
        return null;
      }

    }
    catch (Exception ex)
    {
      Serv.Sqlerro = "Error -> " + ex.Message;
      return null;
    }
    finally
    {
      con.Close();
    }
  }
  public void incluirMotorista(Moto_Model motorista)
  {
    var faz = buscarMotorista(motorista.Cpf).ToString();
    if (faz == "0")
    {
      SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
      try
      {
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
      catch (Exception ex)
      {
        Serv.Sqlerro = "Error -> " + ex.Message;
      }
      finally
      {
        con.Close();
      }

    }
    else
    {
      Serv.Sqlerro = string.Format("O CPF {0} ja esta Cadastrado !!!", motorista.Cpf);
    }

  }
  public static string deletarMotorista(int codigo)
  {
    SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
    try
    {
      con.Open();
      SqlCommand cmd = new SqlCommand("DeletarMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@codigo", codigo);
      cmd.ExecuteNonQuery();
      return null;
    }
    catch (Exception ex)
    {
      Serv.Sqlerro = "Error -> " + ex.Message;
      return null;
    }
    finally
    {
      con.Close();
    }
  }
  public static string atualizarMotorista(Moto_Model motorista)
  {
    SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
    try
    {
      con.Open();
      SqlCommand cmd = new SqlCommand("AtualizarMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@codigo", motorista.Codigo);
      cmd.Parameters.AddWithValue("@cpf", motorista.Cpf);
      cmd.Parameters.AddWithValue("@nome", motorista.Nome);
      cmd.Parameters.AddWithValue("@sexo", motorista.Sexo);
      cmd.Parameters.AddWithValue("@idade", motorista.Idade);
      cmd.Parameters.AddWithValue("@ativo", motorista.Ativo);
      cmd.ExecuteNonQuery();
      return null;
    }
    catch (Exception ex)
    {
      Serv.Sqlerro = "Error -> " + ex.Message;
      return null;
    }
    finally
    {
      con.Close();
    }
  }
  public static string buscarMotorista(string cpf)
  {
    SqlConnection con = new SqlConnection(AcessoDB.ConnectionString);
    try
    {
      con.Open();
      SqlCommand cmd = new SqlCommand("BuscaMotorista", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@cpf", cpf);
      SqlDataReader dr = cmd.ExecuteReader();
      var ret = "0";
      if (dr.Read())
      {
        Moto_Model ct = new Moto_Model();
        ct.Cpf = dr["cpf"].ToString();
        if (ct.Cpf != null)
        {
          ret = "1";
        }
      }
      return ret;
    }
    catch (Exception ex)
    {
      Serv.Sqlerro = "Error -> " + ex.Message;
      return null;
    }
  }
}

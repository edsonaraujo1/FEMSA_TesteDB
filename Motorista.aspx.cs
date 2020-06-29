using AppTeste.Models;
using System;
using System.Web.UI.WebControls;

namespace AppTeste
{
  public partial class Motorista : System.Web.UI.Page
  {
    private void Page_Load(object sender, EventArgs e)
    {
      LinkButton1.Visible = true;      // Incluir
      LinkButton2.Visible = false;     // Alterar
      LinkButton3.Visible = false;     // Excluir
      LinkButton4.Visible = false;     // Cancelar
      LinkButton5.Visible = true;      // Sair
      txtCodigo.Enabled = false;

      GridView1.DataSource = MotoristaDAL.GetMotoristas();
      GridView1.DataBind();

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
      MotoristaDAL ctDal = new MotoristaDAL();
      Moto_Model _motorista = new Moto_Model();

      _motorista.Codigo = _motorista.Codigo + 1;
      _motorista.Cpf = txtCpf.Text;
      _motorista.Nome = txtNome.Text;
      _motorista.Sexo = txtSexo.Text;
      _motorista.Idade = (txtIdade.Text != "") ? Int32.Parse(txtIdade.Text) : 0;
      _motorista.Ativo = txtAtivo.Text;

      txtCodigo.Enabled = false;

      try
      {
        ctDal.incluirMotorista(_motorista);
        if (Serv.Sqlerro == null)
        {
          lblMsg.Text = "Motorista incluido com sucesso!";
          txtCodigo.Text = "";
          txtCpf.Text = "";
          txtNome.Text = "";
          txtIdade.Text = "";
        }
        else
        {
          lblMsg.Text = Serv.Sqlerro.ToString();
        }

      }
      catch (Exception ex)
      {
        lblMsg.Text = "Error -> " + ex.Message;
      }

      LinkButton1.Visible = true;      // Incluir
      LinkButton2.Visible = false;     // Alterar
      LinkButton3.Visible = false;     // Excluir
      LinkButton4.Visible = false;     // Cancelar
      LinkButton5.Visible = true;      // Sair

      GridView1.DataSource = MotoristaDAL.GetMotoristas();
      GridView1.DataBind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
      Moto_Model _motorista = new Moto_Model();
      _motorista.Codigo = Int32.Parse(txtCodigo.Text);
      _motorista.Cpf = txtCpf.Text;
      _motorista.Nome = txtNome.Text;
      _motorista.Sexo = txtSexo.Text;
      _motorista.Idade = (txtIdade.Text != "") ? Int32.Parse(txtIdade.Text) : 0;
      _motorista.Ativo = txtAtivo.Text;
      txtCodigo.Enabled = false;

      try
      {
        MotoristaDAL.atualizarMotorista(_motorista);
        lblMsg.Text = "Motorista Atualizado com sucesso!";
        txtCodigo.Text = "";
        txtCpf.Text = "";
        txtNome.Text = "";
        txtIdade.Text = "";
      }
      catch (Exception ex)
      {
        lblMsg.Text = "Error -> " + ex.Message;
      }

      LinkButton1.Visible = true;      // Incluir
      LinkButton2.Visible = false;     // Alterar
      LinkButton3.Visible = false;     // Excluir
      LinkButton4.Visible = false;     // Cancelar
      LinkButton5.Visible = true;      // Sair

      GridView1.DataSource = MotoristaDAL.GetMotoristas();
      GridView1.DataBind();
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
      try
      {
        MotoristaDAL.deletarMotorista(Int32.Parse(txtCodigo.Text));
        lblMsg.Text = "Motorista excluido com sucesso!";
        txtCodigo.Text = "";
        txtCpf.Text = "";
        txtNome.Text = "";
        txtIdade.Text = "";
      }
      catch (Exception ex)
      {
        lblMsg.Text = "Error -> " + ex.Message;
      }

      LinkButton1.Visible = true;      // Incluir
      LinkButton2.Visible = false;     // Alterar
      LinkButton3.Visible = false;     // Excluir
      LinkButton4.Visible = false;     // Cancelar
      LinkButton5.Visible = true;      // Sair

      GridView1.DataSource = MotoristaDAL.GetMotoristas();
      GridView1.DataBind();
    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
      txtCodigo.Text = "";
      txtCpf.Text = "";
      txtNome.Text = "";
      txtIdade.Text = "";

      LinkButton1.Visible = true;      // Incluir
      LinkButton2.Visible = false;     // Alterar
      LinkButton3.Visible = false;     // Excluir
      LinkButton4.Visible = false;     // Cancelar
      LinkButton5.Visible = true;      // Sair

      GridView1.DataSource = MotoristaDAL.GetMotoristas();
      GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
      var grid = ((GridView)sender);
      int index = grid.SelectedRow.RowIndex;
      if (index >= 0)
      {
        if (int.TryParse(grid.Rows[index].Cells[0].Text, out var Codigo))
        {
          int vrCode = Convert.ToInt32(Codigo);
          if (vrCode == 0)
          {
            lblMsg.Text = "Codigo do Motorista invalido";
            return;
          }

          Moto_Model c = MotoristaDAL.GetMotorista(vrCode);
          if (c != null)
          {
            txtCodigo.Text = Codigo.ToString();
            txtCpf.Text = c.Cpf;
            txtNome.Text = c.Nome;
            txtSexo.Text = c.Sexo;
            txtIdade.Text = c.Idade.ToString();
            txtAtivo.Text = c.Ativo;

            txtCodigo.Enabled = false;

          }
          else
          {
            lblMsg.Text = "Motorista nao encontrado !!!";
          }

          if (String.IsNullOrEmpty(txtCodigo.Text))
          {
            LinkButton1.Visible = true;      // Incluir
            LinkButton2.Visible = false;     // Alterar
            LinkButton3.Visible = false;     // Excluir
            LinkButton4.Visible = false;     // Cancelar
            LinkButton5.Visible = true;      // Sair
          }
          else
          {
            LinkButton1.Visible = false;    // Incluir
            LinkButton2.Visible = true;     // Alterar
            LinkButton3.Visible = true;     // Excluir
            LinkButton4.Visible = true;     // Cancelar
            LinkButton5.Visible = true;     // Sair
          }
        }
      }

    }
  }
}

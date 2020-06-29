using System.ComponentModel.DataAnnotations;

public class Moto_Model
{
  public int Codigo { get; set; }
  
  [Required(ErrorMessage = "O CPF deve ser informada.")]
  public string Cpf { get; set; }
  [Required(ErrorMessage = "O Nome deve ser informada.")]
  public string Nome { get; set; }
  [Required(ErrorMessage = "O Sexo deve ser informada.")]
  public string Sexo { get; set; }
  [Required(ErrorMessage = "O Idade deve ser informada.")]
  public int Idade { get; set; }
  [Required(ErrorMessage = "O Ativo deve ser informada.")]
  public string Ativo { get; set; }


}

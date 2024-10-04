using System.ComponentModel.DataAnnotations;

namespace UC_WebApi.Controllers;
public class Client
{
    [Key]
    public int Id { get; set; }
    [MaxLength(255)]
    [Required(ErrorMessage = "Campo nome obrigatório!")]
    public string Nome { get; set; }
    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Campo Data de Nascimento obrigatório!")]
    public DateTime DataNascimento { get; set; }
    [MaxLength(15)]
    public string Telefone { get; set; }

}

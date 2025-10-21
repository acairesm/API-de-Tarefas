namespace APITAREFAS.Models;

using System.ComponentModel.DataAnnotations;

public class Projeto
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Nome { get; set; } = default!;

    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    public string Responsavel { get; set; } = default!;

    [Required]
    public DateTime DataInicio { get; set; }

    public DateTime? DataFimPrevista { get; set; }

    [Range(0,100)]
    public int ProgressoPercentual { get; set; } = 0;

    [Required]
    public string Status { get; set; } = "Planejado"; // Planejado, EmAndamento, Concluido
}
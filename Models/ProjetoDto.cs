namespace APITAREFAS.Models;

public class ProjetoDto
{
    public string Nome { get; set; } = default!;
    public string? Descricao { get; set; }
    public string Responsavel { get; set; } = default!;
    public DateTime DataInicio { get; set; }
    public DateTime? DataFimPrevista { get; set; }
    public int ProgressoPercentual { get; set; }
    public string Status { get; set; } = "Planejado";
}
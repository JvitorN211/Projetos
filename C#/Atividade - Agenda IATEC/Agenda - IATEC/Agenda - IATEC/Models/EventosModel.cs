using System.ComponentModel.DataAnnotations;

namespace Agenda___IATEC.Models
{
    public class EventosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do evento")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Dê uma pequena descrição ao evento")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "Digite a data do evento")]
        public string Data { get; set; }
        [Required(ErrorMessage = "Digite o horário do evento")]
        public string? Horario { get; set; }
        [Required(ErrorMessage = "Digite o local do evento")]
        public string Local { get; set; }
        [Required(ErrorMessage = "Informe os participantes do evento")]
        public string Participantes { get; set; }
        [Required(ErrorMessage = "Digite o tipo do evento")]
        public string Tipo { get; set; }
    }
}

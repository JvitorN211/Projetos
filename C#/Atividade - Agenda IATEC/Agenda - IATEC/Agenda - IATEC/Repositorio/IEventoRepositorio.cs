using Agenda___IATEC.Models;

namespace Agenda___IATEC.Repositorio
{
    public interface IEventoRepositorio
    {
        EventosModel ListarPorId(int id);
        List<EventosModel> BuscarPublicos();
        EventosModel Adicionar(EventosModel evento);
        EventosModel Atualizar(EventosModel eventos);
        bool Excluir(int id);
    }
}

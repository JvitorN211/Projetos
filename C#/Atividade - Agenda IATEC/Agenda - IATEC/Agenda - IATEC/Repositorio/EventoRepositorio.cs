using Agenda___IATEC.Data;
using Agenda___IATEC.Models;

namespace Agenda___IATEC.Repositorio
{
    public class EventoRepositorio : IEventoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public EventoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public EventosModel ListarPorId(int id)
        {
            return _bancoContext.Eventos.FirstOrDefault(x => x.Id == id);
        }

        public List<EventosModel> BuscarPublicos()
        {
            return _bancoContext.Eventos.ToList();
        }

        public EventosModel Adicionar(EventosModel evento)
        {
            // Adicionar no Banco de Dados
            _bancoContext.Eventos.Add(evento);
            _bancoContext.SaveChanges();
            return evento;
        }

        public EventosModel Atualizar(EventosModel eventos)
        {
            EventosModel eventosDB = ListarPorId(eventos.Id);

            if (eventosDB == null) throw new Exception("Houve um erro na atualização do Evento!");

            eventosDB.Nome = eventos.Nome;
            eventosDB.Descricao = eventos.Descricao;
            eventosDB.Data = eventos.Data;
            eventosDB.Horario = eventos.Horario;
            eventosDB.Local = eventos.Local;
            eventosDB.Participantes = eventos.Participantes;
            eventosDB.Tipo = eventos.Tipo;

            _bancoContext.Eventos.Update(eventosDB);
            _bancoContext.SaveChanges();

            return eventosDB;
        }

        public bool Excluir(int id)
        {
            EventosModel eventosDB = ListarPorId(id);

            if (eventosDB == null) throw new Exception("Houve um erro na exclusão do Evento!");

            _bancoContext.Eventos.Remove(eventosDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}

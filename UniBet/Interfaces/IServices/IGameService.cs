using UniBet.DTOs;
using UniBet.Entities;

namespace UniBet.Interfaces.IServices
{
	public interface IGameService
	{
		void CadastrarJogo(GameDTO gameDto);
		Game BuscarJogo(Guid id);
		List<Game> ListarJogos();
		void EditarJogo(Guid id, GameDTO gameDto);
		void RemoverJogo(Guid id);
	}
}
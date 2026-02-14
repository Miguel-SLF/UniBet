using UniBet.DTOs;
using UniBet.Entities;
using UniBet.Interfaces.IServices;

namespace UniBet.Services
{
    public class GameService : IGameService
    {

        private static List<Game> _jogos = new List<Game>();

        public void CadastrarJogo(GameDTO gameDto)
        {
            var novoJogo = new Game
            {
                Name = gameDto.Name,
                Image = gameDto.Image,
                Description = gameDto.Description
            };
            _jogos.Add(novoJogo);
        }

        public Game BuscarJogo(Guid id)
        {
            return _jogos.FirstOrDefault(g => g.Id == id);
        }

        public List<Game> ListarJogos()
        {
            return _jogos;
        }

        public void EditarJogo(Guid id, GameDTO gameDto)
        {
            var jogo = BuscarJogo(id);
            if (jogo != null)
            {
                jogo.Name = gameDto.Name;
                jogo.Image = gameDto.Image;
                jogo.Description = gameDto.Description;
            }
            else
            {
                throw new Exception("Jogo não encontrado para edição.");
            }
        }

        public void RemoverJogo(Guid id)
        {
            var jogo = BuscarJogo(id);
            if (jogo != null)
            {
                _jogos.Remove(jogo);
            }
            else
            {
                throw new Exception("Jogo não encontrado para remoção.");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using PokedexCRUD.Interfaces;

namespace PokedexCRUD
{
    public class PokemonsRepositorio : IRepositorio<Pokemons>
    {
        private List<Pokemons> listaPokemons = new List<Pokemons>();

        public void Atualizar(int id, Pokemons entidade)
        {
            listaPokemons[id] = entidade;
        }

        public void Excluir(int id)
        {
            listaPokemons[id].Excluir();
        }

        public void Inserir(Pokemons objeto)
        {
            listaPokemons.Add(objeto);
        }

        public List<Pokemons> Lista()
        {
            return listaPokemons;
        }

        public int ProximoId()
        {
            return listaPokemons.Count;
        }

        public Pokemons RetornaPorId(int id)
        {
            return listaPokemons[id];
        }
    }
}
using System;
using Series.Interfaces;
using System.Collections.Generic;

namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade){
            listaSerie[id] = entidade;
        }
        public void Exclui(int id){            
            listaSerie.RemoveAt(id);
            List<Serie> novaLista = new List<Serie>();
            int nId = 0;
            foreach (var item in listaSerie)
            {
                novaLista.Add(new Serie(nId, item.retornaGenero(), item.retornTitulo(), item.retornaDescricao(), item.retornaAno()));
                nId++;
            }
            listaSerie = novaLista;
        }
        public void Insere(Serie entidade){
            listaSerie.Add(entidade);
        }
        public List<Serie> Lista(){
            return listaSerie;
        }
        public int ProximoId(){            
            return listaSerie.Count;
        }
        public Serie RetornaPorId(int id){
            return listaSerie[id];
        }
    }
}

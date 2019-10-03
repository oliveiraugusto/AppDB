using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace AppDB.Class
{
    public class Informacoes
    {
        public List<Model> SelectAll()
        {
            try
            {
                var itens = ((App)Application.Current).Conexao.Query<Model>("SELECT * FROM informacoes");
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir\nDetalhes:" + ex.Message);
            }
            
        }

        public bool Inserir(DateTime data)
        {
            try
            {
                var query = $"INSERT INTO informacoes (info) VALUES ('{data}')";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir\nDetalhes:" + ex.Message);
            }
            
        }

        public bool Update(int id)
        {
            try
            {
                var query = $"UPDATE informacoes SET info = '{DateTime.Now}' WHERE id = {id}";
                ((App)Application.Current).Conexao.Execute(query);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir\nDetalhes:" + ex.Message);
            }
        }

        public bool DeleteAll()
        {
            try
            {
                var query = $"DELETE FROM informacoes";
                ((App)Application.Current).Conexao.Execute(query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir\nDetalhes:" + ex.Message);
            }
        }

        public bool DeleteItem(int id)
        {
            try
            {
                var query = $"DELETE FROM informacoes WHERE id = {id}";
                ((App)Application.Current).Conexao.Execute(query);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao inserir\nDetalhes:" + ex.Message);
            }
            
        }
    }
}

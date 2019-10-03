using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppDB
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CarregarInformacoes();
        }

        private void ButtonInserir_Clicked(object sender, EventArgs e)
        {
            var query = $"INSERT INTO informacoes (info) VALUES ('{DateTime.Now}')";
            ((App)Application.Current).Conexao.Execute(query);
            CarregarInformacoes();
        }

        private void CarregarInformacoes()
        {
            var lista = ((App)Application.Current).Conexao.Query<Model>("SELECT * FROM informacoes");
            listView.ItemsSource = lista;        
        }

        private void MenuItemAtualizar_Clicked(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            var model = (Model)mi.CommandParameter;
            var resultado = ((App)Application.Current).Conexao.Execute($"UPDATE informacoes SET info = '{DateTime.Now}' WHERE id = {model.ID}");
            DisplayAlert("Sucesso!", "Dados atualizados", "OK");
            CarregarInformacoes();
        }

        private void ButtonAdicionar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var lista = ((App)Application.Current).Conexao.Execute($"INSERT INTO informacoes (info) VALUES ('{DateTime.Now}')");
                DisplayAlert("Sucesso!", "Item salvo!", "OK");
                CarregarInformacoes();
            }
            catch (Exception ex)
            {
                DisplayAlert("ERRO", ex.Message, "OK");
            }
        }

        private async void ButtonApagarTudo_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Confimação", "tem certeza que deseja deletar todas as informações?", "SIM", "NÃO");
            if (resposta == true)
            {
                try
                {
                    var lista = ((App)Application.Current).Conexao.Execute($"DELETE FROM informacoes");
                    await DisplayAlert("Sucesso!", "Todas as informações foram deletadas!", "OK");
                    CarregarInformacoes();
                }
                catch (Exception ex)
                {
                   await DisplayAlert("ERRO", ex.Message, "OK");
                }
            }
        }

        private async void MenuItemApagar_Clicked(object sender, EventArgs e)
        {
            var resposta = await DisplayAlert("Confimação", "tem certeza que deseja deletar?", "SIM", "NÃO");
            if (resposta == true)
            {
                try
                {
                    var mi = (MenuItem)sender;
                    var model = (Model)mi.CommandParameter;
                    ((App)Application.Current).Conexao.Execute($"DELETE FROM informacoes WHERE id = {model.ID}");
                    await DisplayAlert("Sucesso!", "Informaçao deletada!", "OK");
                    CarregarInformacoes();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("ERRO", ex.Message, "OK");
                }
            }
        }
    }
}

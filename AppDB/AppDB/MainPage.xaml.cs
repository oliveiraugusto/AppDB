using AppDB.Class;
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
        protected Informacoes informacoes = new Informacoes();

        public MainPage()
        {
            InitializeComponent();
            CarregarInformacoes();
        }

        private void CarregarInformacoes()
        {
            var lista = informacoes.SelectAll();
            listView.ItemsSource = lista;        
        }

        private void MenuItemAtualizar_Clicked(object sender, EventArgs e)
        {
            var mi = (MenuItem)sender;
            var model = (Model)mi.CommandParameter;

            bool resultadoUpdate = informacoes.Update(model.ID);
            if (resultadoUpdate == true)
                DisplayAlert("Sucesso!", "Atualizado", "OK");
            else
                DisplayAlert("Ops...", "Houve um erro", "OK");
            CarregarInformacoes();
        }

        private void ButtonAdicionar_Clicked(object sender, EventArgs e)
        {
            bool resultadoInsert = informacoes.Inserir(DateTime.Now);
            if (resultadoInsert == true)
                DisplayAlert("Sucesso!", "Inserido", "OK");
            else
                DisplayAlert("Ops...", "Houve um erro", "OK");
            CarregarInformacoes();
        }

        private async void ButtonApagarTudo_Clicked(object sender, EventArgs e)
        {
            var respostaConfirmacao = await DisplayAlert("Confimação", "tem certeza que deseja deletar todas as informações?", "SIM", "NÃO");
            if (respostaConfirmacao == true)
            {
                try
                {
                    var resultadoDeleteAll = informacoes.DeleteAll();
                    if (resultadoDeleteAll == true)
                        await DisplayAlert("Sucesso!", "Inserido", "OK");
                    else
                        await DisplayAlert("Ops...", "Houve um erro", "OK");                    
                }
                catch (Exception ex)
                {
                   await DisplayAlert("ERRO", ex.Message, "OK");
                }
            }
            CarregarInformacoes();
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
                    var resultadoDeleteItem = informacoes.DeleteItem(model.ID);
                    if (resultadoDeleteItem == true)
                        await DisplayAlert("Sucesso!", "Item Deletado", "OK");
                    else
                        await DisplayAlert("Ops...", "Houve um erro", "OK");                    
                }
                catch (Exception ex)
                {
                    await DisplayAlert("ERRO", ex.Message, "OK");
                }
            }
            CarregarInformacoes();
        }
    }
}

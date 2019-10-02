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
    }
}

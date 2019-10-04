using PCLExt.FileStorage.Folders;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//Para fazermos 

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppDB
{
    public partial class App : Application
    {
        //String de Conexao SQLite
        public SQLite.SQLiteConnection Conexao { get; private set; }

        public App()
        {
            //pego a pasta no Device
            var pasta = new LocalRootFolder();

            //crio um arquivo (se ele nao existr) no device
            // (se ele existir vai abri-lo)
            var arquivo = pasta.CreateFile("banco.db", PCLExt.FileStorage.CreationCollisionOption.OpenIfExists);

            //abro a conexao com o arquivo/banco
            Conexao = new SQLite.SQLiteConnection(arquivo.Path);

            //executo um SQL (CREATE TABLE)
            Conexao.Execute("CREATE TABLE IF NOT EXISTS informacoes (id INTEGER PRIMARY KEY AUTOINCREMENT, info TEXT)");

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

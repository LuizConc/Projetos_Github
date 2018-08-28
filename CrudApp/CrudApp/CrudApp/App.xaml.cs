using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace CrudApp
{
	public partial class App : Application
	{
        public SQLiteConnection Conexao { get; }

        public App()
        {
            //Criação do Banco de Dados
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("Cliente.db", CreationCollisionOption.OpenIfExists);
            Conexao = new SQLiteConnection(arquivo.Path);
           // Criação da Tabela
            Conexao.Execute("create table if not exists Consumidor (id integer primary key autoincrement, nome text,telefone text,email text,nascimento integer)");

            InitializeComponent();

            MainPage = new NavigationPage( new MainPage());
        }
        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

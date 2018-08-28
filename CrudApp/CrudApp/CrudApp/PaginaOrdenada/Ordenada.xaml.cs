using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace CrudApp.PaginaOrdenada
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Ordenada : ContentPage
	{
        public ObservableCollection<Model.Pessoa> Lista { get; set; }
		public Ordenada ()
		{
			InitializeComponent ();
            BindingContext = new Model.Pessoa();
            CarregarInformacoes();

        }


        public void CarregarInformacoes()
        {
            //exibir informações da tabela

            Lista = new ObservableCollection<Model.Pessoa>(((App)Application.Current).Conexao.Query<Model.Pessoa>("select * from Consumidor order by nascimento"));
            Myview.ItemsSource = Lista;

        }
        //Método de exclusão por item selecionado.
        private void MenuItemApagar(object sender, EventArgs e)
        {

            var mi = (MenuItem)sender;
            var model = (Model.Pessoa)mi.CommandParameter;
            ((App)Application.Current).Conexao.Execute("delete from Consumidor where id = ?", model.id);
            CarregarInformacoes();
            DisplayAlert("Exclusão", "Cliente Excluido com sucesso!", "OK");
        }
        //Botão para exclusão de todos os dados da tabela.
        private void ApagarTudo(object sender, EventArgs e)
        {
            ((App)Application.Current).Conexao.Execute("delete from Consumidor");
            CarregarInformacoes();
            DisplayAlert("Exclusão", "Cliente Excluido com sucesso!", "OK");

        }

    }
}

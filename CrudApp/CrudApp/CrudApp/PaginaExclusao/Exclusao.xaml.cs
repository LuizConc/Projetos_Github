using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace CrudApp.PaginaExclusao
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Exclusao : ContentPage
	{
        public ObservableCollection<Model.Pessoa> Costumer { get; set; }
		public Exclusao ()
		{
			InitializeComponent ();
		}
        public void CarregarInformacoes()
        {
            //exibir informações 
            Costumer = new ObservableCollection<Model.Pessoa>(((App)Application.Current).Conexao.Query<Model.Pessoa>("select * from Consumidor where id=? or nome = ?", ID_Consumidor.Text,ID_Consumidor.Text));

            Myview.ItemsSource = Costumer;
        }

        public void Search(object sender, EventArgs args)
        {
            //Buscar informações do ID ou NOME digitado
            Costumer = new ObservableCollection<Model.Pessoa>(((App)Application.Current).Conexao.Query<Model.Pessoa>("select * from Consumidor where id=? or nome = ?", ID_Consumidor.Text,ID_Consumidor.Text));

            //caso não encontre
            if (Costumer.Count == 0)
            {
                DisplayAlert("Erro", "Cliente Não Encontrado", "OK");

                Navigation.PopModalAsync();

            }
            else
            {
                //caso encontre, Informações do cliente são exibidas
                Myview.ItemsSource = Costumer;

            }

        }
        //Método de exclusão por seleção de item.
        private void MenuItemApagar(object sender, EventArgs e)
        {
            
            var mi = (MenuItem)sender;
            var model = (Model.Pessoa)mi.CommandParameter;
            ((App)Application.Current).Conexao.Execute("delete from Consumidor where id = ?", model.id);
            CarregarInformacoes();
            //depois de excluido mensagem é exibida
            DisplayAlert("Exclusão", "Cliente Excluido com sucesso!", "OK");
        }
        //Botão de exclusão do Cliente via ID ou nome
        private void Delete(object sender, EventArgs e)
        {   
            ((App)Application.Current).Conexao.Execute("delete from Consumidor where id = ? or nome = ? ", ID_Consumidor.Text,ID_Consumidor.Text);
            CarregarInformacoes();
            DisplayAlert("Exclusão", "Cliente Excluido com sucesso!", "OK");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrudApp
{
    
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<Model.Pessoa> Lista;
        
        public MainPage()
		{

			InitializeComponent();

            BindingContext = new Model.Pessoa();
            
            
        }
        //Chamar página de Lista Ordenada
        public void Sort(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PaginaOrdenada.Ordenada());

        }
        //Chamar página de Lista
        public void Consultar(object sender,EventArgs args) {

            Navigation.PushModalAsync(new PaginaConsulta.Consultar());
        }


     //Chamar página para inserção
        private async void Adicionar(object sender, EventArgs e)
        {
            
           await Navigation.PushModalAsync(new PaginaInserir.Inserir());
            
        }
        //chamar página de Consulta por ID
        public void Pesquisar(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PaginaConsultar_id.Consultar_id());

        }

        //chamar página de Exclusão
        public void Excluir( object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new PaginaExclusao.Exclusao());

        }

        //Método para fechar a aplicação
        public void Sair(object sender, EventArgs args)
        {

            System.Environment.Exit(0);

        }


      
    }
}

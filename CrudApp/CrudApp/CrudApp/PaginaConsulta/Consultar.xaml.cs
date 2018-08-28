using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace CrudApp.PaginaConsulta
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consultar : ContentPage
    {
        public ObservableCollection<Model.Pessoa> Lista { get; set; }
        public Consultar()
        {
            InitializeComponent();

            BindingContext = new Model.Pessoa();
            CarregarInformacoes();

        }


        public void CarregarInformacoes()
        {

            //Exibir informções da tabela
            Lista = new ObservableCollection<Model.Pessoa>(((App)Application.Current).Conexao.Query<Model.Pessoa>("select * from Consumidor"));
            Myview.ItemsSource = Lista;

        }


        //retorno para MainPage
        public void voltar(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();

        }

        //Exclusão de todos os dados da tabela
        private void ApagarTudo(object sender, EventArgs e)
        {
            ((App)Application.Current).Conexao.Execute("delete from Consumidor");
            
           
            DisplayAlert("Exclusão", "Clientes Excluidos com sucesso!", "OK");

            CarregarInformacoes();
            
        }
        //Método apagar do Menu Item
        private void MenuItemApagar(object sender, EventArgs e)
        {

            var mi = (MenuItem)sender;
            var model = (Model.Pessoa)mi.CommandParameter;
            ((App)Application.Current).Conexao.Execute("delete from Consumidor where id = ?", model.id);
            
            CarregarInformacoes();
            DisplayAlert("Exclusão", "Cliente Excluido com sucesso!", "OK");
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrudApp.PaginaInserir
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inserir : ContentPage
    {
        

        public Inserir()
        {
            InitializeComponent();

        }
        //inserir pessoa
        private async void Salvar(object sender, EventArgs args)
        {
            
            //cálculo da idade
            int data = DateTime.Today.Year - Nascimento.Date.Year;
           //inserção do Cliente
            ((App)Application.Current).Conexao.Execute($"insert into Consumidor (nome,email,telefone,nascimento) values ('{Nome.Text}','{Emai.Text}','{Telefone.Text}','{data}')");
         
            await Navigation.PopModalAsync();

        }
        
        }
    }

using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.ComponentModel;

namespace CrudApp.Model
{
  public  class Pessoa:INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string Email { get; set; }
        public int Nascimento { get; set; }

        //informação a ser exibida no Text da listview
        public string Informacao {
            get { return $"ID:{id}, Nome:{Nome},Telefone:{Telefone}"; } }

        //Informação a ser exibida na Detail da listviw
        public string Informacao2
        {
            get { return $"Email:{Email}, {Nascimento} anos"; }
        }
        public string Informacao3
        {
            get { return $"ID:{id}, Nome:{Nome}"; }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void Propriedade(string Nome_propriedade)
        {

            if(PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(Nome_propriedade));
            }
        }
    }
}


    
    



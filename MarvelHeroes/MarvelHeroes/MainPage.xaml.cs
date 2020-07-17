using MarvelHeroesNew.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarvelHeroes
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.LoadAsync();
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.ExibirPersonagemCommand.Execute(e.SelectedItem);
        }
    }
}

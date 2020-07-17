using MarvelHeroes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MarvelHeroes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetalhesPage : ContentPage
	{
        private DetalhesViewModel ViewModel => BindingContext as DetalhesViewModel;
        public DetalhesPage ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await ViewModel.LoadAsync();
        }
	}
}
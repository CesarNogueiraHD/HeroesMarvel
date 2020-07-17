using MarvelHeroes.ViewModels;
using MarvelHeroesNew.Models;
using MarvelHeroesNew.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MarvelHeroesNew.ViewModels
{
    class MainViewModel: BaseViewModel
    {
        public ObservableCollection<Personagem> Personagens { get; }
        public Command<Personagem> ExibirPersonagemCommand { get; }

        private MarvelApiService _marvelApiService;

        public MainViewModel()
        {
            Titulo = "Herois Marvel";
            Personagens = new ObservableCollection<Personagem>();
            ExibirPersonagemCommand = new Command<Personagem>(ExecuteExibirPersonagemCommand);
            _marvelApiService = new MarvelApiService();
        }

        private async void ExecuteExibirPersonagemCommand(Personagem personagem)
        {
            await Navigation.PushAsync<DetalhesViewModel>(false, personagem);
        }

        public override async Task LoadAsync()
        {
            Ocupado = true;
            try
            {
                var personagens = await _marvelApiService.GetPersonagensAsync();

                Personagens.Clear();

                foreach (var personagem in personagens)
                {
                    Personagens.Add(personagem);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Erro", e);
            }
            finally
            {
                Ocupado = false;
            }
        }
    }
}
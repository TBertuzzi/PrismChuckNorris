using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismChuckNorris.Models;
using PrismChuckNorris.Services;

namespace PrismChuckNorris.ViewModels
{
    public class JokeViewModel : ViewModelBase
    {
        private Joke _joke;
        public Joke Joke
        {
            get => _joke;
            set => SetProperty(ref _joke, value);
        }

        IChuckNorrisService _chuckNorrisService;

        private DelegateCommand getJokeCommand;
        public DelegateCommand GetJokeCommand => getJokeCommand ?? (getJokeCommand = new DelegateCommand(async () => await GetJokeCommandExecute(), () => !IsBusy));

  
        protected JokeViewModel(INavigationService navigationService, 
            IPageDialogService pageDialogService, IChuckNorrisService chuckNorrisService) : base(navigationService, pageDialogService)
        {
            Title = "Joke Random";

            _chuckNorrisService = chuckNorrisService;
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            await LoadAsync();
        }

        private async Task LoadAsync()
        {
            try
            {
                IsBusy = true;

                Joke = await _chuckNorrisService.GetRandomJoke();
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Erro ao Carregar piada:" + ex.Message, "OK");
            }
            finally
            {

                IsBusy = false;
            }
        }

        private async Task GetJokeCommandExecute()
        {
            await LoadAsync();
        }

    }
}

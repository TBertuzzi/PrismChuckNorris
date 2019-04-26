using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismChuckNorris.Models;
using PrismChuckNorris.Services;

namespace PrismChuckNorris.ViewModels
{

    public class JokeCategoryViewModel : ViewModelBase
    {
        private Joke _joke;
        public Joke Joke
        {
            get => _joke;
            set => SetProperty(ref _joke, value);
        }

        private string _category;
        public string Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        IChuckNorrisService _chuckNorrisService;

        private DelegateCommand getJokeCommand;
        public DelegateCommand GetJokeCommand => getJokeCommand ?? (getJokeCommand = new DelegateCommand(async () => await GetJokeCommandExecute(), () => !IsBusy));

        protected JokeCategoryViewModel(INavigationService navigationService, 
            IPageDialogService pageDialogService, IChuckNorrisService chuckNorrisService) : base(navigationService, pageDialogService)
        {
            Title = "Joke";

            _chuckNorrisService = chuckNorrisService;
        }

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {

            if (parameters.ContainsKey("category"))
            {
                Category =  parameters["category"].ToString();

                await LoadJokeAsync(Category);
            }
        }

        private async Task LoadJokeAsync(string category)
        {
            try
            {
                IsBusy = true;

                Joke = await _chuckNorrisService.GetJokeByCategory(category);
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
            await LoadJokeAsync(Category);
        }
    }

   
}

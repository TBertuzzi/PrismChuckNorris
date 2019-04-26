using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using PrismChuckNorris.Services;

namespace PrismChuckNorris.ViewModels
{
    public class CategoriesViewModel : ViewModelBase
    {
        public ObservableCollection<string> Categories { get; }

        IChuckNorrisService _chuckNorrisService;

        private DelegateCommand<string> showJokeCommand;
        public DelegateCommand<string> ShowJokeCommand => showJokeCommand ?? (showJokeCommand = new DelegateCommand<string>(async (itemSelect) => await ExecuteShowJokeCommandd(itemSelect), (itemSelect) => !IsBusy));


        protected CategoriesViewModel(INavigationService navigationService, 
            IPageDialogService pageDialogService, IChuckNorrisService chuckNorrisService) : base(navigationService, pageDialogService)
        {
            Title = "Categories";

            Categories = new ObservableCollection<string>();

            _chuckNorrisService = chuckNorrisService;

            //IsActiveChanged += HandleIsActiveTrue;
            //IsActiveChanged += HandleIsActiveFalse; 
        }

        //private async void HandleIsActiveTrue(object sender, EventArgs args)
        //{
        //    if (IsActive == false) return;

        //    await LoadAsync();
        //}

        //private void HandleIsActiveFalse(object sender, EventArgs args)
        //{
        //    if (IsActive == true) return;
        //}

        //public override void Destroy()
        //{
        //    IsActiveChanged -= HandleIsActiveTrue;
        //    IsActiveChanged -= HandleIsActiveFalse;
        //}

        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            await LoadAsync();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var navigationMode = parameters.GetNavigationMode();
            if (navigationMode == NavigationMode.Back)
            {
                Console.Write("Voltei!");
                return;
            }
            else
            {
                Console.Write("Navegando para");
            }

        }

        private async Task LoadAsync()
        {
            try
            {
                IsBusy = true;

                var categoriesApi = await _chuckNorrisService.GetCategories();

                Categories.Clear();

                foreach (var categorie in categoriesApi)
                {
                    Categories.Add(categorie);
                }

            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Erro ao Carregar categorias:" + ex.Message, "OK");
            }
            finally
            {

                IsBusy = false;
            }
        }

        private async Task ExecuteShowJokeCommandd(string category)
        {
            var navigationParams = new NavigationParameters
            {
                {"category", category}
            };


            await NavigationService.NavigateAsync("JokeCategoryPage", navigationParams);
        }

    }
}

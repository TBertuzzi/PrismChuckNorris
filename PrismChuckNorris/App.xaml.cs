using System;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using PrismChuckNorris.Services;
using PrismChuckNorris.ViewModels;
using PrismChuckNorris.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismChuckNorris
{
    public partial class App : PrismApplication
    {
        public App()
            : this(null)
        {

        }

        public App(IPlatformInitializer initializer)
            : this(initializer, true)
        {

        }

        public App(IPlatformInitializer initializer, bool setFormsDependencyResolver)
            : base(initializer, setFormsDependencyResolver)
        {

        }


        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/MenuPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CustomNavigationPage>();


            containerRegistry.RegisterForNavigation<MenuPage, MenuViewModel>();
            containerRegistry.RegisterForNavigation<CategoriesPage,CategoriesViewModel>();
            containerRegistry.RegisterForNavigation<JokePage, JokeViewModel>();
            containerRegistry.RegisterForNavigation<JokeCategoryPage, JokeCategoryViewModel>();


            containerRegistry.RegisterSingleton<IChuckNorrisService, ChuckNorrisService>();
        }
    }
}

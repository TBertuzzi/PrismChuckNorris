using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace PrismChuckNorris
{
    public partial class MenuPage : TabbedPage
    {
        public MenuPage()
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            Children.Add(new CustomNavigationPage(new JokePage()));
            Children.Add(new CustomNavigationPage(new CategoriesPage()));
        }
    }
}

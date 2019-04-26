using System;
using Xamarin.Forms;

namespace PrismChuckNorris
{
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage(Page root) : base(root)
        {
            Title = root.Title;
            Icon = root.Icon;
        }

        public CustomNavigationPage()
        {
           
        }


    }
}

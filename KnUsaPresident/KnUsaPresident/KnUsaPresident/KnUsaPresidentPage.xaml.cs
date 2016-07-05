using System;
using System.Collections.Generic;
using System.Linq;
using KnUsaPresident.Models;
using Xamarin.Forms;

namespace KnUsaPresident
{
    public partial class KnUsaPresidentPage : ContentPage
    {
        public KnUsaPresidentPage()
        {
            InitializeComponent();

            listViewPresidents.ItemsSource = getPresidentList();
        }

        private IList<President> getPresidentList()
        {
            return PresidentService.GetPresidentList();
        }

        public void Search(object sender, EventArgs e)
        {
            var pl = new President();
            var items = pl.PresidentList;
            var key = entrySearch.Text;

            items = (nameBehavior.IsChecked
                        ? items = PresidentService.Search(key, "Name")
                        : termBehavior.IsChecked ? items = PresidentService.Search(key, "Term") : items = PresidentService.Search(key, "Party")
                     )
                     .OrderByDescending(x => x.Id)
                     .ToList();

            listViewPresidents.ItemsSource = items;
        }
    }
}


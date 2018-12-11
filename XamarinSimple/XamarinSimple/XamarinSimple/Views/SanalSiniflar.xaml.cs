using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinUcuncuHafta.Data;

namespace XamarinUcuncuHafta.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SanalSiniflar : ContentPage
	{
		public SanalSiniflar ()
		{
			InitializeComponent ();
            lstMVA.BindingContext = MVAFactory.BindingWithGrouping()    ;
            lstMVA.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command=new Command(async (t)=>
                {
                    await lstMVA.ScaleTo(95, 100, Easing.CubicInOut);
                    await lstMVA.ScaleTo(1, 50, Easing.CubicIn);
                }
                )
            });
		}
        private async void onSelected(object sender,SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem==null)
            {
                return;
            }
            ListView lw = (ListView)sender;
            var selectedMVA = (MVAFactory.MVA)e.SelectedItem;
           bool isOk=await DisplayAlert(selectedMVA.PublishDate.ToString("yyyy-MM-dd")
                +" " +selectedMVA.Title, selectedMVA.Description,"Detay","Vazgeç");

            if (isOk)
            {
                Navigation.PushAsync(new Detail(selectedMVA));
                Navigation.PushModalAsync(new Detail(selectedMVA));
            }


            lw.SelectedItem = null;
        }
        private void onRefreshing(object sender,EventArgs e)
        {
            DisplayAlert("Refresh","Oldu","Tamam");
            lstMVA.IsRefreshing = false;
        }

        private void onTextChanged(object sender,TextChangedEventArgs e)
        {
            if (e.NewTextValue.Length>3)
            {
                lstMVA.BindingContext = MVAFactory.BindingWithGrouping(e.NewTextValue);
            }
            else if (string.IsNullOrEmpty(e.NewTextValue))
            {
                lstMVA.BindingContext = MVAFactory.BindingWithGrouping();
            }
        }

        private void onMenuItemClicked(object sender,EventArgs e)
        {
            DisplayAlert("Güncelle", "Menu Item", "Tamam","Vazgeç");
        }
	}
}
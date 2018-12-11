using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinUcuncuHafta.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]


    public class AcikAkademi
    {
        public int ID { get; set; }
        public string NAME  { get; set; }
    }
	public partial class ListViewOrnek : ContentPage
	{
		public ListViewOrnek ()
		{
			InitializeComponent ();
            List<AcikAkademi> akademi = new List<AcikAkademi>();
            akademi.Add(new AcikAkademi { ID = 1, NAME = "YİĞİT" });
            akademi.Add(new AcikAkademi { ID = 2, NAME = "Mustafa" });
            akademi.Add(new AcikAkademi { ID = 3, NAME = "Aydın" });
            //lstView.ItemsSource = akademi;
            BindingContext = akademi;

        }
        private void onSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem==null)
            {
                return;
            }
            AcikAkademi selected = (AcikAkademi)e.SelectedItem;
            DisplayAlert("Açık Akademi", selected.NAME,"OK");
            ListView lst = (ListView)sender;
            lst.SelectedItem=null;
        }
        private void onClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            DisplayAlert("Button", btn.CommandParameter.ToString(),"OK");
        }
	}
}
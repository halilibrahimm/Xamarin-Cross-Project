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
	public partial class Detail : ContentPage
	{
		public Detail (MVAFactory.MVA selected)
		{

			InitializeComponent ();
            lblTitle.Text = selected.Title;
            lblDescription.Text = selected.Description;
		}
	}
}
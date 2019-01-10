using CobaHitAPI.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CobaHitAPI.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            entryName.Completed += BtnCheck_Clicked;
        }

        private async void BtnCheck_Clicked(object sender, EventArgs e)
        {
            try
            {
                aiBusy.IsRunning = true;
                Models.User result = await RestService.For<IGitHubAPI>("https://api.github.com").GetUser(entryName.Text);

                imgUser.Source = result?.avatar_url;
                lblName.Text = result?.name ?? "nama tidak tersedia";

                var gesture = new TapGestureRecognizer();
                gesture.Tapped += (s, ev) => Device.OpenUri(new Uri(result.html_url, UriKind.Absolute));
                var span = new Span { Text = result.html_url, TextDecorations = TextDecorations.Underline, TextColor = Color.Blue };
                span.GestureRecognizers.Add(gesture);
                var fstr = new FormattedString();
                fstr.Spans.Add(span);
                lblUrl.FormattedText = fstr;
            }
            catch (Exception exc)
            {
                await App.Current.MainPage.DisplayAlert("Error", exc.Message, "OKE");
            }
            finally
            {
                aiBusy.IsRunning = false;
            }
        }
    }
}

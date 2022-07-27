using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrimeiroApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        private void btnVerificar_Clicked(object sender, EventArgs e)
        {
            string texto = $"O nome tem {txtNome.Text.Length} caracteres";
            DisplayAlert("Mensagem", texto, "Ok");
        }

        private void DisplayAlert(string v1, string texto, string v2)
        {
            throw new NotImplementedException();
        }

        private async void btnLimpar_Clicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Pergunta","Deseja realmente limpar a tela?", "Yes", "No"))
            {
                txtNome.Text = string.Empty;
                btnCliqueAqui.Text = "Clique Aqui";
            }
                    }

        private Task<bool> DisplayAlert(string v1, string v2, string v3, string v4)
        {
            throw new NotImplementedException();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

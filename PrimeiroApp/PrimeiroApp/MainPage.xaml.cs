using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PrimeiroApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        int count = 0;
        private void btnCliqueAqui_Clicked(object sender, EventArgs e)
        {
            count++;
            ((Button)sender).Text = " Você clicou " + count.ToString() + "Vezes";


        }

        private void btnVerificar_Clicked(object sender, EventArgs e)
        {
            string texto = $"O nome tem {txtNome.Text.Length} caracteres";
            DisplayAlert("Mensagem", texto, "Ok");
        }



        private async void btnLimpar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Pergunta", "Deseja realmente limpar a tela?", "Yes", "No"))
            {
                txtNome.Text = string.Empty;
                btnCliqueAqui.Text = "Clique Aqui";
            }
        }

        private async void btnInformarDataNascimento_Clicked(object sender, EventArgs e)
        {
            try
            {
                String dataDigitada = await DisplayPromptAsync("Info", "Digite a data de nascimento", "Ok");

                DateTime dataConvertida;

                //Converte data para Brasil new "CultureInfo("pt-BR"), DateTimeStyles.None"

                bool converteu = DateTime.TryParse(dataDigitada, new CultureInfo("pt-BR"), DateTimeStyles.None, out dataConvertida);

                //if(!converteu)

                if (converteu == false)
                {
                    throw new Exception("Está data não é valida");
                }

                else
                {   //Retorna a um double com (int)
                    lblDataNascimento.Text = String.Format("{0:dd/MM/yyyy}", dataConvertida);
                    int diasVividos = (int)DateTime.Now.Subtract(dataConvertida).TotalDays;
                    await DisplayAlert("Info", $"Você já viveu {diasVividos}.", "Ok");
                }
            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");
            }
        }

        private async void btnOpcoes_Clicked(object sender, EventArgs e)
        {
            try
            {      //Se está digitando o que é necessário 

                if (string.IsNullOrEmpty(lblDataNascimento.Text))
                    throw new Exception("Informar a data de nascimento");
                else
                {
                    DateTime dtNascimento = Convert.ToDateTime(lblDataNascimento.Text, new CultureInfo("pt-BR"));

                    string resposta = await DisplayActionSheet("Pergunta", "Selecione uma Opcao", "Cancelar", "Saber o dia da semana", "Saber o dia do mês", "Saber o dia do ano");


                    if (resposta == "Saber o dia da semana")
                    {
                        string msg = $"Você nasceu no(a) {dtNascimento.DayOfWeek}";
                        await DisplayAlert("Info", msg, "Ok");

                    }
                    else if (resposta == "Saber o dia do mês")
                    {
                        string msg = $"Você nasceu no(a) {dtNascimento.Day}";
                        await DisplayAlert("Info", msg, "Ok");

                    }
                    else if (resposta == "Saber o dia do ano")
                    {
                        string msg = $"Você nasceu no(a) {dtNascimento.DayOfYear}º no ano";
                        await DisplayAlert("Info", msg, "Ok");
                    }
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message + ex.InnerException, "Ok");

            }

        }
    }
}

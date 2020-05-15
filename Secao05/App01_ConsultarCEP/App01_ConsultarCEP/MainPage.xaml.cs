using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;


namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            //TO DO - Lógica do Programa

            //TO DO - Validações

            string Cep = cep.Text.Trim();
            if (isValidCEP(Cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscaEnderecoViaCEP(Cep);

                    if(end != null)
                    {
                        Resultado.Text = string.Format("Endereço: " + end.Logradouro + ", " + end.Bairro + ", "
                                                                + end.Localidade + ", " + end.Uf + ", " + end.CEP);
                    }
                    else
                    {
                        DisplayAlert("ERRO!", "Endereço não encontrado para o CEP: " + Cep, "Ok");
                    }

                    
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO!", e.Message, "Ok");
                }
            }
        }

        private bool isValidCEP(string Cep)
        {
            if (Cep.Length != 8)
            {
                //ERRO
                DisplayAlert("ERRO!", "CEP Inválido! \nO CEP deve conter 8 números", "Ok");
                return false;
            }
            int C = 0;
            if (!int.TryParse(Cep, out C))
            {
                //ERRO
                DisplayAlert("ERRO!", "CEP Inválido! \nDigite apenas os números", "Ok");
                return false;
            }

         return true;
        }
}
}

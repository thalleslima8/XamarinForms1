using System;
using System.Collections.Generic;
using System.Text;
using App01_ConsultarCEP.Servico.Modelo;
using System.Net;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscaEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient WC = new WebClient();
            string Conteudo = WC.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if(end.CEP == null) return null;
            

            return end;
        }
    }   
}

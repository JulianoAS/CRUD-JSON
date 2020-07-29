using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Layers.DTO;
using Layers.DAL;

namespace Layers.BLL
{

    public class PessoaBll
    {

        public long Incluir(Pessoa pessoa)
        {

            PessoaDal _DaoPessoa = new PessoaDal();
            return _DaoPessoa.Incluir(pessoa);
        }

        public void Atualizar(Pessoa pessoa)
        {
            PessoaDal _DaoPessoa = new PessoaDal();
            _DaoPessoa.Atualizar(pessoa);
        }

        public List<Pessoa> ListPessoa()
        {
            PessoaDal _DaoPessoa = new PessoaDal();
            return _DaoPessoa.ListPessoa();
        }       
        public void Deletar(long id)
        {
            PessoaDal _DaoPessoa = new PessoaDal();
            _DaoPessoa.Deletar(id);
        }

        public Pessoa LerPessoa(long id)
        {
            PessoaDal _DaoPessoa = new PessoaDal();
            return _DaoPessoa.LerPessoa(id);

        }

        public bool CpfValidar(string CPF)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");
            if (CPF.Length != 11 || CPF == "00000000000" || CPF == "11111111111" || CPF == "22222222222" || CPF == "33333333333" || CPF == "44444444444" || CPF == "55555555555" || CPF == "66666666666" || CPF == "77777777777" || CPF == "88888888888" || CPF == "99999999999")
                return false;
            tempCpf = CPF.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return CPF.EndsWith(digito);
        }
    }

}


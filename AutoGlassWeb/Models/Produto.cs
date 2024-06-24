using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace AutoGlass.Model
{
    public class Produto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; } // Ativo ou Inativo
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public int? CNPJFornecedor { get; set; }

        public string Validar()
        {
            if (string.IsNullOrEmpty(this.Codigo))
            {
                return ("Código deve ser preenchido");
            }
            if (string.IsNullOrEmpty(this.Descricao))
            {
                return ("Código deve ser preenchido");
            }
            return "";
        }
    }
    public enum StatusEnum
    {
        Ativo = 1,
        Inativo = 0

    }
}

namespace OrtosleepApi.Models
{
    public class CalculoPrecificacaoRequest
    {
        public int ProdutoId { get; set; }
        public decimal PercentualAumento { get; set; }
        public decimal PercentualDesconto { get; set; }
        public bool UsarPrecoAVista { get; set; } = true;
    }

    public class CalculoPrecificacaoResponse
    {
        public Produto Produto { get; set; } = new();
        public decimal CustoBase { get; set; }
        public decimal PercentualAumento { get; set; }
        public decimal PercentualDesconto { get; set; }
        public decimal PrecoVendaSemDesconto { get; set; }
        public decimal PrecoVendaComDesconto { get; set; }
        public decimal ValorDesconto { get; set; }
        public decimal MargemLucro { get; set; }
        public decimal LucroEmReais { get; set; }
        public string TipoPreco { get; set; } = string.Empty;
    }
}
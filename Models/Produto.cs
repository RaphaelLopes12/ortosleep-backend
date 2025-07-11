namespace OrtosleepApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Categoria { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public decimal CustoAVista { get; set; }
        public decimal CustoAPrazo { get; set; }
    }
}
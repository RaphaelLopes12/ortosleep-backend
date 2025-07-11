// Services/PrecificacaoService.cs - Versão com busca inteligente
using OrtosleepApi.Models;
using OrtosleepApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace OrtosleepApi.Services
{
    public interface IPrecificacaoService
    {
        Task<List<Produto>> BuscarProdutosAsync(string? termoBusca = null);
        Task<CalculoPrecificacaoResponse?> CalcularPrecificacaoAsync(CalculoPrecificacaoRequest request);
    }

    public class PrecificacaoService : IPrecificacaoService
    {
        private readonly AppDbContext _context;

        public PrecificacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Produto>> BuscarProdutosAsync(string? termoBusca = null)
        {
            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(termoBusca))
            {
                var termoLimpo = LimparTermoBusca(termoBusca);
                var termoUpper = termoLimpo.ToUpper();

                query = query.Where(p => 
                    p.Nome.ToUpper().Contains(termoUpper) ||
                    p.Categoria.ToUpper().Contains(termoUpper)
                );

                var palavras = termoLimpo.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (palavras.Length > 1)
                {
                    foreach (var palavra in palavras)
                    {
                        var palavraUpper = palavra.ToUpper();
                        query = query.Where(p => 
                            p.Nome.ToUpper().Contains(palavraUpper) ||
                            p.Categoria.ToUpper().Contains(palavraUpper)
                        );
                    }
                }
            }

            return await query
                .OrderBy(p => p.Categoria)
                .ThenBy(p => p.Nome)
                .Take(50)
                .ToListAsync();
        }

        public async Task<CalculoPrecificacaoResponse?> CalcularPrecificacaoAsync(CalculoPrecificacaoRequest request)
        {
            var produto = await _context.Produtos.FindAsync(request.ProdutoId);
            if (produto == null) return null;

            var custoBase = request.UsarPrecoAVista ? produto.CustoAVista : produto.CustoAPrazo;
            
            var precoVendaSemDesconto = custoBase * (1 + request.PercentualAumento / 100);
            
            var valorDesconto = precoVendaSemDesconto * (request.PercentualDesconto / 100);
            var precoVendaComDesconto = precoVendaSemDesconto - valorDesconto;
            
            var lucroEmReais = precoVendaComDesconto - custoBase;
            var margemLucro = custoBase > 0 ? (lucroEmReais / custoBase) * 100 : 0;

            return new CalculoPrecificacaoResponse
            {
                Produto = produto,
                CustoBase = custoBase,
                PercentualAumento = request.PercentualAumento,
                PercentualDesconto = request.PercentualDesconto,
                PrecoVendaSemDesconto = precoVendaSemDesconto,
                PrecoVendaComDesconto = precoVendaComDesconto,
                ValorDesconto = valorDesconto,
                MargemLucro = margemLucro,
                LucroEmReais = lucroEmReais,
                TipoPreco = request.UsarPrecoAVista ? "À Vista" : "À Prazo"
            };
        }

        private string LimparTermoBusca(string termo)
        {
            if (string.IsNullOrEmpty(termo)) return string.Empty;
            
            var termoLimpo = termo
                .Replace("ç", "c")
                .Replace("ã", "a")
                .Replace("á", "a")
                .Replace("à", "a")
                .Replace("â", "a")
                .Replace("é", "e")
                .Replace("ê", "e")
                .Replace("í", "i")
                .Replace("ó", "o")
                .Replace("ô", "o")
                .Replace("õ", "o")
                .Replace("ú", "u")
                .Replace("ü", "u");
            
            termoLimpo = Regex.Replace(termoLimpo, @"[^\w\s]", " ");
            
            termoLimpo = Regex.Replace(termoLimpo, @"\s+", " ").Trim();
            
            return termoLimpo;
        }
    }
}
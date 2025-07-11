using Microsoft.EntityFrameworkCore;
using OrtosleepApi.Models;

namespace OrtosleepApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.CustoAVista)
                      .HasPrecision(10, 2);
                      
                entity.Property(e => e.CustoAPrazo)
                      .HasPrecision(10, 2);
                      
                entity.Property(e => e.Nome)
                      .HasMaxLength(200)
                      .IsRequired();
                      
                entity.Property(e => e.Categoria)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.HasIndex(e => e.Categoria);
                entity.HasIndex(e => e.Nome);
            });

            SeedProdutos(modelBuilder);
        }

        private void SeedProdutos(ModelBuilder modelBuilder)
        {
            var produtos = new List<Produto>
            {
                // CABECEIRAS
                new Produto { Id = 1, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 0,88X - CAPITONE - RETA / CURVADA", CustoAVista = 184.00m, CustoAPrazo = 196.00m },
                new Produto { Id = 2, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 1,08X - CAPITONE - RETA / CURVADA", CustoAVista = 228.00m, CustoAPrazo = 244.00m },
                new Produto { Id = 3, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 1,38X - CAPITONE - RETA / CURVADA", CustoAVista = 228.00m, CustoAPrazo = 244.00m },
                new Produto { Id = 4, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 1,58X - CAPITONE - RETA / CURVADA", CustoAVista = 275.00m, CustoAPrazo = 294.00m },
                new Produto { Id = 5, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 1,93X - CAPITONE - RETA / CURVADA", CustoAVista = 298.00m, CustoAPrazo = 318.00m },
                new Produto { Id = 6, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 0,88X - SLIM", CustoAVista = 184.00m, CustoAPrazo = 196.00m },
                new Produto { Id = 7, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 1,08X - SLIM", CustoAVista = 228.00m, CustoAPrazo = 244.00m },
                new Produto { Id = 8, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 1,38X - SLIM", CustoAVista = 228.00m, CustoAPrazo = 244.00m },
                new Produto { Id = 9, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 1,58X - SLIM", CustoAVista = 275.00m, CustoAPrazo = 294.00m },
                new Produto { Id = 10, Categoria = "Cabeceiras", Nome = "CABEÇEIRA 1,93X - SLIM", CustoAVista = 298.00m, CustoAPrazo = 318.00m },

                // BASES
                new Produto { Id = 11, Categoria = "Bases", Nome = "BASE 0,88X - TECIDO DALLAS", CustoAVista = 130.00m, CustoAPrazo = 138.00m },
                new Produto { Id = 12, Categoria = "Bases", Nome = "BASE 1,08X - TECIDO DALLAS", CustoAVista = 142.00m, CustoAPrazo = 151.00m },
                new Produto { Id = 13, Categoria = "Bases", Nome = "BASE 1,38X - TECIDO DALLAS", CustoAVista = 164.00m, CustoAPrazo = 175.00m },
                new Produto { Id = 14, Categoria = "Bases", Nome = "BASE 1,58X - TECIDO DALLAS", CustoAVista = 180.00m, CustoAPrazo = 192.00m },
                new Produto { Id = 15, Categoria = "Bases", Nome = "BASE 1,93X - TECIDO DALLAS", CustoAVista = 205.00m, CustoAPrazo = 219.00m },
                new Produto { Id = 16, Categoria = "Bases", Nome = "BASE 0,88X - CORINO", CustoAVista = 155.00m, CustoAPrazo = 165.00m },
                new Produto { Id = 17, Categoria = "Bases", Nome = "BASE 1,08X - CORINO", CustoAVista = 195.00m, CustoAPrazo = 207.00m },
                new Produto { Id = 18, Categoria = "Bases", Nome = "BASE 1,38X - CORINO", CustoAVista = 224.00m, CustoAPrazo = 238.00m },
                new Produto { Id = 19, Categoria = "Bases", Nome = "BASE 1,58X - CORINO", CustoAVista = 254.00m, CustoAPrazo = 270.00m },
                new Produto { Id = 20, Categoria = "Bases", Nome = "BASE 1,93X - CORINO", CustoAVista = 312.00m, CustoAPrazo = 332.00m },

                // COLCHÕES SLEEP MAX
                new Produto { Id = 21, Categoria = "Colchões Sleep Max", Nome = "COLCHÃO SLEEP MAX 0,88X - MOLA POCKET - ALT 34CM", CustoAVista = 435.00m, CustoAPrazo = 474.00m },
                new Produto { Id = 22, Categoria = "Colchões Sleep Max", Nome = "COLCHÃO SLEEP MAX 1,08X - MOLA POCKET - ALT 34CM", CustoAVista = 507.00m, CustoAPrazo = 553.00m },
                new Produto { Id = 23, Categoria = "Colchões Sleep Max", Nome = "COLCHÃO SLEEP MAX 1,38X - MOLA POCKET - ALT 34CM", CustoAVista = 652.00m, CustoAPrazo = 711.00m },
                new Produto { Id = 24, Categoria = "Colchões Sleep Max", Nome = "COLCHÃO SLEEP MAX 1,58X - MOLA POCKET - ALT 34CM", CustoAVista = 740.00m, CustoAPrazo = 807.00m },
                new Produto { Id = 25, Categoria = "Colchões Sleep Max", Nome = "COLCHÃO SLEEP MAX 1,93X - MOLA POCKET - ALT 34CM", CustoAVista = 918.00m, CustoAPrazo = 1001.00m },

                // COLCHONETES D-20
                new Produto { Id = 26, Categoria = "Colchonetes", Nome = "COLCHONETE 0,78X (4CM) D-20", CustoAVista = 56.00m, CustoAPrazo = 60.00m },
                new Produto { Id = 27, Categoria = "Colchonetes", Nome = "COLCHONETE 0,88X (4CM) D-20", CustoAVista = 64.00m, CustoAPrazo = 68.00m },
                new Produto { Id = 28, Categoria = "Colchonetes", Nome = "COLCHONETE 1,08X (4CM) D-20", CustoAVista = 74.00m, CustoAPrazo = 79.00m },
                new Produto { Id = 29, Categoria = "Colchonetes", Nome = "COLCHONETE 1,38X (4CM) D-20", CustoAVista = 96.00m, CustoAPrazo = 102.00m },

                // COLCHÕES ATLANTA
                new Produto { Id = 30, Categoria = "Colchões Atlanta", Nome = "COLCHÃO ATLANTA D-28 ESPUMA - 0,88X - ALT 30CM", CustoAVista = 342.00m, CustoAPrazo = 372.00m },
                new Produto { Id = 31, Categoria = "Colchões Atlanta", Nome = "COLCHÃO ATLANTA D-28 ESPUMA - 1,38X - ALT 30CM", CustoAVista = 502.00m, CustoAPrazo = 547.00m },
                new Produto { Id = 32, Categoria = "Colchões Atlanta", Nome = "COLCHÃO ATLANTA D-28 ESPUMA - 1,58X - ALT 30CM", CustoAVista = 564.00m, CustoAPrazo = 615.00m },
                new Produto { Id = 33, Categoria = "Colchões Atlanta", Nome = "COLCHÃO ATLANTA D-28 ESPUMA - 1,93X - ALT 30CM", CustoAVista = 698.00m, CustoAPrazo = 761.00m },
                new Produto { Id = 34, Categoria = "Colchões Atlanta", Nome = "COLCHÃO ATLANTA D-28 ESPUMA - 0,78X - ALT 30CM", CustoAVista = 320.00m, CustoAPrazo = 349.00m },

                // COLCHÕES MAGNÉTICO
                new Produto { Id = 35, Categoria = "Colchões Magnético", Nome = "COLCHÃO MAGNÉTICO 0,88X - D-28", CustoAVista = 606.00m, CustoAPrazo = 656.30m },
                new Produto { Id = 36, Categoria = "Colchões Magnético", Nome = "COLCHÃO MAGNÉTICO 1,08X - D-28", CustoAVista = 811.00m, CustoAPrazo = 879.05m },
                new Produto { Id = 37, Categoria = "Colchões Magnético", Nome = "COLCHÃO MAGNÉTICO 1,38X - D-28", CustoAVista = 1222.86m, CustoAPrazo = 1293.15m },
                new Produto { Id = 38, Categoria = "Colchões Magnético", Nome = "COLCHÃO MAGNÉTICO 1,58X - D-28", CustoAVista = 1480.00m, CustoAPrazo = 1770.40m },
                new Produto { Id = 39, Categoria = "Colchões Magnético", Nome = "COLCHÃO MAGNÉTICO 1,93X - D-28", CustoAVista = 1760.00m, CustoAPrazo = 1879.45m },
                new Produto { Id = 40, Categoria = "Colchões Magnético", Nome = "COLCHÃO MAGNÉTICO 2,00X - D-28", CustoAVista = 2500.00m, CustoAPrazo = 2770.00m },

                // COLCHÕES SLEEP LIGHT D-20
                new Produto { Id = 41, Categoria = "Colchões Sleep Light", Nome = "COLCHÃO SLEEP LIGHT D-20 (12CM) 0,78X", CustoAVista = 126.00m, CustoAPrazo = 135.00m },
                new Produto { Id = 42, Categoria = "Colchões Sleep Light", Nome = "COLCHÃO SLEEP LIGHT D-20 (12CM) 0,88X", CustoAVista = 142.00m, CustoAPrazo = 151.00m },
                new Produto { Id = 43, Categoria = "Colchões Sleep Light", Nome = "COLCHÃO SLEEP LIGHT D-20 (12CM) 1,08X", CustoAVista = 164.00m, CustoAPrazo = 175.00m },
                new Produto { Id = 44, Categoria = "Colchões Sleep Light", Nome = "COLCHÃO SLEEP LIGHT D-20 (12CM) 1,38X", CustoAVista = 212.00m, CustoAPrazo = 226.00m },
                new Produto { Id = 45, Categoria = "Colchões Sleep Light", Nome = "COLCHÃO SLEEP LIGHT D-20 (12CM) 1,58X", CustoAVista = 238.00m, CustoAPrazo = 254.00m },
                new Produto { Id = 46, Categoria = "Colchões Sleep Light", Nome = "COLCHÃO SLEEP LIGHT D-20 (12CM) 1,93X", CustoAVista = 290.00m, CustoAPrazo = 310.00m },

                // COLCHÕES DALLAS D-33
                new Produto { Id = 47, Categoria = "Colchões Dallas", Nome = "COLCHÃO DALLAS D-33 - ALTURA (17CM) 0,88X - ESPUMA", CustoAVista = 230.00m, CustoAPrazo = 251.00m },
                new Produto { Id = 48, Categoria = "Colchões Dallas", Nome = "COLCHÃO DALLAS D-33 - ALTURA (17CM) 1,08X - ESPUMA", CustoAVista = 268.00m, CustoAPrazo = 293.00m },
                new Produto { Id = 49, Categoria = "Colchões Dallas", Nome = "COLCHÃO DALLAS D-33 - ALTURA (17CM) 1,38X - ESPUMA", CustoAVista = 345.00m, CustoAPrazo = 377.00m },
                new Produto { Id = 50, Categoria = "Colchões Dallas", Nome = "COLCHÃO DALLAS D-33 - ALTURA (17CM) 1,58X - ESPUMA", CustoAVista = 391.00m, CustoAPrazo = 427.00m },
                new Produto { Id = 51, Categoria = "Colchões Dallas", Nome = "COLCHÃO DALLAS D-33 - ALTURA (17CM) 1,93X - ESPUMA", CustoAVista = 485.00m, CustoAPrazo = 529.00m },

                // BASES BAÚS
                new Produto { Id = 52, Categoria = "Bases Baú", Nome = "BASE BAÚS 0,88X", CustoAVista = 434.00m, CustoAPrazo = 461.00m },
                new Produto { Id = 53, Categoria = "Bases Baú", Nome = "BASE BAÚS 1,08X", CustoAVista = 514.00m, CustoAPrazo = 482.00m },
                new Produto { Id = 54, Categoria = "Bases Baú", Nome = "BASE BAÚS 1,38X", CustoAVista = 564.00m, CustoAPrazo = 574.00m },
                new Produto { Id = 55, Categoria = "Bases Baú", Nome = "BASE BAÚS 1,58X", CustoAVista = 640.00m, CustoAPrazo = 689.00m },
                new Produto { Id = 56, Categoria = "Bases Baú", Nome = "BASE BAÚS 1,93X", CustoAVista = 918.00m, CustoAPrazo = 985.00m },

                // RECAMIERS
                new Produto { Id = 57, Categoria = "Recamiers", Nome = "RECAMIER 1,08M", CustoAVista = 184.00m, CustoAPrazo = 196.00m },
                new Produto { Id = 58, Categoria = "Recamiers", Nome = "RECAMIER 1,38M", CustoAVista = 228.00m, CustoAPrazo = 244.00m },
                new Produto { Id = 59, Categoria = "Recamiers", Nome = "RECAMIER 1,58M", CustoAVista = 275.00m, CustoAPrazo = 294.00m },
                new Produto { Id = 60, Categoria = "Recamiers", Nome = "RECAMIER 1,93M", CustoAVista = 298.00m, CustoAPrazo = 318.00m },

                // TRAVESSEIROS
                new Produto { Id = 61, Categoria = "Travesseiros", Nome = "TRAVESSEIRO 0,50M", CustoAVista = 33.00m, CustoAPrazo = 35.00m },
                new Produto { Id = 62, Categoria = "Travesseiros", Nome = "TRAVESSEIRO 0,60M", CustoAVista = 31.00m, CustoAPrazo = 33.00m },

                // ORTO BAÚ - DIVERSOS TAMANHOS
                new Produto { Id = 63, Categoria = "Orto Baú", Nome = "ORTO BAÚ - 40CM - BASE BAÚS 0,88X", CustoAVista = 614.00m, CustoAPrazo = 654.00m },
                new Produto { Id = 64, Categoria = "Orto Baú", Nome = "ORTO BAÚ - 40CM - BASE BAÚS 1,08X", CustoAVista = 774.00m, CustoAPrazo = 825.00m },
                new Produto { Id = 65, Categoria = "Orto Baú", Nome = "ORTO BAÚ - 40CM - BASE BAÚS 1,38X", CustoAVista = 914.00m, CustoAPrazo = 974.00m },
                new Produto { Id = 66, Categoria = "Orto Baú", Nome = "ORTO BAÚ - 30CM - BASE BAÚS 0,88X", CustoAVista = 572.00m, CustoAPrazo = 612.00m },
                new Produto { Id = 67, Categoria = "Orto Baú", Nome = "ORTO BAÚ - 30CM - BASE BAÚS 1,08X", CustoAVista = 732.00m, CustoAPrazo = 781.00m },
                new Produto { Id = 68, Categoria = "Orto Baú", Nome = "ORTO BAÚ - 30CM - BASE BAÚS 1,38X", CustoAVista = 872.00m, CustoAPrazo = 930.00m },

                // UNIBAÚ
                new Produto { Id = 69, Categoria = "Unibaú", Nome = "UNIBAÚ 0,88X", CustoAVista = 502.00m, CustoAPrazo = 538.00m },
                new Produto { Id = 70, Categoria = "Unibaú", Nome = "UNIBAÚ 1,08X", CustoAVista = 632.00m, CustoAPrazo = 676.00m }
            };

            modelBuilder.Entity<Produto>().HasData(produtos);
        }
    }
}
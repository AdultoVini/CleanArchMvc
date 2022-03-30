using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            //mb.Sql("INSERT INTO Categories(Name) " +
            //    "VALUES('Material escolar')");
            //mb.Sql("INSERT INTO Categories(Name) " +
            //    "VALUES('Instrumentos')");
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES('Caderno', 'Caderno espiral 100 foia', 7.45, 50, 'caderno.png', 1)");
            mb.Sql("INSERT INTO Products(Name, Description, Price, Stock, Image, CategoryId) " +
                "VALUES('Caderno diferenciado', 'Caderno espiral 100 foia diferenciadissimo', 7.45, 50, 'caderno.png', 1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}

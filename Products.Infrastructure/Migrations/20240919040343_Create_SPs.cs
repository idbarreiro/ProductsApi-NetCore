using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Products.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create_SPs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.InsertProduct
                    @Name NVARCHAR(max),
                    @Description NVARCHAR(max),
                    @Price DECIMAL(10, 2),
                    @Stock INT,
                    @Id INT OUTPUT
                AS
                BEGIN
                SET NOCOUNT ON;
                    INSERT INTO dbo.Products (Name, Description, Price, Stock)
                    VALUES (@Name, @Description, @Price, @Stock);

                    SELECT @Id = SCOPE_IDENTITY()
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.GetAllProducts
                AS
                BEGIN
                    SELECT *
                    FROM dbo.Products;
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.GetProductById
                    @Id INT
                AS
                BEGIN
                    SELECT *
                    FROM dbo.Products
                    WHERE Id = @Id;
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.UpdateProduct
                    @Id INT,
                    @Name NVARCHAR(100),
                    @Description NVARCHAR(255),
                    @Price DECIMAL(10, 2),
                    @Stock INT
                AS
                BEGIN
                    UPDATE dbo.Products
                    SET Name = @Name, Description = @Description, Price = @Price, Stock = @Stock
                    WHERE Id = @Id;
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE dbo.DeleteProduct
                    @Id INT
                AS
                BEGIN
                    DELETE FROM dbo.Products
                    WHERE Id = @Id;
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.InsertProduct");
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetAllProducts");
            migrationBuilder.Sql("DROP PROCEDURE dbo.GetProductById");
            migrationBuilder.Sql("DROP PROCEDURE dbo.UpdateProduct");
            migrationBuilder.Sql("DROP PROCEDURE dbo.DeleteProduct");
        }
    }
}

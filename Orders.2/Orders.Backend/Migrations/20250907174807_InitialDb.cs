using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        ///     que es lo que va a hacer esta migracion cuando yo la aplique a la base de datos
        ///     que significa up? up es cuando yo aplico la migracion a la base de datos
        ///     y que es protected override void ? es un metodo que se va a ejecutar cuando yo aplique
        ///     la migracion a la base de datos
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // crea una tabla llamada countries va tener dos columnas id y name la tabla id va ser de tipo entity framework
            // que va ser la llave primaria y va ser autoincremental y la columna name va ser de tipo nvarchar de 50 caracteres
            migrationBuilder.CreateTable(
                name: "Countries",
                //que es la linea de abajo que define las columnas como? la columna id y name
                columns: table => new
                {
                    /// que es table.column? es una columna de la tabla
                    /// que es<int> ? es el tipo de dato de la columna
                    /// entonces porque el type es int si ya le dije que es int? porque el type es el tipo de dato que
                    /// va a tener en la base de datos
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });
            // qie es crear un indice? es una estructura de datos que mejora la velocidad de las operaciones en una tabla
            /// que es migrationbuilder.createindex? es un metodo que crea un indice en una tabla
            /// una vez que yo cree el indice no me va a dejar crear dos paises con el mismo nombre
            /// que es ix
            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
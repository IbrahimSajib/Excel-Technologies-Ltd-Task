using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Patient_Information.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    AllergiesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergiesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.AllergiesId);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseasesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseasesName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseasesId);
                });

            migrationBuilder.CreateTable(
                name: "NCDs",
                columns: table => new
                {
                    NCDId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCDName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDs", x => x.NCDId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiseasesId = table.Column<int>(type: "int", nullable: false),
                    Epilepsy = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Diseases_DiseasesId",
                        column: x => x.DiseasesId,
                        principalTable: "Diseases",
                        principalColumn: "DiseasesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AllergiesDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AllergiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergiesDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllergiesDetails_Allergies_AllergiesId",
                        column: x => x.AllergiesId,
                        principalTable: "Allergies",
                        principalColumn: "AllergiesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllergiesDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NCD_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    NCDId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCD_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NCD_Details_NCDs_NCDId",
                        column: x => x.NCDId,
                        principalTable: "NCDs",
                        principalColumn: "NCDId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NCD_Details_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "AllergiesId", "AllergiesName" },
                values: new object[,]
                {
                    { 1, "Drugs - Penicillin" },
                    { 2, "Drusg - Others" },
                    { 3, "Animals" },
                    { 4, "Food" },
                    { 5, "Oniments" },
                    { 6, "Plant" },
                    { 7, "Sprays" },
                    { 8, "Others" },
                    { 9, "No Allergies" }
                });

            migrationBuilder.InsertData(
                table: "Diseases",
                columns: new[] { "DiseasesId", "DiseasesName" },
                values: new object[,]
                {
                    { 1, "Ischemic Heart Disease" },
                    { 2, "Stroke" },
                    { 3, "Influenza or Flu" },
                    { 4, "Pneumonia" },
                    { 5, "Alzheimer’s disease" },
                    { 6, "Arthritis" },
                    { 7, "Angina" },
                    { 8, "Anorexia nervosa" },
                    { 9, "Anxiety disorders" }
                });

            migrationBuilder.InsertData(
                table: "NCDs",
                columns: new[] { "NCDId", "NCDName" },
                values: new object[,]
                {
                    { 1, "Asthma" },
                    { 2, "Cancer" },
                    { 3, "Disorders of ear" },
                    { 4, "Disorder of eye" },
                    { 5, "Mental illness" },
                    { 6, "Oral helth problems" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "DiseasesId", "Epilepsy", "PatientName" },
                values: new object[,]
                {
                    { 1, 9, 2, "Lorem" },
                    { 2, 2, 2, "Amet" }
                });

            migrationBuilder.InsertData(
                table: "AllergiesDetails",
                columns: new[] { "Id", "AllergiesId", "PatientId" },
                values: new object[,]
                {
                    { 1, 4, 1 },
                    { 2, 7, 1 },
                    { 3, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "NCD_Details",
                columns: new[] { "Id", "NCDId", "PatientId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 5, 1 },
                    { 3, 4, 2 },
                    { 4, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesDetails_AllergiesId",
                table: "AllergiesDetails",
                column: "AllergiesId");

            migrationBuilder.CreateIndex(
                name: "IX_AllergiesDetails_PatientId",
                table: "AllergiesDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_NCDId",
                table: "NCD_Details",
                column: "NCDId");

            migrationBuilder.CreateIndex(
                name: "IX_NCD_Details_PatientId",
                table: "NCD_Details",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DiseasesId",
                table: "Patients",
                column: "DiseasesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllergiesDetails");

            migrationBuilder.DropTable(
                name: "NCD_Details");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "NCDs");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Diseases");
        }
    }
}

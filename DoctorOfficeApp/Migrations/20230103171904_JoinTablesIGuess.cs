using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoctorOfficeApp.Migrations
{
    public partial class JoinTablesIGuess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DocPat",
                columns: table => new
                {
                    docpat_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    patient_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id1 = table.Column<int>(type: "int", nullable: true),
                    patient_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocPat", x => x.docpat_id);
                    table.ForeignKey(
                        name: "FK_DocPat_Doctors_doctor_id1",
                        column: x => x.doctor_id1,
                        principalTable: "Doctors",
                        principalColumn: "doctor_id");
                    table.ForeignKey(
                        name: "FK_DocPat_Patients_patient_id1",
                        column: x => x.patient_id1,
                        principalTable: "Patients",
                        principalColumn: "patient_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DocSpec",
                columns: table => new
                {
                    docspec_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    specialty_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id = table.Column<int>(type: "int", nullable: false),
                    doctor_id1 = table.Column<int>(type: "int", nullable: true),
                    specialty_id1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocSpec", x => x.docspec_id);
                    table.ForeignKey(
                        name: "FK_DocSpec_Doctors_doctor_id1",
                        column: x => x.doctor_id1,
                        principalTable: "Doctors",
                        principalColumn: "doctor_id");
                    table.ForeignKey(
                        name: "FK_DocSpec_Specialties_specialty_id1",
                        column: x => x.specialty_id1,
                        principalTable: "Specialties",
                        principalColumn: "specialty_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DocPat_doctor_id1",
                table: "DocPat",
                column: "doctor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_DocPat_patient_id1",
                table: "DocPat",
                column: "patient_id1");

            migrationBuilder.CreateIndex(
                name: "IX_DocSpec_doctor_id1",
                table: "DocSpec",
                column: "doctor_id1");

            migrationBuilder.CreateIndex(
                name: "IX_DocSpec_specialty_id1",
                table: "DocSpec",
                column: "specialty_id1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocPat");

            migrationBuilder.DropTable(
                name: "DocSpec");
        }
    }
}

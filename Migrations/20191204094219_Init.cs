﻿using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookyAPI.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gerne",
                columns: table => new
                {
                    GerneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GerneName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerne", x => x.GerneID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodName = table.Column<string>(nullable: true),
                    Material = table.Column<string>(nullable: true),
                    PrepareTime = table.Column<string>(nullable: true),
                    CookTime = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    GerneID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Food_Gerne_GerneID",
                        column: x => x.GerneID,
                        principalTable: "Gerne",
                        principalColumn: "GerneID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Food_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Step",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    No = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    FoodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Step", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Step_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Gerne",
                columns: new[] { "GerneID", "GerneName" },
                values: new object[] { 1, "Bua sang" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Avatar", "EMail", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1, null, "chang@gmail.com", "Chang", "cooky", 1 },
                    { 2, null, "chu@gmail.com", "Chu", "cooky", 0 },
                    { 3, null, "cao@gmail.com", "Cao", "cooky", 0 },
                    { 4, null, "cuc@gmail.com", "Cuc", "cooky", 0 },
                    { 5, null, "kabi@gmail.com", "Kabi", "cooky", 0 },
                    { 6, null, "ponkgmail.com", "Ponk", "cooky", 0 },
                    { 7, null, "khoabe@gmail.com", "Khoa Be", "cooky", 0 },
                    { 8, null, "na@gmail.com", "Na", "cooky", 0 },
                    { 9, null, "chi@gmail.com", "Chi", "cooky", 0 },
                    { 10, null, "zayn@gmail.com", "Zayn", "cooky", 0 },
                    { 11, null, "kem@gmail.com", "Kem", "cooky", 0 }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "CookTime", "FoodName", "GerneID", "Material", "PrepareTime", "UserId" },
                values: new object[,]
                {
                    { 1, null, "Canh cai nau tom", null, "Cai ngot, Tom", null, 1 },
                    { 2, null, "Ga chien mam", null, "Ga", null, 1 },
                    { 3, null, "Tom rang", null, "Tom", null, 5 },
                    { 4, null, "Canh chua ca loc", null, "Do chua, ca", null, 6 }
                });

            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "Id", "Content", "FoodId", "Image", "No" },
                values: new object[] { 1, "Rua sach rau, sau do cat nho thanh mot doan bang 2cm.", 1, null, 1 });

            migrationBuilder.InsertData(
                table: "Step",
                columns: new[] { "Id", "Content", "FoodId", "Image", "No" },
                values: new object[] { 2, "Rua sach tom, lot vo, bam nho tom", 1, null, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Food_GerneID",
                table: "Food",
                column: "GerneID");

            migrationBuilder.CreateIndex(
                name: "IX_Food_UserId",
                table: "Food",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Step_FoodId",
                table: "Step",
                column: "FoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Step");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Gerne");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

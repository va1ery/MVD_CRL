using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVD_CRL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Виды_преступлений",
                columns: table => new
                {
                    Код_вида_преступления = table.Column<int>(nullable: false),
                    Наименование = table.Column<string>(maxLength: 50, nullable: true),
                    Статья = table.Column<string>(maxLength: 50, nullable: true),
                    Наказание = table.Column<string>(maxLength: 50, nullable: true),
                    Срок = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Виды_пре__C2E8B24414EB3E63", x => x.Код_вида_преступления);
                });

            migrationBuilder.CreateTable(
                name: "Должности",
                columns: table => new
                {
                    Код_должности = table.Column<int>(nullable: false),
                    Наименование_должности = table.Column<string>(maxLength: 50, nullable: true),
                    Оклад = table.Column<int>(nullable: true),
                    Обязанности = table.Column<string>(maxLength: 50, nullable: true),
                    Требования = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Должност__6F49B82E1D6C000B", x => x.Код_должности);
                });

            migrationBuilder.CreateTable(
                name: "Звания",
                columns: table => new
                {
                    Код_звания = table.Column<int>(nullable: false),
                    Наименование = table.Column<string>(maxLength: 50, nullable: true),
                    Надбавка = table.Column<int>(nullable: true),
                    Обязанности = table.Column<string>(maxLength: 50, nullable: true),
                    Требования = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Звания__590635FC51286356", x => x.Код_звания);
                });

            migrationBuilder.CreateTable(
                name: "Пострадавшие",
                columns: table => new
                {
                    Код_пострадавшего = table.Column<int>(nullable: false),
                    ФИО = table.Column<string>(maxLength: 50, nullable: true),
                    Дата_рождения = table.Column<DateTime>(type: "date", nullable: true),
                    Пол = table.Column<string>(maxLength: 50, nullable: true),
                    Адрес = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Пострада__797BA8E29F4973AF", x => x.Код_пострадавшего);
                });

            migrationBuilder.CreateTable(
                name: "Сотрудники",
                columns: table => new
                {
                    Код_сотрудника = table.Column<int>(nullable: false),
                    ФИО = table.Column<string>(maxLength: 50, nullable: true),
                    Возраст = table.Column<int>(nullable: true),
                    Пол = table.Column<string>(maxLength: 50, nullable: true),
                    Адрес = table.Column<string>(maxLength: 50, nullable: true),
                    Телефон = table.Column<string>(maxLength: 50, nullable: true),
                    Паспортные_данные = table.Column<string>(maxLength: 50, nullable: true),
                    Код_должности = table.Column<int>(nullable: false),
                    Код_звания = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Сотрудни__409003AE3329DB43", x => x.Код_сотрудника);
                    table.ForeignKey(
                        name: "FK__Сотрудник__Код_д__182C9B23",
                        column: x => x.Код_должности,
                        principalTable: "Должности",
                        principalColumn: "Код_должности",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Сотрудник__Код_з__1920BF5C",
                        column: x => x.Код_звания,
                        principalTable: "Звания",
                        principalColumn: "Код_звания",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Преступники",
                columns: table => new
                {
                    Номер_дела = table.Column<int>(nullable: false),
                    ФИО = table.Column<string>(maxLength: 50, nullable: true),
                    Дата_рождения = table.Column<DateTime>(type: "date", nullable: true),
                    Пол = table.Column<string>(maxLength: 50, nullable: true),
                    Адрес = table.Column<string>(maxLength: 50, nullable: true),
                    Состояние = table.Column<string>(maxLength: 50, nullable: true),
                    Код_сотрудника = table.Column<int>(nullable: false),
                    Код_пострадавшего = table.Column<int>(nullable: false),
                    Код_вида_преступления = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Преступн__A3C5D89E181AAD63", x => x.Номер_дела);
                    table.ForeignKey(
                        name: "FK__Преступни__Код_в__1DE57479",
                        column: x => x.Код_вида_преступления,
                        principalTable: "Виды_преступлений",
                        principalColumn: "Код_вида_преступления",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Преступни__Код_п__1CF15040",
                        column: x => x.Код_пострадавшего,
                        principalTable: "Пострадавшие",
                        principalColumn: "Код_пострадавшего",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Преступни__Код_с__1BFD2C07",
                        column: x => x.Код_сотрудника,
                        principalTable: "Сотрудники",
                        principalColumn: "Код_сотрудника",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Преступники_Код_вида_преступления",
                table: "Преступники",
                column: "Код_вида_преступления");

            migrationBuilder.CreateIndex(
                name: "IX_Преступники_Код_пострадавшего",
                table: "Преступники",
                column: "Код_пострадавшего");

            migrationBuilder.CreateIndex(
                name: "IX_Преступники_Код_сотрудника",
                table: "Преступники",
                column: "Код_сотрудника");

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_Код_должности",
                table: "Сотрудники",
                column: "Код_должности");

            migrationBuilder.CreateIndex(
                name: "IX_Сотрудники_Код_звания",
                table: "Сотрудники",
                column: "Код_звания");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Преступники");

            migrationBuilder.DropTable(
                name: "Виды_преступлений");

            migrationBuilder.DropTable(
                name: "Пострадавшие");

            migrationBuilder.DropTable(
                name: "Сотрудники");

            migrationBuilder.DropTable(
                name: "Должности");

            migrationBuilder.DropTable(
                name: "Звания");
        }
    }
}

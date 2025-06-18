using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWpf.Migrations
{
    /// <inheritdoc />
    public partial class FixIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Лист_1$",
                columns: table => new
                {
                    Этаж = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Номер = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Категория = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    F4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    document_number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    check_in = table.Column<DateOnly>(type: "date", nullable: false),
                    check_out = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Integrations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    integration_details = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    floor = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    number = table.Column<int>(type: "int", nullable: false),
                    category = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics_hotel",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    occupancy_rate = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    adr = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    revpar = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    revenue = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics_hotel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lastname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: true),
                    IsLocked = table.Column<bool>(type: "bit", nullable: true),
                    IsFirstLogin = table.Column<bool>(type: "bit", nullable: true),
                    LastLoginDate = table.Column<DateTime>(name: "LastLoginDate ", type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    guest_id = table.Column<int>(type: "int", nullable: true),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    check_in_date = table.Column<DateOnly>(type: "date", nullable: false),
                    check_out_date = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservations_Guests",
                        column: x => x.guest_id,
                        principalTable: "Guests",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Room_Access",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    guest_id = table.Column<int>(type: "int", nullable: true),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    access_card_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room_Access", x => x.id);
                    table.ForeignKey(
                        name: "FK_Room_Access_Guests",
                        column: x => x.guest_id,
                        principalTable: "Guests",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Room_Access_Rooms",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cleaning_Schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    cleaning_date = table.Column<DateOnly>(type: "date", nullable: false),
                    cleaner_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cleaning_Schedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cleaning_Schedule_Rooms",
                        column: x => x.room_id,
                        principalTable: "Rooms",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Cleaning_Schedule_Users",
                        column: x => x.cleaner_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Guest_Services",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    reservations_id = table.Column<int>(type: "int", nullable: true),
                    service_id = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest_Services", x => x.id);
                    table.ForeignKey(
                        name: "FK_Guest_Services_Reservations",
                        column: x => x.reservations_id,
                        principalTable: "Reservations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Guest_Services_Services",
                        column: x => x.service_id,
                        principalTable: "Services",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    reservation_id = table.Column<int>(type: "int", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    payment_date = table.Column<DateOnly>(type: "date", nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Payments_Reservations",
                        column: x => x.reservation_id,
                        principalTable: "Reservations",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cleaning_Schedule_cleaner_id",
                table: "Cleaning_Schedule",
                column: "cleaner_id");

            migrationBuilder.CreateIndex(
                name: "IX_Cleaning_Schedule_room_id",
                table: "Cleaning_Schedule",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_Services_reservations_id",
                table: "Guest_Services",
                column: "reservations_id");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_Services_service_id",
                table: "Guest_Services",
                column: "service_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_reservation_id",
                table: "Payments",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_guest_id",
                table: "Reservations",
                column: "guest_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_room_id",
                table: "Reservations",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Access_guest_id",
                table: "Room_Access",
                column: "guest_id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_Access_room_id",
                table: "Room_Access",
                column: "room_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Лист_1$");

            migrationBuilder.DropTable(
                name: "Cleaning_Schedule");

            migrationBuilder.DropTable(
                name: "Guest_Services");

            migrationBuilder.DropTable(
                name: "Integrations");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Room_Access");

            migrationBuilder.DropTable(
                name: "Statistics_hotel");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

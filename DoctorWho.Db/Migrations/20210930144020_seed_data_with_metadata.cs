using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoctorWho.Db.Migrations
{
    public partial class seed_data_with_metadata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, "Ida Gibson", "admin", new DateTime(2017, 10, 23, 16, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), "modify-user", new DateTime(2021, 9, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 2, "Lula Nitzsche", "admin", new DateTime(2020, 7, 5, 1, 8, 2, 314, DateTimeKind.Local).AddTicks(6354), "modify-user", new DateTime(2021, 9, 29, 7, 15, 10, 968, DateTimeKind.Local).AddTicks(6473) },
                    { 3, "Dana Daniel", "admin", new DateTime(2017, 7, 17, 6, 5, 17, 826, DateTimeKind.Local).AddTicks(8435), "modify-user", new DateTime(2021, 9, 28, 20, 58, 22, 249, DateTimeKind.Local).AddTicks(1588) },
                    { 4, "Lora Ernser", "admin", new DateTime(2021, 8, 10, 22, 51, 17, 137, DateTimeKind.Local).AddTicks(6277), "modify-user", new DateTime(2021, 9, 29, 1, 3, 14, 487, DateTimeKind.Local).AddTicks(7671) },
                    { 5, "Vergie Gerhold", "admin", new DateTime(2020, 3, 18, 7, 39, 43, 474, DateTimeKind.Local).AddTicks(9863), "modify-user", new DateTime(2021, 9, 29, 2, 19, 56, 560, DateTimeKind.Local).AddTicks(3397) },
                    { 6, "Daphney Waters", "admin", new DateTime(2021, 8, 13, 3, 45, 43, 343, DateTimeKind.Local).AddTicks(1348), "modify-user", new DateTime(2021, 9, 29, 0, 10, 36, 832, DateTimeKind.Local).AddTicks(2050) },
                    { 7, "Bertram Bergnaum", "admin", new DateTime(2019, 2, 17, 20, 39, 13, 83, DateTimeKind.Local).AddTicks(6223), "modify-user", new DateTime(2021, 9, 28, 22, 42, 30, 746, DateTimeKind.Local).AddTicks(955) },
                    { 8, "Rubye Gusikowski", "admin", new DateTime(2017, 2, 15, 13, 45, 2, 357, DateTimeKind.Local).AddTicks(6165), "modify-user", new DateTime(2021, 9, 28, 19, 26, 24, 326, DateTimeKind.Local).AddTicks(5147) },
                    { 9, "Mike Green", "admin", new DateTime(2019, 6, 17, 12, 44, 24, 864, DateTimeKind.Local).AddTicks(944), "modify-user", new DateTime(2021, 9, 28, 22, 40, 9, 950, DateTimeKind.Local).AddTicks(7750) },
                    { 10, "Rachelle Hayes", "admin", new DateTime(2019, 3, 30, 18, 32, 21, 951, DateTimeKind.Local).AddTicks(3956), "modify-user", new DateTime(2021, 9, 29, 12, 27, 51, 545, DateTimeKind.Local).AddTicks(1273) }
                });

            migrationBuilder.InsertData(
                table: "Companions",
                columns: new[] { "CompanionId", "CompanionName", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "WhoPlayed" },
                values: new object[,]
                {
                    { 9, "Modesta Terry", "admin", new DateTime(2021, 8, 26, 12, 14, 3, 104, DateTimeKind.Local).AddTicks(4436), "modify-user", new DateTime(2021, 9, 28, 18, 19, 16, 570, DateTimeKind.Local).AddTicks(4260), 1 },
                    { 8, "Neha Kreiger", "admin", new DateTime(2021, 8, 15, 22, 53, 3, 553, DateTimeKind.Local).AddTicks(216), "modify-user", new DateTime(2021, 9, 29, 5, 29, 49, 313, DateTimeKind.Local).AddTicks(6696), 0 },
                    { 7, "Cesar Tremblay", "admin", new DateTime(2020, 1, 2, 4, 52, 42, 670, DateTimeKind.Local).AddTicks(2167), "modify-user", new DateTime(2021, 9, 29, 2, 14, 33, 861, DateTimeKind.Local).AddTicks(9738), 1 },
                    { 6, "Vicenta Bogan", "admin", new DateTime(2017, 12, 21, 14, 49, 10, 420, DateTimeKind.Local).AddTicks(1068), "modify-user", new DateTime(2021, 9, 29, 10, 25, 9, 645, DateTimeKind.Local).AddTicks(9924), 0 },
                    { 10, "Eddie McGlynn", "admin", new DateTime(2018, 4, 29, 17, 16, 36, 442, DateTimeKind.Local).AddTicks(5446), "modify-user", new DateTime(2021, 9, 29, 13, 9, 23, 901, DateTimeKind.Local).AddTicks(228), 0 },
                    { 4, "Jameson Williamson", "admin", new DateTime(2017, 5, 26, 15, 41, 2, 761, DateTimeKind.Local).AddTicks(8927), "modify-user", new DateTime(2021, 9, 29, 13, 5, 27, 813, DateTimeKind.Local).AddTicks(6481), 0 },
                    { 3, "Ursula Boyle", "admin", new DateTime(2021, 9, 14, 16, 6, 13, 339, DateTimeKind.Local).AddTicks(2087), "modify-user", new DateTime(2021, 9, 28, 17, 31, 55, 105, DateTimeKind.Local).AddTicks(9708), 1 },
                    { 2, "Greyson Walker", "admin", new DateTime(2018, 10, 26, 2, 10, 9, 93, DateTimeKind.Local).AddTicks(9495), "modify-user", new DateTime(2021, 9, 29, 3, 39, 24, 518, DateTimeKind.Local).AddTicks(4947), 0 },
                    { 1, "Tillman Zemlak", "admin", new DateTime(2017, 11, 5, 12, 39, 32, 562, DateTimeKind.Local).AddTicks(5367), "modify-user", new DateTime(2021, 9, 28, 17, 41, 25, 517, DateTimeKind.Local).AddTicks(3271), 1 },
                    { 5, "Cyrus Berge", "admin", new DateTime(2017, 12, 16, 19, 58, 3, 721, DateTimeKind.Local).AddTicks(7954), "modify-user", new DateTime(2021, 9, 28, 17, 17, 36, 176, DateTimeKind.Local).AddTicks(7471), 1 }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "Birthdate", "CreatedBy", "CreatedOn", "DoctorName", "DoctorNumber", "FirstEpisodeDate", "LastEpisodeDate", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 8, 5, 21, 44, 6, 681, DateTimeKind.Local).AddTicks(9525), "admin", new DateTime(2020, 11, 27, 15, 42, 36, 14, DateTimeKind.Local).AddTicks(6590), "Elyse Cassin", 7, new DateTime(2021, 8, 6, 18, 20, 53, 146, DateTimeKind.Local).AddTicks(5166), new DateTime(2021, 8, 5, 23, 28, 15, 933, DateTimeKind.Local).AddTicks(1538), "modify-user", new DateTime(2021, 9, 29, 12, 7, 28, 647, DateTimeKind.Local).AddTicks(1255) },
                    { 9, new DateTime(2021, 8, 5, 22, 12, 57, 676, DateTimeKind.Local).AddTicks(9865), "admin", new DateTime(2020, 4, 26, 20, 25, 9, 873, DateTimeKind.Local).AddTicks(2903), "Ronaldo Bayer", 5, new DateTime(2021, 8, 6, 17, 17, 38, 643, DateTimeKind.Local).AddTicks(8583), new DateTime(2021, 8, 6, 6, 34, 6, 370, DateTimeKind.Local).AddTicks(7573), "modify-user", new DateTime(2021, 9, 29, 2, 21, 37, 45, DateTimeKind.Local).AddTicks(8890) },
                    { 7, new DateTime(2021, 8, 6, 5, 25, 54, 145, DateTimeKind.Local).AddTicks(661), "admin", new DateTime(2020, 3, 6, 19, 55, 47, 61, DateTimeKind.Local).AddTicks(1584), "Easter Homenick", 4, new DateTime(2021, 8, 6, 14, 47, 43, 648, DateTimeKind.Local).AddTicks(178), new DateTime(2021, 8, 5, 21, 4, 59, 401, DateTimeKind.Local).AddTicks(2522), "modify-user", new DateTime(2021, 9, 28, 21, 51, 29, 952, DateTimeKind.Local).AddTicks(6923) },
                    { 6, new DateTime(2021, 8, 6, 19, 12, 6, 617, DateTimeKind.Local).AddTicks(3811), "admin", new DateTime(2016, 10, 26, 1, 48, 25, 719, DateTimeKind.Local).AddTicks(9254), "Curtis Little", 3, new DateTime(2021, 8, 5, 20, 54, 50, 292, DateTimeKind.Local).AddTicks(6629), new DateTime(2021, 8, 6, 0, 42, 32, 538, DateTimeKind.Local).AddTicks(1788), "modify-user", new DateTime(2021, 9, 29, 7, 41, 32, 693, DateTimeKind.Local).AddTicks(9317) },
                    { 8, new DateTime(2021, 8, 6, 2, 58, 52, 452, DateTimeKind.Local).AddTicks(4600), "admin", new DateTime(2019, 2, 20, 14, 22, 48, 810, DateTimeKind.Local).AddTicks(1314), "Darron Barton", 11, new DateTime(2021, 8, 6, 14, 55, 40, 568, DateTimeKind.Local).AddTicks(5083), new DateTime(2021, 8, 5, 22, 2, 20, 20, DateTimeKind.Local).AddTicks(6155), "modify-user", new DateTime(2021, 9, 29, 9, 43, 43, 651, DateTimeKind.Local).AddTicks(3827) },
                    { 4, new DateTime(2021, 8, 6, 16, 56, 49, 527, DateTimeKind.Local).AddTicks(1792), "admin", new DateTime(2021, 5, 10, 18, 4, 6, 867, DateTimeKind.Local).AddTicks(7717), "Osbaldo Homenick", 7, new DateTime(2021, 8, 6, 14, 33, 55, 701, DateTimeKind.Local).AddTicks(5825), new DateTime(2021, 8, 6, 18, 57, 15, 33, DateTimeKind.Local).AddTicks(7174), "modify-user", new DateTime(2021, 9, 29, 4, 36, 40, 699, DateTimeKind.Local).AddTicks(5440) },
                    { 3, new DateTime(2021, 8, 6, 2, 35, 32, 211, DateTimeKind.Local).AddTicks(9173), "admin", new DateTime(2019, 12, 17, 4, 51, 17, 156, DateTimeKind.Local).AddTicks(6127), "Audie Mosciski", 9, new DateTime(2021, 8, 6, 18, 34, 23, 694, DateTimeKind.Local).AddTicks(575), new DateTime(2021, 8, 6, 17, 50, 50, 555, DateTimeKind.Local).AddTicks(6256), "modify-user", new DateTime(2021, 9, 29, 10, 21, 20, 503, DateTimeKind.Local).AddTicks(3214) },
                    { 2, new DateTime(2021, 8, 5, 22, 30, 42, 231, DateTimeKind.Local).AddTicks(2321), "admin", new DateTime(2018, 3, 14, 8, 37, 44, 531, DateTimeKind.Local).AddTicks(6692), "Ralph Weimann", 18, new DateTime(2021, 8, 6, 13, 6, 32, 605, DateTimeKind.Local).AddTicks(5274), new DateTime(2021, 8, 5, 23, 25, 2, 32, DateTimeKind.Local).AddTicks(2241), "modify-user", new DateTime(2021, 9, 28, 19, 17, 46, 940, DateTimeKind.Local).AddTicks(2482) },
                    { 1, new DateTime(2021, 8, 6, 8, 51, 47, 75, DateTimeKind.Local).AddTicks(8532), "admin", new DateTime(2021, 9, 28, 0, 17, 33, 604, DateTimeKind.Local).AddTicks(5829), "Michael Fadel", 2, new DateTime(2021, 8, 6, 16, 19, 34, 568, DateTimeKind.Local).AddTicks(5415), new DateTime(2021, 8, 6, 15, 47, 34, 867, DateTimeKind.Local).AddTicks(8176), "modify-user", new DateTime(2021, 9, 29, 16, 30, 19, 98, DateTimeKind.Local).AddTicks(5737) },
                    { 5, new DateTime(2021, 8, 6, 7, 0, 11, 90, DateTimeKind.Local).AddTicks(3591), "admin", new DateTime(2021, 4, 7, 17, 15, 40, 489, DateTimeKind.Local).AddTicks(1012), "Darien Murazik", 12, new DateTime(2021, 8, 6, 11, 49, 44, 733, DateTimeKind.Local).AddTicks(1670), new DateTime(2021, 8, 6, 1, 31, 27, 695, DateTimeKind.Local).AddTicks(2999), "modify-user", new DateTime(2021, 9, 29, 9, 42, 35, 852, DateTimeKind.Local).AddTicks(1902) }
                });

            migrationBuilder.InsertData(
                table: "Enemies",
                columns: new[] { "EnemyId", "CreatedBy", "CreatedOn", "Description", "EnemyName", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 9, "admin", new DateTime(2017, 7, 17, 4, 41, 28, 48, DateTimeKind.Local).AddTicks(433), "Odio aut velit similique itaque. Molestias placeat vitae aut in sed nemo dicta. Exercitationem sit tempora velit quaerat at debitis officiis temporibus ut. Debitis sunt qui facere aut. Amet eaque eum qui. Vel atque dolor quos quasi sed non amet rem.", "Margarett Mueller", "modify-user", new DateTime(2021, 9, 29, 10, 21, 59, 825, DateTimeKind.Local).AddTicks(5822) },
                    { 1, "admin", new DateTime(2016, 11, 18, 5, 2, 39, 192, DateTimeKind.Local).AddTicks(1672), "Et eligendi aspernatur quis. Repellat molestias vitae occaecati aut sunt. Officia autem repellat fugiat magni at autem dolores vero qui.", "Brain Stanton", "modify-user", new DateTime(2021, 9, 29, 9, 5, 46, 587, DateTimeKind.Local).AddTicks(9255) },
                    { 2, "admin", new DateTime(2018, 6, 24, 2, 18, 27, 666, DateTimeKind.Local).AddTicks(3621), "Quaerat est sapiente soluta ratione aspernatur nesciunt dolorem placeat at. Rerum iusto nulla sed aut illum sint ipsa. Quisquam sit iste occaecati illum ut et.", "Kobe Heller", "modify-user", new DateTime(2021, 9, 29, 12, 54, 40, 288, DateTimeKind.Local).AddTicks(160) },
                    { 3, "admin", new DateTime(2021, 3, 30, 12, 3, 44, 101, DateTimeKind.Local).AddTicks(9466), "Dolore ipsa non quod eveniet quia voluptas. Doloribus quo voluptas quae ratione sed sit quam provident. Placeat consequatur quia aut distinctio dolore molestiae illo odio eos.", "Taya Miller", "modify-user", new DateTime(2021, 9, 29, 1, 52, 24, 124, DateTimeKind.Local).AddTicks(1385) },
                    { 4, "admin", new DateTime(2018, 2, 18, 17, 8, 33, 87, DateTimeKind.Local).AddTicks(2519), "Nam quis eum ut voluptates aut. Doloribus aut illo illo maxime a quis voluptate. Harum vel ut et id. Ea dignissimos vel. Vel nulla soluta reiciendis rerum.", "Gilda Gaylord", "modify-user", new DateTime(2021, 9, 29, 7, 1, 58, 900, DateTimeKind.Local).AddTicks(2092) },
                    { 5, "admin", new DateTime(2018, 3, 24, 8, 29, 14, 73, DateTimeKind.Local).AddTicks(703), "Eos qui veniam excepturi molestiae quia. Doloremque sequi facere repudiandae quis rerum facilis quia incidunt. Harum delectus officiis. Molestiae earum cupiditate et nostrum autem enim.", "Zena Brekke", "modify-user", new DateTime(2021, 9, 29, 3, 46, 48, 710, DateTimeKind.Local).AddTicks(4185) },
                    { 6, "admin", new DateTime(2019, 12, 2, 6, 4, 49, 729, DateTimeKind.Local).AddTicks(7658), "Libero et unde et aliquid corporis. Nostrum nulla quae quia est laudantium asperiores. Velit natus placeat nulla. Nostrum esse temporibus recusandae aut omnis aut eos provident. Aperiam ipsa dicta nihil dolorum minus.", "Ayana Mraz", "modify-user", new DateTime(2021, 9, 29, 13, 28, 5, 33, DateTimeKind.Local).AddTicks(4016) },
                    { 7, "admin", new DateTime(2017, 3, 5, 4, 5, 26, 27, DateTimeKind.Local).AddTicks(2862), "Sunt tempore accusantium ut quisquam magnam inventore quidem fugit. Placeat dolore voluptatem et sed magnam sed. Dolorum deserunt quam ea omnis in perferendis. Animi ipsa quis odio. Itaque officiis ab. Et reprehenderit magnam non et cumque dolore voluptatem.", "Tre Powlowski", "modify-user", new DateTime(2021, 9, 28, 20, 33, 23, 776, DateTimeKind.Local).AddTicks(1161) },
                    { 8, "admin", new DateTime(2019, 2, 1, 19, 25, 51, 49, DateTimeKind.Local).AddTicks(2402), "Dolor modi consequatur et atque alias quis autem est. Fuga cupiditate natus est sit voluptatem cum dolores vel autem. Et qui vero et. Doloribus necessitatibus ipsum vel dolorem nihil. Vel nihil illum alias. Et itaque qui tempore reiciendis nihil voluptas est est.", "William Pfannerstill", "modify-user", new DateTime(2021, 9, 29, 8, 29, 47, 923, DateTimeKind.Local).AddTicks(4819) },
                    { 10, "admin", new DateTime(2017, 7, 17, 17, 58, 39, 496, DateTimeKind.Local).AddTicks(8201), "Totam possimus atque est quos natus. Dolorum doloremque cum. Quam est voluptas alias adipisci sit enim cumque aspernatur. Quis quod sit voluptas dolor nisi. Id quasi deserunt aliquam dolore quo veniam aliquam porro praesentium. Dolorem vel adipisci repellendus consequatur quam architecto.", "Jalen DuBuque", "modify-user", new DateTime(2021, 9, 29, 0, 12, 55, 471, DateTimeKind.Local).AddTicks(4273) }
                });

            migrationBuilder.InsertData(
                table: "Episodes",
                columns: new[] { "EpisodeId", "AuthorId", "CreatedBy", "CreatedOn", "DoctorId", "EpisodeDate", "EpisodeNumber", "EpisodeType", "ModifiedBy", "ModifiedOn", "Notes", "SeriesNumber", "Title" },
                values: new object[,]
                {
                    { 6, 8, "admin", new DateTime(2020, 4, 13, 11, 45, 40, 924, DateTimeKind.Local).AddTicks(4892), 2, new DateTime(2021, 8, 6, 19, 16, 13, 256, DateTimeKind.Local).AddTicks(8223), 2, "Sed velit ipsa officia et consequatur dolorem sit.", "modify-user", new DateTime(2021, 9, 28, 19, 26, 10, 964, DateTimeKind.Local).AddTicks(3356), "Est vel quia qui voluptatem. Quis facere quidem laudantium excepturi ut molestias. Atque ab id. Dolorem ducimus in sint corrupti. Est consectetur voluptatibus. Et autem saepe qui est commodi in reprehenderit quia.\n\nAsperiores id placeat ea nemo et aliquid sequi. Consequatur temporibus minima molestias quo ducimus recusandae quia necessitatibus quis. Architecto est est rerum voluptatem similique. Laudantium ratione quisquam sunt officiis maiores rerum quia. Est nesciunt sit ipsum exercitationem aperiam sit tenetur beatae.\n\nMaiores voluptas et consectetur quas necessitatibus. Et eum asperiores. Explicabo id quia necessitatibus aut et porro repudiandae exercitationem.", 8, "Vel officia nam vitae nostrum voluptas aut quo consequatur." },
                    { 10, 4, "admin", new DateTime(2020, 12, 7, 10, 33, 15, 845, DateTimeKind.Local).AddTicks(2967), 3, new DateTime(2021, 8, 5, 21, 2, 42, 163, DateTimeKind.Local).AddTicks(2040), 7, "Quo similique culpa.", "modify-user", new DateTime(2021, 9, 29, 14, 24, 32, 863, DateTimeKind.Local).AddTicks(3346), "Similique sit sunt et pariatur rerum dolores neque aut. Tenetur dolor ad. Voluptatibus ullam omnis. Ut officia aperiam et sint libero repudiandae doloribus. Delectus fugit qui velit nostrum consectetur debitis. Nostrum sit animi.\n\nMagnam quia provident fugiat est. Et doloremque quasi quia. A et vel minus tenetur nam et. Vero inventore dolorem quae corrupti repudiandae distinctio maiores in illo. Fugit quia optio rerum suscipit voluptates vitae nobis. Soluta corrupti omnis eveniet itaque et labore quos vel ratione.\n\nMinima est fugit enim vitae architecto quae. Aut et aut aut vel inventore quam voluptatem nesciunt ipsa. Accusamus voluptatibus aut enim consequatur quas enim aut est.", 7, "Voluptate omnis fugit illo rem quis fuga assumenda." },
                    { 3, 7, "admin", new DateTime(2017, 1, 31, 21, 51, 24, 958, DateTimeKind.Local).AddTicks(8080), 4, new DateTime(2021, 8, 6, 14, 51, 54, 376, DateTimeKind.Local).AddTicks(2839), 3, "Officiis ut ut adipisci sint.", "modify-user", new DateTime(2021, 9, 29, 4, 27, 12, 236, DateTimeKind.Local).AddTicks(9327), "Nisi dolor et non consequatur libero natus et eveniet libero. Labore aperiam odio ullam et necessitatibus vitae architecto enim. Sit atque officia occaecati omnis dicta illo non. Iste laboriosam voluptates sit nobis ut excepturi perferendis. Incidunt harum soluta aut dolorum odit. Sed ut molestiae omnis aliquid.\n\nOfficia incidunt nesciunt eligendi doloremque. Dolore qui molestias quis consectetur fugit. Voluptas cumque possimus hic ex officiis.\n\nRerum veritatis quia et deleniti incidunt facilis id consequuntur. Ea corrupti inventore quia aspernatur cupiditate. Deleniti id voluptatem est quia qui illum molestias. Sapiente esse deserunt reiciendis voluptate deleniti vel odio. Ipsum maiores dolorem unde dolor animi nulla vel quo fugiat.", 2, "Et labore voluptatem ea." },
                    { 7, 4, "admin", new DateTime(2017, 9, 10, 10, 47, 3, 573, DateTimeKind.Local).AddTicks(5089), 6, new DateTime(2021, 8, 6, 9, 45, 36, 313, DateTimeKind.Local).AddTicks(5850), 1, "Repellat minus assumenda cupiditate aut.", "modify-user", new DateTime(2021, 9, 28, 23, 28, 16, 501, DateTimeKind.Local).AddTicks(9395), "Repellat ea voluptatem est ut neque. Cupiditate quia est ratione qui autem est et sunt. Laboriosam illo molestiae iste totam facere exercitationem porro magni.\n\nQuo officiis facere et maiores voluptatem. Quibusdam sit illum. Facilis consequatur distinctio eum velit similique. Autem numquam earum blanditiis asperiores molestias. Dolores necessitatibus non est est inventore odit labore. Nobis ducimus ut est sequi.\n\nConsequuntur omnis reiciendis et voluptate natus saepe vitae. Qui voluptas suscipit quo corrupti. Debitis dolore voluptas at autem deserunt. Exercitationem possimus ipsam voluptate. Aut recusandae dignissimos et ut voluptatem error illum ut sit.", 20, "Non officia maiores et accusantium temporibus pariatur repellendus." },
                    { 4, 1, "admin", new DateTime(2018, 9, 4, 1, 8, 47, 478, DateTimeKind.Local).AddTicks(6158), 7, new DateTime(2021, 8, 6, 17, 34, 11, 114, DateTimeKind.Local).AddTicks(8555), 7, "Et exercitationem nihil cupiditate quis.", "modify-user", new DateTime(2021, 9, 29, 10, 4, 56, 818, DateTimeKind.Local).AddTicks(5663), "Aut et autem molestiae sed eum non molestiae unde aut. Natus maiores aut enim tenetur consequatur ea soluta. Non quo et et quas et totam.\n\nAutem cumque incidunt autem tenetur excepturi assumenda harum soluta optio. Earum voluptas asperiores reprehenderit est odit. Voluptatum perspiciatis ipsam quam repellendus. Excepturi nam enim autem rerum nihil. Commodi velit occaecati quia aut sint voluptas aperiam quis quas.\n\nNam numquam officia quis. Pariatur expedita qui quaerat doloribus amet deserunt a repudiandae. Veniam quis et qui est quaerat repellendus aut quod. Qui quis quaerat nisi suscipit.", 5, "Illum enim tempora ratione voluptatem." },
                    { 2, 2, "admin", new DateTime(2021, 1, 21, 14, 18, 20, 930, DateTimeKind.Local).AddTicks(5316), 8, new DateTime(2021, 8, 6, 15, 47, 57, 518, DateTimeKind.Local).AddTicks(1174), 12, "Voluptates quis saepe non.", "modify-user", new DateTime(2021, 9, 29, 15, 37, 46, 941, DateTimeKind.Local).AddTicks(6572), "Iure hic natus voluptatem libero. Quibusdam officiis quisquam excepturi. Perspiciatis non ullam. Facere aut esse quas.\n\nOdio at qui in consequuntur voluptas praesentium voluptatem nisi. Aspernatur quia laudantium. Modi et voluptatem odio aperiam occaecati. Nam autem sed corrupti magnam quae dolorum quasi quidem.\n\nUt iusto hic explicabo reiciendis. Ut voluptas laboriosam pariatur autem atque aut laboriosam laudantium qui. Eum corrupti aut totam molestiae sunt est deleniti quae voluptates. Minima voluptas hic impedit optio assumenda nemo accusantium cupiditate.", 5, "Aperiam sit nisi fugiat qui dignissimos placeat eum." },
                    { 1, 4, "admin", new DateTime(2020, 4, 16, 16, 56, 34, 566, DateTimeKind.Local).AddTicks(7477), 9, new DateTime(2021, 8, 6, 7, 9, 52, 331, DateTimeKind.Local).AddTicks(8505), 2, "Et quia deleniti rerum odit sed voluptatem et.", "modify-user", new DateTime(2021, 9, 28, 23, 46, 44, 567, DateTimeKind.Local).AddTicks(8940), "Voluptas amet labore magnam et quo. Placeat quia dolorem quisquam repudiandae ut similique. Dolor sint eveniet cum. Laudantium nam excepturi.\n\nUt reprehenderit vitae ipsa velit nisi eveniet ipsum cum. Vero molestias modi illo. Enim sed aut voluptas numquam est temporibus facere aut voluptas.\n\nExcepturi quis aperiam aspernatur cum neque iure incidunt. Cupiditate nihil voluptas deleniti dolorem quod. Iusto nemo tempore exercitationem.", 1, "Eligendi voluptatem eos sit est et amet." },
                    { 8, 6, "admin", new DateTime(2021, 7, 30, 23, 19, 48, 559, DateTimeKind.Local).AddTicks(1395), 9, new DateTime(2021, 8, 6, 12, 25, 20, 608, DateTimeKind.Local).AddTicks(4658), 5, "Est repudiandae odit omnis.", "modify-user", new DateTime(2021, 9, 29, 9, 1, 52, 675, DateTimeKind.Local).AddTicks(5795), "Et ratione eveniet consequatur explicabo quasi voluptatem. Atque eos distinctio dignissimos ad vel ratione quo. Accusantium perspiciatis rerum fugit tempore. Est eaque non aut quas. Rerum autem reiciendis quia perferendis architecto ullam velit consectetur. Cumque autem non illum quo inventore odio accusantium.\n\nQui sapiente velit et fugit dignissimos dolore repellendus ipsum assumenda. Sapiente facilis fugiat voluptas. Nobis sed quaerat. Pariatur nihil odit iure voluptas. Ut vero est nam animi et suscipit. Eligendi cum mollitia repudiandae non sunt dolorem.\n\nQuam voluptatum id qui. Aut facilis autem quia voluptas totam. Quisquam vero consequatur. Id ut reprehenderit dolores. Ipsum quaerat et inventore qui dolorem rem.", 4, "Aut corporis sequi inventore voluptatibus quaerat modi est." },
                    { 5, 6, "admin", new DateTime(2020, 4, 19, 14, 13, 32, 571, DateTimeKind.Local).AddTicks(9580), 10, new DateTime(2021, 8, 6, 2, 51, 49, 35, DateTimeKind.Local).AddTicks(7976), 19, "Libero optio quia est et omnis tenetur qui aut.", "modify-user", new DateTime(2021, 9, 29, 8, 42, 44, 133, DateTimeKind.Local).AddTicks(5606), "Magni odit quidem officiis debitis aut pariatur illo. Natus in illo. Aut qui animi libero autem molestias ea asperiores illum accusamus. Incidunt eos qui qui qui id.\n\nVero qui reiciendis itaque ea velit et. Architecto et qui delectus. Ut quisquam quos officiis voluptas unde qui dolore quia possimus.\n\nUt rerum quod eum. Expedita nihil praesentium. Velit nisi ut quia et aliquam omnis commodi quis placeat. Et excepturi voluptatem esse labore at.", 1, "Perferendis molestiae numquam amet facere." },
                    { 9, 5, "admin", new DateTime(2020, 7, 24, 18, 58, 35, 560, DateTimeKind.Local).AddTicks(3466), 10, new DateTime(2021, 8, 6, 6, 2, 38, 830, DateTimeKind.Local).AddTicks(1547), 9, "Possimus quas qui ut eum quis.", "modify-user", new DateTime(2021, 9, 28, 20, 21, 46, 51, DateTimeKind.Local).AddTicks(5261), "Ut qui repellendus eligendi id doloremque iusto. Minus dolore numquam aut tempore ut. Quia id esse beatae maiores minus ut ipsum eveniet. Eum sit molestias. Modi saepe quia omnis. Ipsum ut nobis beatae corporis distinctio quae.\n\nOdio optio asperiores odit quis architecto. Soluta eos veritatis debitis temporibus molestiae est rerum in. Aut molestiae dolore excepturi ex explicabo ut eos veritatis. Quos cupiditate fugit esse earum est. Qui sed quia. Qui iusto corporis ut aperiam veritatis aut maxime.\n\nQuibusdam quas non et sed quo itaque dicta. Est delectus modi laborum suscipit sequi placeat. Itaque sit suscipit et nobis qui illo minima. Earum ut voluptatem aperiam laudantium qui. Voluptas eligendi voluptatem officia voluptas.", 8, "Quis ad eos." }
                });

            migrationBuilder.InsertData(
                table: "EpisodeCompanion",
                columns: new[] { "EpisodeCompanionId", "CompanionId", "CreatedBy", "CreatedOn", "EpisodeId", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 4, 6, "admin", new DateTime(2015, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 6, "admin", new DateTime(2018, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 5, 4, "admin", new DateTime(2003, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 9, "admin", new DateTime(2015, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 1, 1, "admin", new DateTime(2021, 1, 23, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 9, "modify-user", new DateTime(2021, 9, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 3, 4, "modify-user", new DateTime(2008, 11, 23, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 5, "modify-user", new DateTime(2020, 9, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 10, 2, "modify-user", new DateTime(2003, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 8, "admin", new DateTime(2004, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 7, 4, "modify-user", new DateTime(2012, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 8, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 2, 8, "admin", new DateTime(2019, 11, 23, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 8, "modify-user", new DateTime(2020, 9, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 9, 3, "modify-user", new DateTime(2020, 1, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 3, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 8, 7, "modify-user", new DateTime(2021, 1, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 3, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 6, 4, "modify-user", new DateTime(2020, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 10, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) }
                });

            migrationBuilder.InsertData(
                table: "EpisodeEnemy",
                columns: new[] { "EpisodeEnemyId", "CreatedBy", "CreatedOn", "EnemyId", "EpisodeId", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 2, "modify-user", new DateTime(2000, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 3, 4, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 5, "modify-user", new DateTime(2020, 9, 2, 16, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 5, 4, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 6, "admin", new DateTime(2001, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 7, 9, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 7, "admin", new DateTime(2012, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 8, 8, "admin", new DateTime(2013, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 8, "modify-user", new DateTime(2015, 1, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 9, 10, "admin", new DateTime(2015, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 3, "modify-user", new DateTime(2002, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 1, 10, "admin", new DateTime(2003, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 1, "modify-user", new DateTime(2019, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 10, 9, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 4, "modify-user", new DateTime(2010, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 3, 9, "admin", new DateTime(2021, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 9, "admin", new DateTime(2013, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 3, 3, "modify-user", new DateTime(2018, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) },
                    { 10, "modify-user", new DateTime(2012, 11, 2, 15, 48, 45, 723, DateTimeKind.Local).AddTicks(7137), 2, 9, "admin", new DateTime(2013, 7, 28, 20, 48, 50, 28, DateTimeKind.Local).AddTicks(2904) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EpisodeCompanion",
                keyColumn: "EpisodeCompanionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EpisodeEnemy",
                keyColumn: "EpisodeEnemyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companions",
                keyColumn: "CompanionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Enemies",
                keyColumn: "EnemyId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Episodes",
                keyColumn: "EpisodeId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "DoctorId",
                keyValue: 10);
        }
    }
}

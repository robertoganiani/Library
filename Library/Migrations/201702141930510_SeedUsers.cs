namespace Library.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'747ab28b-d231-4166-9de8-a35c66537279', N'admin@library.com', 0, N'AJ9Wx4vVcrSsn+lNmGAviOdk1RJhfgdOCJzjSox0RByNYLjiAO0GyQUL7Cy3fH+Lig==', N'0d2a110d-2254-4923-be90-35e923af23cc', NULL, 0, 0, NULL, 1, 0, N'admin@library.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f18065ca-fc5c-4cdf-baca-619c21e0ea17', N'guest@library.com', 0, N'AGjH9Hu8inUB4oz7YPXOwrzjMguW4IiPRhheSQFCrPJFIjcOf6N7K21XuXMgfv9PQg==', N'c1ec7992-081d-492b-ac05-ba68da1eea07', NULL, 0, 0, NULL, 1, 0, N'guest@library.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ef16bf90-73e1-4857-b90f-2a6116ed1ae7', N'CanManageBooks')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'747ab28b-d231-4166-9de8-a35c66537279', N'ef16bf90-73e1-4857-b90f-2a6116ed1ae7')
            ");
        }

        public override void Down()
        {
        }
    }
}

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'17faab1f-80a5-4198-ac85-641fb7d30ee9', N'guest', N'ADAzEHHBkX2JiZOQWXasMgi3dXYTvH2Dc0L5Tx6ZbSwVRTWj4nwiD0EHDbC2cNZpYg==', N'bcaa0ece-12d0-4814-8cb1-beb5ef67adb8', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'22660c4e-2f73-4905-bd1f-c9313b7becf2', N'admin', N'AEo4ItYjflKz4jyv5ZzycIs+AD1lVy4iqvEd6iOLmjTytLLlztWnovOOIORmmyAdxQ==', N'49c33460-df30-4128-90a3-f1d6ed24ecb3', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1b7c4b1a-f869-4aac-8f0a-fc6134718a69', N'CanManageMovie')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'22660c4e-2f73-4905-bd1f-c9313b7becf2', N'1b7c4b1a-f869-4aac-8f0a-fc6134718a69')


");
        }
        
        public override void Down()
        {
        }
    }
}

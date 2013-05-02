namespace SEProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DaoTaos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenMonHoc = c.String(),
                        tenGiangVien = c.String(),
                        khoaHoc = c.String(),
                        nganhHoc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DaoTaos");
        }
    }
}

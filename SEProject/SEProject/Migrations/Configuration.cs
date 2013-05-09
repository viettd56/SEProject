namespace SEProject.Migrations
{
    using SEProject.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SEProject.Models.DaoTaoDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SEProject.Models.DaoTaoDBContext context)
        {
            context.daoTaos.AddOrUpdate(i => i.tenGiangVien,
                new DaoTao
                {
                    tenMonHoc = "Lập trình nâng cao",
                    tenGiangVien = "Nguyễn Văn Vinh",
                    khoaHoc = "QH-2011",
                    nganhHoc = "Công nghệ thông tin"
                }
            );
        }
    }
}

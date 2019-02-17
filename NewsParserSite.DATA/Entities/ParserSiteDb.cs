namespace NewsParserSite.DATA.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ParserSiteDb : DbContext
    {
        public ParserSiteDb()
            : base("name=ParserSiteDb")
        {
        }

        public virtual DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

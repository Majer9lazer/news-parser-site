namespace NewsParserSite.DATA.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1750)]
        public string Theme { get; set; }

        [StringLength(3500)]
        public string Description { get; set; }

        public DateTime DateOfPublish { get; set; }
    }
}

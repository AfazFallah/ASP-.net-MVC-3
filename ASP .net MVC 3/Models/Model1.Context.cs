namespace ASP.net_MVC_3.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class db_WebTestEntities : DbContext
    {
        public db_WebTestEntities()
            : base("name=db_WebTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_Students> T_Students { get; set; }
    }
}

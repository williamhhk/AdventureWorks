using EntityFramework.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
    public partial class AdventureWorks : DbContext
    {
        public const string Production = nameof(Production);
        public AdventureWorks()
            : base("name=AdventureWorks2014Entities")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.AddFunctions(typeof(NiladicFunctions));
        }

        public DbSet<ProductCategory> ProductCategories { get; set; }

    }

    [Table(nameof(ProductCategory), Schema = AdventureWorks.Production)]
    public partial class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductCategoryID { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }


    public static class NiladicFunctions
    {
        [Function(FunctionType.NiladicFunction, "CURRENT_TIMESTAMP")]
        public static DateTime? CurrentTimestamp() => Function.CallNotSupported<DateTime?>();

        [Function(FunctionType.NiladicFunction, "CURRENT_USER")]
        public static string CurrentUser() => Function.CallNotSupported<string>();

        [Function(FunctionType.NiladicFunction, "SESSION_USER")]
        public static string SessionUser() => Function.CallNotSupported<string>();

        [Function(FunctionType.NiladicFunction, "SYSTEM_USER")]
        public static string SystemUser() => Function.CallNotSupported<string>();

        [Function(FunctionType.NiladicFunction, "USER")]
        public static string User() => Function.CallNotSupported<string>();
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks
{
    class Program
    {
        public static object Assert { get; private set; }

        static void Main(string[] args)
        {
            using (var context = new AdventureWorks())
            {
                var firstCategory = context.ProductCategories.GroupBy
                    (p => p.ProductCategoryID)
                    .Select(category => new
                    {
                        CategoryId = category.Key,
                        CurrentTimestamp = NiladicFunctions.CurrentTimestamp(),
                        CurrentUser = NiladicFunctions.CurrentUser(),
                        SessionUser = NiladicFunctions.SessionUser(),
                        SystemUser = NiladicFunctions.SystemUser(),
                        User = NiladicFunctions.User()
                    }).First();



                var list = firstCategory;
            }
        }
    }
}

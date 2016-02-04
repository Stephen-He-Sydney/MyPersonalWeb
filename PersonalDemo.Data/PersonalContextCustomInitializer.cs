using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDemo.Data
{
    public class PersonalContextCustomInitializer : IDatabaseInitializer<PersonalDemoContext>
    {
        public void InitializeDatabase(PersonalDemoContext context)
        {
            if (!context.Database.Exists())
            {
                context.Database.Create();
            }
        }
    }
}

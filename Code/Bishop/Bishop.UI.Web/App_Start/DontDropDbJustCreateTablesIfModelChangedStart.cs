using System.Data.Entity;
using Devtalk.EF.CodeFirst;

[assembly: WebActivator.PreApplicationStartMethod(typeof(Bishop.UI.Web.App_Start.DontDropDbJustCreateTablesIfModelChangedStart), "Start")]

namespace Bishop.UI.Web.App_Start
{
    using Bishop.Model;

    public static class DontDropDbJustCreateTablesIfModelChangedStart
    {
        public static void Start()
        {
            // Uncomment this line and replace CONTEXT_NAME with the name of your DbContext if you are 
            // using your DbContext to create and manage your database
        }
    }
}

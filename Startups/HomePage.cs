using System;
using MVVMSidekick.Views;
using SLWeek.ViewModels;
using SLWeek.Views;

namespace MVVMSidekick.Startups
{
    internal static partial class StartupFunctions
    {
        static Action HomePageConfig =
           CreateAndAddToAllConfig(ConfigHomePage);

        public static void ConfigHomePage()
        {
            ViewModelLocator<HomePage_Model>
                .Instance
                .Register(context =>
                    new HomePage_Model())
                .GetViewMapper()
                .MapToDefault<HomePage>();

        }
    }
}

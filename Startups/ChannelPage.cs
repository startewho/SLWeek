using System;
using MVVMSidekick.Views;
using SLWeek.ViewModels;
using SLWeek.Views;

namespace MVVMSidekick.Startups
{
    internal static partial class StartupFunctions
    {
        static Action ChannelPageConfig =
           CreateAndAddToAllConfig(ConfigChannelPage);

        public static void ConfigChannelPage()
        {
            ViewModelLocator<ChannelPage_Model>
                .Instance
                .Register(context =>
                    new ChannelPage_Model())
                .GetViewMapper()
                .MapToDefault<ChannelPage>();

        }
    }
}

using MVVMSidekick.Views;
using SLWeek.ViewModels;
using SLWeek.Views;
using System;


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

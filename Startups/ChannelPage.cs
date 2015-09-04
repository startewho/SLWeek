using System.Reactive;
using System.Reactive.Linq;
using MVVMSidekick.ViewModels;
using MVVMSidekick.Views;
using MVVMSidekick.Reactive;
using MVVMSidekick.Services;
using MVVMSidekick.Commands;
using SLWeek;
using SLWeek.ViewModels;
using SLWeek.Views;
using System;
using System.Net;
using System.Windows;


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

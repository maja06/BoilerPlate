using System.Security.Policy;
using Abp.Application.Navigation;
using Abp.Localization;

namespace BoilerPlate.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class BoilerPlateNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fa fa-home"
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "Home/About",
                        icon: "fa fa-info"
                    )

                ).AddItem(
                    new MenuItemDefinition(
                        "Kancelarija",
                        L("Kancelarija"),

                        icon: "fa fa-tasks"


                    ).AddItem(
                        new MenuItemDefinition(
                            "Kancelarija",
                            L("Dodaj novu kancelariju"),
                            url: "Kancelarija/Add",
                            icon: "fa fa-tasks")
                    ).AddItem(
                        new MenuItemDefinition(
                            "Kancelarija",
                            L("Sve kancelarije"),
                            url: "Kancelarija",
                            icon: "fa fa-tasks"))

                ).AddItem(new MenuItemDefinition(
                        "Osoba",
                        L("Osoba"),

                        icon: "fa fa-task"
                    ).AddItem(new MenuItemDefinition(
                        "Osoba",
                        L("Dodaj novu osobu"),
                        url: "Osoba/Add",
                        icon: "fa fa-tasks")
                    ).AddItem(new MenuItemDefinition(
                        "Osoba",
                        L("Sve Osobe"),
                        url: "Osoba",
                        icon: "fa fa-tasks" ))




                
        );




    }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BoilerPlateConsts.LocalizationSourceName);
        }
    }
}

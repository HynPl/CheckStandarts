using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace CheckStandarts {
    [Transaction(TransactionMode.Manual)]
    class App: IExternalApplication {

        public Result OnStartup(UIControlledApplication application) {
            Setting.SolveLang(application);
            
            string tabname=Setting.Lang.TabName;
            string panelName=Setting.Lang.PanelName;
            Uri app_32x32=new Uri("pack://application:,,,/CheckStandarts;component/Resources/app_32x32.png");

            application.CreateRibbonTab(tabname);
            RibbonPanel panel =application.CreateRibbonPanel(tabname, panelName);
            
            PushButtonData button = new PushButtonData("CheckerApp", Setting.Lang.OpenApp, Assembly.GetExecutingAssembly().Location, "CheckStandarts.Command") {
                LargeImage = new BitmapImage(app_32x32),
                ToolTip = "Click to open aplication",
                LongDescription = "",
            };
            panel.AddItem(button);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application) {
            return Result.Succeeded;
        }
    }   
}

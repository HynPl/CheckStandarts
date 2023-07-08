using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace CheckStandarts {

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand {
        public static UIApplication uiApp;
        public static UIDocument doc;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) {
            UIApplication uiapp=commandData.Application;
            uiApp=uiapp;
            UIDocument activeDoc = uiapp.ActiveUIDocument;
            doc=activeDoc;

            Setting.Load();
           
            FormApp appForm=new FormApp();
            appForm.Show();

            return Result.Succeeded;
        }
    }
}
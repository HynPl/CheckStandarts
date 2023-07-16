using System.Drawing;

namespace CheckStandarts {
    public interface IControlReportedProblem  {
        void SetCheckObject(CheckObject obj);

        void Dispose();

        int Height{ get; set; }
        bool Visible{ get; set; }
        Point Location { get; set; }
    }
}
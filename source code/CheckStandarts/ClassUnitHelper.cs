namespace CheckStandarts {
    static class ClassUnitHelper {
        public static double ConvertToMeters(double inches) => inches*0.3048d;
        public static double ConvertToMilimeters(double inches) => inches*304.8d;
        public static string PrintableHeight(double meters){
            if (meters>0) return "+"+meters.ToString("{0:#.0,000}");
            else if (meters<0) return meters.ToString("{0:#.0,000}");
            else return "±0,000";
        }
    }

    //class Unit {
    //    public double Value;
        
    //    public int ToM(){ }
    //}
}

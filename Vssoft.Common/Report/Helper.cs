namespace Vssoft.Common.Report
{
    using DevExpress.XtraReports.UI;
    using System;
    using System.IO;
    using System.Reflection;

    public static class Helper
    {
        public static string GetReportPath(XtraReport fReport, string ext)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            string name = fReport.Name;
            if (name.Length == 0)
            {
                name = fReport.GetType().Name;
            }
            return Path.Combine(Path.GetDirectoryName(executingAssembly.Location), name + "." + ext);
        }
    }
}


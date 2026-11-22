// ReportManager violates SRP because it handles both formatting and saving reports.
// It violates OCP because adding a new format like Excel requires changing
// the existing GenerateReport() method.

using System;

namespace SolidRefactoringLab
{
    // Every formatter must provide a FormatReport() method.
    public interface IReportFormatter
    {awd 
        void FormatReport();
    }

    public class PdfFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a PDF...");
        }
    }

    public class WordFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }

    public class PlainTextFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as plain text...");
        }
    }

    public class ReportManager
    {
        private readonly IReportFormatter formatter;

        // Main passes in the formatter when it creates the manager.
        public ReportManager(IReportFormatter formatter)
        {
            this.formatter = formatter;
        }

        public void GenerateReport()
        {
            formatter.FormatReport();
        }
    }

    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IReportFormatter formatter = new PdfFormatter();

            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();

            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}
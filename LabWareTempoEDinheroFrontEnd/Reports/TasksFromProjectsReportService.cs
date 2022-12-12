using iTextSharp.text.pdf;
using iTextSharp.text;
using LabWareTempoEDinheroFrontEnd.Models.ReportModels;
using LabWareTempoEDinheroFrontEnd.Reports.Helper;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using System.Diagnostics;
using LabWareTempoEDinheroFrontEnd.Reports.Interfaces;

namespace LabWareTempoEDinheroFrontEnd.Reports
{
    public class TasksFromProjectsReportService : ITasksFromProjectsReportService
    {
        static BaseFont fontBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        private readonly ITaskProjectRepository reportRepository;

        public TasksFromProjectsReportService(ITaskProjectRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public void GetProjectsAgentsWorkingReport()
        {
            var projectAgentReport = reportRepository.GetTasksProjectReport();
            GeneratePDF(projectAgentReport);
        }

        public List<TasksFromProjectReportModel> GetTasksProjectReport()
        {
            return reportRepository.GetTasksProjectReport();
        }

        public void GeneratePDF(List<TasksFromProjectReportModel> projectAgentReport)
        {
            var totalPages = 1;
            int totalLines = projectAgentReport.Count;
            if (totalLines > 24)
                totalPages += (int)Math.Ceiling((totalLines - 24) / 29F);
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4.Rotate(), 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
            var fileName = $"tarefasProjetos{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.pdf";
            var file = new FileStream(fileName, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, file);
            writer.PageEvent = new PageEvents(totalPages);
            pdf.Open();

            var fontParagraph = new Font(fontBase, 32, Font.NORMAL, BaseColor.Black);
            var title = new Paragraph("Relatório Tarefas / Projetos\n\n", fontParagraph);
            title.Alignment = Element.ALIGN_LEFT;
            title.SpacingAfter = 4;
            pdf.Add(title);
            var table = new PdfPTable(5);
            float[] columnsWidth = { 1f, 0.7f, 1.5f, 0.8f, 1f };
            table.SetWidths(columnsWidth);
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;


            CreateTextCelula(table, "Id da tarefa", Element.ALIGN_CENTER, true);
            CreateTextCelula(table, "Objetivo", Element.ALIGN_CENTER, true);
            CreateTextCelula(table, "Status da Tarefa", Element.ALIGN_CENTER, true);
            CreateTextCelula(table, "Nome do Projeto", Element.ALIGN_CENTER, true);
            CreateTextCelula(table, "Descrição do Projeto", Element.ALIGN_CENTER, true);

            foreach (var t in projectAgentReport)
            {
                CreateTextCelula(table, t.IdTask.ToString("D6"), Element.ALIGN_CENTER);
                CreateTextCelula(table, t.Objective.ToString(), Element.ALIGN_CENTER);
                CreateTextCelula(table, t.StatusTask.ToString(), Element.ALIGN_CENTER);
                CreateTextCelula(table, t.NameProject.ToString(), Element.ALIGN_CENTER);
                CreateTextCelula(table, t.DescriptionProject.ToString(), Element.ALIGN_CENTER);
            }

            pdf.Add(table);

            pdf.Close();
            file.Close();

            var pdfPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (File.Exists(pdfPath))
            {
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = $"/c start firefox {pdfPath}",
                    FileName = "cmd.exe",
                    CreateNoWindow = true
                });
            }

        }

        static void CreateTextCelula(PdfPTable table, string text, int alignmentHorz = Element.ALIGN_LEFT, bool negrito = false,
            bool italico = false, int tamanhoFonte = 12, int alturaCelula = 25)
        {
            int style = Font.NORMAL;
            if (negrito && italico)
            {
                style = Font.BOLDITALIC;
            }
            else if (negrito)
            {
                style = Font.BOLD;
            }
            else if (italico)
            {
                style = Font.ITALIC;
            }

            var fontCelula = new Font(fontBase, tamanhoFonte, style, BaseColor.Black);

            var bgColor = BaseColor.White;
            if (table.Rows.Count % 2 == 1)
            {
                bgColor = new BaseColor(0.95F, 0.95F, 0.95F);
            }

            var celula = new PdfPCell(new Phrase(text, fontCelula));

            celula.HorizontalAlignment = alignmentHorz;
            celula.VerticalAlignment = Element.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.FixedHeight = alturaCelula;
            celula.PaddingBottom = 5;
            celula.BackgroundColor = bgColor;
            table.AddCell(celula);
        }
    }
}

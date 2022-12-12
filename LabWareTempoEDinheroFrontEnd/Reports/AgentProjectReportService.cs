using iTextSharp.text;
using iTextSharp.text.pdf;
using LabWareTempoEDinheroFrontEnd.Models.ReportModels;
using LabWareTempoEDinheroFrontEnd.Reports.Helper;
using LabWareTempoEDinheroFrontEnd.Reports.Interfaces;
using LabWareTempoEDinheroFrontEnd.Repository.Interfaces;
using System.Diagnostics;

namespace LabWareTempoEDinheroFrontEnd.Reports
{
    public class AgentProjectReportService : IAgentProjectReportService
    {
        static BaseFont fontBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        private readonly IReportRepository reportRepository;

        public AgentProjectReportService(IReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public void GetProjectsAgentsWorkingReport()
        {
            var projectAgentReport = reportRepository.GetAgentProjectReport();
            GeneratePDF(projectAgentReport);
        }

        public List<ProjectsAgentsWorkingReportModel> GetAgentProjectReport()
        {
            return reportRepository.GetAgentProjectReport();
        }

        public void GeneratePDF(List<ProjectsAgentsWorkingReportModel> projectAgentReport)
        {
            var totalPages = 1;
            int totalLines = projectAgentReport.Count;
            if (totalLines > 24)
                totalPages += (int)Math.Ceiling((totalLines - 24) / 29F);
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4.Rotate(), 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
            var fileName = $"agentesProjetos{DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss")}.pdf";
            var file = new FileStream(fileName, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, file);
            writer.PageEvent = new PageEvents(totalPages);
            pdf.Open();

            var fontParagraph = new iTextSharp.text.Font(fontBase, 32, Font.NORMAL, BaseColor.Black);
            var title = new Paragraph("Relatório Agentes / Projetos\n\n", fontParagraph);
            title.Alignment = Element.ALIGN_LEFT;
            title.SpacingAfter = 4;
            pdf.Add(title);
            var table = new PdfPTable(6);
            float[] columnsWidth = { 1f, 0.7f, 1.5f, 0.8f, 1f, 0.8f };
            table.SetWidths(columnsWidth);
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;


            CreateTextCelula(table, "Id Agente", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Nome Agente", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Id Projeto", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Nome do Projeto", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Descrição do Projeto", PdfPCell.ALIGN_CENTER, true);
            CreateTextCelula(table, "Status do Projeto", PdfPCell.ALIGN_CENTER, true);

            foreach (var t in projectAgentReport)
            {
                CreateTextCelula(table, t.IdAgent.ToString("D6"), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.NameAgent.ToString(), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.IdProject.ToString(), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.NameProject.ToString(), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.DescriptionProject.ToString(), PdfPCell.ALIGN_CENTER);
                CreateTextCelula(table, t.StatusProject.ToString(), PdfPCell.ALIGN_CENTER);
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

        static void CreateTextCelula(PdfPTable table, string text, int alignmentHorz = PdfPCell.ALIGN_LEFT, bool negrito = false,
            bool italico = false, int tamanhoFonte = 12, int alturaCelula = 25)
        {
            int style = iTextSharp.text.Font.NORMAL;
            if (negrito && italico)
            {
                style = iTextSharp.text.Font.BOLDITALIC;
            }
            else if (negrito)
            {
                style = iTextSharp.text.Font.BOLD;
            }
            else if (italico)
            {
                style = iTextSharp.text.Font.ITALIC;
            }

            var fontCelula = new iTextSharp.text.Font(fontBase, tamanhoFonte, style, BaseColor.Black);

            var bgColor = iTextSharp.text.BaseColor.White;
            if (table.Rows.Count % 2 == 1)
            {
                bgColor = new BaseColor(0.95F, 0.95F, 0.95F);
            }

            var celula = new PdfPCell(new Phrase(text, fontCelula));

            celula.HorizontalAlignment = alignmentHorz;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.FixedHeight = alturaCelula;
            celula.PaddingBottom = 5;
            celula.BackgroundColor = bgColor;
            table.AddCell(celula);
        }
    }
}

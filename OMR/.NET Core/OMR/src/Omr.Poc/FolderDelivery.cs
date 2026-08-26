using System.Text;
using Omr.Engine.Results;

namespace Omr.Poc;

public sealed class PageDelivery
{
    public required int PageIndex { get; init; }

    public required string StudentId { get; init; }

    public required string ExamId { get; init; }

    public required double Grade { get; init; }

    public required bool NeedsReview { get; init; }

    public required string PageStatus { get; init; }

    public required string? FailureReason { get; init; }

    public required string Answers { get; init; }

    public required string Confidence { get; init; }

    public required string Diagnostics { get; init; }

    public required string JsonPath { get; init; }

    public required string ImagePath { get; init; }
}

public interface IResultDelivery
{
    Task DeliverAsync(PageDelivery page, CancellationToken cancellationToken = default);

    Task CompleteAsync(IReadOnlyList<PageDelivery> pages, CancellationToken cancellationToken = default);
}

public sealed class FolderDelivery : IResultDelivery
{
    public FolderDelivery(string outputDirectory)
    {
        OutputDirectory = outputDirectory;
        Directory.CreateDirectory(OutputDirectory);
    }

    public string OutputDirectory { get; }

    public Task DeliverAsync(PageDelivery page, CancellationToken cancellationToken = default) => Task.CompletedTask;

    public async Task CompleteAsync(IReadOnlyList<PageDelivery> pages, CancellationToken cancellationToken = default)
    {
        string csvPath = Path.Combine(OutputDirectory, "summary.csv");
        StringBuilder csv = new();
        csv.AppendLine("pageIndex,studentId,examId,grade,needsReview,pageStatus,failureReason,answers,confidence,diagnostics,jsonPath,imagePath");
        foreach (PageDelivery page in pages)
        {
            csv.AppendLine(string.Join(',',
                page.PageIndex,
                Csv(page.StudentId),
                Csv(page.ExamId),
                page.Grade.ToString("0.##"),
                page.NeedsReview,
                Csv(page.PageStatus),
                Csv(page.FailureReason ?? ""),
                Csv(page.Answers),
                Csv(page.Confidence),
                Csv(page.Diagnostics),
                Csv(page.JsonPath),
                Csv(page.ImagePath)));
        }

        await File.WriteAllTextAsync(csvPath, csv.ToString(), cancellationToken);
    }

    private static string Csv(string value)
    {
        if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
        {
            return '"' + value.Replace("\"", "\"\"") + '"';
        }

        return value;
    }
}

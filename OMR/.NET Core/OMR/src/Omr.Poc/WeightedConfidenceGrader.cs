using Omr.Engine;
using Omr.Engine.Results;

namespace Omr.Poc;

public sealed class GradeResult
{
    public required string StudentId { get; init; }

    public required string ExamId { get; init; }

    public required double Score { get; init; }

    public required int Awarded { get; init; }

    public required int Possible { get; init; }

    public required bool NeedsReview { get; init; }

    public required IReadOnlyList<string> Notes { get; init; }
}

public interface IExamGrader
{
    GradeResult Grade(OmrPageResult page);
}

/// <summary>
/// Example policy: correct answer with High=1, Medium=0.5, Low=0.25.
/// Blank, multiple, and ambiguous answers score 0 and flag review.
/// </summary>
public sealed class WeightedConfidenceGrader : IExamGrader
{
    private readonly IReadOnlyDictionary<string, string> _answerKey;

    public WeightedConfidenceGrader(IReadOnlyDictionary<string, string> answerKey)
    {
        _answerKey = answerKey;
    }

    public static WeightedConfidenceGrader Cs101V3() => new(new Dictionary<string, string>
    {
        ["q1"] = "B",
        ["q2"] = "A",
        ["q3"] = "D",
        ["q4"] = "C",
        ["q5"] = "B"
    });

    public GradeResult Grade(OmrPageResult page)
    {
        string studentId = "unknown";
        string examId = page.TemplateId ?? "unknown";
        if (!string.IsNullOrWhiteSpace(page.DecodedQrValue))
        {
            string[] parts = page.DecodedQrValue.Split('|');
            if (parts.Length >= 1)
            {
                examId = parts[0];
            }

            if (parts.Length >= 3)
            {
                studentId = parts[2];
            }
        }

        double awarded = 0;
        int possible = _answerKey.Count;
        List<string> notes = [];
        bool review = page.PageStatus is PageStatus.NeedsReview or PageStatus.Failed;

        foreach ((string questionId, string correct) in _answerKey)
        {
            OmrGroupResult? answer = page.Groups.FirstOrDefault(g => g.Id == questionId);
            OmrGroupResult? confidence = page.Groups.FirstOrDefault(g => g.Id == questionId + "-confidence");
            if (answer is null)
            {
                notes.Add($"{questionId}: missing");
                review = true;
                continue;
            }

            switch (answer.Status)
            {
                case GroupStatus.Selected:
                    if (answer.SelectedOptionIds.Count == 1 && answer.SelectedOptionIds[0] == correct)
                    {
                        awarded += ConfidenceWeight(confidence);
                    }
                    else
                    {
                        notes.Add($"{questionId}: incorrect");
                    }

                    break;
                case GroupStatus.Blank:
                    notes.Add($"{questionId}: blank");
                    review = true;
                    break;
                case GroupStatus.Multiple:
                    notes.Add($"{questionId}: multiple");
                    review = true;
                    break;
                case GroupStatus.Ambiguous:
                    notes.Add($"{questionId}: ambiguous");
                    review = true;
                    break;
                case GroupStatus.Unreadable:
                    notes.Add($"{questionId}: unreadable");
                    review = true;
                    break;
                default:
                    throw new InvalidOperationException($"Unhandled group status {answer.Status}.");
            }

            if (confidence is not null && confidence.Status is not GroupStatus.Selected and not GroupStatus.Blank)
            {
                notes.Add($"{questionId}: confidence {confidence.Status}");
                review = true;
            }
        }

        double score = possible == 0 ? 0 : Math.Round(100.0 * awarded / possible, 2);
        return new GradeResult
        {
            StudentId = studentId,
            ExamId = examId,
            Score = score,
            Awarded = (int)Math.Round(awarded * 100),
            Possible = possible * 100,
            NeedsReview = review,
            Notes = notes
        };
    }

    private static double ConfidenceWeight(OmrGroupResult? confidence)
    {
        if (confidence is null || confidence.Status != GroupStatus.Selected || confidence.SelectedOptionIds.Count != 1)
        {
            return 1.0;
        }

        return confidence.SelectedOptionIds[0] switch
        {
            "H" => 1.0,
            "M" => 0.5,
            "L" => 0.25,
            _ => 0
        };
    }
}

using Omr.Engine;
using Omr.Engine.Templates;

namespace Omr.Poc;

public sealed class CatalogTemplateResolver : ITemplateResolver
{
    private readonly Dictionary<string, OmrTemplate> _byKey;

    public CatalogTemplateResolver(params OmrTemplate[] templates)
    {
        _byKey = new Dictionary<string, OmrTemplate>(StringComparer.OrdinalIgnoreCase);
        foreach (OmrTemplate template in templates)
        {
            _byKey[$"{template.TemplateId}|{template.TemplateVersion}"] = template;
            _byKey[template.TemplateId] = template;
        }
    }

    public OmrTemplate? Resolve(string? qrValue)
    {
        if (string.IsNullOrWhiteSpace(qrValue))
        {
            return null;
        }

        // Payload: exam-cs101|v3|student-001
        string[] parts = qrValue.Split('|');
        if (parts.Length >= 2)
        {
            string version = parts[1].StartsWith('v') ? parts[1][1..] : parts[1];
            string key = $"{parts[0]}|{version}";
            if (_byKey.TryGetValue(key, out OmrTemplate? exact))
            {
                return exact;
            }
        }

        return _byKey.GetValueOrDefault(parts[0]);
    }
}

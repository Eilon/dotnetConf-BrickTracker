using System.Globalization;
using System.Reflection;

namespace BrickSummary
{
    internal static class BrickSetLoader
    {
        public static async Task LoadSets(Stream csvStream, List<BrickSetItem> setCollection)
        {
            using var reader = new StreamReader(csvStream);
            var allCsv = await reader.ReadToEndAsync();
            var csvLines = allCsv.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var columnMap = GetColumnMapping(csvLines[0]);

            foreach (var brickSetLine in csvLines.Skip(1))
            {
                setCollection.Add(
                    BuildBrickSetItem(brickSetLine, columnMap));
            }
        }

        private static readonly PropertyInfo[] BrickSetProperties = typeof(BrickSetItem).GetProperties();

        private static BrickSetItem BuildBrickSetItem(string brickSetLine, IDictionary<string, int> columnMap)
        {
            var columnValues = GetRowParts(brickSetLine);

            var bsi = new BrickSetItem();

            foreach (var brickProp in BrickSetProperties)
            {
                if (columnMap.TryGetValue(brickProp.Name, out var columnIndex))
                {
                    var value = GetValue(columnValues[columnIndex], brickProp.PropertyType);
                    brickProp.SetValue(bsi, value);
                }
            }

            return bsi;
        }

        private static object? GetValue(string? stringValue, Type propertyType)
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return null;
            }

            return Convert.ChangeType(stringValue, Nullable.GetUnderlyingType(propertyType) ?? propertyType, CultureInfo.InvariantCulture);
        }

        private static IDictionary<string, int> GetColumnMapping(string headerLine)
        {
            var rawColumnNames = GetRowParts(headerLine);
            var columnNames = rawColumnNames.Select((rawName, index) => (name: SimplifyName(rawName), index: index)).ToDictionary(x => x.name, x => x.index);
            return columnNames;
        }

        private static string SimplifyName(string rawName)
        {
            return rawName
                .Replace("(", "")
                .Replace(")", "")
                .Replace(" ", "_");
        }

        private static IList<string?> GetRowParts(string csvRow)
        {
            var parts = new List<string?>();

            var index = 0;

            while (index < csvRow.Length)
            {
                if (csvRow[index] == ',')
                {
                    parts.Add(null);
                }
                else if (csvRow[index] == '"')
                {
                    var nextQuoteIndex = csvRow.IndexOf('"', index + 1);
                    parts.Add(csvRow.Substring(index + 1, nextQuoteIndex - index - 1));
                    index = nextQuoteIndex + 1; // skip the close quote
                }
                else
                {
                    var nextCommaIndex = csvRow.IndexOf(',', index + 1);
                    if (nextCommaIndex == -1)
                    {
                        nextCommaIndex = csvRow.Length;
                    }
                    parts.Add(csvRow.Substring(index, nextCommaIndex - index));
                    index = nextCommaIndex;
                }

                index++; // skip the comma
            }

            return parts;
        }
    }
}

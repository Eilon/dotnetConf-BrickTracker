namespace BrickSummary
{
    public class BrickSetCollection
    {
        public string? Name { get; set; }
        public List<BrickSetItem> Sets { get; } = new();
        public Dictionary<string, string> Analysis { get; } = new();

        public async Task LoadSets(Stream csvStream)
        {
            Sets.Clear();

            await BrickSetLoader.LoadSets(csvStream, Sets);
        }
    }
}

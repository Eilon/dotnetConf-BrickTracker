namespace BrickSummary
{
    public class BrickSetItem
    {
        public string? Number { get; set; }
        public string? Theme { get; set; }
        public string? Subtheme { get; set; }
        public int? Year { get; set; }
        public string? Set_name { get; set; }
        public int? Minifigs { get; set; }
        public int? Pieces { get; set; }
        public decimal? RRP_USD { get; set; }
        /// <summary>
        /// Width in centimeters.
        /// </summary>
        public decimal? Width { get; set; }
        /// <summary>
        /// Height in centimeters.
        /// </summary>
        public decimal? Height { get; set; }
        /// <summary>
        /// Depth in centimeters.
        /// </summary>
        public decimal? Depth { get; set; }
        /// <summary>
        /// Weight in kilograms.
        /// </summary>
        public decimal? Weight { get; set; }
        public string? Notes { get; set; }
        public int? Qty_owned { get; set; }
        public int? Wanted { get; set; }
        public string? Launch_date { get; set; }
    }
}

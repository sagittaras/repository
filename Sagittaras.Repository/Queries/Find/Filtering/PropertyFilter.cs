namespace Sagittaras.Repository.Queries.Find.Filtering
{
    /// <summary>
    /// Defines a filter over a property.
    /// </summary>
    public class PropertyFilter
    {
        /// <summary>
        /// The name of property.
        /// </summary>
        public string PropertyName { get; set; } = string.Empty;
        
        /// <summary>
        /// The type of filter to apply.
        /// </summary>
        public ComparisonType ComparisonType { get; set; } = ComparisonType.Equals;
        
        /// <summary>
        /// The value to filter by.
        /// </summary>
        public string Value { get; set; } = string.Empty;
    }
}
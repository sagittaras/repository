namespace Sagittaras.Repository.Queries.Find.Filtering
{
    /// <summary>
    /// Defines the type of property value comparision.
    /// </summary>
    public enum ComparisonType
    {
        /// <summary>
        /// The value of property must be equal.
        /// </summary>
        /// <example>Property == value</example>
        Equals,
        
        /// <summary>
        /// The value of property must be not equal.
        /// </summary>
        /// <example>Property != value</example>
        NotEqual,
        
        /// <summary>
        /// The property value should contains the filtered value.
        /// </summary>
        /// <example>Property.Contains(value)</example>
        Contains,
        
        /// <summary>
        /// The property value should not contains the filtered value.
        /// </summary>
        /// <example>!Property.Contains(value)</example>
        NotContains
    }
}
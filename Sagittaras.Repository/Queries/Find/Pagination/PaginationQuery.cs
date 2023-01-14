namespace Sagittaras.Repository.Queries.Find.Pagination
{
    /// <summary>
    /// Query object enabling the pagination behaviour.
    /// </summary>
    public class PaginationQuery
    {
        /// <summary>
        /// How many items should be selected from the database.
        /// </summary>
        public int Limit { get; set; }
        
        /// <summary>
        /// How many items should be skipped from the database.
        /// </summary>
        public int Offset { get; set; }
    }
}
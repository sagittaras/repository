namespace Sagittaras.Repository.Operations
{
    /// <summary>
    /// Represents a postponed operation which should be applied when the repository is saving its changes.
    /// </summary>
    public interface IRepositoryOperation
    {
        /// <summary>
        /// Apply the changes made by this operation.
        /// </summary>
        void Apply();
    }
}
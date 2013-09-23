namespace CubedElement.DataTable.Contracts
{
    /// <summary>
    /// IDataTableRequestCollection is a contract that is used to help provide a way to organize the data received from JQuery DataTables plug in, so 
    /// you can just focus on grabbing information from the database system
    /// </summary>
    public interface IDataTableRequestCollection
    {
        /// <summary>
        /// 'sEcho'
        /// </summary>
        string Echo { get; set; }

        /// <summary>
        /// Determines if the output should be serialized as a <c>DataContract</c> or an <c>object[]</c>
        /// </summary>
        /// <returns></returns>
        bool SerializeAsDataContract();
    }
}
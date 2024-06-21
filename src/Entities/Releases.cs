using System.ComponentModel.DataAnnotations.Schema;
using Accounting.Project.src.Entities.Base;
using Accounting.Project.src.Infra.Enums;

namespace Accounting.Project.src.Entities
{
    /// <summary>
    /// Lançamentos
    /// </summary>
    public class Releases : EntityBase
    {
        /// <summary>
        /// Débito/crédito
        /// </summary>
        [Column("type")]
        public FactType Type { get; set; }

        /// <summary>
        /// Valor total
        /// </summary>
        [Column("total_amount")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Id da conta contábil
        /// </summary>
        [Column("account_id")]
        public long AccountId { get; set; }

        #region References

        public virtual Accounts Account { get; set; }

        #endregion
    }
}
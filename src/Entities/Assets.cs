using System.ComponentModel.DataAnnotations.Schema;
using Accounting.Project.src.Entities.Base;
using Accounting.Project.src.Infra.Enums;

namespace Accounting.Project.src.Entities
{
    /// <summary>
    /// Itens (Mercadorias e bens)
    /// </summary>
    public class Assets : EntityBase
    {
        /// <summary>
        /// Nome
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Preço de compra
        /// </summary>
        [Column("purchase_price")]
        public decimal PurchasePrice { get; set; }

        /// <summary>
        /// Preço de venda
        /// </summary>
        [Column("selling_price")]
        public decimal? SellingPrice { get; set; } = 0;

        /// <summary>
        /// Preço de venda
        /// </summary>
        [Column("type")]
        public AssetsTypeEnum Type { get; set; }

        /// <summary>
        /// Id da conta contábil
        /// </summary>
        [Column("account_id")]
        public long AccountId { get; set; }

        #region References

        public virtual Accounts Account { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<Notes> Notes { get; set; }

        #endregion
    }
}
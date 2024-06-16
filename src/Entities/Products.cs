using System.ComponentModel.DataAnnotations.Schema;
using Child.Growth.src.Entities.Base;

namespace Child.Growth.src.Entities
{
    /// <summary>
    /// Produto
    /// </summary>
    public class Products : EntityBase
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
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// Porcentagem do ICMS
        /// </summary>
        [NotMapped]
        public decimal Icms { get; } = 18;

        /// <summary>
        /// ICMS a crédito
        /// </summary>
        [NotMapped]
        public decimal IcmsCredit => PurchasePrice * (Icms / 100);

        /// <summary>
        /// ICMS a débito
        /// </summary>
        [NotMapped]
        public decimal IcmsDebit => SellingPrice * (Icms / 100);

        /// <summary>
        /// Custo é o preço de compra mais o crédito de ICMS
        /// </summary>
        /// <returns></returns>
        public decimal CalculateCost()
        {
            return PurchasePrice + IcmsCredit;
        }

        /// <summary>
        /// Lucro é o total da venda menos o custo total
        /// </summary>
        /// <returns></returns>
        public decimal CalculateProfit()
        {
            return SellingPrice - CalculateCost();
        }
    }
}
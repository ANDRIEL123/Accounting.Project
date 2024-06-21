using System.ComponentModel.DataAnnotations.Schema;
using Accounting.Project.src.Entities.Base;
using Accounting.Project.src.Infra.Enums;
using Microsoft.OpenApi.Models;

namespace Accounting.Project.src.Entities
{
    /// <summary>
    /// Notas fiscais
    /// </summary>
    public class Notes : EntityBase
    {
        /// <summary>
        /// Entrada/Saída
        /// </summary>
        [Column("signal")]
        public SignalTypeEnum Signal { get; set; }

        /// <summary>
        /// A vista ou a prazo
        /// </summary>
        [Column("operation")]
        public OperationTypeEnum Operation { get; set; }

        /// <summary>
        /// Id da mercadoria/bem/produto
        /// </summary>
        [Column("asset_id")]
        public long AssetId { get; set; }

        /// <summary>
        /// Id do cliente/fornecedor
        /// </summary>
        [Column("person_id")]
        public long PersonId { get; set; }

        #region References

        public virtual Assets Asset { get; set; }

        public virtual People Person { get; set; }

        #endregion
    }
}
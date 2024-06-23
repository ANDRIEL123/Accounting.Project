using System.ComponentModel.DataAnnotations.Schema;
using Accounting.Project.src.Entities.Base;
using Accounting.Project.src.Infra.Enums;

namespace Accounting.Project.src.Entities
{
    /// <summary>
    /// Lançamentos contábeis
    /// </summary>
    public class Accounts : EntityBase
    {
        /// <summary>
        /// Código
        /// </summary>
        [Column("code")]
        public string Code { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tipo de conta
        /// </summary>
        [Column("type")]
        public AccountType Type { get; set; }

        /// <summary>
        /// Circulante
        /// </summary>
        [Column("current")]
        public CurrentTypeEnum? Current { get; set; }

        /// <summary>
        /// Id da conta contábil
        /// </summary>
        [Column("match_account_id")]
        public long? MatchAccountId { get; set; }

        #region References

        public virtual Accounts MatchAccount { get; set; }

        #endregion

        #region Collections

        public virtual ICollection<Releases> Releases { get; set; }
        public virtual ICollection<Assets> Assets { get; set; }
        public virtual ICollection<Accounts> MatchAccounts { get; set; }

        #endregion
    }
}
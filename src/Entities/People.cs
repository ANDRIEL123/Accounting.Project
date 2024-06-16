using System.ComponentModel.DataAnnotations.Schema;
using Accounting.Project.src.Infra.Enums;
using Child.Growth.src.Entities.Base;

namespace Child.Growth.src.Entities
{
    /// <summary>
    /// Pessoas
    /// </summary>
    public class People : EntityBase
    {
        /// <summary>
        /// CPF/CNPJ
        /// </summary>
        [Column("cpf_cnpj")]
        public string CpfCnpj { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [Column("city")]
        public string City { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [Column("state")]
        public string State { get; set; }

        /// <summary>
        /// Tipo de pessoa Cliente/Fornecedor
        /// </summary>
        [Column("type")]
        public PeopleType Type { get; set; }
    }
}
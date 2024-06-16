using System.ComponentModel.DataAnnotations.Schema;

namespace Child.Growth.src.Entities.Base
{
    public class EntityBase
    {
        /// <summary>
        /// Identificador
        /// </summary>
        [Column("id")]
        public long Id { get; set; }

        /// <summary>
        /// Criado em
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Modificado em
        /// </summary>
        [Column("modified_at")]
        public DateTime? ModifiedAt { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
    [Table("clientespimpedidoetapas")]
    public class PedidosEtapas
    {
        public int id { get; set; }

        public int pedido_id { get; set; }

        public string status { get; set; }

        public string finalizado { get; set; }

        public DateTime? data_criacao { get; set; }

        public DateTime? data_atualizacao { get; set; }
    }
}
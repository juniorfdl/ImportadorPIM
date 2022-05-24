using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
    [Table("clientespimpedidoitens")]
    public class PedidoItem
    {
        public int id { get; set; }

        public string produto_sku { get; set; }

        public int? produto_variacao_id { get; set; }

        public double? valor_total { get; set; }

        public int? quantidade { get; set; }

        public double? valor_unitario { get; set; }

        public string pedido { get; set; }

        public string produto_nome { get; set; }

        public int? pedido_id { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerImportadorPIM.Models
{
    [Table("clientespimpedido")]
    public class Pedido
    {
        public int id { get; set; }

        public double? valor_desconto { get; set; }

        public double? valor_total { get; set; }

        public string endereco_entrega { get; set; }

        public string forma_pagamento { get; set; }

        public int? cliente_id { get; set; }

        public string codigo_faturamento_direto { get; set; }

        public DateTime? data_criacao { get; set; }

        public DateTime? data_atualizacao { get; set; }

        public double? valor_itens { get; set; }

        public double? valor_entrega { get; set; }

        public string codigo_rastreio { get; set; }

        public string frete { get; set; }

        public string frete_prazo { get; set; }

        public string status { get; set; }
    }
}
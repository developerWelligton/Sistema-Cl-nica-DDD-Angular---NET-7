﻿namespace WebApi.Model
{
    public class ExameDto
    {
        public string Nome { get; set; }
        public string Detalhes { get; set; }
        public decimal Custo { get; set; }

        // Chave estrangeira para Cliente.
        public int ClienteId { get; set; }
    }
}
namespace WebApi.Model
{
    public class ClienteDto
    {
        public int ID_Cliente { get; set; } // Existing line

        public string Nome { get; set; }

        // Assuming CPF/CNPJ is a string
        public string CPF_CNPJ { get; set; }

        public string? Endereco { get; set; }

        public string? Email { get; set; }

        // Separating TelefoneFixo and TelefoneMovel as per the form fields
        public string? TelefoneFixo { get; set; }
        public string? TelefoneMovel { get; set; }

        // Postal code, assumed to be a string to account for different formats
        public string? CEP { get; set; }

        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; } // Assuming UF stands for "Unidade Federativa" (State)
        public string? Complemento { get; set; }

        // Including Municipial and State registration, nullable if they are optional
        public string? InscricaoMunicipal { get; set; }
        public string? InscricaoEstadual { get; set; }

        public int ID_Usuario { get; set; } // Existing line

        // Property for the list of animals associated with the client
        public List<AnimalDto> Animais { get; set; } // Existing line

        // Additional properties
        public string? Observacoes { get; set; }
        public string? Grupo { get; set; }
        public string? Empresa { get; set; }

        // Fields related to notifications and additional emails
        public bool NotificacaoDesabilitada { get; set; }
        public string? EmailsAdicionais { get; set; }
    }
}

namespace MYCUSTOMERS.DOMAIN.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public int IdTipo { get; set; }
        public DateTime DataHoraAtualizacao { get; set; }
        public DateTime DataHoraInclusao { get; set; }
        public DateTime DataFichaCadastral { get; set; }
        public int Idrating { get; set; }
        public bool ExposicaoMidia { get; set; }
        public string Email { get; set; }
        public bool PessoaPep { get; set; }

    }
}
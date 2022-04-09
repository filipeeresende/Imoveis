namespace Imoveis_Dominio.v1.Dto_s
{
    public class ImovelPorIdResponse
    {
        public string Endereco { get; set; }
        public string? Tipo { get; set; }
        public string? TipoContrato { get; set; }
        public decimal? Valor { get; set; }
    }
}


namespace EnerGenius.HttpObjects.Usuario
{
    public class UsuarioResponse
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}

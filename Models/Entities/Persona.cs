using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace personapi_dotnet.Models.Entities;

[Table("persona")]
public partial class Persona
{
    public int Cc { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string? Genero { get; set; } = null!;

    public int? Edad { get; set; }


    [JsonIgnore]
    public virtual ICollection<Estudio> Estudios { get; set; } = [];

    [JsonIgnore]
    public virtual ICollection<Telefono> Telefonos { get; set; } = [];
}

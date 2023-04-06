
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace BackendTest.Domain.Core.Enumerables
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum StatusTarefa
    {
        [EnumMember(Value = "Agendada")]
        Agendada = 1,
        [EnumMember(Value = "EmProgresso")]
        EmProgresso = 2,
        [EnumMember(Value = "Concluida")]
        Concluida = 3
    }
}

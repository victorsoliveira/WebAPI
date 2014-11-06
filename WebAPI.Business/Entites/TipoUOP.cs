using System.Runtime.Serialization;

namespace WebAPI.Business.Entites
{
    [DataContract]
    public enum TipoUOP
    {
        [EnumMember]
        OnShore,
        [EnumMember]
        OffShore,
        [EnumMember]
        Extra
    }
}

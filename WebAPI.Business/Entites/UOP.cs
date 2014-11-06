using System;
using System.Runtime.Serialization;

namespace WebAPI.Business.Entites
{
    [Serializable]
    [DataContract]
    public class UOP
    {
        [DataMember]
        public virtual int Id { get; set; }
        [DataMember]
        public virtual string Sigla { get; set; }
        [DataMember]
        public virtual string Descricao { get; set; }
        [DataMember]
        public virtual TipoUOP Tipo { get; set; }
    }
}

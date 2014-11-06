using FluentNHibernate.Mapping;
using WebAPI.Business.Entites;

namespace WebAPI.Business.Maps
{
    public class UOPMap : ClassMap<UOP>
    {
        public UOPMap()
        {
            Table("UOP_UNIDADE_OPERACIONAL");

            Id(x => x.Id, "UOP_ID");

            Map(x => x.Sigla, "UOP_SIGLA");
            Map(x => x.Descricao, "UOP_DESCRICAO");
            Map(x => x.Tipo, "UOP_TIPO").CustomType<int>();
        }

    }
}

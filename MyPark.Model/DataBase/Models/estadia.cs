using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Models
{
    public class estadia
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime DtEntrada { get; set; }
        public virtual TimeSpan HoraEntrada { get; set; }
        public virtual DateTime Dtsaida { get; set; }
        public virtual TimeSpan HoraSaida { get; set; }
        public virtual String Observacao { get; set; }
        public virtual Double TotalAPagar { get; set; }
        public virtual veiculo Veiculo { get; set; }
    }

    public class EstadiaMap : ClassMapping<estadia>
    {
        public EstadiaMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.DtEntrada);
            Property(x => x.HoraEntrada);
            Property(x => x.Dtsaida);
            Property(x => x.HoraSaida);
            Property(x => x.Observacao);
            Property(x => x.TotalAPagar);

            ManyToOne(x => x.Veiculo, m =>
             {
                 m.Lazy(LazyRelation.NoLazy);
                 m.Cascade(Cascade.All);
                 m.Column("idVeiculo");
             });
        }
    }
}

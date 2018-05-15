using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Models
{
    public class veiculo
    {
        public virtual String Placa { get; set; }
        public virtual String Marca { get; set; }
        public virtual String Modelo { get; set; }
        public virtual String Cor { get; set; }
        public virtual tipoveiculo Tipo { get; set; }

        public virtual IList<estadia> Estadias { get; set; }

        public veiculo()
        {
            Estadias = new List<estadia>();
        }
    }

    public class VeiculoMap : ClassMapping<veiculo>
    {
        public VeiculoMap()
        {
            Id(x => x.Placa);
            Property(x => x.Marca);
            Property(x => x.Modelo);
            Property(x => x.Cor);

            //1 Veiculo pode ser apenas de 1 tipo
            ManyToOne(x => x.Tipo, m =>
           {
               //Criando a coluna IdTipo na tabela veiculo
               m.Column("IdTipo");
               m.Lazy(LazyRelation.NoLazy);
           });

            Bag(x => x.Estadias, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy(CollectionLazy.NoLazy);
                m.Inverse(true);
                m.Key(k => k.Column("idVeiculo"));
            }, r => r.OneToMany());
        }
    }
}

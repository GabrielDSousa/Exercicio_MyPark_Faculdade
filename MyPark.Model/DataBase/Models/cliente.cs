using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Models
{
    public class cliente
    {
        public virtual Guid Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual String Cpf { get; set; }
        public virtual String Cnh { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public virtual Boolean Inativo { get; set; }
    }

    public class ClienteMap : ClassMapping<cliente>
    {
        public ClienteMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Nome);
            Property(x => x.Cpf);
            Property(x => x.Cnh);
            Property(x => x.DtNascimento);
            Property(x => x.Inativo);
        }
    }
}

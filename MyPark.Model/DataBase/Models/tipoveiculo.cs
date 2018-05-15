using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPark.Model.DataBase.Models
{
    public class tipoveiculo
    {
        public virtual Guid Id { get; set; }

        [Required(ErrorMessage = "O Titulo é Obrigátorio!")]
        public virtual String Titulo { get; set; }
        public virtual String Descricao { get; set; }

        [Required(ErrorMessage = "O Valor é Obrigátorio!")]
        [DataType(DataType.Currency)]
        public virtual Double ValorHora { get; set; }

        [DataType(DataType.Date)]
        public virtual DateTime DtCadastro { get; set; }
        public virtual Boolean Inativo { get; set; }
        //Criando uma lista de veiculos pois um tipo de veiculos poderá ter varios veiculos
        public virtual IList<veiculo> Veiculos { get; set; }

        //Necessário instanciar a lista de veiculos para que funcione
        public tipoveiculo()
        {
            Veiculos = new List<veiculo>();
        }
    }

    public class TipoVeiculoMap : ClassMapping<tipoveiculo>
    {
        public TipoVeiculoMap()
        {
            Id(x => x.Id, m => m.Generator(Generators.Guid));

            Property(x => x.Titulo);
            Property(x => x.Descricao);
            Property(x => x.ValorHora);
            Property(x => x.DtCadastro);
            Property(x => x.Inativo);

            Bag(x => x.Veiculos, m =>
            {
                //setar nulo no tipo da classe veiculo caso a classe tipoveiculo for deletada
                m.Cascade(Cascade.Detach);
                m.Lazy(CollectionLazy.Lazy);
                //Referencia a chave na coluna idTipo da tabela veiculo
                m.Key(k => k.Column("IdTipo"));
                m.Inverse(true);
            },
                //Dizendo que a relação é 1:N(tipodeveiculo poderá ter varios veiculos)
                r => r.OneToMany()
            );
        }
    }
}

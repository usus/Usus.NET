using FluentNHibernate.Mapping;
using QueryOverSamples.Domain;

namespace QueryOverSamples.Mappings
{
	public class PersonMap : ClassMap<Person>
	{
		public PersonMap()
		{
			Id(p => p.Id).GeneratedBy.Identity();
			Map(p => p.Name);
			Table("Person");
		}
	}
}

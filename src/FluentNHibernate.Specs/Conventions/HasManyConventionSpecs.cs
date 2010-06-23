using System;
using System.Linq;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using FluentNHibernate.MappingModel.ClassBased;
using FluentNHibernate.Specs.Conventions.Fixtures;
using Machine.Specifications;

namespace FluentNHibernate.Specs.Conventions
{
    public abstract class HasManyConventionSpec
    {
        Establish context = () =>
        {
            model = new FluentNHibernate.PersistenceModel();
            model.Conventions.Add(new TestHasManyConvention());
        };

        protected static FluentNHibernate.PersistenceModel model;
        protected static ClassMapping mapping;
        protected const int DefaultBatchSize = 100;

        class TestHasManyConvention : IHasManyConvention, ICollectionConvention
        {
            public void Apply(IOneToManyCollectionInstance instance)
            {
                instance.BatchSize(DefaultBatchSize);
            }

            public void Apply(ICollectionInstance instance)
            {
                instance.BatchSize(DefaultBatchSize);
            }
        }
    }

    public class when_a_has_many_convention_is_being_applied_to_a_set_mapping : HasManyConventionSpec
    {
        Establish context = () =>
            model.Add(new SetCollectionEntityMap());

        Because of = () =>
            mapping = model.BuildMappingFor<SetCollectionEntity>();

        It should_set_the_batch_size = () =>
            mapping.Collections.Single().BatchSize.ShouldEqual(DefaultBatchSize);
    }

    public class when_a_has_many_convention_is_being_applied_to_a_set_mapping_with_an_element : HasManyConventionSpec
    {
        Establish context = () =>
            model.Add(new SetElementCollectionEntityMap());

        Because of = () =>
            mapping = model.BuildMappingFor<SetElementCollectionEntity>();

        It should_set_the_batch_size = () =>
            mapping.Collections.Single().BatchSize.ShouldEqual(DefaultBatchSize);
    }

    public class when_a_has_many_convention_is_being_applied_to_a_set_mapping_with_a_composite_element : HasManyConventionSpec
    {
        Establish context = () =>
            model.Add(new SetCompositeElementCollectionEntityMap());

        Because of = () =>
            mapping = model.BuildMappingFor<SetCompositeElementCollectionEntity>();

        It should_set_the_batch_size = () =>
            mapping.Collections.Single().BatchSize.ShouldEqual(DefaultBatchSize);
    }
}

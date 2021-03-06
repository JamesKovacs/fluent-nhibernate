﻿using FluentNHibernate.MappingModel.ClassBased;
using NUnit.Framework;

namespace FluentNHibernate.Testing.MappingModel.Defaults
{
    [TestFixture]
    public class ComponentMappingDefaultsTester
    {
        [Test]
        public void UniqueShouldDefaultToFalse()
        {
            var mapping = new ComponentMapping(ComponentType.Component);
            mapping.Unique.ShouldBeFalse();
        }

        [Test]
        public void InsertShouldDefaultToTrue()
        {
            var mapping = new ComponentMapping(ComponentType.Component);
            mapping.Insert.ShouldBeTrue();
        }

        [Test]
        public void UpdateShouldDefaultToTrue()
        {
            var mapping = new ComponentMapping(ComponentType.Component);
            mapping.Update.ShouldBeTrue();
        }

        [Test]
        public void OptimisticLockShouldDefaultToTrue()
        {
            var mapping = new ComponentMapping(ComponentType.Component);
            mapping.OptimisticLock.ShouldBeTrue();
        }

        [Test]
        public void LazyShouldDefaultToFalse()
        {
            var mapping = new ComponentMapping(ComponentType.Component);
            mapping.Lazy.ShouldBeFalse();
        }
    }
}

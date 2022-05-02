using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;
using System;
using System.Linq;

namespace Mc2.CrudTest.TestTools
{
    public class AutoMoqDataAttribute : AutoDataAttribute
    {
        static readonly ICustomization[] localCustomizations =
            new[]
            {
                new AutoMoqCustomization()
            };
        static Func<IFixture> Customize(Func<IFixture> createFixture, ICustomization[] customizations)
        {

            IFixture apply() =>
                customizations
                .Concat(localCustomizations)
                .Aggregate(createFixture(),
                    (acc, customization) =>
                         acc.Customize(customization));

            return apply;

        }
        protected static IFixture CreateFixture() => Customize(() => new Fixture(), localCustomizations)();

        public AutoMoqDataAttribute()
            : this(CreateFixture)
        {
        }
        public AutoMoqDataAttribute(Func<IFixture> factory)
           : this(factory, new ICustomization[] { })
        {
        }

        public AutoMoqDataAttribute(params ICustomization[] customizations)
            : this(CreateFixture, customizations)
        {
        }
        public AutoMoqDataAttribute(Func<IFixture> fixture, params ICustomization[] customizations)
            : base(Customize(fixture, customizations))
        {
        }


    }
}

﻿namespace Machete.Translators
{
    using TranslatorConfiguration;
    using TranslatorConfiguration.Builders;


    public class EntityCreatorFactory<TResult, TSchema> :
        IEntityCreatorFactory<TSchema>
        where TSchema : Entity
        where TResult : TSchema
    {
        readonly IEntityCreatorSpecification<TResult, TSchema> _specification;

        public EntityCreatorFactory(IEntityCreatorSpecification<TResult, TSchema> specification)
        {
            _specification = specification;
        }

        public IEntityCreator<TSchema> Create(TranslatorFactoryContext<TSchema> context)
        {
            var builder = new EntityCreatorBuilder<TResult, TSchema>(context, _specification.Name);

            _specification.Apply(builder);

            return builder.Build();
        }
    }
}
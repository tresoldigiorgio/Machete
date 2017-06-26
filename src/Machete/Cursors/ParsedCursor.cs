﻿namespace Machete.Cursors
{
    using Payloads;


    public class ParsedCursor<TSchema> :
        BaseCursor,
        Cursor<TSchema>
        where TSchema : Entity
    {
        readonly EntityResult<TSchema> _entityResult;
        readonly int _index;

        bool _nextComputed;
        Cursor<TSchema> _next;

        public ParsedCursor(EntityResult<TSchema> entityResult)
        {
            _entityResult = entityResult;
            _index = -1;
        }

        ParsedCursor(IPayloadCache payloadCache, EntityResult<TSchema> entityResult, int index, TSchema entity)
            : base(payloadCache)
        {
            _entityResult = entityResult;
            _index = index;
            Value = entity;
            HasValue = true;
        }

        public bool HasValue { get; }
        public TSchema Value { get; }

        public bool HasNext
        {
            get
            {
                if (_nextComputed)
                    return _next != null;

                GetNext();

                return _next != null;
            }
        }

        public Cursor<TSchema> Next()
        {
            if (_nextComputed)
                return _next ?? Cursor.Empty<TSchema>();

            return GetNext() ?? Cursor.Empty<TSchema>();
        }

        Cursor<TSchema> GetNext()
        {
            int nextIndex = _index + 1;

            TSchema entity;
            if (_entityResult.TryGetEntity(nextIndex, out entity))
            {
                _next = new ParsedCursor<TSchema>(PayloadCache, _entityResult, nextIndex, entity);
            }

            _nextComputed = true;

            return _next;
        }
    }
}
﻿namespace Machete.Internals.Mapping
{
    public interface IObjectConverter
    {
        object GetObject(IObjectValueProvider valueProvider);
    }
}
﻿namespace Machete.Internals.Mapping
{
    using System;


    public interface IDictionaryConverterCache
    {
        IDictionaryConverter GetConverter(Type type);
    }
}
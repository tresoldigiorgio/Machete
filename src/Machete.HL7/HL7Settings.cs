﻿namespace Machete.HL7
{
    public interface HL7Settings 
    {
        char FieldSeparator { get; }
        char ComponentSeparator { get; }
        char RepetitionSeparator { get; }
        char SubComponentSeparator { get; }
        char EscapeCharacter { get; }
    }
}
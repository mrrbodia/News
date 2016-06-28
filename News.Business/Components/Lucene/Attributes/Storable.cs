using Lucene.Net.Documents;
using System;

namespace News.Business.Components.Lucene.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Storable : Attribute
    {
        public Field.Index Type = Field.Index.NO;
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class FieldName : Attribute
    {
    }
}
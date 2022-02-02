using System;

namespace AssistantSorekeeperBase.Data
{
    public class KeyedBaseModel<TEntity, TKey>
        where TEntity : KeyedBaseModel<TEntity, TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
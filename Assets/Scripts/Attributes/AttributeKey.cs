using System;

namespace PVZ.Attributes
{
    public enum AttributeSide : sbyte
    {
        Plants,
        Zombies,
        General,
    }

    public enum AttributeType : sbyte
    {
        Health,
        SunPoints,
        AttackSpeed,
        Damage,
    }

    public readonly struct AttributeKey
    {
        public readonly AttributeSide Side;
        public readonly AttributeType Type;

        public AttributeKey(AttributeSide side, AttributeType type)
        {
            Side = side;
            Type = type;
        }
    }
}
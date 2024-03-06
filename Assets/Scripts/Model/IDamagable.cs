using AbilitySystem.Authoring;

namespace PVZ
{
    public interface IDamagable
    {
        void Damage(GameplayEffectScriptableObject damageEffect);
    }
}
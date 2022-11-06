namespace TestProject1.Luana_Mennuti;

public abstract class AbstractAbilityInstant : AbstractAbility 
{
    protected AbstractAbilityInstant(EAbility idAbility) : base(idAbility, ETypeAbility.Instant)
    {
    }
}
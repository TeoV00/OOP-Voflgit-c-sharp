namespace TestProject1.Luana_Mennuti;

public abstract class AbstractAbilityDurable : AbstractAbility
{
    private readonly int duration;
    protected AbstractAbilityDurable(EAbility idAbility, int duration) : base(idAbility, ETypeAbility.Durable)
    {
        this.duration = duration;
    }
}
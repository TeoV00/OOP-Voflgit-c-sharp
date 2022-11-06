namespace TestProject1.Luana_Mennuti.Concrete;

public class AbilityFreezeTimeImpl : AbstractAbilityDurable, IAbilityDurable
{
    public AbilityFreezeTimeImpl(int duration) : base(EAbility.FreezeTime, duration)
    {
        
    }

    public void DeActive()
    {
        
    }
}
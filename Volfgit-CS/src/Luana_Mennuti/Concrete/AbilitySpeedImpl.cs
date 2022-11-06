namespace TestProject1.Luana_Mennuti.Concrete;

public class AbilitySpeedImpl : AbstractAbilityDurable, IAbilityDurable
{
    private readonly int speed;
    public AbilitySpeedImpl(int duration, int speed) : base(EAbility.SpeedUp, duration)
    {
        this.speed = speed;
    }

    public void DeActive()
    {
        
    }
}
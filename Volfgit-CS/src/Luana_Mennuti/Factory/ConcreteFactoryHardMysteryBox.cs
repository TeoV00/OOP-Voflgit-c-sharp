using TestProject1.Luana_Mennuti.Concrete;

namespace TestProject1.Luana_Mennuti.Factory;

public class ConcreteFactoryHardMysteryBox : AbstractFactoryMysteryBox
{
    /**
     * {@inheritDoc}
     */
    public override IAbilityInTheBox CreateFreezeTime() {
        const int duration = 6000;
        return new AbilityFreezeTimeImpl(duration);
    }
    /**
     * {@inheritDoc}
     */
    public override IAbilityInTheBox CreateSpeedUp() {
        const int duration = 3000;
        const int increaseSpeed = 1;
        return new AbilitySpeedImpl(duration, increaseSpeed);
    }
    /**
     * {@inheritDoc}
     */
    public override IAbilityInTheBox CreateScore() {
        const int increase = 700;
        return new AbilityScoreImpl(increase);
    }
    /**
     * {@inheritDoc}
     */
    public override IAbilityInTheBox CreateKillMosquitoes() {
        return new AbilityKillMosquitoesImpl();
    }
}
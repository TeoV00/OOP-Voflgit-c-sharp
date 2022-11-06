namespace TestProject1.Luana_Mennuti.Factory;

public abstract class AbstractFactoryMysteryBox
{
    /**
     * This is the abstract method for freeze time in the mystery box.
     * @return the ability freeze time in the box.
     */
    public abstract IAbilityInTheBox CreateFreezeTime();
    /**
     * This is the abstract method for speed up in the mystery box.
     * @return the ability for speed up in the box.
     */
    public abstract IAbilityInTheBox CreateSpeedUp();
    /**
     * This is the abstract method for score in the mystery box.
     * @return the ability for score in the box.
     */
    public abstract IAbilityInTheBox CreateScore();
    /**
     * This is the abstract method to kill the mosquitoes in the mystery box.
     * @return the ability to kill the mosquitoes in the box.
     */
    public abstract IAbilityInTheBox CreateKillMosquitoes();
}
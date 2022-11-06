using TestProject1.Luana_Mennuti.Path;

namespace TestProject1.Luana_Mennuti;

public class EAbility
{
    /**
     * Score ability.
     */
    public static readonly EAbility Score = new(PathImageMysteryBox.CoinScore);
    /**
     * Time ability.
     */
    public static readonly EAbility FreezeTime = new(PathImageMysteryBox.CoinTime);
    /**
     * Speed ability.
     */
    public static readonly EAbility SpeedUp = new(PathImageMysteryBox.CoinSpeed);
    /**
     * Kill mosquitoes ability.
     */
    public static readonly EAbility KillAllMosquitoes = new(PathImageMysteryBox.CoinKillAllMoquetoes);
    
    private readonly string pathReveled;
    
    private EAbility(string pathReveled) {
        this.pathReveled = pathReveled;
    }
    /**
     * This method is used to get the path of the ability.
     * @return the path of the ability.
     */
    public string GetPathReveled() 
    {
        return pathReveled;
    }
    /**
     * This method is used to randomize the ability.
     * @return the ability.
     */
    public static EAbility RandomAll()
    {
        var rnd = new Random();
        return Values()[rnd.Next(0, Values().Count)];
    }
    
    public static List<EAbility> Values() => new()
    {
     Score,
     FreezeTime,
     SpeedUp,
     KillAllMosquitoes,
    };
    
    
}
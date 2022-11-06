namespace TestProject1.Luana_Mennuti.Path;

public static class PathImageMysteryBox
{
    private const string PATH_RADICE = "img/mysteryBox/";
    private const string PATH_COIN = PATH_RADICE + "coins/";

    /**
     * Provides the path of the image of the mystery box.
     */
    public const string MYSTERY_BOX = PATH_RADICE + "box.png";

    /**
     * Provides the path of the image of special mystery box, for the animation.
     */
    public static readonly List<string> MysteryBoss = new() 
    {
     PATH_RADICE + "BoxBoss.png",
     PATH_RADICE + "BoxBoss1.png"
    };

    /**
     * Provides the path of the image of the coins Time, for the animation.
     */
    public const string CoinTime = PATH_COIN + "coin-T.png";
    /**
     * Provides the path of the image of the coins Speed, for the animation.
     */
    public const string CoinSpeed = PATH_COIN + "coin-S.png";
    /**
     * Provides the path of the image of the coins Score, for the animation.
     */
    public const string CoinScore = PATH_COIN + "coin-P.png";
    /**
     * Provides the path of the image of the coins to kill mosquitoes, for the animation.
     */
    public const string CoinKillAllMoquetoes = PATH_COIN + "coin-C.png";
}
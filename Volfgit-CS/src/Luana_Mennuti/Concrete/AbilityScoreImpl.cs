namespace TestProject1.Luana_Mennuti.Concrete;

public class AbilityScoreImpl : AbstractAbilityInstant, IAbilityInTheBox
{
    private readonly int score;
    public AbilityScoreImpl(int score) : base(EAbility.Score)
    {
        this.score = score;
    }
}
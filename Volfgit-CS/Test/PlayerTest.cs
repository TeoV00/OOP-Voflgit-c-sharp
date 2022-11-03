using vg.model.entity.dynamicEntity.player;
using vg.utility;

namespace vg;

public class PlayerTest
{
    private readonly V2D _position = new V2D(5, 5);
    private IPlayer _pl;

    [SetUp]
    public void Setup()
    {
        _pl = BasePlayer.NewPlayer(_position);
    }

    [Test]
    public void LifeDecInc()
    {
        Assert.That(_pl.GetLife(), Is.EqualTo(BasePlayer.PlayerMaxLife));
        _pl.IncLife();
        Assert.That(_pl.GetLife(), Is.EqualTo(BasePlayer.PlayerMaxLife+1));
        _pl.DecLife();
        Assert.That(_pl.GetLife(), Is.EqualTo(BasePlayer.PlayerMaxLife));
    }

    [Test]
    public void PlayerMove() {
        Assert.That(_pl.GetPosition(), Is.EqualTo(_position));
        _pl.Move();
        Assert.That(_pl.GetPosition(), Is.EqualTo(new V2D(5, 5)));
        _pl.ChangeDirection(EDirection.Down, true);
        _pl.Move();
        _pl.Move();
        _pl.Move();
        Assert.That(_pl.GetPosition(), Is.EqualTo(new V2D(5, 8)));

        _pl.ChangeDirection(EDirection.Left, true);
        _pl.Move();
        _pl.Move();
        _pl.Move();
        Assert.That(_pl.GetPosition(), Is.EqualTo(new V2D(2, 8)));

    }

    [Test]
    public void PlayerSpeedup() {
        //Default _player speed is (1,1)
        IPlayer pl1 = BasePlayer.NewPlayer(new V2D(0, 0));
        V2D bonusSpeed = new V2D(3, 3);
        pl1.ChangeDirection(EDirection.Down, true);

        pl1.Move();
        Assert.That(pl1.GetPosition(), Is.EqualTo(new V2D(0, 1)));

        //-----ENABLE SPEEDUP BONUS-------
        pl1.EnableSpeedUp(bonusSpeed);
        //Speed of _player must be increased of amount speedImprove
        Assert.That(pl1.GetSpeed(), Is.EqualTo(BasePlayer.DefaultPlayerSpeed.Sum(bonusSpeed)));

        pl1.Move();
        Assert.That(pl1.GetPosition(), Is.EqualTo(new V2D(0, 5)));
        //-----DISABLE SPEEDUP BONUS-------
        pl1.DisableSpeedUp();
        pl1.Move();
        Assert.That(pl1.GetPosition(), Is.EqualTo(new V2D(0, 6)));
    }
}
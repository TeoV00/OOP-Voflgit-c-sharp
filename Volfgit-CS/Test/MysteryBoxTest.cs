using TestProject1.Luana_Mennuti.Factory;

namespace vg;

public class MysteryBoxTest
{
    private AbstractFactoryMysteryBox easyFactoryMysteryBox;
    private AbstractFactoryMysteryBox mediumFactoryMysteryBox;
    private AbstractFactoryMysteryBox hardFactoryMysteryBox;
    
    [SetUp]
    public void Setup()
    {
        this.easyFactoryMysteryBox = new ConcreteFactoryEasyMysteryBox();
        this.mediumFactoryMysteryBox = new ConcreteFactoryMediumMysteryBox();
        this.hardFactoryMysteryBox = new ConcreteFactoryHardMysteryBox();
    }

    [Test]
    public void EasyTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.easyFactoryMysteryBox.CreateScore(), !Is.Null);
            Assert.That(this.easyFactoryMysteryBox.CreateSpeedUp(), !Is.Null);
            Assert.That(this.easyFactoryMysteryBox.CreateFreezeTime(), !Is.Null);
            Assert.That(this.easyFactoryMysteryBox.CreateKillMosquitoes(), !Is.Null);
        });
    }

    [Test]
    public void MediumTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.mediumFactoryMysteryBox.CreateScore(), !Is.Null);
            Assert.That(this.mediumFactoryMysteryBox.CreateSpeedUp(), !Is.Null);
            Assert.That(this.mediumFactoryMysteryBox.CreateFreezeTime(), !Is.Null);
            Assert.That(this.mediumFactoryMysteryBox.CreateKillMosquitoes(), !Is.Null);
        });
    }
    
    [Test]
    public void HardTest()
    {
        Assert.Multiple(() =>
        {
            Assert.That(this.hardFactoryMysteryBox.CreateScore(), !Is.Null);
            Assert.That(this.hardFactoryMysteryBox.CreateSpeedUp(), !Is.Null);
            Assert.That(this.hardFactoryMysteryBox.CreateFreezeTime(), !Is.Null);
            Assert.That(this.hardFactoryMysteryBox.CreateKillMosquitoes(), !Is.Null);
        });
    }
}
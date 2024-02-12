using Zenject;
using NUnit.Framework;

[TestFixture]
public class UntitledUnitTest : ZenjectUnitTestFixture
{
    [SetUp]
    public void SetUp()
    {
        Container.Bind<TimeController>().AsSingle();
        Container.Bind<UnitPositionController>().AsSingle();

        Container.BindFactory<float, float, GameController, PlayerController, PlayerController.PlayerFabrik>();

        Container.BindFactory<float, float, GameController, OpponentController, OpponentController.OpponentFabrik>();

        Container.BindSignal<OpponentWonSignal>();
        Container.BindSignal<PlayerWonSignal>();
        
        Container.Bind<GameConfig>().FromMock();

        Container.Inject(this);
    }
    
    [Inject] private GameController _gameController;
    [Inject] private GameConfig _gameConfig;
    
    [Test]
    public void IsPlayerNotNull_Test()
    {
        
    }
}
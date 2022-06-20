using UnityEngine;
using Zenject;

public class GameMonoInstaller : MonoInstaller
{
    [SerializeField] private ObjectPooler _objectPooler;
    [SerializeField] private Searcher _searcher;
    [SerializeField] private LevelRepeater _levelRepeater;

    public override void InstallBindings()
    {
        Container.Bind<ObjectPooler>()
            .FromInstance(_objectPooler)
            .AsSingle();

        Container.Bind<Searcher>()
            .FromInstance(_searcher)
            .AsSingle();

        Container.Bind<LevelRepeater>()
            .FromInstance(_levelRepeater)
            .AsSingle();
    }
}
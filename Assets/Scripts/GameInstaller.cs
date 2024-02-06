using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<TimeController>().AsSingle();
        Container.Bind<UnitPositionController>().AsSingle();
    }
}
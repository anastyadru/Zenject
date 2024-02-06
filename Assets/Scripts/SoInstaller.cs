using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SoInstaller", menuName = "Create SO Installer")]
public class SoInstaller: ScriptableObjectInstaller
{
    [SerializeField] 
    private GameConfig _config;
    
    public override void InstallBindings()
    {
        Container.BindInstance(_config);
    }
}
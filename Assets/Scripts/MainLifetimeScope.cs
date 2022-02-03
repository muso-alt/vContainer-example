using DefaultNamespace.Data;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace DefaultNamespace
{
    public class MainLifetimeScope : LifetimeScope
    {
        [SerializeField] private HelloView _helloView;
        [SerializeField] private Text _scoreText;

        [Header("Data")]
        [SerializeField] private ObjectsPoolData _objectsPool;
        
        protected override void Configure(IContainerBuilder builder)
        {
            BindCore(builder);
        }
    
        private void BindCore(IContainerBuilder builder)
        {
            builder.Register<TapModel>(Lifetime.Singleton);
            builder.Register<ScoreChanger>(Lifetime.Singleton);
            builder.Register<PointSpawner>(Lifetime.Singleton);
            
            builder.RegisterComponent(_helloView);
            builder.RegisterComponent(_objectsPool);
            builder.RegisterComponent(_scoreText);
            
            builder.RegisterEntryPoint<GamePresenter>();
        }
    }
}
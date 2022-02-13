using Pop_Items.Data;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Pop_Items
{
    public class PopItemsLifetimeScope : LifetimeScope
    {
        [SerializeField] private Camera _mainCamera;
        
        [SerializeField] private PopItemsView _mainView;

        [SerializeField] private PopItemsSpawnerData _spawnerData;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<PopItemsSpawner>(Lifetime.Singleton);
            builder.Register<PopItemTapProxy>(Lifetime.Singleton);
            builder.Register<PopItemInitializer>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.RegisterComponent(_mainView);
            builder.RegisterComponent(_mainCamera);
            builder.RegisterComponent(_spawnerData);
            
            builder.RegisterEntryPoint<PopItemsPresenter>();
        }
    }
}
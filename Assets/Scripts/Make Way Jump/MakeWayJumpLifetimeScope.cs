using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Make_Way_Jump
{
    public class MakeWayJumpLifetimeScope : LifetimeScope
    {
        [SerializeField] private MainView _mainView;
        
        [Header("Data")]
        [SerializeField] private HeroData _heroData;
        [SerializeField] private BlocksData _blocksData; 
        
        protected override void Configure(IContainerBuilder builder)
        {
            BindCore(builder);
        }

        private void BindCore(IContainerBuilder builder)
        {
            builder.Register<HeroInitializer>(Lifetime.Singleton);
            
            //Data
            builder.RegisterComponent(_heroData);
            builder.RegisterComponent(_blocksData);
            
            //Views
            builder.RegisterComponent(_mainView);

            builder.RegisterEntryPoint<GamePresenter>();
        }
    }
}
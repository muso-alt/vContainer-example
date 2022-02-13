using System;
using VContainer.Unity;

namespace Make_Way_Jump
{
    public class GamePresenter : IStartable, IDisposable
    {
        private readonly MainView _mainView;
        private readonly HeroInitializer _heroInitializer;
        
        public GamePresenter(MainView mainView, HeroInitializer heroInitializer)
        {
            _mainView = mainView;
            _heroInitializer = heroInitializer;
        }
        
        public void Start()
        {
            _mainView.OnStarted += _heroInitializer.Initialize;
        }

        public void Dispose()
        {
            _mainView.OnStarted -= _heroInitializer.Initialize;
        }
    }
}
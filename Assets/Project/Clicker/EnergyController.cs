using DG.Tweening;
using UI.Main;

namespace Project.Clicker
{
    public class EnergyController
    {
        public int GetCurrentEnergy => _currentEnergy;
        
        private readonly ClickerSettings _clickerSettings;
        
        private UIPlayingScene _uiPlayingScene;
        private Tween _autoCollectTween;
        
        private int _maxEnergy;
        private int _currentEnergy;
        
        public EnergyController(
            ClickerSettings clickerSettings,
            IUIService uiService)
        {
            _clickerSettings = clickerSettings;
            _maxEnergy = clickerSettings.MaxValueEnergy;
            _currentEnergy = _maxEnergy;
            
            _uiPlayingScene = uiService.Get<UIPlayingScene>();
            
            _uiPlayingScene.SetTextEnergy($"{_maxEnergy}/{_maxEnergy}");
            
            CollectAutomatically();
        }

        private void CollectAutomatically()
        {
            _autoCollectTween = DOVirtual.DelayedCall(_clickerSettings.TimeToAddingOneValueEnergy, () => 
            {
                if (_currentEnergy < _maxEnergy)
                {
                    _currentEnergy += _clickerSettings.HowMachPlusPerTime;
                    
                    if (_currentEnergy > _maxEnergy)
                    {
                        _currentEnergy = _maxEnergy;
                    }
                    
                    SetEnergy(_currentEnergy);
                }
                
                CollectAutomatically();
            });
        }

        public void ChangeEnergyByTap()
        {
            _currentEnergy -= _clickerSettings.HowMachMinusEnergyPerTap;
            if (_currentEnergy < 0)
            {
                _currentEnergy = 0;
            }

            SetEnergy(_currentEnergy);
        }

        private void SetEnergy(int energy)
        {
            _uiPlayingScene.SetTextEnergy($"{energy}/{_maxEnergy}");
        }
    }
}
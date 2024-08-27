using DG.Tweening;
using Project.Clicker.FlyingText;
using UI.Main;

namespace Project.Clicker
{
    public class ClickController
    {
        private readonly EnergyController _energyController;
        private readonly ClickerSettings _clickerSettings;
        private readonly FlyingTextController _flyingTextController;

        private Tween _autoCollectTween;
        private UIPlayingScene _uiPlayingScene;
        
        public ClickController(
            EnergyController energyController,
            ClickerSettings clickerSettings,
            IUIService uiService,
            FlyingTextController flyingTextController)
        {
            _energyController = energyController;
            _clickerSettings = clickerSettings;
            _flyingTextController = flyingTextController;

            _uiPlayingScene = uiService.Get<UIPlayingScene>();

            CollectAutomatically();
        }
        
        public void Click()
        {
            if (_energyController.GetCurrentEnergy >=_clickerSettings.HowMachMinusEnergyPerTap)
            {
                _energyController.ChangeEnergyByTap();
                
                CalculateCoinTapValue();
                
                ClickAnimation();
            }
        }

        private void ClickAnimation()
        {
            _uiPlayingScene.ImageForAnimation.transform
                .DOScale(_clickerSettings.ClickScale, _clickerSettings.ClickAnimationDuration)
                .OnComplete(() => _uiPlayingScene.ImageForAnimation.transform
                    .DOScale(1f, _clickerSettings.ClickAnimationDuration));
            
            _flyingTextController.Spawn();
        }

        private void AddCoinValue(float value)
        {
            _uiPlayingScene.SetTextCoin(value);
        }

        private void CalculateCoinTapValue()
        {
            int currencyPerTap = (int)(_clickerSettings.BaseCurrencyPerTap * _clickerSettings.TapModifier);
            currencyPerTap += (int)((_clickerSettings.AmountIncomeForPeriod / _clickerSettings.TimeDivisor) * _clickerSettings.TapModifier);
            
            AddCoinValue(currencyPerTap);
        }
        
        private void CollectAutomatically()
        {
            _autoCollectTween = DOVirtual.DelayedCall(_clickerSettings.AutoLootTimer, () =>
            {
                AddCoinValue(_clickerSettings.AutoLootValue);
                
                _clickerSettings.TapModifier += _clickerSettings.PercentForAutoLoot * _clickerSettings.AutoLootValue / 100f;

                CollectAutomatically();
            });
        }
    }
}
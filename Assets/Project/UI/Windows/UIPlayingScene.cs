using System;
using Platformer.UI;
using TMPro;
using UI.Main;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayingScene : UIWindow
{
    public event EventHandler OnTapButtonClickEvent;

    public Image ImageForAnimation => imageForAnimation;
    
    [SerializeField] private UIButton tapButton;
    [SerializeField] private Image imageForAnimation;
    [SerializeField] private TextMeshProUGUI energyText;
    [SerializeField] private TextMeshProUGUI coinText;

    public override void Show()
    {
        tapButton.OnClickEvent += OnTapButtonClickLogic;
    }

    private void OnTapButtonClickLogic(object sender, EventArgs e)
    {
        OnTapButtonClickEvent?.Invoke(this, EventArgs.Empty);
    }

    public void SetTextEnergy(string energyValue)
    {
        energyText.text = energyValue;
    }
    
    public void SetTextCoin(float value)
    {
        var coin = Int32.Parse(coinText.text);
        coinText.text = $"{coin + value}";
    }
    

    public override void Hide()
    {
        tapButton.OnClickEvent -= OnTapButtonClickLogic;
    }
}
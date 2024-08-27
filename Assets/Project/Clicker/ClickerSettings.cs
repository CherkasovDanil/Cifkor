using UnityEngine;

namespace Project.Clicker
{
    [CreateAssetMenu(fileName = "ClickerSettings", menuName = "Settings/ClickerSettings")]
    public class ClickerSettings : ScriptableObject
    {
        [Header("Energy Settings")]
        public int MaxValueEnergy;
        public int HowMachMinusEnergyPerTap;
        public int HowMachPlusPerTime;
        public int TimeToAddingOneValueEnergy;

        [Header("Click Settings")] 
        public int BaseCurrencyPerTap;
        public float TapModifier = 1f;
        public float AmountIncomeForPeriod;
        public float TimeDivisor = 0.1f;
        public float ClickAnimationDuration = 0.1f;
        public float ClickScale = 0.9f;

        [Header("Auto Loot")] 
        public int AutoLootTimer;
        public int AutoLootValue = 1;
        public float  PercentForAutoLoot;
        
        [Header("Flying Text")] 
        public int FlyDistance;
        public float AnimationDuration;
    }
}
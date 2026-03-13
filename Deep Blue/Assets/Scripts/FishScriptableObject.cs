using UnityEngine;

[CreateAssetMenu(fileName = "FishScriptableObject", menuName = "ScriptableObjects/Fish")]
public class FishScriptableObject : ScriptableObject
{
    [SerializeField] private string fishName;
    [SerializeField] private Sprite fishSprite;

    [SerializeField] private Rarity rarity;
    [SerializeField] private FishAttribute attribute;

    public Rarity FishRarity => rarity;
    public FishAttribute Attribute => attribute;

    public enum Rarity
    {
        Common,
        Rare,
        Legendary
    }

    public enum FishAttribute
    {
        None,
        HPBuff,
        BetterJump,
        BetterHPBuff,
        BetterDamageBuff,
        DamageBuff,
        LuckBuff,
        PiercingSpear
    }
}

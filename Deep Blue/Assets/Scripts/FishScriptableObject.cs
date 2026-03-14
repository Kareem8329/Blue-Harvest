using UnityEngine;

[CreateAssetMenu(fileName = "FishScriptableObject", menuName = "ScriptableObjects/Fish")]
public class FishScriptableObject : ScriptableObject
{
    [SerializeField] private string FishName;
    [SerializeField] private Sprite FishSprite;

    [SerializeField] private RarityEnum rarity;
    [SerializeField] private AttributeEnum attribute;

    // Properties for other scripts to access the private fields (Getters)
    public string fishName => FishName;
    public Sprite fishSprite => FishSprite;
    public RarityEnum FishRarity => rarity;
    public AttributeEnum FishAttribute => attribute;

    public enum RarityEnum
    {
        Common,
        Rare,
        Legendary
    }

    public enum AttributeEnum
    {
        None,
        HPBuff,
        BetterHPBuff,
        DamageBuff,
        BetterDamageBuff,
        LuckBuff,
        PiercingSpear
    }
}

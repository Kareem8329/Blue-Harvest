using UnityEngine;

[CreateAssetMenu(fileName = "FishScriptableObject", menuName = "ScriptableObjects/Fish")]
public class FishScriptableObject : ScriptableObject
{
    // Properties to define the types of fish in the inspector
    [SerializeField] private string fishName;
    [SerializeField] private Sprite fishSprite;
    [SerializeField] private GameObject fishPrefab;


    [SerializeField] private RarityEnum rarity;
    [SerializeField] private AttributeEnum attribute;
    [SerializeField] private BehaviorEnum behavior;

    // Properties for other scripts to access the private fields (Getters)
    public string FishName => fishName;
    public Sprite FishSprite => fishSprite;
    public GameObject FishPrefab => fishPrefab;
    public RarityEnum FishRarity => rarity;
    public AttributeEnum FishAttribute => attribute;
    public BehaviorEnum FishBehavior => behavior;

    // Enums to define the rarity, attribute, and behavior of the fish
    public enum RarityEnum
    {
        Trash,
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

    public enum BehaviorEnum
    {
        Jump,
        DoubleJump,
        TripleJump,
        Flying

    //  ZigZag,
    //  OverTheShip

    }
}

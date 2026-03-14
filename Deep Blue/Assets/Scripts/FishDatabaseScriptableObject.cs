using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "FishDatabaseScriptableObject", menuName = "ScriptableObjects/FishDatabase")]
public class FishDatabaseScriptableObject : ScriptableObject
{
    // Lists of all fish ScriptableObjects
    [SerializeField] private List<FishScriptableObject> allFish;
    [SerializeField] private List<FishScriptableObject> trashFish;
    [SerializeField] private List<FishScriptableObject> commonFish;
    [SerializeField] private List<FishScriptableObject> rareFish;
    [SerializeField] private List<FishScriptableObject> legendaryFish;

    // Read-only getters for other scripts
    public List<FishScriptableObject> AllFish => allFish;
    public List<FishScriptableObject> TrashFish => trashFish;
    public List<FishScriptableObject> CommonFish => commonFish;
    public List<FishScriptableObject> RareFish => rareFish;
    public List<FishScriptableObject> LegendaryFish => legendaryFish;


    private void OnEnable() 
    {
        // Populate the lists based on the rarity of the fish
        foreach (FishScriptableObject fish in AllFish)
        {
            switch (fish.FishRarity)
            {
                case FishScriptableObject.RarityEnum.Trash:
                    TrashFish.Add(fish);
                    break;
                case FishScriptableObject.RarityEnum.Common:
                    CommonFish.Add(fish);
                    break;
                case FishScriptableObject.RarityEnum.Rare:
                    RareFish.Add(fish);
                    break;
                case FishScriptableObject.RarityEnum.Legendary:
                    LegendaryFish.Add(fish);
                    break;
            }
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PotionRecipe", menuName = "Potion/Recipe")]
public class PotionRecipe : ScriptableObject
{
    public List<PotionData> ingredients;
    public PotionData result;
}
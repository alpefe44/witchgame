using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Cauldron : MonoBehaviour
{
    public static Cauldron Instance;
    [SerializeField] private List<PotionRecipe> allRecipes;
    private List<PotionData> currentIngredients = new();
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject potionPrefab;
    [SerializeField] private PotionTrigger _potionTrigger;


    void Awake()
    {
        Instance = this;
    }

    public void AddPotion(Potion potion)
    {
        if (currentIngredients.Count >= 3) return;

        currentIngredients.Add(potion.GetPotionData());
        // _potionTrigger.SetCurrentPotion(null);
        Destroy(potion.gameObject);


        if (currentIngredients.Count == 3)
        {
            TryCraftPotion();
        }
    }

    private void TryCraftPotion()
    {
        foreach (var recipe in allRecipes)
        {
            if (IsMatchingRecipe(recipe))
            {
                SpawnCraftedPotion(recipe.result);

                // Müşteri varsa ve bu iksiri istiyorsa ona ver
                // if (CustomerManager.CurrentCustomer != null)
                // {
                //     CustomerManager.CurrentCustomer.ReceivePotion(recipe.result);
                //     CustomerManager.CurrentCustomer = null;
                // }

                currentIngredients.Clear();
                return;
            }
        }

        Debug.Log("No matching recipe!");
        currentIngredients.Clear();
    }


    private bool IsMatchingRecipe(PotionRecipe recipe)
    {
        var input = currentIngredients.Select(p => p.potionName).OrderBy(n => n).ToList();
        var target = recipe.ingredients.Select(p => p.potionName).OrderBy(n => n).ToList();
        return input.SequenceEqual(target);
    }

    private void SpawnCraftedPotion(PotionData craftedData)
    {
        // Instantiate iksir prefabını oluştur
        GameObject newPotion = Instantiate(potionPrefab, transform.position + Vector3.up, Quaternion.identity);
        newPotion.GetComponent<Potion>().SetPotionData(craftedData);
        newPotion.GetComponent<Potion>().SetSpriteData(craftedData);
        newPotion.GetComponent<Potion>().SetCharPos(_characterController);
        newPotion.GetComponent<Potion>().TakePotion();

    }
}

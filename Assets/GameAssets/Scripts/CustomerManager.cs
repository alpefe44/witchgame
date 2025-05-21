using UnityEngine;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour
{
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private List<PotionRecipe> allRecipes;
    [SerializeField] private Transform spawnPoint;
    public static Customer CurrentCustomer { get; set; }

    void Start()
    {
        SpawnCustomer();
    }

    public void SpawnCustomer()
    {
        if (CurrentCustomer != null) return;

        GameObject newCustomer = Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
        Customer customerScript = newCustomer.GetComponent<Customer>();

        var randomRecipe = allRecipes[Random.Range(0, allRecipes.Count)];
        customerScript.SetWantedRecipe(randomRecipe);

        CurrentCustomer = customerScript;
    }
}

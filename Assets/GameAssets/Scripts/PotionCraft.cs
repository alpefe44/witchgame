using System.Collections.Generic;
using UnityEngine;

public class PotionCraft : MonoBehaviour
{
    [SerializeField] private PotionData potionData;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private CharacterController characterController;
    [SerializeField] public PotionTrigger potionTrigger;

    public static List<PotionCraft> AllPotionCrafts = new List<PotionCraft>();

    public bool isSpawnable;

    public int spawnCount;

    void Awake()
    {
        AllPotionCrafts.Add(this);
        foreach (var item in AllPotionCrafts)
        {
            Debug.Log(item.gameObject.name);
        }
    }

    private void OnDestroy()
    {
        AllPotionCrafts.Remove(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isSpawnable && !potionTrigger.CurrentPotion)
        {
            SpawnPotion();
        }
    }


    public void SpawnPotion()
    {
        if (spawnCount < 1)
        {
            GameObject gameObject = Instantiate(spawnObject, transform.position, spawnObject.transform.rotation);
            Debug.Log(gameObject.GetComponent<Potion>().IsTaken);
            if (!gameObject.GetComponent<Potion>().IsTaken)
            {
                gameObject.GetComponent<Potion>().SetCharPos(characterController);
                gameObject.GetComponent<Potion>().TakePotion();
                gameObject.GetComponent<Potion>().SetPotionCraft(this);
                spawnCount++;
            }
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CharacterController>(out var player))
        {
            // Sadece en yakın PotionCraft aktif olacak
            PotionCraft closest = GetClosestPotionCraft(player.transform.position);

            if (closest == this)
            {
                isSpawnable = true;
                spawnObject = closest.spawnObject;
            }
            else
            {
                isSpawnable = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<CharacterController>(out var player))
        {
            isSpawnable = false;
        }
    }

    public void DecreaseSpawnCount()
    {
        spawnCount = Mathf.Max(0, spawnCount - 1);
    }

    public PotionCraft GetClosestPotionCraft(Vector3 targetPosition)
    {
        PotionCraft closest = null;
        float closestDistance = float.MaxValue;

        foreach (var craft in AllPotionCrafts)
        {
            float dist = Vector2.Distance(targetPosition, craft.transform.position);
            if (dist < closestDistance)
            {
                closest = craft;
                closestDistance = dist;
            }
        }

        return closest;
    }

}

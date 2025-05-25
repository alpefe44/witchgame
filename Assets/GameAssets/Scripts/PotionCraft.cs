using UnityEngine;

public class PotionCraft : MonoBehaviour
{
    [SerializeField] private PotionData potionData;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PotionTrigger potionTrigger;

    public bool isSpawnable;

    public int spawnCount;


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
            isSpawnable = true;
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
}

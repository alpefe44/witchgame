using UnityEngine;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{
    [SerializeField] private CharacterController _characterPosition;
    [SerializeField] private PotionData _potionData;
    private bool isTake;
    private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer image;
    private PotionCraft potionCraft;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        image = GetComponent<SpriteRenderer>();
        image.sprite = _potionData.sprite;
    }

    public void TakePotion()
    {
        if (!isTake)
        {
            transform.position = _characterPosition.GetHandLocation().position;
            transform.rotation = _characterPosition.GetHandLocation().transform.rotation;
            transform.SetParent(_characterPosition.GetHandLocation());

            if (_rb != null)
                _rb.isKinematic = true;

            isTake = true;
        }
    }

    public void ReleasePotion()
    {
        if (isTake)
        {
            transform.SetParent(null);

            if (_rb != null)
            {
                _rb.isKinematic = false;
                Vector2 direction = _characterPosition.GetHandLocation().transform.right;
                direction = new Vector2(direction.x, direction.y).normalized;
                _rb.AddForce(direction * 5f, ForceMode2D.Impulse);
                potionCraft?.DecreaseSpawnCount();

            }

            isTake = false;
        }
    }

    public void ReleaseToCauldron()
    {
        if (isTake)
        {
            transform.SetParent(null);
            _rb.isKinematic = true; // Kazana atma değil, içine yerleştirme

            // Örneğin kazanın ortasına yerleştir
            transform.position = GameObject.FindWithTag("Cauldron").transform.position;
            Cauldron.Instance.AddPotion(this);

            isTake = false;
        }
    }


    public void SetCharPos(CharacterController characterController)
    {
        _characterPosition = characterController;
    }

    public PotionData GetPotionData() => _potionData;
    public void SetPotionData(PotionData data) => _potionData = data;
    public void SetSpriteData(PotionData data)
    {
        image.sprite = data.sprite;
    }
    public bool IsTaken => isTake;

    public void SetPotionCraft(PotionCraft pc)
    {
        potionCraft = pc;
    }

}

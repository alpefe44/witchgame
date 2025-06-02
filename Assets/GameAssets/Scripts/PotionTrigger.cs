using System.Collections.Generic;
using UnityEngine;

public class PotionTrigger : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private Potion _currentPotion;

    public Potion CurrentPotion => _currentPotion;

    private List<Potion> potions = new List<Potion>();

    void Update()
    {
        Debug.Log(_currentPotion + "currentpotion");
        Debug.Log(isPlayerInRange + "isplayerinrange");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Potion>(out var potion) && _currentPotion == null)
        {
            isPlayerInRange = true;
            _currentPotion = potion;
            potions.Add(_currentPotion);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Potion>(out var potion) && (object)potion == _currentPotion)
        {
            isPlayerInRange = false;
            _currentPotion = null;
        }
    }

    public void SetCurrentPotion(Potion potion)
    {
        _currentPotion = potion;
    }

    public void DestroyCurrenPotion()
    {
        if (_currentPotion != null)
        {
            Destroy(_currentPotion.gameObject); // 🔥 gameObject'i destroy et
            _currentPotion = null;
        }
    }

    public bool IsRange => isPlayerInRange;


}

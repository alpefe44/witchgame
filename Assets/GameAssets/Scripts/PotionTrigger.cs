using UnityEngine;

public class PotionTrigger : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private Potion _currentPotion;

    public Potion CurrentPotion => _currentPotion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Potion>(out var potion) && _currentPotion == null)
        {
            isPlayerInRange = true;
            _currentPotion = potion;
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

    public bool IsRange => isPlayerInRange;

}

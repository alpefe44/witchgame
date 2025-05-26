using System.Collections.Generic;
using UnityEngine;

public class PotionTrigger : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private Potion _currentPotion;

    public Potion CurrentPotion => _currentPotion;

    private List<Potion> potions = new List<Potion>();

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

    public bool IsRange => isPlayerInRange;

    public Potion ClosestPotion()
    {

        if (potions == null || potions.Count == 0)
            return null;

        Potion closestPotion = potions[0];
        float closestDistance = Vector2.Distance(transform.position, closestPotion.transform.position);

        foreach (var potion in potions)
        {
            float distance = Vector2.Distance(transform.position, potion.transform.position);
            if (distance < closestDistance)
            {
                closestPotion = potion;
                closestDistance = distance;
            }
        }

        Debug.Log(closestPotion  + "closest potion");

        return closestPotion;
    }

}

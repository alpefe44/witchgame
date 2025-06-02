using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    [SerializeField] private PotionTrigger _potionTrigger;
    [SerializeField] private CauldronTrigger _cauldronTrigger;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_potionTrigger.IsRange && _potionTrigger.CurrentPotion)
            {
                Debug.Log("ife girdi"); 
                _potionTrigger.CurrentPotion.TakePotion();
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_potionTrigger.CurrentPotion != null)
            {
                if (_cauldronTrigger.IsInRange)
                {
                    _potionTrigger.CurrentPotion.ReleaseToCauldron();
                }
                else
                {
                    _potionTrigger.CurrentPotion.ReleasePotion();
                }
            }
        }
    }
}

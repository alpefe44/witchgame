using TMPro;
using UnityEngine;

public class CauldronUI : MonoBehaviour
{
    [SerializeField] private CauldronTrigger _cauldronTrigger;
    [SerializeField] private GameObject _cauldronTriggerRect;

    [SerializeField] private PotionTrigger _potionTrigger;

    public void SetVisibleText()
    {
        if (_cauldronTriggerRect.activeSelf && !_cauldronTrigger.IsInRange || _potionTrigger.CurrentPotion == null)
        {
            _cauldronTriggerRect.SetActive(false);
            return;
        }

        _cauldronTriggerRect.SetActive(true);
    }

}

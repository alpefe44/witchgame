using UnityEngine;

public class CauldronTrigger : MonoBehaviour
{
    public bool IsInRange { get; private set; }

    [SerializeField] private CauldronUI _cauldronUI;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsInRange = true;
            _cauldronUI.SetVisibleText();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        _cauldronUI.SetVisibleText();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            IsInRange = false;
            _cauldronUI.SetVisibleText();
        }
    }
}

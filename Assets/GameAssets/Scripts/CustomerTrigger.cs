using UnityEngine;

public class CustomerTrigger : MonoBehaviour
{
    public static bool isCustomerRange { get; set; }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Potion>(out var potion))
        {
            if (!CustomerManager.CurrentCustomer.IsSatisfied && !isCustomerRange)
            {
                isCustomerRange = true;
                if (CustomerManager.CurrentCustomer != null)
                {
                    CustomerManager.CurrentCustomer.ReceivePotion(potion.GetPotionData());
                    CustomerManager.CurrentCustomer = null;
                    CustomerManager.Instance.CustomerLeft();
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Potion>(out var potion) && isCustomerRange)
        {
            isCustomerRange = false;
        }
    }
}

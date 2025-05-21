using UnityEngine;

public class Customer : MonoBehaviour
{
    public PotionRecipe WantedRecipe { get; private set; }
    public bool IsSatisfied { get; private set; }

    public void SetWantedRecipe(PotionRecipe recipe)
    {
        WantedRecipe = recipe;
        // UI gösterimi yapılabilir (örneğin ikon vs.)
        Debug.Log("Müşteri bu iksiri istiyor: " + recipe.result.potionName);
    }

    public void ReceivePotion(PotionData deliveredPotion)
    {
        if (deliveredPotion == WantedRecipe.result && CustomerTrigger.isCustomerRange)
        {
            Debug.Log("Doğru iksir verildi! Müşteri memnun.");
            IsSatisfied = true;
            // Animasyon, skor, para vs.
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Yanlış iksir verildi! Müşteri mutsuz.");
            IsSatisfied = false;
            Destroy(gameObject);
            // Animasyon vs.
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class CashUI : MonoBehaviour
{
    public Text cashText;

    public CashManager cashManager;

    public void updateText()
    {
        int currCash = cashManager.cash;
        cashText.text = currCash.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashManager : MonoBehaviour
{
    public int cash;

    public CashUI cashUi;

    [SerializeField]
    private int startCash = 100;

    void Start()
    {
        cash = startCash;
        cashUi.updateText();
    }

    public void addCash(int val)
    {
        cash += val;
        cashUi.updateText();
    }
}

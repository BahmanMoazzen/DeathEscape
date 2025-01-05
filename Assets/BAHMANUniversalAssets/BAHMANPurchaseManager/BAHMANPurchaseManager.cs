using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BAHMANPurchaseManager : MonoBehaviour
{
    [SerializeField] string _publicKey;
    [SerializeField] MarketInfo _marketConfig;
    
    public UnityEvent OnPurchaseFailed;
    public UnityEvent OnPurchaseSuccessful;
    public string[] _SKUList = { "sku0", "sku1" };
    public void StartPurchase(AllSKUs iSKUtoBuy)
    {
        _marketConfig.InitializeMarket();
        AC.GlobalVariables.GetVariable(15).BooleanValue = true;
    }

    public void _StartLow()
    {


    }
    public void _StartHigh()
    {


    }
    private void Start()
    {
        StartPurchase(AllSKUs.PayLess);
    }
}
public enum AllSKUs { PayLess, PlayMore }

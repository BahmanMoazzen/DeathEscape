using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BAHMANPurchaseManager : MonoBehaviour
{
    public static BAHMANPurchaseManager _Instance;



    [SerializeField] MarketInfo _marketConfig;

    public UnityEvent OnPurchaseFailed;
    public UnityEvent OnPurchaseSuccessful;

    private void Awake()
    {
        if (_Instance == null)
        {
            _Instance = this;
            _marketConfig._InitializeMarket();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        _marketConfig._DisposeMarket();
    }

    public void _StartPurchase(AllSKUs iSKUtoBuy)
    {
        _marketConfig._BuyWholeProcess(_marketConfig._SKUs[(int)iSKUtoBuy], _Success, _Failed);

        //AC.GlobalVariables.GetVariable(15).BooleanValue = true;
    }

    public void _Success()
    {
        OnPurchaseSuccessful?.Invoke();

    }
    public void _Failed()
    {
        OnPurchaseFailed?.Invoke();

    }
}
public enum AllSKUs { PayLess, PlayMore }

using BazaarInAppBilling;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "NewBazaar", menuName = "Bahman/Bazaar", order = 1)]
public class BazaarInfo : MarketInfo
{
    public override void _ConsumProduct(string iSKU)
    {
        throw new System.NotImplementedException();
    }
    public override void _BuyWholeProcess(string iSKU, UnityAction iOnSuccess, UnityAction iOnFail)
    {
        base._BuyWholeProcess(iSKU, iOnSuccess, iOnFail);
        StoreHandler.instance.Purchase(_SKUtoIndex(iSKU), onBuyFailed, onBuySuccess);

    }
    public override void _DisposeMarket()
    {

    }
    protected int _SKUtoIndex(string iSKU)
    {
        for (int i = 0; i < _SKUs.Length; i++)
        {
            if (_SKUs[i] == iSKU)
            {
                return i;
            }
        }
        return -1;
    }
    public override void _InitializeMarket()
    {
        _dLog("initializing ...");
        StoreHandler.instance.InitializeBillingService(onInitFailed, onInitSuccess);
    }

    public override void _PurchaseProduct(string iSKU)
    {
        throw new System.NotImplementedException();
    }

    public override void _QueryInventory()
    {
        throw new System.NotImplementedException();
    }

    public override void _QueryPurchases()
    {
        foreach (string s in _SKUs)
        {
            StoreHandler.instance.CheckInventory(_SKUtoIndex(s), null, onQueryInventorySuccess);
        }

    }

    public override void _QuerySKUDetails()
    {
        throw new System.NotImplementedException();
    }



    void onInitFailed(int iErrorNumber, string iErrorMessage)
    {
        _dLog("Init Failed: " + iErrorMessage);
    }
    void onInitSuccess()
    {
        _dLog("Init Success. Querying ...");
        _QueryPurchases();
    }
    void onQueryInventorySuccess(Purchase iPurchase, int iIndex)
    {
        _dLog(iPurchase.productId + " is in inventory. Consuming ...");
        StoreHandler.instance.ConsumePurchase(iPurchase, iIndex, null, onConsumeSuccess);
    }
    void onBuyFailed(int iErrorNumber, string iErrorMessage)
    {
        _dLog("Buy failed");
        _onFail();
    }
    void onBuySuccess(Purchase iPurchase, int iIndex)
    {
        _dLog("Buy Success" + iPurchase.purchaseToken);
        StoreHandler.instance.ConsumePurchase(iPurchase, iIndex, onConsumeFailed, onConsumeSuccess);
    }

    void onConsumeFailed(int iErrorNumber, string iErrorMessage)
    {
        _dLog("Consume failed");
        _onFail();
    }

    void onConsumeSuccess(Purchase iPurchase, int iIndex)
    {
        _dLog("Consume Success" + iPurchase.purchaseToken);
        _onSuccess();
    }

}

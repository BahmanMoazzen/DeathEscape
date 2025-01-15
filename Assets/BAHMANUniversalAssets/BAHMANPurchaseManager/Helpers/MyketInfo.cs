using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using MyketPlugin;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "NewMyket", menuName = "Bahman/Myket", order = 1)]
public class MyketInfo : MarketInfo
{
    #region public methods

    public override void _BuyWholeProcess(string iSKU, UnityAction iOnSuccess, UnityAction iOnFail)
    {
        base._BuyWholeProcess(iSKU, iOnSuccess, iOnFail);

        _PurchaseProduct(iSKU);

    }


    public override void _ConsumProduct(string iSKU)
    {
        //MyketIAB.consumeProduct(iSKU);
    }

    public override void _DisposeMarket()
    {

        //IABEventManager.billingSupportedEvent -= billingSupportedEvent;
        //IABEventManager.billingNotSupportedEvent -= billingNotSupportedEvent;
        //IABEventManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
        //IABEventManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
        //IABEventManager.querySkuDetailsSucceededEvent -= querySkuDetailsSucceededEvent;
        //IABEventManager.querySkuDetailsFailedEvent -= querySkuDetailsFailedEvent;
        //IABEventManager.queryPurchasesSucceededEvent -= queryPurchasesSucceededEvent;
        //IABEventManager.queryPurchasesFailedEvent -= queryPurchasesFailedEvent;
        //IABEventManager.purchaseSucceededEvent -= purchaseSucceededEvent;
        //IABEventManager.purchaseFailedEvent -= purchaseFailedEvent;
        //IABEventManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
        //IABEventManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
        //MyketIAB.unbindService();
    }

    public override void _InitializeMarket()
    {

        //IABEventManager.billingSupportedEvent += billingSupportedEvent;
        //IABEventManager.billingNotSupportedEvent += billingNotSupportedEvent;
        //IABEventManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
        //IABEventManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
        //IABEventManager.querySkuDetailsSucceededEvent += querySkuDetailsSucceededEvent;
        //IABEventManager.querySkuDetailsFailedEvent += querySkuDetailsFailedEvent;
        //IABEventManager.queryPurchasesSucceededEvent += queryPurchasesSucceededEvent;
        //IABEventManager.queryPurchasesFailedEvent += queryPurchasesFailedEvent;
        //IABEventManager.purchaseSucceededEvent += purchaseSucceededEvent;
        //IABEventManager.purchaseFailedEvent += purchaseFailedEvent;
        //IABEventManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
        //IABEventManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
        //_dLog("Events Added. Using Myket init...");
        //MyketIAB.init(_MarketKey);
        //_dLog("Myket init called. Waiting for response...");


    }

    public override void _PurchaseProduct(string iSKU)
    {
        _dLog("Purchasing " + iSKU);
        _currentSKU = iSKU;
        //MyketIAB.purchaseProduct(iSKU);

    }

    public override void _QueryInventory()
    {
        //MyketIAB.queryInventory(_SKUs);
    }

    public override void _QueryPurchases()
    {
        //MyketIAB.queryPurchases();
    }

    public override void _QuerySKUDetails()
    {
        //MyketIAB.querySkuDetails(_SKUs);
    }
    #endregion
    #region events
    //void billingSupportedEvent()
    //{
    //    _dLog("Myket is Initialised. Querying purchases ...");
    //    _QueryPurchases();
    //}

    //void billingNotSupportedEvent(string error)
    //{
    //    _dLog("Myket is not initialized.");
    //    _onFail();
    //    //_DisposeMarket();

    //}

    ////void queryInventorySucceededEvent(List<MyketPurchase> purchases, List<MyketSkuInfo> skus)
    ////{
    ////    Debug.Log(string.Format("queryInventorySucceededEvent. total purchases: {0}, total skus: {1}", purchases.Count, skus.Count));

    ////    for (int i = 0; i < purchases.Count; ++i)
    ////    {
    ////        Debug.Log(purchases[i].ToString());
    ////    }

    ////    Debug.Log("-----------------------------");

    ////    for (int i = 0; i < skus.Count; ++i)
    ////    {
    ////        Debug.Log(skus[i].ToString());
    ////    }
    ////}

    //void queryInventoryFailedEvent(string error)
    //{
    //    Debug.Log("queryInventoryFailedEvent: " + error);
    //}

    ////private void querySkuDetailsSucceededEvent(List<MyketSkuInfo> skus)
    ////{
    ////    Debug.Log(string.Format("querySkuDetailsSucceededEvent. total skus: {0}", skus.Count));

    ////    for (int i = 0; i < skus.Count; ++i)
    ////    {
    ////        Debug.Log(skus[i].ToString());
    ////    }
    ////}

    //private void querySkuDetailsFailedEvent(string error)
    //{
    //    Debug.Log("querySkuDetailsFailedEvent: " + error);
    //}

    //private void queryPurchasesSucceededEvent(List<MyketPurchase> purchases)
    //{
    //    _dLog(string.Format("queryPurchasesSucceededEvent. total purchases: {0}", purchases.Count));
    //    if (purchases.Count > 0)
    //    {
    //        //bool hasCurrentSKU = false;
    //        for (int i = 0; i < purchases.Count; ++i)
    //        {
    //            _ConsumProduct(purchases[i].ProductId);
    //            //if (purchases[i].ProductId == _currentSKU)
    //            //{
    //            //    hasCurrentSKU = true;
    //            //}
    //        }
    //        //if (!hasCurrentSKU)
    //        //{
    //        //    _PurchaseProduct(_currentSKU);
    //        //}
    //        //else
    //        //{
    //        //    _onSuccess();
    //        //    _DisposeMarket();
    //        //}
    //    }
    //    else
    //    {
    //        //_PurchaseProduct(_currentSKU);
    //    }
    //}

    //private void queryPurchasesFailedEvent(string error)
    //{
    //    _dLog("Querying failed.");

    //    //_PurchaseProduct(_currentSKU);
    //}

    //void purchaseSucceededEvent(MyketPurchase purchase)
    //{
    //    _dLog("Purchas Success " + purchase.ProductId + " .Consuming ...");

    //    _ConsumProduct(purchase.ProductId);

    //}

    //void purchaseFailedEvent(string error)
    //{
    //    _dLog("Purchas failed " + error);

    //    _onFail();
    //    //_DisposeMarket();
    //}

    //void consumePurchaseSucceededEvent(MyketPurchase purchase)
    //{
    //    _dLog("Consumption Success " + purchase.ProductId);

    //    _onSuccess();
    //    //_DisposeMarket();

    //}

    //void consumePurchaseFailedEvent(string error)
    //{
    //    _dLog($"Consumed purchase failed: {error}");
    //    _onFail();
    //    //_DisposeMarket();
    //}
    #endregion
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OnePF;


public class DemoBilling : MonoBehaviour {



	public const string SKU = "no_ads";
	public const string googleKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAoe/BLnWQEkNqOABTksY2pvHTrqeZGbGAE89XWIEah901QJWkrmKpeVaNcf8e2Hf65vcEJWo3MNdJ9te/Ce/yzWjV98XF3fWOowzoTLMKqPk71w9s1/c+Y9smRxZOwrs4Va6mlqNnj7DqOB9aXbD6QXg6FA/8U1G4SduhZSuirnrlaX3LMGJDYA6d8yYMIqKCVJaqbjAvvnHIO8EvUG/OjIlEDrlbyX1/JqyWxXV6NLB7YHYbGJI1I19P2aKIS5GixE0mW1vaMbWynZegR49N1zcdPw7FZHr2vNPn1n+fFkUdjn2gLSQPzV92s/aZ3EOVyrOzV98flg29jSVGrLUMiwIDAQAB";
	//public const string iosKey = "";
	private void Awake()
	{
		// Subscribe to all billing events
		OpenIABEventManager.billingSupportedEvent += OnBillingSupported;
		OpenIABEventManager.billingNotSupportedEvent += OnBillingNotSupported;
		OpenIABEventManager.purchaseSucceededEvent += OnPurchaseSucceded;
		OpenIABEventManager.purchaseFailedEvent += OnPurchaseFailed;
		OpenIABEventManager.consumePurchaseSucceededEvent += OnConsumePurchaseSucceeded;
		OpenIABEventManager.consumePurchaseFailedEvent += OnConsumePurchaseFailed;
		OpenIABEventManager.transactionRestoredEvent += OnTransactionRestored;
		OpenIABEventManager.restoreSucceededEvent += OnRestoreSucceeded;
		OpenIABEventManager.restoreFailedEvent += OnRestoreFailed;
	}

	private void OnDestroy()
	{
		// Unsubscribe to avoid nasty leaks
		OpenIABEventManager.billingSupportedEvent -= OnBillingSupported;
		OpenIABEventManager.billingNotSupportedEvent -= OnBillingNotSupported;
		OpenIABEventManager.purchaseSucceededEvent -= OnPurchaseSucceded;
		OpenIABEventManager.purchaseFailedEvent -= OnPurchaseFailed;
		OpenIABEventManager.consumePurchaseSucceededEvent -= OnConsumePurchaseSucceeded;
		OpenIABEventManager.consumePurchaseFailedEvent -= OnConsumePurchaseFailed;
		OpenIABEventManager.transactionRestoredEvent -= OnTransactionRestored;
		OpenIABEventManager.restoreSucceededEvent -= OnRestoreSucceeded;
		OpenIABEventManager.restoreFailedEvent -= OnRestoreFailed;
	}

	void Start() 
	{

		OpenIAB.mapSku(SKU, OpenIAB_Android.STORE_GOOGLE, "no_ads");
		OpenIAB.mapSku(SKU, OpenIAB_iOS.STORE, "no_ads");
		var options = new OnePF.Options ();
		//options.storeKeys.Add(OpenIAB_iOS.STORE,);
		options.storeKeys.Add (OpenIAB_Android.STORE_GOOGLE, googleKey);
		OpenIAB.init (options);

	}

	public void NoAds()
	{
		OpenIAB.purchaseProduct (SKU);
	
	}


	private void OnBillingSupported()
	{
		Debug.Log("Billing is supported");
		OpenIAB.queryInventory(new string[] { SKU });
	}
	
	private void OnBillingNotSupported(string error)
	{
		Debug.Log("Billing not supported: " + error);
	}
	
	
	private void OnQueryInventoryFailed(string error)
	{
		Debug.Log("Query inventory failed: " + error);
	}
	
	private void OnPurchaseSucceded(Purchase purchase)
	{
		SPlayerPrefs.SetString("jgdfkjgbbsdfusdhufhfksfggrwebnasksdfsd","SUCCED");
		this.SendMessage("CheckSKU");
	}
	
	private void OnPurchaseFailed(int errorCode, string error)
	{
		Debug.Log("Purchase failed: " + error);

	}
	
	private void OnConsumePurchaseSucceeded(Purchase purchase)
	{
		Debug.Log("Consume purchase succeded: " + purchase.ToString());
	}
	
	private void OnConsumePurchaseFailed(string error)
	{
		Debug.Log("Consume purchase failed: " + error);
	}
	
	private void OnTransactionRestored(string sku)
	{
		Debug.Log("Transaction restored: " + sku);
	}
	
	private void OnRestoreSucceeded()
	{
		Debug.Log("Transactions restored successfully");
	}
	
	private void OnRestoreFailed(string error)
	{
		Debug.Log("Transaction restore failed: " + error);
	}








}
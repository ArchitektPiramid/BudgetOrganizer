using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Helper : MonoBehaviour
{
    
    public static Helper Instance {
        get { return _instance; }
    }
    
    private static Helper _instance = null;
     
    void Awake() {
        if(_instance == null) {
            _instance = this;
            Debug.Log("Created Helper class singleton");
        }
        DontDestroyOnLoad(this);
    }

    public static void DuplicateDB(string dbPath) {
        var temp = dbPath.Split('.');
        if(temp.Length == 2) {
            try {
                string formatedTime = System.DateTime.Now.ToString("_yyyy_MM_dd-HH_mm_ss");
                File.Copy(dbPath, temp[0] + formatedTime + "." + temp[1]);
                Debug.Log("Created copy of database");
            }
            catch (System.Exception){
                Debug.LogError("CANNOT create copy of database");
            }
        } else {
            Debug.LogError(string.Format("db path have {0} dots inscead of 1", temp.Length.ToString()));
        }
    }
}

public class SingleShopData
{
    public SingleShopData(string id, string shop, string add1, string add2, string nip) {
        this.id = id;
        this.shopName = shop;
        this.address01 = add1;
        this.address02 = add2;
        this.nip = nip;
    }

    public string id;
    public string shopName;
    public string address01;
    public string address02;
    public string nip;
}
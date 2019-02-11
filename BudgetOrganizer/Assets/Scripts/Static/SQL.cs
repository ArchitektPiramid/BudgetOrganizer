
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mono.Data.Sqlite;
//using Mono.Data.SqliteClient;
using System.Data;


public class SQL : MonoBehaviour {

    private string dbPath = string.Empty;
    private string dbName = "exampleDatabase.db";
	
    public static SQL Instance {
        get { return _instance; }
    }
    
    private static SQL _instance = null;
     
    void Awake() {
        if(_instance == null) {
            _instance = this;
            Debug.Log("Created SQLLLLLLLLL class singleton");
        }
        DontDestroyOnLoad(this);

		dbPath = "URI=file:" + Application.persistentDataPath + "/" + dbName;
        Helper.DuplicateDB(Application.persistentDataPath + "/" + dbName);

		CreateSchema();
    }


	private void Start() {


	}


	public void CreateSchema() {
		using (var conn = new SqliteConnection(dbPath)) {
			conn.Open();
			using (var cmd = conn.CreateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "CREATE TABLE IF NOT EXISTS 'shop' ( " +
					            	"  'id' INTEGER PRIMARY KEY, " +
					            	"  'shop_name' TEXT NOT NULL, " +
									"  'address_01' TEXT NOT NULL, " +
									"  'address_02' TEXT NOT NULL, " +
					            	"  'nip' TEXT" +
					            	");";

				var result = cmd.ExecuteNonQuery();
				Debug.Log("create schema: " + result);
			}
		}
	}

	public void CreateNewShop(string shopName, string address01, string address02, string nip) {
		using (var conn = new SqliteConnection(dbPath)) {
			conn.Open();
			using (var cmd = conn.CreateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "INSERT INTO shop (shop_name, address_01, address_02, nip) " +
				                  "VALUES (@SHOP, @ADDRESS01, @ADDRESS02, @NIP);";

				cmd.Parameters.Add(new SqliteParameter { ParameterName = "SHOP", Value = shopName});
				cmd.Parameters.Add(new SqliteParameter { ParameterName = "ADDRESS01", Value = address01});
				cmd.Parameters.Add(new SqliteParameter { ParameterName = "ADDRESS02", Value = address02});
				cmd.Parameters.Add(new SqliteParameter { ParameterName = "NIP", Value = nip});

				// cmd.Parameters.Add(new SqliteParameter {
				// 	ParameterName = "Name",
				// 	Value = highScoreName
				// });


					var result = cmd.ExecuteNonQuery();
					Debug.Log("insert score: " + result);
				}
			}
		}


	public List<SingleShopData> GetAllShopts() {
		List<SingleShopData> dupa = new List<SingleShopData>();
		using(var conn = new SqliteConnection(dbPath)) {
			conn.Open();
			using(var cmd = conn.CreateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM shop";
				var reader = cmd.ExecuteReader();
				while(reader.Read()) {
					var dd = reader.GetValue(0).ToString();
					var aa = reader.GetValue(1).ToString();
					var bb = reader.GetValue(2).ToString();
					var cc = reader.GetValue(3).ToString();
					var zz = reader.GetValue(4).ToString();
					dupa.Add(new SingleShopData(dd, aa, bb, cc, zz));
				}
			}
		}

		return dupa;
	}


	public void GetHighScores(int limit) {
		using (var conn = new SqliteConnection(dbPath)) {
			conn.Open();
			using (var cmd = conn.CreateCommand()) {
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM high_score ORDER BY score DESC LIMIT @Count;";

				cmd.Parameters.Add(new SqliteParameter {
					ParameterName = "Count",
					Value = limit
				});

				Debug.Log("scores (begin)");
				var reader = cmd.ExecuteReader();
				while (reader.Read()) {
					var id = reader.GetInt32(0);
					var highScoreName = reader.GetString(1);
					var score = reader.GetInt32(2);
					var text = string.Format("{0}: {1} [#{2}]", highScoreName, score, id);
						Debug.Log(text);
				}
				Debug.Log("scores (end)");
			}
		}
	}
	
   
 
}
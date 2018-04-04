using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System;

public class testSQLite : MonoBehaviour {

	SqliteConnection sqlConnect;

	// Use this for initialization
	void Start () {
		try {
			sqlConnect = new SqliteConnection("data source=sqliteTest.db");
			sqlConnect.Open();
		}
		catch(Exception e) {
			Debug.Log(e.Message);
		}
		SqliteCommand dbCommand = sqlConnect.CreateCommand();
		string strCommand = "CREATE TABLE IF NOT EXISTS testInfo(id integer primary key,name TEXT,age INTEGER)";
		dbCommand.CommandText = strCommand;
		dbCommand.ExecuteReader();

		SqliteCommand dbCommand1 = sqlConnect.CreateCommand();
		strCommand = "insert into testInfo values(1,'Tom',22)";
		dbCommand1.CommandText = strCommand;
		dbCommand1.ExecuteReader();

		SqliteCommand dbCommand2 = sqlConnect.CreateCommand();
		strCommand = "select * from testInfo";
		dbCommand2.CommandText = strCommand;
		SqliteDataReader reader = dbCommand2.ExecuteReader();
		while(reader.Read()) {
			Debug.Log(reader.GetInt32(reader.GetOrdinal("id")));
			Debug.Log(reader.GetString(reader.GetOrdinal("name")));
			Debug.Log(reader.GetInt32(reader.GetOrdinal("age")));
		}
		sqlConnect.Close();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class SearchRecordsButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject _recordPrefab, _recordPrefabBT_L;
    [SerializeField]
    private GameObject _scrollContentLB, _scrollContentBT, _scrollContentBR;
    [SerializeField]
    private GameObject _searchRecords, _searchLibraryBooks, _searchLibraryBooksBack, _searchBooksTaken, _searchBooksTakenBack, _searchBooksReturned, _searchBooksReturnedBack;

    private List<GameObject> _lbPrefabs = new List<GameObject>();
    private List<GameObject> _btPrefabs = new List<GameObject>();
    private List<GameObject> _brPrefabs = new List<GameObject>();

    private Vector3 pos;
    private Vector3 pos2;

    public static string dbName;

    public List<GameObject> LBPrefabs
    {
        get
        {
            return _lbPrefabs;
        }
    }

    public List<GameObject> BTPrefabs
    {
        get
        {
            return _btPrefabs;
        }
    }

    public List<GameObject> BRPrefabs
    {
        get
        {
            return _brPrefabs;
        }
    }

    void Awake()
    {

        dbName = "URI=file:" + Application.dataPath + "/Library.db";
    }

    private void deactivateThisGameObject()
    {
        _searchRecords.SetActive(false);
    }


    public void displayRecords(string tableName)
    {
        pos = new Vector3(31f, 89f, 0);
        pos2 = new Vector3(-7f, 89f, 0);
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM " + tableName + ";";
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (tableName == "LibraryBooks")
                        {
                            GameObject recordP = Instantiate(_recordPrefab, pos, Quaternion.identity);
                            recordP.transform.SetParent(_scrollContentLB.transform, false);
                            _lbPrefabs.Add(recordP);
                            Text bName = recordP.transform.GetChild(1).GetComponent<Text>();
                            Text author = recordP.transform.GetChild(2).GetComponent<Text>();
                            Text date = recordP.transform.GetChild(3).GetComponent<Text>();
                            Text taken = recordP.transform.GetChild(4).GetComponent<Text>();

                            bName.text = reader["name"].ToString();
                            author.text = reader["author"].ToString();
                            date.text = reader["date"].ToString();
                            taken.text = reader["taken"].ToString();
                            pos.y -= 38;
                        }
                        else
                        {
                            GameObject recordP = Instantiate(_recordPrefabBT_L, pos2, Quaternion.identity);
                            if (tableName == "BooksTaken")
                            {
                                recordP.transform.SetParent(_scrollContentBT.transform, false);
                                _btPrefabs.Add(recordP);
                            }
                            else if (tableName == "BooksReturned")
                            {
                                recordP.transform.SetParent(_scrollContentBR.transform, false);
                                _brPrefabs.Add(recordP);
                            }
                            Text bName = recordP.transform.GetChild(1).GetComponent<Text>();
                            Text author = recordP.transform.GetChild(2).GetComponent<Text>();
                            Text nameOStudent = recordP.transform.GetChild(3).GetComponent<Text>();
                            Text matricNo = recordP.transform.GetChild(4).GetComponent<Text>();
                            Text department = recordP.transform.GetChild(5).GetComponent<Text>();
                            Text date = recordP.transform.GetChild(6).GetComponent<Text>();

                            bName.text = reader["name"].ToString();
                            author.text = reader["author"].ToString();
                            nameOStudent.text = reader["nameOfStudent"].ToString();
                            matricNo.text = reader["matricNumber"].ToString();
                            department.text = reader["department"].ToString();
                            date.text = reader["date"].ToString();
                            pos2.y -= 38;
                        }
                    }
                }
            }

            connection.Close();
        }
    }

    public void SearchLibraryBooks()
    {
        deactivateThisGameObject();
        _searchLibraryBooks.SetActive(true);
        _searchLibraryBooksBack.SetActive(true);
        displayRecords("LibraryBooks");
        DBFunction.Instance.setSubmitScreen("LB");
    }

    public void SearchBooksTaken()
    {
        deactivateThisGameObject();
        _searchBooksTaken.SetActive(true);
        _searchBooksTakenBack.SetActive(true);
        displayRecords("BooksTaken");
        DBFunction.Instance.setSubmitScreen("BT");
    }

    public void SearchBooksReturned()
    {
        deactivateThisGameObject();
        _searchBooksReturned.SetActive(true);
        _searchBooksReturnedBack.SetActive(true);
        displayRecords("BooksReturned");
        DBFunction.Instance.setSubmitScreen("BR");
    }
}

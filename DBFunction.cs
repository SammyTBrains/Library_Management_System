using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class DBFunction : MonoBehaviour
{
    private static DBFunction instance;
    public static DBFunction Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.Log("Submit Function is null!");
            }
            return instance;
        }
    }

    [SerializeField]
    private GameObject _addRecord;
    [SerializeField]
    private GameObject _addLibraryBooks;
    [SerializeField]
    private GameObject _addBooksTaken;
    [SerializeField]
    private GameObject _addBooksReturned;

    [SerializeField]
    private GameObject _searchLibraryBooks, _searchBooksTaken, _searchBooksReturned;
    [SerializeField]
    private GameObject _findInLibraryBooks, _findInBooksTaken, _findInBooksReturned;
    [SerializeField]
    private GameObject _updateRecordLB, _updateRecordBT_L;
    [SerializeField]
    private GameObject _updateButtonBackLB, _updateButtonBackBT_L;

    [SerializeField]
    private GameObject _deletePopUp;

    [SerializeField]
    private GameObject _recordPrefab, _recordPrefabBT_L;

    [SerializeField]
    private GameObject _recordFound, _recordNotFound;

    [Header("Library Books")]
    [SerializeField]
    private InputField _bookName;
    [SerializeField]
    private InputField _author;
    [SerializeField]
    private InputField _date;

    [Header("Books Taken")]
    [SerializeField]
    private InputField _bookNameT;
    [SerializeField]
    private InputField _authorT;
    [SerializeField]
    private InputField _nameOfStudentT;
    [SerializeField]
    private InputField _matricNoT;
    [SerializeField]
    private InputField _departmentT;
    [SerializeField]
    private InputField _dateT;

    [Header("Books Returned")]
    [SerializeField]
    private InputField _bookNameR;
    [SerializeField]
    private InputField _authorR;
    [SerializeField]
    private InputField _nameOfStudentR;
    [SerializeField]
    private InputField _matricNoR;
    [SerializeField]
    private InputField _departmentR;
    [SerializeField]
    private InputField _dateR;

    [Space]
    [Space]

    [Header("Library Books")]
    [SerializeField]
    private InputField _bookNameU;
    [SerializeField]
    private InputField _authorU;
    [SerializeField]
    private InputField _dateU;

    [Header("Books Taken/Returned")]
    [SerializeField]
    private InputField _bookNameUT_L;
    [SerializeField]
    private InputField _authorUT_L;
    [SerializeField]
    private InputField _nameOfStudentUT_L;
    [SerializeField]
    private InputField _matricNoUT_L;
    [SerializeField]
    private InputField _departmentUT_L;
    [SerializeField]
    private InputField _dateUT_L;

    [Space]
    [Space]

    [Header("Find Section")]
    [SerializeField]
    private InputField _bookNameFindLB;
    [SerializeField]
    private InputField _bookNameFindBT;
    [SerializeField]
    private InputField _bookNameFindBR;

    public InputField BookNameFindLB
    {
        get
        {
            return _bookNameFindLB;
        }
    }

    public InputField BookNameFindBT
    {
        get
        {
            return _bookNameFindBT;
        }
    }

    public InputField BookNameFindBR
    {
        get
        {
            return _bookNameFindBR;
        }
    }

    private string _nameDLB;
    private string _authorDLB;
    private string _dateDLB;

    private string _nameDBT_L;
    private string _authorDBT_L;
    private string _nameOfStudentDBT_L;
    private string _matricNoDBT_L;
    private string _departmentDBT_L;
    private string _dateDBT_L;

    private SearchRecordsButtons SB;
    private string _submitScreen;

    private GameObject _lbPrefab;
    private GameObject _btPrefab;
    private GameObject _brPrefab;

    public GameObject LBPrefab
    {
        get
        {
            return _lbPrefab;
        }
    }

    public GameObject BTPrefab
    {
        get
        {
            return _btPrefab;
        }
    }

    public GameObject BRPrefab
    {
        get
        {
            return _brPrefab;
        }
    }

    public static string dbName;

    void Awake()
    {
        instance = this;
        dbName = "URI=file:" + Application.dataPath + "/Library.db";
    }

    private void Start()
    {
        dbConnectAndExecute("CREATE TABLE IF NOT EXISTS LibraryBooks (name VARCHAR(20), author VARCHAR(20), date VARCHAR(10), taken VARCHAR(4));");
        dbConnectAndExecute("CREATE TABLE IF NOT EXISTS BooksTaken (name VARCHAR(20), author VARCHAR(20), nameOfStudent VARCHAR(30), " +
            "matricNumber VARCHAR(20), department VARCHAR(20), date VARCHAR(10));");
        dbConnectAndExecute("CREATE TABLE IF NOT EXISTS BooksReturned (name VARCHAR(20), author VARCHAR(20), nameOfStudent VARCHAR(30), " +
            "matricNumber VARCHAR(20), department VARCHAR(20), date VARCHAR(10));");

        SB = this.gameObject.GetComponent<SearchRecordsButtons>();
    }

    public void setSubmitScreen(string subScreenString)
    {
        _submitScreen = subScreenString;
    }

    public string getSubmitScreen()
    {
        return _submitScreen;
    }

    private void dbConnectAndExecute(string commandString)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = commandString;
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }

    public void SubmitRecord()
    {
        if (_submitScreen == "LB")
        {
            dbConnectAndExecute("INSERT INTO LibraryBooks (name, author, date, taken) VALUES ('" + _bookName.text + "', '" + _author.text + "', '" + _date.text + "', 'NO');");
            _bookName.text = "";
            _author.text = "";
            _date.text = "";
            _addLibraryBooks.SetActive(false);
        }
        else if (_submitScreen == "BT")
        {
            dbConnectAndExecute("INSERT INTO BooksTaken (name, author, nameOfStudent, matricNumber, department, date) VALUES ('"
                + _bookNameT.text + "', '" + _authorT.text + "', '" + _nameOfStudentT.text + "', '" + _matricNoT.text + "', '" + _departmentT.text + "', '"
                + _dateT.text + "');");
            dbConnectAndExecute("UPDATE LibraryBooks SET taken = 'YES' WHERE name = '" + _bookNameT.text + "'; ");
            _bookNameT.text = "";
            _authorT.text = "";
            _nameOfStudentT.text = "";
            _matricNoT.text = "";
            _departmentT.text = "";
            _dateT.text = "";
            _addBooksTaken.SetActive(false);
        }
        else if (_submitScreen == "BR")
        {
            dbConnectAndExecute("INSERT INTO BooksReturned (name, author, nameOfStudent, matricNumber, department, date) VALUES ('"
                + _bookNameR.text + "', '" + _authorR.text + "', '" + _nameOfStudentR.text + "', '" + _matricNoR.text + "', '" + _departmentR.text + "', '"
                + _dateR.text + "');");
            dbConnectAndExecute("UPDATE LibraryBooks SET taken = 'NO' WHERE name = '" + _bookNameR.text + "'; ");
            _bookNameR.text = "";
            _authorR.text = "";
            _nameOfStudentR.text = "";
            _matricNoR.text = "";
            _departmentR.text = "";
            _dateR.text = "";
            _addBooksReturned.SetActive(false);
        }

        _addRecord.SetActive(true);
    }

    public void UpdateLBData(string name, string author, string date)
    {
        _bookNameU.text = name;
        _authorU.text = author;
        _dateU.text = date;
        if (_submitScreen == "LBF")
        {
            Destroy(_lbPrefab);
            _findInLibraryBooks.SetActive(false);
        }
        else if (_submitScreen == "LB")
        {
            destroyRecords(SB.LBPrefabs);
            _searchLibraryBooks.SetActive(false);
        }
        _updateRecordLB.SetActive(true);
        _updateButtonBackLB.SetActive(true);
    }

    public void UpdateLBT_LData(string name, string author, string nameOfStudent, string matricNo, string department, string date)
    {
        _bookNameUT_L.text = name;
        _authorUT_L.text = author;
        _nameOfStudentUT_L.text = nameOfStudent;
        _matricNoUT_L.text = matricNo;
        _departmentUT_L.text = department;
        _dateUT_L.text = date;

        if (_submitScreen == "BTF")
        {
            Destroy(_btPrefab);
            _findInBooksTaken.SetActive(false);
        }
        else if (_submitScreen == "BT")
        {
            destroyRecords(SB.BTPrefabs);
            _searchBooksTaken.SetActive(false);
        }
        else if (_submitScreen == "BRF")
        {
            Destroy(_brPrefab);
            _findInBooksReturned.SetActive(false);
        }
        else if (_submitScreen == "BR")
        {
            destroyRecords(SB.BRPrefabs);
            _searchBooksReturned.SetActive(false);
        }
        _updateRecordBT_L.SetActive(true);
        _updateButtonBackBT_L.SetActive(true);
    }

    public void SetDeleteLBData(string name, string author, string date, GameObject record)
    {
        _nameDLB = name;
        _authorDLB = author;
        _dateDLB = date;
    }

    public void SetDeleteLBT_LData(string name, string author, string nameOfStudent, string matricNo, string department, string date, GameObject record)
    {
        _nameDBT_L = name;
        _authorDBT_L = author;
        _nameOfStudentDBT_L = nameOfStudent;
        _matricNoDBT_L = matricNo;
        _departmentDBT_L = department;
        _dateDBT_L = date;
    }

    private void destroyRecords(List<GameObject> prefabs)
    {
        if (prefabs != null)
        {
            foreach (GameObject prefab in prefabs)
            {
                Destroy(prefab);
            }
        }
    }

    private void refreshRecords(List<GameObject> prefabs, string tableName)
    {
        destroyRecords(prefabs);
        SB.displayRecords(tableName);
    }

    public void YesDelete()
    {
        if (_submitScreen == "LB")
        {
            dbConnectAndExecute("DELETE FROM LibraryBooks WHERE name = '" + _nameDLB + "' AND author = '" + _authorDLB + "' AND date = '" + _dateDLB + "';");
            refreshRecords(SB.LBPrefabs, "LibraryBooks");
        }
        else if (_submitScreen == "LBF")
        {
            dbConnectAndExecute("DELETE FROM LibraryBooks WHERE name = '" + _nameDLB + "' AND author = '" + _authorDLB + "' AND date = '" + _dateDLB + "';");
            Destroy(_lbPrefab);
        }
        else if (_submitScreen == "BT")
        {
            dbConnectAndExecute("DELETE FROM BooksTaken WHERE name = '" + _nameDBT_L + "' AND author = '" + _authorDBT_L + "' AND nameOfStudent = '" + _nameOfStudentDBT_L
           + "' AND matricNumber = '" + _matricNoDBT_L + "' AND department = '" + _departmentDBT_L + "' AND date = '" + _dateDBT_L + "';");
            refreshRecords(SB.BTPrefabs, "BooksTaken");
        }
        else if (_submitScreen == "BTF")
        {
            dbConnectAndExecute("DELETE FROM BooksTaken WHERE name = '" + _nameDBT_L + "' AND author = '" + _authorDBT_L + "' AND nameOfStudent = '" + _nameOfStudentDBT_L
          + "' AND matricNumber = '" + _matricNoDBT_L + "' AND department = '" + _departmentDBT_L + "' AND date = '" + _dateDBT_L + "';");
            Destroy(_btPrefab);
        }
        else if (_submitScreen == "BR")
        {
            dbConnectAndExecute("DELETE FROM BooksReturned WHERE name = '" + _nameDBT_L + "' AND author = '" + _authorDBT_L + "' AND nameOfStudent = '" + _nameOfStudentDBT_L
          + "' AND matricNumber = '" + _matricNoDBT_L + "' AND department = '" + _departmentDBT_L + "' AND date = '" + _dateDBT_L + "';");
            refreshRecords(SB.BRPrefabs, "BooksReturned");
        }
        else if (_submitScreen == "BRF")
        {
            dbConnectAndExecute("DELETE FROM BooksReturned WHERE name = '" + _nameDBT_L + "' AND author = '" + _authorDBT_L + "' AND nameOfStudent = '" + _nameOfStudentDBT_L
          + "' AND matricNumber = '" + _matricNoDBT_L + "' AND department = '" + _departmentDBT_L + "' AND date = '" + _dateDBT_L + "';");
            Destroy(_brPrefab);
        }

        _deletePopUp.SetActive(false);
    }

    public void SubmitUpdate()
    {
        if (_submitScreen == "LB" || _submitScreen == "LBF")
        {
            dbConnectAndExecute("UPDATE LibraryBooks SET author = '" + _authorU.text + "', date = '" + _dateU.text
                + "' WHERE name = '" + _bookNameU.text + "'; ");
            _updateRecordLB.SetActive(false);
            if (_submitScreen == "LBF")
            {
                _findInLibraryBooks.SetActive(true);
                SelectBookFromDB("LibraryBooks", _bookNameFindLB.text);
            }
            else if (_submitScreen == "LB")
            {
                _searchLibraryBooks.SetActive(true);
                SB.displayRecords("LibraryBooks");
            }

        }
        else if (_submitScreen == "BT" || _submitScreen == "BTF")
        {
            dbConnectAndExecute("UPDATE BooksTaken SET author = '" + _authorUT_L.text + "', nameOfStudent = '" + _nameOfStudentUT_L.text + "', matricNumber = '" +
                 _matricNoUT_L.text + "', department = '" + _departmentUT_L.text + "', date = '" + _dateUT_L.text + "' WHERE name = '" + _bookNameUT_L.text + "'; ");
            _updateRecordBT_L.SetActive(false);

            if (_submitScreen == "BTF")
            {
                _findInBooksTaken.SetActive(true);
                SelectBookFromDB("BooksTaken", _bookNameFindBT.text);
            }
            else if (_submitScreen == "BT")
            {
                _searchBooksTaken.SetActive(true);
                SB.displayRecords("BooksTaken");
            }
        }
        else if (_submitScreen == "BR" || _submitScreen == "BRF")
        {
            dbConnectAndExecute("UPDATE BooksReturned SET author = '" + _authorUT_L.text + "', nameOfStudent = '" + _nameOfStudentUT_L.text + "', matricNumber = '" +
                 _matricNoUT_L.text + "', department = '" + _departmentUT_L.text + "', date = '" + _dateUT_L.text + "' WHERE name = '" + _bookNameUT_L.text + "'; ");
            _updateRecordBT_L.SetActive(false);

            if (_submitScreen == "BRF")
            {
                _findInBooksReturned.SetActive(true);
                SelectBookFromDB("BooksReturned", _bookNameFindBR.text);
            }
            else if (_submitScreen == "BR")
            {
                _searchBooksReturned.SetActive(true);
                SB.displayRecords("BooksReturned");
            }
        }
    }

    public void SelectBookFromDB(string tableName, string bookName)
    {
        Vector2 pos = new Vector2(12f, -64f);

        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM " + tableName + " WHERE name = '" + bookName + "';";

                SqliteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (tableName == "LibraryBooks")
                    {
                        GameObject recordP = Instantiate(_recordPrefab, pos, Quaternion.identity);
                        recordP.transform.SetParent(_recordFound.transform, false);
                        if (_lbPrefab != null)
                        {
                            Destroy(_lbPrefab);
                        }
                        _lbPrefab = recordP;
                        Text bName = recordP.transform.GetChild(1).GetComponent<Text>();
                        Text author = recordP.transform.GetChild(2).GetComponent<Text>();
                        Text date = recordP.transform.GetChild(3).GetComponent<Text>();
                        Text taken = recordP.transform.GetChild(4).GetComponent<Text>();

                        bName.text = reader["name"].ToString();
                        author.text = reader["author"].ToString();
                        date.text = reader["date"].ToString();
                        taken.text = reader["taken"].ToString();
                    }
                    else
                    {
                        GameObject recordP = Instantiate(_recordPrefabBT_L, pos, Quaternion.identity);
                        recordP.transform.SetParent(_recordFound.transform, false);
                        if (tableName == "BooksTaken")
                        {
                            if (_btPrefab != null)
                            {
                                Destroy(_btPrefab);
                            }
                            _btPrefab = recordP;
                        }
                        else if (tableName == "BooksReturned")
                        {
                            if (_brPrefab != null)
                            {
                                Destroy(_brPrefab);
                            }
                            _brPrefab = recordP;
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
                    }
                }
                else
                {
                    _recordNotFound.SetActive(true);
                }
            }

            connection.Close();
        }
    }

    public void OkRecord()
    {
        _recordNotFound.SetActive(false);
    }

    public void SubmitSearch()
    {
        string bookName;

        if (_submitScreen == "LBF")
        {
            bookName = _bookNameFindLB.text;
            SelectBookFromDB("LibraryBooks", bookName);
        }
        else if (_submitScreen == "BTF")
        {
            bookName = _bookNameFindBT.text;
            SelectBookFromDB("BooksTaken", bookName);
        }
        else if (_submitScreen == "BRF")
        {
            bookName = _bookNameFindBR.text;
            SelectBookFromDB("BooksReturned", bookName);
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBasicApp02.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel() 
        {
            LoadControlFromDb();
            LoadGridFromDb();
        }

        private void LoadControlFromDb()
        {
            //1. DB연결문자열(필수)
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";

            // 2. 사용쿼리
            string query = "SELECT division, names FROM divtbl";

            // Dictionary나 KeyVlauePair 둘다 상관없음
            List<KeyValuePair<string, string>> divisions = new List<KeyValuePair<string, string>>();

            // 3. DB연결, 명령, 리더
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); // 연결문 
                    MySqlCommand cmd = new MySqlCommand(query, conn); // 사용할 쿼리랑 연결문 넣서 cmd로 생성
                    MySqlDataReader reader = cmd.ExecuteReader(); // ExecuteReader는 DB에서 컨트롤엔터로 실행하는것

                    while (reader.Read())
                    {
                        var division = reader.GetString("division");        // 가져올거 넣기 
                        var names = reader.GetString("names");              // 가져올거 넣기 

                        divisions.Add(new KeyValuePair<string, string>(division, names));
                    }
                }
                catch (MySqlException ex)
                {
                    // 나중에.....
                }

            }// conn.Close()자동발생
        }

        private void LoadGridFromDb()
        {
            //1. DB연결문자열(필수)
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;Charset=utf8;";

            // 2. 사용쿼리, 기본쿼리로 먼저 작업 후 
            string query = "SELECT b.Idx, b.Author, b.Division, b.Names, b.ReleaseDate, b.ISBN, b.Price,\r\n       " +
                "d.Names AS dNames\r\n  " +
                "FROM bookstbl AS b, divtbl AS d\r\n " +
                "WHERE b.Division = d.Division\r\n " +
                "ORDER by b.Idx";

            // 3. DB연결, 명령, 리더
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                }
                catch (MySqlException ex)
                {
                    // 나중에.....
                }

            }// conn.Close()자동발생
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

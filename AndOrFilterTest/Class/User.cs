using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AndOrFilterTest.Class
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            var ret = new StringBuilder();

            PropertyInfo[] infoArray = this.GetType().GetProperties();

            // プロパティ情報出力をループで回す
            foreach (PropertyInfo info in infoArray)
            {
                ret.Append($"{info.Name} : {info.GetValue(this, null)} ");
            }

            return ret.ToString();
        }
    }

    public class Users
    {
        private List<User> users;
        public IReadOnlyCollection<User> Data { get => new ReadOnlyCollection<User>(users); }

        public Users()
        {
            CreateUsers();
        }

        private void CreateUsers()
        {
            users = new List<User>()
            {
                new User(){FirstName ="",LastName=""},
                new User(){FirstName ="田中",LastName="太郎"},
                new User(){FirstName ="田中",LastName="次郎"},
                new User(){FirstName ="田中",LastName="三郎"},
                new User(){FirstName ="田中",LastName="四郎"},
                new User(){FirstName ="田中",LastName="五郎"},
                new User(){FirstName ="田中",LastName="六郎"},
                new User(){FirstName ="田中",LastName="七郎"},
                new User(){FirstName ="田中",LastName="八郎"},
                new User(){FirstName ="田中",LastName="九郎"},
                new User(){FirstName ="田中",LastName="十郎"},

                new User(){FirstName ="佐藤",LastName="太郎"},
                new User(){FirstName ="佐藤",LastName="次郎"},
                new User(){FirstName ="佐藤",LastName="三郎"},
                new User(){FirstName ="佐藤",LastName="四郎"},
                new User(){FirstName ="佐藤",LastName="五郎"},
                new User(){FirstName ="佐藤",LastName="六郎"},
                new User(){FirstName ="佐藤",LastName="七郎"},
                new User(){FirstName ="佐藤",LastName="八郎"},
                new User(){FirstName ="佐藤",LastName="九郎"},
                new User(){FirstName ="佐藤",LastName="十郎"},

                new User(){FirstName ="山田",LastName="一子"},
                new User(){FirstName ="山田",LastName="次子"},
                new User(){FirstName ="山田",LastName="三子"},
                new User(){FirstName ="山田",LastName="四子"},
                new User(){FirstName ="山田",LastName="五子"},
                new User(){FirstName ="山田",LastName="六子"},
                new User(){FirstName ="山田",LastName="七子"},
                new User(){FirstName ="山田",LastName="八子"},
                new User(){FirstName ="山田",LastName="九子"},
                new User(){FirstName ="山田",LastName="十子"},


            };

        }

    }
}

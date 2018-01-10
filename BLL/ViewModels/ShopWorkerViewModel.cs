using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModels
{
    public class ShopWorkerAddViewModel
    {
        public bool IsLocked { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }  // зробити умову якщо значення встановлено -1 то юзер створюється без ролі 







    }
}

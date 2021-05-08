using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace FormUI.UserControls
{
    public partial class UC_ManageUser : UserControl
    {
        public UC_ManageUser()
        {
            InitializeComponent();
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            UserSave();
        }
        private void UserSave()
        {
            //burda usercheck yaparken nasıl olacak IDataResult mı yine_
            //usercheck fonksiyonu nerde
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.Add(new User()
            {
                UserName=txtUserName.Text,
                FirstName=txtFirstName.Text,
                LastName=txtLastName.Text,
                Password=txtPassword.Text                
            });



            //if (result.Success != true)
            //{
            
            //}
            //    else
            //    {
            //        MessageBox.Show(result.Message);
            //    }
            //}
        }
    }
}

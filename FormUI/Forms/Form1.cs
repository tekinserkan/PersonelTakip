using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using FormUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginPage();

        }

        private void btnAppExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void LoginPage()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.FormLogin(txtUserName.Text,txtPassword.Text);
                        
            string PersonelName = "";
            if (result.Success == true)
            {
                var user = result.Data;
                PersonelName = user.FirstName + " " + user.LastName;
                using (Form_Dashboard fd = new Form_Dashboard())
                {
                    fd.wellcomePer = PersonelName;
                    fd.Owner = this;
                    fd.ShowDialog();
                    this.Dispose();
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
            
        }
        //******************************
        //var userCheck = userManager.CheckIfUserNameExits(txtUserName.Text);            
        //if (userCheck.Success != true)
        //{
        //    var result = userManager.FormLogin(txtUserName.Text, txtPassword.Text);
        //    string PersonelName = "";
        //    if (result.Success==true)
        //    {
        //        var user = userManager.GetByUserName(txtUserName.Text);
        //        PersonelName = user.Data.FirstName + " " + user.Data.LastName;
        //        using (Form_Dashboard fd = new Form_Dashboard())
        //        {
        //            fd.wellcomePer = PersonelName;
        //            fd.Owner = this;
        //            fd.ShowDialog();
        //            this.Dispose();
        //        }
        //    }else if (result.Success == false)
        //    {
        //        MessageBox.Show(result.Message);
        //    }
        //}
        //else
        //{
        //    MessageBox.Show(userCheck.Message);
        //}

    }
}

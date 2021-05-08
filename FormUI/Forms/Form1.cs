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
            //PersonelTakipContext personelTakipContext = new PersonelTakipContext();
            ////var checkName = personelTakipContext.Users.FirstOrDefault(x => x.UserName == txtUserName.Text);
            ////var personel = personelTakipContext.Users.FirstOrDefault(x => x.UserName == txtUserName.Text && x.Password == txtPassword.Text);
            //if (checkName == null)
            //{
            //    MessageBox.Show("Kayıtlı kullanıcı bulunamadı.");
            //}
            //else if (personel != null)
            //{
            //    string PersonelName = personel.FirstName + " " + personel.Lastname;
            //    using (Form_Dashboard fd = new Form_Dashboard())
            //    {
            //        fd.wellcomePer = PersonelName;
            //        fd.Owner = this;
            //        fd.ShowDialog();
            //        this.Dispose();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Hatalı şifre. Tekrar deneyiniz. ");
            //}
        }

        private void btnAppExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void LoginPage()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var userCheck = userManager.CheckIfUserNameExits(txtUserName.Text);            
            if (userCheck.Success != true)
            {
                var result = userManager.FormLogin(txtUserName.Text, txtPassword.Text);
                //string PersonelName = userManager.Get();

                if (result.Success==true)
                {
                    //PersonelName = userManager.FirstName + " " + personel.Lastname;
                    using (Form_Dashboard fd = new Form_Dashboard())
                    {
                        //fd.wellcomePer = PersonelName;
                        fd.Owner = this;
                        fd.ShowDialog();
                        this.Dispose();
                    }
                }else if (result.Success == false)
                {
                    MessageBox.Show("Hatalı şifre. Tekrar deneyiniz. ");
                }
            }
            else
            {
                MessageBox.Show("Kayıtlı kullanıcı bulunamadı.");
            }
        }
    }
}

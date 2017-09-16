using AuthenticationInASP.NET_Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationInASP.NET_Sample
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //check if user exists first 
            if(DbUtils.CheckIfUserExists(txtUsername.Text) > 0)
            {
                Response.Redirect("AlreadyRegistered.aspx");
            }else
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if ((username != string.Empty) && (password != string.Empty))
                {
                    User user = new User
                    {
                        Username = username,
                        Password = GenerateSHA256String(password)
                    };

                    DbUtils.InsertUser(user);
                    FormsAuthentication.RedirectFromLoginPage(user.Username, true);
                }
            }

        }

        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

    }
}
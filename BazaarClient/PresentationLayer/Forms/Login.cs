using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Forms
{
	public partial class Login : Form
	{
		private IAccountController _accountController;
		private Bazaar bazaar;

		public Login(IAccountController dependency, Bazaar ba)
		{
			_accountController = dependency;
			bazaar = ba;
			ba.FormClosed += new FormClosedEventHandler(Bazaar_FormClosed);
            ba.VisibleChanged += new EventHandler(Bazaar_FormHidden);
			InitializeComponent();
		}

        private void Bazaar_FormHidden(object sender, EventArgs e)
        {
            if (bazaar.Visible == false)
            {
                this.Show();
                Object o = Guid.Empty;
                WinformsSession.dictionary.TryGetValue("LoginToken", out o);
                if (o is Guid)
                    _accountController.Logout((Guid)o);
                else MessageBox.Show("Invalid login!");
            }
        }

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			string username = textBoxUsername.Text;
			string password = textBoxPassword.Text;

			if (username == "")
				MessageBox.Show("Username must not be empty!");
			else if (password.Length < 6)
				MessageBox.Show("Password must be at least 6 characters long!");
			else
			{
				byte[] byteArray = Encoding.UTF8.GetBytes(password);
				MemoryStream stream = new MemoryStream(byteArray);

				SHA384 hasher = new SHA384Managed();
				byte[] hashByteArray = hasher.ComputeHash(stream);

				string hashedPassword = Convert.ToBase64String(hashByteArray);

                try
                {
                    Guid succesfulLogIn = _accountController.Login(username, hashedPassword);

                    if (succesfulLogIn != Guid.Empty)
                    {
                        this.Hide();
                        WinformsSession.dictionary.Add("LoginToken", succesfulLogIn);
                        bazaar.Show();
                    }
                    else MessageBox.Show("Invalid credentials!");
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message);
                }
			}
		}

		private void buttonRegister_Click(object sender, EventArgs e)
		{
			string username = textBoxUsername.Text;
			string password = textBoxPassword.Text;

			if (username == "")
				MessageBox.Show("Username must not be empty!");
			else if (password.Length < 6)
				MessageBox.Show("Password must be at least 6 characters long!");
			else
			{
				byte[] byteArray = Encoding.UTF8.GetBytes(password);
				MemoryStream stream = new MemoryStream(byteArray);

				SHA384 hasher = new SHA384Managed();
				byte[] hashByteArray = hasher.ComputeHash(stream);

				string hashedPassword = Convert.ToBase64String(hashByteArray);

                try
                {
                    Guid succesfulRegister = _accountController.Register(username, hashedPassword);

                    if (succesfulRegister != Guid.Empty)
                    {
                        this.Hide();
                        WinformsSession.dictionary.Add("UserID", succesfulRegister);
                        bazaar.Show();
                    }
                    else MessageBox.Show("Failed to register!");
                }
                catch (WebException ex)
                {
                    MessageBox.Show(ex.Message);
                }
			}
		}

		private void Bazaar_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}

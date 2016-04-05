using PresentationLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
			ba.FormClosed += new FormClosedEventHandler(f_FormClosed);
			InitializeComponent();
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

				int succesfulLogIn = _accountController.Login(username, hashedPassword);

				if (succesfulLogIn > 0)
				{
					this.Hide();
					WinformsSession.dictionary.Add("UserID", succesfulLogIn);
					bazaar.Show();
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

				int succesfulRegister = _accountController.Register(username, hashedPassword);

				if (succesfulRegister > 0)
				{
					this.Hide();
					WinformsSession.dictionary.Add("UserID", succesfulRegister);
					bazaar.Show();
				}
			}
		}

		private void f_FormClosed(object sender, FormClosedEventArgs e)
		{
			this.Close();
		}
	}
}

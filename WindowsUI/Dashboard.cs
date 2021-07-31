using DemoLibrary;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsUI
{
    public partial class Dashboard : Form
    {
        double firstNumber = 0;
        double secondNumber = 0;
        List<PersonModel> people;

        public Dashboard()
        {
            InitializeComponent();

            RebindUserList();
        }

        private void RebindUserList()
        {
            people = DataAccess.GetAllPeople();
            cmbUsers.DataSource = null;
            cmbUsers.DataSource = people;
            cmbUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(false == ValidInputsForCalculation()) return;
            GetUserInputData();
            txtResult.Text = Calculator.Add(firstNumber, secondNumber).ToString();
            CleanupUserInputs();
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (false == ValidInputsForCalculation()) return;
            GetUserInputData();
            txtResult.Text = Calculator.Subtract(firstNumber, secondNumber).ToString();
            CleanupUserInputs();
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (false == ValidInputsForCalculation()) return;
            GetUserInputData();
            txtResult.Text = Calculator.Multiply(firstNumber, secondNumber).ToString();
            CleanupUserInputs();
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (false == ValidInputsForCalculation()) return;
            GetUserInputData();

            if (secondNumber == 0)
            {
                ShowMessage("Cannot divide by Zero...");
                CleanupUserInputs();
                return;
            }
            txtResult.Text = Calculator.Divide(firstNumber, secondNumber).ToString();
            CleanupUserInputs();
        }

        private void CleanupUserInputs()
        {
            txtFirstNumber.Text = "";
            txtSecondNumber.Text = "";
        }

        private void GetUserInputData()
        {
            firstNumber = Convert.ToDouble(txtFirstNumber.Text);
            secondNumber = Convert.ToDouble(txtSecondNumber.Text);
            txtResult.Text = "";
        }

        private bool ValidInputsForCalculation()
        {
            int outInt = 0;

            if (string.IsNullOrEmpty(txtFirstNumber.Text))
            {
                ShowMessage("First Number is Empty");
                return false;
            }
            else if (false == int.TryParse(txtFirstNumber.Text, out outInt))
            { 
                ShowMessage("First Number is not an Integer, Please input integer...");
                return false;
            }
            else if (string.IsNullOrEmpty(txtSecondNumber.Text))
            { 
                ShowMessage("Second Number is Empty");
                return false;
            }
            else if (false == int.TryParse(txtSecondNumber.Text, out outInt))
            { 
                ShowMessage("Second Number is not an Integer, Please input integer...");
                return false;
            }

            return true;
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "Message");
        }

        private void btnAddUsers_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }

        private void AddNewUser()
        {
            if (false == ValidInputsForNewUser()) return;

            DataAccess.AddNewPerson(new PersonModel
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text
            });

            txtFirstName.Text = ""; txtLastName.Text = "";
            RebindUserList();
        }

        private bool ValidInputsForNewUser()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                ShowMessage("First Name is Empty");
                return false;
            }
            else if (string.IsNullOrEmpty(txtLastName.Text))
            {
                ShowMessage("Last Name is Empty");
                return false;
            }
            
            return true;
        }
    }
}

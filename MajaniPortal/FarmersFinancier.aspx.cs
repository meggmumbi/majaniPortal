using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class FarmersFinancier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ValidateFactoryDetail_Click(object sender, EventArgs e)
        {
            var tgrowerNumber = growerNumber.Text.Trim();
            var status = new Config().ObjNav().FnCheckifGrowerNoExist(tgrowerNumber);
            var res = status.Split('*');
            if (res[0] == "danger")
            {
                growerdetails.InnerText = "The Grower Number Provided Already Exist.Kindly use a different Unique Grower No.";

            }
            else
            {
                growerdetails.InnerText = "";
            }
        }
        protected void ValidateIDNumberDetail_Click(object sender, EventArgs e)
        {
            bool error = false;
            var ttxtIdNumber = txtIdNumber.Text.Trim();
            if (ttxtIdNumber.Length > 8)
            {
                error = true;
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
            if (ttxtIdNumber.Length < 6)
            {
                error = true;
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
            if (!error)
            {
                var status = new Config().ObjNav().FnCheckifIdentityNoExist(ttxtIdNumber);
                var res = status.Split('*');
                if (res[0] == "danger")
                {
                    error = true;
                    idNumberPassport.InnerText = "The ID No/Passport Provided Already Exist.Kindly use a different Unique ID No/Passport";
                }
                else
                {
                    idNumberPassport.InnerText = "";
                }
            }
            else
            {
                idNumberPassport.InnerText = "Please Enter the Correct ID No/Passport Value,It must be a Whole number between 6 and 8";
            }
        }

        protected void next_Click(object sender, EventArgs e)
        {
            string str = "";
            bool flag = false;
            string TgrowerName = growerNumber.Text.Trim();
            if (TgrowerName.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Grower Number)";
            }
            string Tname = txtName.Text.Trim();
            if (Tname.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Name)";
            }
            string tFactoryCode = factoryCode.Text.Trim();
            if (tFactoryCode.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Factory Code)";
            }
            string tfactoryName = factoryName.Text.Trim();
            if (tfactoryName.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Factory Name)";
            }
            string tIdNo = txtIdNumber.Text.Trim();
            if (tIdNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Id Number)";
            }
            string tMobileNo = telnumber1.Text.Trim();
            if (tMobileNo.Length < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Mobile Number)";
            }
            int TbstType = Convert.ToInt32(bstType.SelectedValue);
            if (TbstType < 1)
            {
                flag = true;
                str = "Please fill all highlighted fields with *(Business Type)";
            }
            try
            {
                if (flag)
                {
                    feedbackdetails.InnerHtml = "<div class='alert alert-danger'>" + str + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
                }
                else
                {
                    var status = new Config().ObjNav().FnCreateFinancier(TgrowerName, Tname, tFactoryCode, tfactoryName, tIdNo, tMobileNo, TbstType);
                    var res = status.Split('*');
                    if (res[0] == "success")
                    {
                        growerNumber.Text = "";
                        txtName.Text = "";
                        factoryCode.Text = "";
                        factoryName.Text = "";
                        txtIdNumber.Text = "";
                        bstType.SelectedValue = "1";
                        telnumber1.Text = "";
                        feedbackdetails.InnerHtml = "<div class='alert alert-success'>" + res[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    }
                    else
                    {
                        feedbackdetails.InnerHtml = "<div class='alert alert-danger'>The New Client Application Details Could not be Submitted.Kindly Try Again" + res[1] + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

                    }
                }
            }
            catch (Exception ex)
            {
                feedbackdetails.InnerHtml = "<div class='alert alert-danger'>." + ex.Message + " <a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";
            }

        }
    }
}
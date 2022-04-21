using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MajaniPortal
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var nav = Config.ReturnNav();
                var infos = nav.CompanyInformation.ToList();
                foreach (var info in infos)
                {
                    companame.Text = info.Name;
                    ourvission.Text = info.Vision;
                    mission.Text = info.Mission;
                    city.Text = info.City;
                    address.Text = info.Address;
                    phonenumber.Text = info.Phone_No;
                    emailaddress.Text = info.Administrator_Email;
                    mobilenumber.Text = info.Phone_No;
                    addressess.Text = info.Address;
                    cities.Text = info.City;
                    postcodes.Text = info.Post_Code;
                    country.Text = info.Country_Region_Code;
                    phonenumbers.Text = info.Phone_No;
                    emailaddresses.Text = info.Administrator_Email;
                }
            }
        }
    }
}
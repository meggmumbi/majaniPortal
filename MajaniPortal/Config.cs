using MajaniPortal.KYMCodeunit;
using MajaniPortal.Nav;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

namespace MajaniPortal
{
    public class Config
    {
        public static NAV ReturnNav()
        {
            NAV nav = new NAV(new Uri(ConfigurationManager.AppSettings["ODATA_URI"]));
            nav.Credentials = (ICredentials)new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
            return nav;
        }

        public KYM ObjNav()
        {
            KYM kym = new KYM();
            try
            {
                NetworkCredential networkCredential = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"], ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
                kym.Credentials = (ICredentials)networkCredential;
                kym.PreAuthenticate = true;
            }
            catch (Exception ex)
            {
                ex.Data.Clear();
            }
            return kym;
        }

        public static string Receiver() => ConfigurationManager.AppSettings[nameof(Receiver)];

        public static string FilesLocation() => ConfigurationManager.AppSettings[nameof(FilesLocation)];

        public bool IsAllowedExtension(string extension)
        {
            if (!Convert.ToBoolean(ConfigurationManager.AppSettings["CheckFileExtensions"]))
                return true;
            string[] strArray = ConfigurationManager.AppSettings["AllowedFileExtensions"].Split(',');
            extension = extension.Replace('.', ' ');
            extension = extension.Trim();
            extension = extension.ToLower();
            foreach (string str in strArray)
            {
                if (str.Replace('.', ' ').Trim().ToLower() == extension)
                    return true;
            }
            return false;
        }

        public static string GetAlert(string type, string message) => "<div class='alert alert-" + type + "'>" + message + " <a href = '#' class='close' data-dismiss='alert' aria-label='close'>&times;</a></div>";

        public List<string> GetYears()
        {
            List<string> stringList = new List<string>();
            int num = 5;
            int year = DateTime.Now.Year;
            for (int index = 0; index < num; ++index)
                stringList.Add(Convert.ToString(year - index));
            return stringList;
        }

        public static NavExtender.NavXtender navExtender
        {
            get
            {
                var res = new NavExtender.NavXtender();
                try
                {
                    var credential = new NetworkCredential(ConfigurationManager.AppSettings["W_USER"],
                        ConfigurationManager.AppSettings["W_PWD"], ConfigurationManager.AppSettings["DOMAIN"]);
                    res.Credentials = credential;
                    res.PreAuthenticate = true;

                }
                catch (Exception ex)
                {

                    ex.Data.Clear();
                }

                return res;
            }
        }
    }
}

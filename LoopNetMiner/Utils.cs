using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LoopNetMiner
{
    public static class Utils
    {
        public static string PropertyLinkElementsXPath = ".//*[@id='placardSec']/div[2]/div[1]/article/div[1]/section[2]/div[1]/h5/a";
        public static string LogoutUrl = @"http://www.loopnet.com/xNet/MainSite/User/logoff.aspx";
        public static string LoginButtonXPath = "html/body/section/header/nav/div/div[2]/ul/li[5]/a";
        public static string SearchNameTDsXPath = ".//*[@id='form1']/div[5]/div/div/table/tbody/tr/td[2]";
        public static string SearchLinksXPath = ".//*[@id='form1']/div[5]/div/div/table/tbody/tr/td[1]/div/a[1]";
        public static string AllPropertyTypesBtnXPath = "html/body/section/main/section[1]/div/section[1]/div/div/div[2]/div[2]/div[1]/button";
        public static string SelectAllPropertyTypesChkBoxXPath = "html/body/section/main/section[1]/div/section[1]/div/div/div[2]/div[2]/div[1]/div/ul/li[1]/label/input";
        public static string PropertyTypesLIElementsXPath = "html/body/section/main/section[1]/div/section[1]/div/div/div[2]/div[2]/div[1]/div/ul/li";
        public static string PropertyTypeNamesXPath = "html/body/section/main/section[1]/div/section[1]/div/div/div[2]/div[2]/div[1]/div/ul/li/label/text()";
        public static string PropertyTypeChkBoxXPath = "html/body/section/main/section[1]/div/section[1]/div/div/div[2]/div[2]/div[1]/div/ul/li/label/input";
        //public static string PropertyTypes

    }
    public enum PropertyType
    {
        Retail = 0, Industrial = 1, Office = 2, Land = 3
    }
}

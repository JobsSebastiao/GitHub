using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;

/// <summary>
/// Summary description for WsColetor
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WsColetor : System.Web.Services.WebService {

    public WsColetor () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public XmlDocument xmlReturn()
    {

        StringBuilder sbXml = new StringBuilder();
        sbXml.Append("<title>");
        sbXml.Append("<texte>");
        sbXml.Append("vai dar certo!!!");
        sbXml.Append("</texte>");
        sbXml.Append("</title>");
        XmlDocument xXml = new XmlDocument();

        xXml.LoadXml(sbXml.ToString());

        return xXml;

    }

}

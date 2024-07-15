using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumAndroid;

public class LoginScreen : BaseScreen
{
    public AppiumElement TxtCPFouCNPJ => Driver.FindElement(By.XPath("//android.widget.EditText[1]"));

    public AppiumElement TxtSenha => Driver.FindElement(By.XPath("//android.widget.EditText[2]"));

    public AppiumElement BtnLogin => Driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Login\"]"));
    public string idAllowAccessLocation => "com.android.permissioncontroller:id/permission_allow_foreground_only_button";
    public string XPathAllowAccessLocation => "//android.widget.Button[@resource-id=\"com.android.permissioncontroller:id/permission_allow_one_time_button\"]";
    public AppiumElement BtnAllowAccessLocation => Driver.FindElement(By.XPath(XPathAllowAccessLocation));
}

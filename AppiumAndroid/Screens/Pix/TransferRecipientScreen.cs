
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumAndroid;

public class TransferRecipientScreen : BaseScreen
{
    public AppiumElement BtnCPFCNPJ => Driver.FindElement(MobileBy.AccessibilityId("CPF/CNPJ"));

    public AppiumElement TxtChavePix => Driver.FindElement(By.XPath("//android.widget.EditText"));

    public AppiumElement BtnSetaDireita => Driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.widget.Button"));
}

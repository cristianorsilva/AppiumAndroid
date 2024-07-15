using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumAndroid;

public class TransferValuePixScreen : BaseScreen
{
    public AppiumElement TxtValor
    {
        get
        {
            return Driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.widget.EditText"));
        }
    }

    public AppiumElement BtnSetaDireita
    {
        get
        {
            return Driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.widget.Button"));
        }
    }
}

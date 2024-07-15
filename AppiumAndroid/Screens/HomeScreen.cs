using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumAndroid;

public class HomeScreen : BaseScreen
{
    public AppiumElement BtnPix => Driver.FindElement(By.XPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View/android.view.View/android.view.View/android.view.View[4]/android.view.View[1]"));
}

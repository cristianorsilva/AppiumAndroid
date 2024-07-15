using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interactions;

namespace AppiumAndroid;

public class BaseScreen
{

    protected static AndroidDriver Driver
    {
        get
        {
            return BaseTest.Driver;
        }
    }

    //https://github.com/appium/appium-uiautomator2-driver/blob/master/docs/android-mobile-gestures.md
    //https://www.browserstack.com/docs/app-automate/appium/advanced-features/appium-gestures#c_sharp
    //https://github.com/appium/appium-uiautomator2-driver#mobile-gesture-commands
    //https://github.com/AppiumTestDistribution/appium-gestures-plugin/blob/main/README.md?trk=article-ssr-frontend-pulse_x-social-details_comments-action_comment-text

    public void TapElement(AppiumElement AppiumElement)
    {
        
        Driver.ExecuteScript("mobile: clickGesture", new Dictionary<string, object>()
            {
                { "elementId", AppiumElement.Id }
            });
        Thread.Sleep(500);
        
       
        //new TouchAction(Driver).Tap(AppiumElement).Perform();
        //Thread.Sleep(500);

    }

    public void ScrollElement(AppiumElement AppiumElement)
    {
       
        Driver.ExecuteScript("mobile: scrollGesture", new Dictionary<string, object>()
            {
                { "elementId", AppiumElement.Id },
                { "direction", "down" },
                { "percent", "25.0"}
            });
            
         /*
        Driver.ExecuteScript("mobile: swipeGesture", new Dictionary<string, object>()
            {
                { "elementId", AppiumElement.Id },
                { "direction", "down" }
            });
        */
    }

    public bool AguardarElementExistirByContentDesc(string contentDesc, int segundos, Boolean clicarElemento = false)
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(segundos));
        bool elementExists = false;
        string xpath = $"//android.view.View[@content-desc=\"{contentDesc}\"]";
        try
        {
            wait.Until(driver => driver.FindElement(By.XPath(xpath)));
            elementExists = true;

        }
        catch (Exception ex) when (ex is WebDriverTimeoutException || ex is NoSuchElementException || ex is NullReferenceException)
        {
            elementExists = false;
        }

        if (clicarElemento && elementExists)
        {
            Driver.FindElement(By.XPath(xpath)).Click();
        }

        return elementExists;

    }

    public bool AguardarElementExistirById(string id, int segundos, Boolean clicarElemento = false)
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(segundos));
        bool elementExists = false;
        try
        {
            wait.Until(driver => driver.FindElement(By.Id(id)));
            elementExists = true;

        }
        catch (Exception ex) when (ex is WebDriverTimeoutException || ex is NoSuchElementException || ex is NullReferenceException)
        {
            elementExists = false;
        }

        if (clicarElemento && elementExists)
        {
            Driver.FindElement(By.Id(id)).Click();
        }

        return elementExists;

    }

    public bool AguardarElementExistirByXPath(string xpath, int segundos, Boolean clicarElemento = false)
    {
        WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(segundos));
        bool elementExists = false;
        try
        {
            wait.Until(driver => driver.FindElement(By.XPath(xpath)));
            elementExists = true;

        }
        catch (Exception ex) when (ex is WebDriverTimeoutException || ex is NoSuchElementException || ex is NullReferenceException)
        {
            elementExists = false;
        }

        if (clicarElemento && elementExists)
        {
            Driver.FindElement(By.XPath(xpath)).Click();
        }

        return elementExists;

    }

    public string BuscaPropriedadeDoUsuarioPorNomeReferencia(string nomeReferenciaUsuario, UserProperty propriedade)
    {
        return BaseTest.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaUsuario, propriedade);
    }

}

using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumAndroid;

public class PixScreen : BaseScreen
{
    public AppiumElement BtnTransferirComPix
    {
        get
        {

            //Devido ao \r\n a busca falha.
            //return Driver.FindElement(By.XPath("//android.view.View[@content-desc=\"Transferir\r\ncom Pix\"]"));
            //return Driver.FindElement(By.XPath("new UiSelector().description(\"Transferir\r\ncom Pix\")"));

            List<AppiumElement> lstWebElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstWebElements[8].TagName;
            if (!tagName.Equals("Transferir\r\ncom Pix"))
            {
                throw new NotFoundException("Button 'Transferir com Pix' não foi encontrado");
            }
            return lstWebElements[8];


        }
    }

    public AppiumElement BtnMinhasChaves => Driver.FindElement(By.XPath("//android.view.View[@content-desc=\"Minhas Chaves\"]"));
}

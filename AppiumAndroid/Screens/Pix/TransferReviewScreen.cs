using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumAndroid;

public class TransferReviewScreen : BaseScreen
{
    public AppiumElement BtnTransferir
    {
        get
        {
            return Driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Transferir\"]"));        }
    }

    public AppiumElement ValorTransferencia
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstAppiumElements[7].TagName;
            if (!tagName.Equals("Transferindo"))
            {
                throw new NotFoundException("label 'Transferindo' não foi encontrado - utilizado para obter o valor da transferência");
            }
            return lstAppiumElements[8];
        }
    }

    public AppiumElement NomeDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstAppiumElements[7].TagName;
            if (!tagName.Equals("Transferindo"))
            {
                throw new NotFoundException("label 'Transferindo' não foi encontrado - utilizado para obter Nome do destinatário");
            }
            return lstAppiumElements[9];
        }
    }

    public AppiumElement QuandoTransferir
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstAppiumElements[7].TagName;
            if (!tagName.Contains("Transferindo"))
            {
                throw new NotFoundException("label 'Transferindo' não foi encontrado - utilizado para obter quando será realizada a transferência");
            }
            return lstAppiumElements[10];
        }
    }

    public AppiumElement TipoTransferencia
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstAppiumElements[11].TagName;
            if (!tagName.Equals("Tipo de transferência"))
            {
                throw new NotFoundException("label 'Tipo de transferência' não foi encontrado");
            }
            return lstAppiumElements[12];
        }
    }

    public AppiumElement CPFDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstAppiumElements[13].TagName;
            if (!tagName.Equals("CPF"))
            {
                throw new NotFoundException("label 'CPF' não foi encontrado");
            }
            return lstAppiumElements[14];
        }
    }

    public AppiumElement InstituicaoDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstAppiumElements[15].TagName;
            if (!tagName.Equals("Instituição"))
            {
                throw new NotFoundException("label 'Instituição' não foi encontrado");
            }
            return lstAppiumElements[16];
        }
    }

    public AppiumElement AgenciaDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstAppiumElements[17].TagName;
            if (!tagName.Equals("Agência"))
            {
                throw new NotFoundException("label 'Agência' não foi encontrado");
            }
            return lstAppiumElements[18];
        }
    }

    public AppiumElement ContaCorrenteDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            string tagName = lstAppiumElements[19].TagName;
            if (!tagName.Equals("Conta corrente"))
            {
                throw new NotFoundException("label 'Conta corrente' não foi encontrado");
            }
            return lstAppiumElements[20];
        }
    }
}

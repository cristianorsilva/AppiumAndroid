using OpenQA.Selenium;
using OpenQA.Selenium.Appium;

namespace AppiumAndroid;

public class TransferReceiptScreen : BaseScreen
{

    private AppiumElement AncoraValor => Driver.FindElement(By.XPath("//android.view.View[@content-desc=\"Valor\"]"));

    private AppiumElement AncoraOrigem => Driver.FindElement(By.XPath("//android.view.View[@content-desc=\"Origem\"]"));

    private AppiumElement AncoraDestino => Driver.FindElement(By.XPath("//android.view.View[@content-desc=\"Destino\"]"));

    
    public string XpathScrollTelaComprovante => "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.view.View/android.view.View/android.view.View[1]/android.view.View/android.widget.ScrollView";
    public AppiumElement ScrollTelaComprovante => Driver.FindElement(By.XPath(XpathScrollTelaComprovante));

 
    public string XPathComprovanteDeTransferencia => "//android.view.View[@content-desc=\"Comprovante de transferência\"]";

    public AppiumElement ValorTransferencia
    {        
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraValor.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Valor"))
            {
                throw new NotFoundException("label 'Valor' não foi encontrado");
            }
            return lstAppiumElements[index + 1];
        }
    }

    public AppiumElement TipoTransferencia
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraValor.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Valor"))
            {
                throw new NotFoundException("label 'Valor' não foi encontrado - utilizado para obter o Tipo de Transferência");
            }
            return lstAppiumElements[index + 3];
        }
    }



    public AppiumElement NomeDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraDestino.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Destino"))
            {
                throw new NotFoundException("label 'Destino' não foi encontrado - utilizado para obter o Nome do Destinatário");
            }
            return lstAppiumElements[index + 2];
        }
    }

    public AppiumElement CPFDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraDestino.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Destino"))
            {
                throw new NotFoundException("label 'Destino' não foi encontrado - utilizado para obter o CPF do Destinatário");
            }
            return lstAppiumElements[index + 4];
        }
    }

    public AppiumElement InstituicaoDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraDestino.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Destino"))
            {
                throw new NotFoundException("label 'Destino' não foi encontrado - utilizado para obter a Instituição do Destinatário");
            }
            return lstAppiumElements[index + 6];
        }
    }

    public AppiumElement AgenciaDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraDestino.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Destino"))
            {
                throw new NotFoundException("label 'Destino' não foi encontrado - utilizado para obter a Agência do Destinatário");
            }
            return lstAppiumElements[index + 8];
        }
    }

    public AppiumElement ContaDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraDestino.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Destino"))
            {
                throw new NotFoundException("label 'Destino' não foi encontrado - utilizado para obter a Conta Corrente do Destinatário");
            }
            return lstAppiumElements[index + 10];
        }
    }

    public AppiumElement TipoContaDestinatario
    {
        get
        {
            List<AppiumElement> lstAppiumElements = Driver.FindElements(By.XPath("//android.view.View")).ToList();
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraDestino.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Destino"))
            {
                throw new NotFoundException("label 'Destino' não foi encontrado - utilizado para obter o Tipo de Conta do Destinatário");
            }
            return lstAppiumElements[index + 12];
        }
    }





    public AppiumElement NomeRemetente
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraOrigem.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Origem"))
            {
                throw new NotFoundException("label 'Origem' não foi encontrado - utilizado para obter o Nome do Remetente");
            }
            return lstAppiumElements[index + 2];
        }
    }

    public AppiumElement CPFRemetente
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraOrigem.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Origem"))
            {
                throw new NotFoundException("label 'Origem' não foi encontrado - utilizado para obter o CPF do Remetente");
            }
            return lstAppiumElements[index + 4];
        }
    }

    public AppiumElement InstituicaoRemetente
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraOrigem.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Origem"))
            {
                throw new NotFoundException("label 'Origem' não foi encontrado - utilizado para obter a Instituição do Remetente");
            }
            return lstAppiumElements[index + 6];
        }
    }

    public AppiumElement AgenciaRemetente
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraOrigem.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Origem"))
            {
                throw new NotFoundException("label 'Origem' não foi encontrado - utilizado para obter a Agência do Remetente");
            }
            return lstAppiumElements[index + 8];
        }
    }

    public AppiumElement ContaRemetente
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraOrigem.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Origem"))
            {
                throw new NotFoundException("label 'Origem' não foi encontrado - utilizado para obter a Conta Corrente do Remetente");
            }
            return lstAppiumElements[index + 10];
        }
    }

    public AppiumElement TipoContaRemetente
    {
        get
        {
            List<AppiumElement> lstAppiumElements = [.. Driver.FindElements(By.XPath("//android.view.View"))];
            int index = lstAppiumElements.FindIndex(e => e.Id == AncoraOrigem.Id);
            string tagName = lstAppiumElements[index].TagName;
            if (!tagName.Equals("Origem"))
            {
                throw new NotFoundException("label 'Origem' não foi encontrado - utilizado para obter o Tipo de Conta do Remetente");
            }
            return lstAppiumElements[index + 12];
        }
    }
}

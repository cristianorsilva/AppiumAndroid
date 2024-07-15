using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumAndroid;

public class BaseTest
{

    private static Users? users;
    private static AppiumOptions? appiumOptions;
    private static AndroidDriver? driver;

    private static string pathReportVideos;

    [OneTimeSetUp]
    public static void OneTimeSetUp()
    {
        string testEnvironment = TestContext.Parameters["testEnvironment"]!;
        if (testEnvironment == "DEV")
        {
            users = ReadUsersFromJson(Environment.CurrentDirectory + @"\Users_dev.json");
        }
        else if (testEnvironment == "PROD")
        {
            users = ReadUsersFromJson(Environment.CurrentDirectory + @"\Users_prod.json");
        }

        string myDocumentsPaths = TestContext.Parameters["evidencesRootDirectory"]!;
        string directoryDateName = GenerateDateName();
        string? displayName = TestContext.CurrentContext.Test.DisplayName;        
        pathReportVideos = $@"{myDocumentsPaths}\Run_" + directoryDateName + $@"\{displayName}\";
        Directory.CreateDirectory(pathReportVideos);

    }

    [SetUp]
    public void Setup()
    {
        bool.TryParse(TestContext.Parameters["isTestBS"]!, out bool isTestBS);
        if (isTestBS){
            SetAppiumOptionsAndroidBrowserStack();
        }else{
            SetAppiumOptionsAndroid();
            StartVideoRecording_Android();
        }        
    }

    [TearDown]
    public void TearDown()
    {
        //https://www.browserstack.com/docs/app-automate/appium/set-up-tests/mark-tests-as-pass-fail
        //https://www.browserstack.com/docs/app-automate/appium/js-executors

        bool.TryParse(TestContext.Parameters["isTestBS"]!, out bool isTestBS);

        if (isTestBS)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionName\", \"arguments\": {\"name\":\" "+ TestContext.CurrentContext.Test.FullName +" \"}}");

            if (TestContext.CurrentContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" PASSED \"}}");
            }
            else
            {
                string mensagem = TestContext.CurrentContext.Result.Message.Replace("\n", "").Replace("\t", "").Replace("\b", "").Replace("\"", "'").Replace("\r", "").ToString();
                List<string> lstMensagens = SplitByLength(mensagem, 250);
                foreach (string msg in lstMensagens){
                    ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"annotate\", \"arguments\": {\"data\":\"" + msg + "\", \"level\": \"error\"}}");
                }                
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" FAILED \"}}");
                
            }
        }
        else
        {
            StopVideoRecording_Android(TestContext.CurrentContext.Test.Name);
        }
        driver.Dispose();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {

    }

    public static AndroidDriver Driver => driver;

    private static void SetAppiumOptionsAndroid()
    {
        string udid = TestContext.Parameters["udid"]!;
        string platformName = TestContext.Parameters["platformName"]!;
        string appActivity = TestContext.Parameters["appActivity"]!;
        string appPackage = TestContext.Parameters["appPackage"]!;
        string ipAddress = TestContext.Parameters["ipAddress"]!;
        string port = TestContext.Parameters["port"]!;
        string appPath = TestContext.Parameters["appPath"]!;
        string automationName = TestContext.Parameters["automationName"]!;
        string noReset = TestContext.Parameters["noReset"]!;
        string fullReset = TestContext.Parameters["fullReset"]!;
        string implicitWait = TestContext.Parameters["implicitWait"]!;

        appiumOptions = new AppiumOptions()
        {
            PlatformName = platformName,
            AutomationName = automationName,
            App = appPath,
        };
        appiumOptions.AddAdditionalAppiumOption("appium:udid", udid);
        appiumOptions.AddAdditionalAppiumOption("appium:appPackage", appPackage);
        appiumOptions.AddAdditionalAppiumOption("appium:appActivity", appActivity);
        appiumOptions.AddAdditionalAppiumOption("noReset", noReset);
        appiumOptions.AddAdditionalAppiumOption("fullReset", fullReset);

        string address = $"http://{ipAddress}:{port}/";
        Uri url = new Uri(address);

        driver = new AndroidDriver(url, appiumOptions);
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Int32.Parse(implicitWait));

        /* Exemplo Device Físico
            {
            "appium:platformName": "Android",
            "appium:appActivity": "a.foradacaixa.foradacaixaa.MainActivity",
            "appium:appPackage": "a.foradacaixa.foradacaixaa",
            "appium:deviceName": "moto g14",
            "appium:automationName": "uiautomator2"
            }
        */
    }
    private static void SetAppiumOptionsAndroidBrowserStack()
    {
        //https://www.browserstack.com/app-automate/capabilities?tag=w3c
        //https://www.browserstack.com/docs/automate/selenium/set-name-and-status-of-test#c_sharp
        //https://www.browserstack.com/docs/automate/selenium/get-session-id#c_sharp

        string usernameBrowserStack = TestContext.Parameters["usernameBrowserStack"]!;
        string accessKeyBrowserStack = TestContext.Parameters["accessKeyBrowserStack"]!;
        string appiumVersionBrowserStack = TestContext.Parameters["appiumVersionBrowserStack"]!;
        string appBrowserStack = TestContext.Parameters["appBrowserStack"]!;
        string platformVersionBrowserStack = TestContext.Parameters["platformVersionBrowserStack"]!;
        string deviceNameBrowserStack = TestContext.Parameters["deviceNameBrowserStack"]!;
        string automationNameBrowserStack = TestContext.Parameters["automationNameBrowserStack"]!;
        string platformNameBrowserStack = TestContext.Parameters["platformNameBrowserStack"]!;
        string uriBrowserStack = TestContext.Parameters["uriBrowserStack"]!;
        string implicitWait = TestContext.Parameters["implicitWait"]!;
        string projectBrowserStack = TestContext.Parameters["projectBrowserStack"]!;
        string buildBrowserStack = TestContext.Parameters["buildBrowserStack"]!;
        string timeOutBrowserStack = TestContext.Parameters["timeOutBrowserStack"]!;

        AppiumOptions appiumOptions = new AppiumOptions();
        Dictionary<string, object> browserstackOptions = new Dictionary<string, object>
        {
            { "userName", usernameBrowserStack },
            { "accessKey", accessKeyBrowserStack },
            { "appiumVersion", appiumVersionBrowserStack }
            
        };
        appiumOptions.AddAdditionalAppiumOption("bstack:options", browserstackOptions);
        appiumOptions.PlatformVersion = platformVersionBrowserStack;
        appiumOptions.DeviceName = deviceNameBrowserStack;
        appiumOptions.App = appBrowserStack;
        appiumOptions.AutomationName = automationNameBrowserStack;
        appiumOptions.PlatformName = platformNameBrowserStack;
        appiumOptions.AddAdditionalAppiumOption("project", projectBrowserStack);
        appiumOptions.AddAdditionalAppiumOption("build", buildBrowserStack);
        appiumOptions.AddAdditionalAppiumOption("browserstack.idleTimeout", timeOutBrowserStack);

        driver = new AndroidDriver(new Uri(uriBrowserStack), appiumOptions);
        
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Int32.Parse(implicitWait));
    }

    private static List<string> SplitByLength(string stringToSplit, int lenght){
        List<string> splitByLength = new List<string>();
        if (stringToSplit.Length > lenght)
        {
            int numeroDeSubstrings = stringToSplit.Length / lenght;
            int restoDivisao = stringToSplit.Length % lenght;
            for (int i = 0; i < numeroDeSubstrings; i++)
            {
                splitByLength.Add(stringToSplit.Substring(i * lenght, 50));
            }
            if (restoDivisao > 0)
            {
                splitByLength.Add(stringToSplit[(numeroDeSubstrings * lenght)..]);
            }
            //0 - 0, 49
            //1 - 50, 99
            //2 - 100, 149 

            return splitByLength;
        }
        else
        {
            splitByLength.Add(stringToSplit);
            return splitByLength;
        }
    }
    
    #region Video recording management
    private static void StartVideoRecording_Android()
    {
        Driver.StartRecordingScreen(AndroidStartScreenRecordingOptions
            .GetAndroidStartScreenRecordingOptions()
            .WithBitRate(4000000));
    }
    private static void StopVideoRecording_Android(string testname)
    {
        string base64String = Driver.StopRecordingScreen();
        byte[] data = Convert.FromBase64String(base64String);

        string videoName = testname;
        string videoPathAbsolute = pathReportVideos + @"\" + videoName + ".mp4";

        File.WriteAllBytes(videoPathAbsolute, data);

    }
    private static string GenerateDateName()
    {
        return DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss").Replace(" ", "_").Replace(":", "_");
    }
    #endregion

    #region Data test management
    public static Users Usuarios => users;

    public static string BuscaPropriedadeDoUsuarioPorNomeReferencia(string nomeReferenciaUsuario, UserProperty propriedade)
    {
        switch (propriedade)
        {
            case UserProperty.Referencia:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.Referencia).First<string>();
            case UserProperty.NomeCompleto:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.NomeCompleto).First<string>();
            case UserProperty.NomeAbreviado:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.NomeAbreviado).First<string>();
            case UserProperty.CPF_CNPJ:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.CPF_CNPJ).First<string>();
            case UserProperty.Banco:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.Banco).First<string>();
            case UserProperty.Agencia:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.Agencia).First<string>();
            case UserProperty.Conta:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.Conta).First<string>();
            case UserProperty.TipoConta:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.TipoConta).First<string>();
            case UserProperty.Senha6Digitos:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.Senha6digitos).First<string>();
            case UserProperty.Senha4Digitos:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.Senha4digitos).First<string>();
            case UserProperty.Tarifa:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.Tarifa).First<string>();
            case UserProperty.Telefone:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.Telefone).First<string>();
            case UserProperty.ValorTransferencia:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.ValorTransferencia).First<string>();
            case UserProperty.CPF_Protegido:
                return Usuarios.User.Where(u => u.Referencia == nomeReferenciaUsuario).Select(u => u.CPF_protegido).First<string>();
            default:
                return null;
        }
    }

    private static Users ReadUsersFromJson(string filePath)
    {
        string jsonString = File.ReadAllText(filePath, Encoding.UTF8);

        Users users = Newtonsoft.Json.JsonConvert.DeserializeObject<Users>(jsonString)!;
        return users;
    }

    #endregion
}

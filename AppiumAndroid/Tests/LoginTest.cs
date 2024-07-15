namespace AppiumAndroid;

public class LoginTest : BaseTest
{
    LoginSteps loginSteps = new();
    HomeSteps homeSteps = new();
    [Test, Order(2)]
    public void EfetuarLoginSucesso()
    {
         loginSteps.InformarUsuarioSenha("USUÁRIO A");
        loginSteps.EfetuarLogin();
        loginSteps.PermitirLocalizacao();
        homeSteps.VerificarLoginSucesso("USUÁRIO A");
    }

    [Test, Order(1)]
    public void UsuarioInvalido()
    {
        loginSteps.InformarUsuarioSenha("USUÁRIO LOGIN INVÁLIDO");
        loginSteps.EfetuarLogin();
        loginSteps.VerificarMensagem("Usuário ou senha inválidos");

    }
}

//https://www.browserstack.com/docs/app-automate/appium/set-up-tests/mark-tests-as-pass-fail

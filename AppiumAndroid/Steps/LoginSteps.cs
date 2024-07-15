using FluentAssertions;

namespace AppiumAndroid;

public class LoginSteps
{
    private LoginScreen loginScreen = new LoginScreen();
    private HomeScreen homeScreen = new HomeScreen();

    public void InformarUsuarioSenha(string nomeReferenciaUsuario)
    {
        string cpfUsuario = loginScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaUsuario, UserProperty.CPF_CNPJ);
        string senhaUsuario = loginScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaUsuario, UserProperty.Senha6Digitos);
        loginScreen.TapElement(loginScreen.TxtCPFouCNPJ);
        loginScreen.TxtCPFouCNPJ.SendKeys(cpfUsuario);
        loginScreen.TapElement(loginScreen.TxtSenha);
        loginScreen.TxtSenha.SendKeys(senhaUsuario);
    }

    public void EfetuarLogin()
    {
        loginScreen.TapElement(loginScreen.BtnLogin);
    }

    public void VerificarMensagem(string mensagem)
    {
        bool exibiuMensagem = homeScreen.AguardarElementExistirByContentDesc(mensagem, 5);
        exibiuMensagem.Should().BeTrue();

    }

    public void PermitirLocalizacao()
    {
        loginScreen.AguardarElementExistirByXPath(loginScreen.XPathAllowAccessLocation, 5, true);
    }
}

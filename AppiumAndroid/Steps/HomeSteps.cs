using FluentAssertions;

namespace AppiumAndroid;

public class HomeSteps
{
    private HomeScreen homeScreen = new HomeScreen();

    public void VerificarLoginSucesso(string nomeReferenciaUsuario)
    {
        string nomeCompleto = homeScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaUsuario, UserProperty.NomeCompleto);
        string primeiroNome = nomeCompleto.Split()[0];
        string contentDesc = $"Olá, {primeiroNome}";

        bool loginSucesso = homeScreen.AguardarElementExistirByContentDesc(contentDesc, 5);

        loginSucesso.Should().BeTrue();
    }

    public void SelecionarPix()
    {
        homeScreen.TapElement(homeScreen.BtnPix);
    }
}
using FluentAssertions;
using FluentAssertions.Execution;

namespace AppiumAndroid;

public class TransferReviewSteps
{
    TransferReviewScreen transferReviewScreen = new TransferReviewScreen();
    public void ValidarDadosTransferencia(string nomeReferenciaRemetente, string nomeReferenciaDestinatario)
    {
        //buscar do json todas as propriedades a serem validadas
        string valorTransferenciaEsperado = transferReviewScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaRemetente, UserProperty.ValorTransferencia);
        string nomeCompletoDestinatarioEsperado = transferReviewScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.NomeCompleto);
        string quandoTransferirEsperado = "Quando\r\nAgora";
        string tipoTransferenciaEsperado = "Pix";
        string cpfDestinatarioEsperado = transferReviewScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.CPF_Protegido);
        string instituicaoDestinatarioEsperado = transferReviewScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.Banco);
        string agenciaDestinatarioEsperado = transferReviewScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.Agencia);
        string contaCorrenteDestinatarioEsperado = transferReviewScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.Conta);


        //obtém os valores exibidos em tela
        string valorTransferencia = transferReviewScreen.ValorTransferencia.TagName;
        string nomeDestinatario = transferReviewScreen.NomeDestinatario.TagName;
        string quandoTransferir = transferReviewScreen.QuandoTransferir.TagName;
        string tipoTransferencia = transferReviewScreen.TipoTransferencia.TagName;
        string cpfDestinatario = transferReviewScreen.CPFDestinatario.TagName;
        string instituicaoDestinatario = transferReviewScreen.InstituicaoDestinatario.TagName;
        string agenciaDestinatario = transferReviewScreen.AgenciaDestinatario.TagName;
        string contaCorrenteDestinatario = transferReviewScreen.ContaCorrenteDestinatario.TagName;

        //valida os dados
        using (new AssertionScope())
        {
            valorTransferencia.Should().Be(valorTransferenciaEsperado);
            nomeDestinatario.Should().Be(nomeCompletoDestinatarioEsperado);
            quandoTransferir.Should().Be(quandoTransferirEsperado);
            tipoTransferencia.Should().Be(tipoTransferenciaEsperado);
            cpfDestinatario.Should().Be(cpfDestinatarioEsperado);
            instituicaoDestinatario.Should().Be(instituicaoDestinatarioEsperado);
            agenciaDestinatario.Should().Be(agenciaDestinatarioEsperado);
            contaCorrenteDestinatario.Should().Be(contaCorrenteDestinatarioEsperado);
        }
    }

    public void TapTransferir()
    {
        transferReviewScreen.BtnTransferir.Click();
        //transferReviewScreen.TapElement(transferReviewScreen.BtnTransferir); //não funciona para o botão: //Tap at [x=540.0, y=2052.0] has failed
    }
}

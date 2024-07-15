using FluentAssertions;
using FluentAssertions.Execution;

namespace AppiumAndroid;

public class TransferReceiptSteps
{
    TransferReceiptScreen transferReceiptScreen = new TransferReceiptScreen();

    public void AguardarComprovanteNaTela()
    {
        transferReceiptScreen.AguardarElementExistirByXPath(transferReceiptScreen.XPathComprovanteDeTransferencia, 10, false);
    }

    public void ArrastarComprovanteParaCima()
    {
        bool existe = transferReceiptScreen.AguardarElementExistirByXPath(transferReceiptScreen.XpathScrollTelaComprovante, 1, false);
        if (existe)
        {
            transferReceiptScreen.ScrollElement(transferReceiptScreen.ScrollTelaComprovante);
        }
    }

    public void ValidarDadosComprovante(string nomeReferenciaRemetente, string nomeReferenciaDestinatario)
    {
        //buscar do json todas as propriedades a serem validadas
        string valorTransferenciaEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaRemetente, UserProperty.ValorTransferencia);
        //string quandoTransferirEsperado = "Quando\r\nAgora";
        string tipoTransferenciaEsperado = "Pix";


        //Dados esperados do remetente
        string nomeCompletoRemetenteEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaRemetente, UserProperty.NomeCompleto);
        string cpfRemetenteEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaRemetente, UserProperty.CPF_CNPJ);
        string instituicaoRemetenteEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaRemetente, UserProperty.Banco);
        string agenciaRemetenteEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaRemetente, UserProperty.Agencia);
        string contaRemetenteEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaRemetente, UserProperty.Conta);
        string tipoContaRemetenteEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaRemetente, UserProperty.TipoConta);


        //Dados esperados do destinatário
        string nomeCompletoDestinatarioEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.NomeCompleto);
        string cpfDestinatarioEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.CPF_CNPJ);
        string instituicaoDestinatarioEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.Banco);
        string agenciaDestinatarioEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.Agencia);
        string contaDestinatarioEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.Conta);
        string tipoContaDestinatarioEsperado = transferReceiptScreen.BuscaPropriedadeDoUsuarioPorNomeReferencia(nomeReferenciaDestinatario, UserProperty.TipoConta);


        //obtém os valores exibidos em tela
        string valorTransferencia = transferReceiptScreen.ValorTransferencia.TagName;
        string tipoTransferencia = transferReceiptScreen.TipoTransferencia.TagName;

        //valores exibidos em tela para o destinatário
        string nomeDestinatario = transferReceiptScreen.NomeDestinatario.TagName;
        string cpfDestinatario = transferReceiptScreen.CPFDestinatario.TagName;
        string instituicaoDestinatario = transferReceiptScreen.InstituicaoDestinatario.TagName;
        string agenciaDestinatario = transferReceiptScreen.AgenciaDestinatario.TagName;
        string contaDestinatario = transferReceiptScreen.ContaDestinatario.TagName;
        string tipoContaDestinatario = transferReceiptScreen.TipoContaDestinatario.TagName;

        ArrastarComprovanteParaCima();

        //valores exibidos em tela para o remetente
        string nomeRemetente = transferReceiptScreen.NomeRemetente.TagName;
        string cpfRemetente = transferReceiptScreen.CPFRemetente.TagName;
        string instituicaoRemetente = transferReceiptScreen.InstituicaoRemetente.TagName;
        string agenciaRemetente = transferReceiptScreen.AgenciaRemetente.TagName;
        string contaRemetente = transferReceiptScreen.ContaRemetente.TagName;
        string tipoContaRemetente = transferReceiptScreen.TipoContaRemetente.TagName;



        //valida os dados
        using (new AssertionScope())
        {
            valorTransferencia.Should().Be(valorTransferenciaEsperado);
            tipoTransferencia.Should().Be(tipoTransferenciaEsperado);

            //dados remetente
            nomeRemetente.Should().Be(nomeCompletoRemetenteEsperado);
            cpfRemetente.Should().Be(cpfRemetenteEsperado);
            instituicaoRemetente.Should().Be(instituicaoRemetenteEsperado);
            agenciaRemetente.Should().Be(agenciaRemetenteEsperado);
            contaRemetente.Should().Be(contaRemetenteEsperado);
            tipoContaRemetente.Should().Be(tipoContaRemetenteEsperado);


            //dados destinatario
            nomeDestinatario.Should().Be(nomeCompletoDestinatarioEsperado);
            cpfDestinatario.Should().Be(cpfDestinatarioEsperado);
            instituicaoDestinatario.Should().Be(instituicaoDestinatarioEsperado);
            agenciaDestinatario.Should().Be(agenciaDestinatarioEsperado);
            contaDestinatario.Should().Be(contaDestinatarioEsperado);
            tipoContaDestinatario.Should().Be(tipoContaDestinatarioEsperado);
        }

    }

}

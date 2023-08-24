﻿#pragma warning disable CS1591

#if INTEROP
using System.Runtime.InteropServices;
#endif
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unimake.Business.DFe.Servicos;

namespace Unimake.Business.DFe.Xml.EFDReinf
{
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.Reinf2010")]
    [ComVisible(true)]
#endif

    [Serializable()]
    [XmlRoot("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evtTomadorServicos/v2_01_02", IsNullable = false)]
    public class Reinf2010 : XMLBase
    {
        [XmlElement("evtServTom")]
        public EvtServTom EvtServTom { get; set; }

        [XmlElement(ElementName = "Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
        public Signature Signature { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.EvtServTom")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class EvtServTom
    {
        [XmlElement("ideEvento")]
        public Reinf2010IdeEvento IdeEvento { get; set; }

        [XmlElement("ideContri")]
        public IdeContri IdeContri { get; set; }

        [XmlElement("infoServTom")]
        public InfoServTom InfoServTom { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.Reinf2010IdeEvento")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class Reinf2010IdeEvento
    {
        [XmlElement("indRetif")]
        public IndicativoRetificacao IndRetif { get; set; }

        /// <summary>
        /// Validação: O preenchimento é obrigatório se {indRetif} = [2]. Deve ser um recibo de entrega válido, correspondente ao arquivo objeto da retificação.
        /// </summary>
        [XmlElement("nrRecibo")]
        public string NrRecibo { get; set; }

        /// <summary>
        /// Informar o ano/mês de referência das informações no formato AAAA-MM. Validação: Deve ser um ano/mês válido para o qual haja informações do contribuinte encaminhadas através do evento R-1000.
        /// </summary>
        [XmlElement("perApur")]
        public string PerApur { get; set; }

        [XmlElement("tpAmb")]
        public TipoAmbiente TpAmb { get; set; }

        [XmlElement("procEmi")]
        public ProcessoEmissaoReinf ProcEmi { get; set; }

        [XmlElement("verProc")]
        public string VerProc { get; set; }

        #region ShouldSerialize

        public bool ShouldSereializeNrRecibo() => !string.IsNullOrEmpty(NrRecibo);

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.InfoServTom")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class InfoServTom
    {
        [XmlElement("ideEstabObra")]
        public IdeEstabObra IdeEstabObra { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.IdeEstabObra")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class IdeEstabObra
    {
        [XmlElement("tpInscEstab")]
        public TipoInscricaoEstabelecimento tpInscEstab { get; set; }

        /// <summary>
        /// Validação: A inscrição informada deve ser compatível com o {tpInscEstab}.
        /// Se {indObra} = [0], o número informado deve ser um CNPJ.Se {indObra} for igual a[1, 2] o número informado deve ser um CNO.
        /// </summary>
        [XmlElement("nrInscEstab")]
        public string NrInscEstab { get; set; }

        [XmlElement("indObra")]
        public IndicativoObra IndObra { get; set; }

        [XmlElement("idePrestServ")]
        public IdePrestServ IdePrestServ { get; set; }
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.IdePrestServ")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class IdePrestServ
    {
        /// <summary>
        /// Deve ser um CNPJ válido. Não pode pertencer ao declarante. 
        /// Se {indObra} for igual a [1] (empreitada total) o CNPJ do prestador terá que ser o proprietário do CNO informado no campo {nrInscEstab}.
        /// </summary>
        [XmlElement("cnpjPrestador")]
        public string CnpjPrestador { get; set; }

        /// <summary>
        /// Deve corresponder à soma dos valores informados no {vlrBruto} dos registros vinculados.
        /// </summary>
        [XmlElement("vlrTotalBruto")]
        public string VlrTotalBruto { get; set; }

        /// <summary>
        /// Preencher com a soma da base de cálculo da retenção da contribuição previdenciária das notas fiscais emitidas para o contratante.
        /// Deve corresponder à soma dos valores informados no campo {vlrBaseRet} dos registros vinculados.
        /// </summary>
        [XmlElement("vlrTotalRet")]
        public string VlrTotalBaseRet { get; set; }

        /// <summary>
        /// Soma do valor da retenção sobre o valor das notas fiscais de serviço emitidas para o contratante.
        /// Deve corresponder à soma dos valores informados no campo {vlrRetencao}, subtraído da soma dos valores informados no campo {vlrRetSub} dos registros vinculados.
        /// </summary>
        [XmlElement("vlrTotalRetPrinc")]
        public string VlrTotalRetPrinc { get; set; }

        /// <summary>
        /// Deve corresponder à soma dos valores informados no campo {vlrAdicional} dos registros vinculados.
        /// </summary>
        [XmlElement("vlrTotalRetAdic")]
        public string VlrTotalRetAdic { get; set; }

        /// <summary>
        /// Valor da retenção principal que deixou de ser efetuada pelo contratante ou que foi depositada em juízo em decorrência de decisão judicial.
        /// Deve corresponder à soma dos valores informados no campo {vlrNRetPrinc} dos registros vinculados.
        /// </summary>
        [XmlElement("vlrTotalNRetPrinc")]
        public string VlrTotalNRetPrinc { get; set; }

        /// <summary>
        /// Valor da retenção adicional que deixou de ser efetuada pelo contratante ou que foi depositada em juízo em decorrência de decisão judicial.
        /// </summary>
        [XmlElement("vlrTotalNRetAdic")]
        public string VlrTotalNRetAdic { get; set; }

        [XmlElement("indCPRB")]
        public IndicativoCPRB IndCPRB { get; set; }

        [XmlElement("nfs")]
        public List<Nfs> Nfs { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddNfs(Nfs item)
        {
            if (Nfs == null)
            {
                Nfs = new List<Nfs>();
            }

            Nfs.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista Nfs (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da Nfs</returns>
        public Nfs GetNfs(int index)
        {
            if ((Nfs?.Count ?? 0) == 0)
            {
                return default;
            };

            return Nfs[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista Nfs
        /// </summary>
        public int GetNfsCount => (Nfs != null ? Nfs.Count : 0);

#endif

        [XmlElement("infoProcRetPr")]
        public List<InfoProcRetPr> InfoProcRetPr { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddInfoProcRetPr(InfoProcRetPr item)
        {
            if (InfoProcRetPr == null)
            {
                InfoProcRetPr = new List<InfoProcRetPr>();
            }

            InfoProcRetPr.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista InfoProcRetPr (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da InfoProcRetPr</returns>
        public InfoProcRetPr GetInfoProcRetPr(int index)
        {
            if ((InfoProcRetPr?.Count ?? 0) == 0)
            {
                return default;
            };

            return InfoProcRetPr[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista InfoProcRetPr
        /// </summary>
        public int GetInfoProcRetPrCount => (InfoProcRetPr != null ? InfoProcRetPr.Count : 0);

#endif

        [XmlElement("infoProcRetAd")]
        public List<InfoProcRetAd> InfoProcRetAd { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddInfoProcRetAd(InfoProcRetAd item)
        {
            if (InfoProcRetAd == null)
            {
                InfoProcRetAd = new List<InfoProcRetAd>();
            }

            InfoProcRetAd.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista InfoProcRetAd (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da InfoProcRetAd</returns>
        public InfoProcRetAd GetInfoProcRetAd(int index)
        {
            if ((InfoProcRetAd?.Count ?? 0) == 0)
            {
                return default;
            };

            return InfoProcRetAd[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista InfoProcRetAd
        /// </summary>
        public int GetInfoProcRetAdCount => (InfoProcRetAd != null ? InfoProcRetAd.Count : 0);

#endif

        #region ShouldSerialize

        public bool ShouldSerializeVlrTotalRetAdic() => !string.IsNullOrEmpty(VlrTotalRetAdic);

        public bool ShouldSerializeVlrTotalNRetPrinc() => !string.IsNullOrEmpty(VlrTotalNRetPrinc);

        public bool ShouldSerializeVlrTotalNRetAdic() => !string.IsNullOrEmpty(VlrTotalNRetAdic);

        
        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.Nfs")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class Nfs
    {
        /// <summary>
        /// Informar o número de série da nota fiscal/fatura ou do Recibo Provisório de Serviço - RPS ou de outro documento fiscal válido.Preencher com 0 (zero) caso não exista número de série.
        /// </summary>
        [XmlElement("serie")]
        public string Serie { get; set; }

        /// <summary>
        /// Número da nota fiscal/fatura ou outro documento fiscal válido, como ReciboProvisório de Serviço - RPS, CT-e, entre outros.
        /// </summary>
        [XmlElement("numDocto")]
        public string NumDocto { get; set; }

        /// <summary>
        /// Data de emissão da nota fiscal/fatura ou do Recibo Provisório de Serviço - RPS ou de outro documento fiscal válido.
        /// O mês/ano informado deve ser igual ao mês/ano indicado no registro de abertura do arquivo.
        /// </summary>
        [XmlElement("dtEmissaoNF")]
        public string DtEmissaoNF { get; set; }

        /// <summary>
        /// Preencher com o valor bruto da nota fiscal ou do Recibo Provisório de Serviço - RPS ou de outro documento fiscal válido
        /// Validação: Deve ser maior que zero.
        /// </summary>
        [XmlElement("vlrBruto")]
        public string VlrBruto { get; set; }

        /// <summary>
        /// Observações.
        /// </summary>
        [XmlElement("obs")]
        public string Obs { get; set; }

        /// <summary>
        /// Informações sobre os tipos de serviços constantes da nota fiscal.
        /// </summary>
        [XmlElement("infoTpServ")]
        public List<InfoTpServ> InfoTpServ { get; set; }

#if INTEROP

        /// <summary>
        /// Adicionar novo elemento a lista
        /// </summary>
        /// <param name="item">Elemento</param>
        public void AddInfoTpServ(InfoTpServ item)
        {
            if (InfoTpServ == null)
            {
                InfoTpServ = new List<InfoTpServ>();
            }

            InfoTpServ.Add(item);
        }

        /// <summary>
        /// Retorna o elemento da lista InfoTpServ (Utilizado para linguagens diferentes do CSharp que não conseguem pegar o conteúdo da lista)
        /// </summary>
        /// <param name="index">Índice da lista a ser retornado (Começa com 0 (zero))</param>
        /// <returns>Conteúdo do index passado por parâmetro da InfoTpServ</returns>
        public InfoTpServ GetInfoTpServ(int index)
        {
            if ((InfoTpServ?.Count ?? 0) == 0)
            {
                return default;
            };

            return InfoTpServ[index];
        }

        /// <summary>
        /// Retorna a quantidade de elementos existentes na lista InfoTpServ
        /// </summary>
        public int GetInfoTpServCount => (InfoTpServ != null ? InfoTpServ.Count : 0);

#endif

        #region ShouldSerialize

        public bool ShouldSerializeObs() => !string.IsNullOrEmpty(Obs);

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.InfoTpServ")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class InfoTpServ
    {
        /// <summary>
        /// O código informado deve existir na Tabela 06.
        /// </summary>
        [XmlElement("tpServico")]
        public string TpServico { get; set; }


        /// <summary>
        /// Valor da base de cálculo da retenção da contribuição previdenciária.
        /// </summary>
        [XmlElement("vlrBaseRet")]
        public string VlrBaseRet { get; set; }

        /// <summary>
        /// Preencher com o valor da retenção apurada de acordo com o que determina a legislação vigente relativa aos serviços contidos na nota fiscal/fatura. 
        /// Se {indCPRB} = [0] preencher com valor correspondente a 11% de {vlrBaseRet}. 
        /// Se {indCPRB}= [1] preencher com valor correspondente a 3,5% de {vlrBaseRet}.
        /// </summary>
        [XmlElement("vlrRetencao")]
        public string VlrRetencao { get; set; }

        /// <summary>
        /// Informar o valor da retenção destacada na nota fiscal relativo aos serviços subcontratados, se houver, desde que todos os documentos envolvidos se refiram à mesma competência e ao mesmo serviço, conforme disciplina a legislação.
        /// </summary>
        [XmlElement("vlrRetSub")]
        public string VlrRetSub { get; set; }

        /// <summary>
        /// Valor da retenção principal que deixou de ser efetuada pelo contratante ou que foi depositada em juízo em decorrência de decisão judicial/administrativa.
        /// </summary>
        [XmlElement("vlrNRetPrinc")]
        public string VlrNRetPrinc { get; set; }

        /// <summary>
        /// Valor dos serviços prestados por segurados em condições especiais, cuja atividade permita concessão de aposentadoria especial após 15 anos de contribuição.
        /// </summary>
        [XmlElement("vlrServicos15")]
        public string VlrServicos15 { get; set; }

        /// <summary>
        /// Valor dos serviços prestados por segurados em condições especiais, cuja atividade permita concessão de aposentadoria especial após 20 anos de contribuição.
        /// </summary>
        [XmlElement("vlrServicos20")]
        public string VlrServicos20 { get; set; }

        /// <summary>
        /// Valor dos serviços prestados por segurados em condições especiais, cuja atividade permita concessão de aposentadoria especial após 25 anos de contribuição.
        /// </summary>
        [XmlElement("vlrServicos25")]
        public string VlrServicos25 { get; set; }

        /// <summary>
        /// Adicional apurado de retenção da nota fiscal, caso os serviços tenham sido prestados sob condições especiais que ensejem aposentadoria especial aos trabalhadores após 15, 20, ou 25 anos de contribuição. 
        /// Preencher com o valor correspondente ao somatório de 4% sobre o {vlrServicos15} mais 3% sobre {vlrServicos20} mais 2% sobre {vlrServicos25}
        /// </summary>
        [XmlElement("vlrAdicional")]
        public string VlrAdicional { get; set; }

        /// <summary>
        /// Valor da retenção adicional que deixou de ser efetuada pelo contratante ou que foi depositada em juízo em decorrência de decisão judicial/administrativa
        /// </summary>
        [XmlElement("vlrNRetAdic")]
        public string VlrNRetAdic { get; set; }

        #region Should Serialize

        public bool ShouldSerializeVlrRetSub() => !string.IsNullOrEmpty(VlrRetSub);

        public bool ShouldSerializeVlrNRetPrinc() => !string.IsNullOrEmpty(VlrNRetPrinc);

        public bool ShouldSerializeVlrServicos15() => !string.IsNullOrEmpty(VlrServicos15);

        public bool ShouldSerializeVlrServicos20() => !string.IsNullOrEmpty(VlrServicos20);

        public bool ShouldSerializeVlrServicos25() => !string.IsNullOrEmpty(VlrServicos25);

        public bool ShouldSerializeVlrAdicional() => !string.IsNullOrEmpty(VlrAdicional);

        public bool ShouldSerializeVlrNRetAdic() => !string.IsNullOrEmpty(VlrNRetAdic);

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.InfoProcRetPr")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class InfoProcRetPr
    {
        [XmlElement("tpProcRetPrinc")]
        public TipoProcessoRetPrinc TpProcRetPrinc { get; set; }

        /// <summary>
        /// Informar o número do processo administrativo/judicial.
        /// </summary>
        [XmlElement("nrProcRetPrinc")]
        public string NrProcRetPrinc { get; set; }

        /// <summary>
        /// Código do indicativo da suspensão atribuído pelo contribuinte. 
        /// Este campo deve ser utilizado se, num mesmo processo, houver mais de uma matéria tributária objeto de contestação e as decisões forem diferentes para cada uma.
        /// </summary>
        [XmlElement("codSuspPrinc")]
        public string CodSuspPrinc { get; set; }

        /// <summary>
        /// Valor da retenção de contribuição previdenciária principal que deixou de ser efetuada em função de processo administrativo ou judicial.
        /// </summary>
        [XmlElement("valorPrinc")]
        public string ValorPrinc { get; set; }

        #region ShouldSerialize

        public bool ShouldSerializeCodSuspPrinc() => !string.IsNullOrEmpty(CodSuspPrinc);

        #endregion
    }

#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Xml.EFDReinf.InfoProcRetAd")]
    [ComVisible(true)]
#endif
    [Serializable()]
    public class InfoProcRetAd
    {
        [XmlElement("tpProcRetAdic")]
        public TipoProcessoRetPrinc TpProcRetAdic { get; set; }

        [XmlElement("nrProcRetAdic")]
        public string NrProcRetAdic { get; set; }

        [XmlElement("codSuspAdic")]
        public string CodSuspAdic { get; set; }

        [XmlElement("valorAdic")]
        public string ValorAdic { get; set; }

        #region ShouldSerialize

        public bool ShouldSerializeCodSuspAdic() => !string.IsNullOrEmpty(CodSuspAdic);

        #endregion
    }
}
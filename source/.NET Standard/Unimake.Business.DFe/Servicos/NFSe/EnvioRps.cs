﻿#if INTEROP
using System.Runtime.InteropServices;
#endif
using System.Xml;

namespace Unimake.Business.DFe.Servicos.NFSe
{
    /// <summary>
    /// Enviar o XML de Envio Rps NFSe para o webservice
    /// </summary>
#if INTEROP
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ProgId("Unimake.Business.DFe.Servicos.NFSe.EnvioRps")]
    [ComVisible(true)]
#endif
    public class EnvioRps : GerarNfse
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EnvioRps() : base()
        { }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="conteudoXML">Conteúdo do XML que será enviado para o WebService</param>
        /// <param name="configuracao">Objeto "Configuracoes" com as propriedade necessária para a execução do serviço</param>
        public EnvioRps(XmlDocument conteudoXML, Configuracao configuracao) : base(conteudoXML, configuracao)
        { }       
    }
}
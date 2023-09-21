﻿using System.IO;
using System.Xml;
using Unimake.Business.DFe.Servicos;
using Unimake.Business.DFe.Utility;
using Unimake.Business.DFe.Xml.EFDReinf;
using Xunit;

namespace Unimake.DFe.Test.EFDReinf
{
    /// <summary>
    /// Testar a serialização e desserialização dos XMLs do NFe
    /// </summary>
    public class SerializacaoDesserializacaoTest
    {
        /// <summary>
        /// Testar a serialização e desserialização do Evento 1000 Reinf
        /// </summary>
        [Theory]
        [Trait("DFe", "EFDReinf")]
        [InlineData(@"..\..\..\EFDReinf\Resources\1000_evtInfoContri-Reinf-evt.xml")]
        public void SerializacaoDesserializacaoReinf1000(string arqXML)
        {
            Assert.True(File.Exists(arqXML), "Arquivo " + arqXML + " não foi localizado para a realização da serialização/desserialização.");

            var doc = new XmlDocument();
            doc.Load(arqXML);

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.EFDReinf,
                CertificadoDigital = PropConfig.CertificadoDigital
            };

            var xml = XMLUtility.Deserializar<Reinf1000>(doc);
            var doc2 = xml.GerarXML();

            Assert.True(doc.InnerText == doc2.InnerText, "XML gerado pela DLL está diferente do conteúdo do arquivo serializado.");
        }

        /// <summary>
        /// Testar a serialização e desserialização do Evento 1050 Reinf
        /// </summary>
        [Theory]
        [Trait("DFe", "EFDReinf")]
        [InlineData(@"..\..\..\EFDReinf\Resources\1050_evtTabLig-Reinf-evt.xml")]
        public void SerializacaoDesserializacaoReinf1050(string arqXML)
        {
            Assert.True(File.Exists(arqXML), "Arquivo " + arqXML + " não foi localizado para a realização da serialização/desserialização.");

            var doc = new XmlDocument();
            doc.Load(arqXML);

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.EFDReinf,
                CertificadoDigital = PropConfig.CertificadoDigital
            };

            var xml = XMLUtility.Deserializar<Reinf1050>(doc);
            var doc2 = xml.GerarXML();

            Assert.True(doc.InnerText == doc2.InnerText, "XML gerado pela DLL está diferente do conteúdo do arquivo serializado.");
        }

        /// <summary>
        /// Testar a serialização e desserialização do Evento 1070 Reinf
        /// </summary>
        [Theory]
        [Trait("DFe", "EFDReinf")]
        [InlineData(@"..\..\..\EFDReinf\Resources\1070_evtTabProcesso-Reinf-evt.xml")]
        public void SerializacaoDesserializacaoReinf1070(string arqXML)
        {
            Assert.True(File.Exists(arqXML), "Arquivo " + arqXML + " não foi localizado para a realização da serialização/desserialização.");

            var doc = new XmlDocument();
            doc.Load(arqXML);

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.EFDReinf,
                CertificadoDigital = PropConfig.CertificadoDigital
            };

            var xml = XMLUtility.Deserializar<Reinf1070>(doc);
            var doc2 = xml.GerarXML();

            Assert.True(doc.InnerText == doc2.InnerText, "XML gerado pela DLL está diferente do conteúdo do arquivo serializado.");
        }

        /// <summary>
        /// Testar a serialização e desserialização do Evento 2010 Reinf
        /// </summary>
        [Theory]
        [Trait("DFe", "EFDReinf")]
        [InlineData(@"..\..\..\EFDReinf\Resources\2010_evtServTom-Reinf-evt.xml")]
        public void SerializacaoDesserializacaoReinf2010(string arqXML)
        {
            Assert.True(File.Exists(arqXML), "Arquivo " + arqXML + " não foi localizado para a realização da serialização/desserialização.");

            var doc = new XmlDocument();
            doc.Load(arqXML);

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.EFDReinf,
                CertificadoDigital = PropConfig.CertificadoDigital
            };

            var xml = XMLUtility.Deserializar<Reinf2010>(doc);
            var doc2 = xml.GerarXML();

            Assert.True(doc.InnerText == doc2.InnerText, "XML gerado pela DLL está diferente do conteúdo do arquivo serializado.");
        }

        /// <summary>
        /// Testar a serialização e desserialização do Evento 2020 Reinf
        /// </summary>
        [Theory]
        [Trait("DFe", "EFDReinf")]
        [InlineData(@"..\..\..\EFDReinf\Resources\2020_evtServPrest-Reinf-evt.xml")]
        public void SerializacaoDesserializacaoReinf2020(string arqXML)
        {
            Assert.True(File.Exists(arqXML), "Arquivo " + arqXML + " não foi localizado para a realização da serialização/desserialização.");

            var doc = new XmlDocument();
            doc.Load(arqXML);

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.EFDReinf,
                CertificadoDigital = PropConfig.CertificadoDigital
            };

            var xml = XMLUtility.Deserializar<Reinf2020>(doc);
            var doc2 = xml.GerarXML();

            Assert.True(doc.InnerText == doc2.InnerText, "XML gerado pela DLL está diferente do conteúdo do arquivo serializado.");
        }

        /// <summary>
        /// Testar a serialização e desserialização do Evento 2030 Reinf
        /// </summary>
        [Theory]
        [Trait("DFe", "EFDReinf")]
        [InlineData(@"..\..\..\EFDReinf\Resources\2030_evtAssocDespRec-Reinf-evt.xml")]
        public void SerializacaoDesserializacaoReinf2030(string arqXML)
        {
            Assert.True(File.Exists(arqXML), "Arquivo " + arqXML + " não foi localizado para a realização da serialização/desserialização.");

            var doc = new XmlDocument();
            doc.Load(arqXML);

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.EFDReinf,
                CertificadoDigital = PropConfig.CertificadoDigital
            };

            var xml = XMLUtility.Deserializar<Reinf2030>(doc);
            var doc2 = xml.GerarXML();

            Assert.True(doc.InnerText == doc2.InnerText, "XML gerado pela DLL está diferente do conteúdo do arquivo serializado.");
        }

        /// <summary>
        /// Testar a serialização e desserialização do Evento 2040 Reinf
        /// </summary>
        [Theory]
        [Trait("DFe", "EFDReinf")]
        [InlineData(@"..\..\..\EFDReinf\Resources\2040_evtAssocDespRep-Reinf-evt.xml")]
        public void SerializacaoDesserializacaoReinf2040(string arqXML)
        {
            Assert.True(File.Exists(arqXML), "Arquivo " + arqXML + " não foi localizado para a realização da serialização/desserialização.");

            var doc = new XmlDocument();
            doc.Load(arqXML);

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.EFDReinf,
                CertificadoDigital = PropConfig.CertificadoDigital
            };

            var xml = XMLUtility.Deserializar<Reinf2040>(doc);
            var doc2 = xml.GerarXML();

            Assert.True(doc.InnerText == doc2.InnerText, "XML gerado pela DLL está diferente do conteúdo do arquivo serializado.");
        }

        /// <summary>
        /// Testar a serialização e desserialização do Evento 2050 Reinf
        /// </summary>
        [Theory]
        [Trait("DFe", "EFDReinf")]
        [InlineData(@"..\..\..\EFDReinf\Resources\2050_evtComProd-Reinf-evt.xml")]
        public void SerializacaoDesserializacaoReinf2050(string arqXML)
        {
            Assert.True(File.Exists(arqXML), "Arquivo " + arqXML + " não foi localizado para a realização da serialização/desserialização.");

            var doc = new XmlDocument();
            doc.Load(arqXML);

            var configuracao = new Configuracao
            {
                TipoDFe = TipoDFe.EFDReinf,
                CertificadoDigital = PropConfig.CertificadoDigital
            };

            var xml = XMLUtility.Deserializar<Reinf2050>(doc);
            var doc2 = xml.GerarXML();

            Assert.True(doc.InnerText == doc2.InnerText, "XML gerado pela DLL está diferente do conteúdo do arquivo serializado.");
        }
    }
}
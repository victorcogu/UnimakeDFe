﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Unimake.Business.DFe.Utility;
using Unimake.Exceptions;

namespace Unimake.Business.DFe
{
    /// <summary>{
    /// Classe para consumir API
    /// </summary>
    public class ConsumirAPI : ConsumirBase
    {

        /// <summary>
        /// Estabelece conexão com o Webservice e faz o envio do XML e recupera o retorno. Conteúdo retornado pelo webservice pode ser recuperado através das propriedades RetornoServicoXML ou RetornoServicoString.
        /// </summary>
        /// <param name="xml">XML a ser enviado para o webservice</param>
        /// <param name="apiConfig">Parâmetros para execução do serviço (parâmetros da API)</param>
        /// <param name="certificado">Certificado digital a ser utilizado na conexão com os serviços</param>
        public void ExecutarServico(XmlDocument xml, APIConfig apiConfig, X509Certificate2 certificado)
        {
            if (certificado == null)
            {
                throw new CertificadoDigitalException();
            }

            var Content = EnveloparXML(apiConfig, xml);

            var Handler = new HttpClientHandler
            {
                ClientCertificateOptions = ClientCertificateOption.Automatic,
            };

            var httpWebRequest = new HttpClient(Handler)
            {
                BaseAddress = new Uri(apiConfig.RequestURI),
            };

            if (!string.IsNullOrWhiteSpace(apiConfig.Token))
            {
                httpWebRequest.DefaultRequestHeaders.Add("Authorization", apiConfig.Token);
            }

            ServicePointManager.Expect100Continue = false;
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(RetornoValidacao);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

  
            var postData = new HttpResponseMessage();
            if (apiConfig.MetodoAPI.ToLower() == "get")
            {
                postData = httpWebRequest.GetAsync("").GetAwaiter().GetResult();
            }
            else
            {
                postData = httpWebRequest.PostAsync(apiConfig.RequestURI, Content).GetAwaiter().GetResult();
            }

            WebException webException = null;
            var responsePost = string.Empty;
            try
            {
                responsePost = postData.Content.ReadAsStringAsync().Result;
            }
            catch (WebException ex)
            {
                if (ex.Response == null)
                {
                    throw (ex);
                }
                else
                {
                    webException = ex;
                }
            }

            var retornoXml = new XmlDocument();
            try
            {
                retornoXml = new TratarRetornoAPI(apiConfig, postData).ReceberRetorno();

            }
            catch (XmlException)
            {
                if (webException != null)
                {
                    throw (webException);
                }

                throw new Exception(responsePost);
            }
            catch
            {
                throw new Exception(responsePost);
            }

            if (apiConfig.TagRetorno.ToLower() != "prop:innertext" && postData.IsSuccessStatusCode == true)
            {
                if (retornoXml.GetElementsByTagName(apiConfig.TagRetorno)[0] == null)
                {
                    throw new Exception("Não foi possível localizar a tag <" + apiConfig.TagRetorno + "> no XML retornado pelo webservice.\r\n\r\n" +
                        "Conteúdo retornado pelo servidor:\r\n\r\n" +
                        retornoXml.InnerXml);
                }
                RetornoServicoString = retornoXml.GetElementsByTagName(apiConfig.TagRetorno)[0].OuterXml;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(retornoXml.InnerText))
                {
                    throw new Exception("A propriedade InnerText do XML retornado pelo webservice está vazia.");
                }

                RetornoServicoString = retornoXml.InnerText;

                //Remover do XML retornado o conteúdo ﻿<?xml version="1.0" encoding="utf-8"?> ou gera falha na hora de transformar em XmlDocument
                if (RetornoServicoString.IndexOf("?>") >= 0)
                {
                    RetornoServicoString = RetornoServicoString.Substring(RetornoServicoString.IndexOf("?>") + 2);
                }

                //Remover quebras de linhas
                RetornoServicoString = RetornoServicoString.Replace("\r\n", "");
            }

            RetornoServicoXML = new XmlDocument
            {
                PreserveWhitespace = false
            };
            RetornoServicoXML.LoadXml(retornoXml.InnerXml);
        }

        /// <summary>
        /// Método para envolopar o XML, formando o JSON para comunicação com a API
        /// </summary>
        /// <param name="apiConfig"></param>    Configurações básicas para consumo da API
        /// <param name="xml"></param>          Arquivo XML que será enviado
        /// <returns></returns>
        private HttpContent EnveloparXML(APIConfig apiConfig, XmlDocument xml)
        {
            var xmlBody = xml.OuterXml;
            if (apiConfig.GZipCompress)
            {
                xmlBody = Compress.GZIPCompress(xmlBody);
                xmlBody = Convert.ToBase64String(Encoding.UTF8.GetBytes(xmlBody));
            }
            if (apiConfig.WebSoapString.IndexOf("soapenv") > 0)
            {
                apiConfig.WebSoapString = apiConfig.WebSoapString.Replace("{xml}", xmlBody);
                return new StringContent(apiConfig.WebSoapString, Encoding.UTF8, apiConfig.ContentType);
            }


            if (apiConfig.B64) {  }
            if (apiConfig.ContentType == "multipart/form-data")
            {
                var path = xml.BaseURI.Substring(8, xml.BaseURI.Length - 8);
                var boundary = "----------------------------" + DateTime.Now.Ticks.ToString("x");

                #region ENVIO EM BYTES
                byte[] xmlBytes = Encoding.UTF8.GetBytes(xmlBody);
                ByteArrayContent xmlContent = new ByteArrayContent(xmlBytes);
                xmlContent.Headers.ContentType = MediaTypeHeaderValue.Parse("text/xml");
                xmlContent.Headers.ContentEncoding.Add("ISO-8859-1");
                xmlContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                {
                    Name = "f1",
                    FileName = path,

                };
                #endregion ENVIO EM BYTES

                HttpContent MultiPart = new MultipartContent("form-data", boundary)
                {
                    xmlContent,
                };
                return MultiPart;
            }

            var n = apiConfig.WebSoapString.CountChars('{');
            var dicionario = new Dictionary<string, string>();
            var posicaoInicial = 0;

            while (n > 0)
            {
                try
                {
                    var InicioTag = apiConfig.WebSoapString.IndexOf('{', posicaoInicial);
                    var FimTag = apiConfig.WebSoapString.IndexOf('}', posicaoInicial);
                    var tag = apiConfig.WebSoapString.Substring(InicioTag + 1, (FimTag - InicioTag) - 1);
                    posicaoInicial = FimTag + 1;

                    switch (tag.ToLower())
                    {
                        case "usuario":
                            dicionario.Add("usuario", apiConfig.MunicipioUsuario);
                            break;

                        case "senha":
                            dicionario.Add("senha", apiConfig.MunicipioSenha);
                            break;

                        case "xml":
                            dicionario.Add((apiConfig.WebAction == null ? "xml" : apiConfig.WebAction), xmlBody);
                            break;

                        default:
                            throw new Exception($"Não foi encontrado a Tag {tag} encontrada no WebSoapString - Xml de configução do Município");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                n--;
            }

            var result = "";

            if (apiConfig.ContentType == "application/json")
            {
                result = JsonConvert.SerializeObject(dicionario);
            }
            else
            {
                result = xmlBody;
            }

            HttpContent temp = new StringContent(result, Encoding.UTF8, apiConfig.ContentType);
            return temp;
        }
    }
}
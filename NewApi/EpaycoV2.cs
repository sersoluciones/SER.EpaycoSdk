using Microsoft.Extensions.Logging;
using SER.EpaycoSdk.NewApi.Models;
using SER.EpaycoSdk.NewApi.Models.Request;
using SER.EpaycoSdk.NewApi.Models.Response;
using SER.EpaycoSdk.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi
{
    public class EpaycoV2
    {
        #region Atributes
        private readonly ILogger _logger;
        private string _auth = string.Empty;
        private Consume _consume;
        #endregion

        public EpaycoV2(ILoggerFactory logger, string auth)
        {
            _auth = auth;
            _logger = logger.CreateLogger("Epayco");
            _consume = new Consume(_logger, _auth);
        }

        #region Access token       
        public async Task<Login> LoginAsync()
        {
            return await _consume.ExecuteAsync<Login>(_consume.MakePostRequest(endPoint: Constantes.LOGIN_ENDPOINT), isLogin: true);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DetailTransactionRes>> DetailTransaction(DetailTransaction model)
        {
            return await _consume.ExecuteAsync<BaseResponse<DetailTransactionRes>>(_consume.MakePostRequest(endPoint: Constantes.DETAIL_TRANSACTION_ENDPOINT, model: model));
        }

        /// <summary>
        /// city	String	Ciudad.
        /// country	String	País
        /// department String	Departamento
        /// phone String	Teléfono celular.
        /// tax String	Impuesto.
        /// taxBase String	Valor base sin impuesto.
        /// description String	Descripción.
        /// invoice String	Número de factura.
        /// currency String	Moneda (COP, USD).
        /// typePerson String	Naturaleza de la persona (1=Persona Natural, 2=Persona Jurídica).
        /// address String	Dirección.
        /// urlConfirmation String	Url de confirmación.
        /// methodConfimation String	Método de confirmación (GET, POST).
        /// openPayment Boolean	Pago único (true, false).
        /// extra1 String	información extra permitidos hasta 10 extras.
        /// extra2 String	información extra permitidos hasta 10 extras.
        /// extra3 String	información extra, permitidos hasta 10 extras.
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<StandardRes>> StandardTransaction(StandardTransaction model)
        {
            return await _consume.ExecuteAsync<BaseResponse<StandardRes>>(_consume.MakePostRequest(endPoint: Constantes.STANDARD_TRANSACTION_ENDPOINT, model: model));
        }

        /// <summary>
        /// Confirmar Transaccion de daviplata
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<StandardRes>> ConfirmStandardTransaction(ConfirmStandardTC model)
        {
            return await _consume.ExecuteAsync<BaseResponse<StandardRes>>(_consume.MakePostRequest(endPoint: Constantes.CONFIRM_STANDARD_TRANSACTION_ENDPOINT,
                model: model));
        }

        /// <summary>
        /// crea una transaccion con Daviplata
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<DaviplataRes>> DaviplataTransaction(DaviplataTransaction model)
        {
            return await _consume.ExecuteAsync<BaseResponse<DaviplataRes>>(_consume.MakePostRequest(endPoint: Constantes.DAVIPLATA_TRANSACTION_ENDPOINT, model: model));
        }

        /// <summary>
        /// Confirmar Transaccion de daviplata
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<ConfirmDaviplataRes>> ConfirmDaviplataTransaction(ConfirmDaviplata model)
        {
            return await _consume.ExecuteAsync<BaseResponse<ConfirmDaviplataRes>>(_consume.MakePostRequest(endPoint: Constantes.DAVIPLATA_CONFIRM_ENDPOINT,
                model: model));
        }

        /// <summary>
        /// Transaccion para PSE
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<PseRes>> PSETransaction(PSETransaction model)
        {
            return await _consume.ExecuteAsync<BaseResponse<PseRes>>(_consume.MakePostRequest(endPoint: Constantes.PSE_TRANSACTION_ENDPOINT, model: model));
        }

        /// <summary>
        /// Transaccion para PSE
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<PseRes>> ConfirmPSETransaction(long transactionID)
        {
            return await _consume.ExecuteAsync<BaseResponse<PseRes>>(_consume.MakePostRequest(endPoint: Constantes.CONFIRM_PSE_TRANSACTION_ENDPOINT, 
                model: new ConfirmPSETransaction
                {
                    TransactionID = transactionID
                }));
        }

        /// <summary>
        /// Obtener los bancos
        /// </summary>
        /// <returns></returns>
        public async Task<BaseResponse<List<BankRes>>> FetchBanks()
        {
            return await _consume.ExecuteAsync<BaseResponse<List<BankRes>>>(_consume.MakeGetRequest(endPoint: Constantes.BANKS_ENDPOINT));
        }


        ////// METODOS EN EFECTIVO ////////////
        /// <summary>
        /// hacer la transaccion con metodos en efectivo (Efecty, sured, etc)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<StandardRes>> CashTransaction(CashTransaction model)
        {
            return await _consume.ExecuteAsync<BaseResponse<StandardRes>>(_consume.MakePostRequest(endPoint: Constantes.CASH_TRANSACTION_ENDPOINT, model: model));
        }


        ////// TARJETAS DE CREDITO ////////////
        ///
        /// <summary>
        /// Transaccion para TC
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<TCRes>> CreateTCTransaction(TCTransaction model)
        {
            return await _consume.ExecuteAsync<BaseResponse<TCRes>>(_consume.MakePostRequest(endPoint: Constantes.TC_TRANSACTION_ENDPOINT, model: model));
        }

        /// <summary>
        /// Tokenizacion de tarjeta
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<TokenCardRes>> CreateTokenCard(TokenCardTransaction model)
        {
            return await _consume.ExecuteAsync<BaseResponse<TokenCardRes>>(_consume.MakePostRequest(endPoint: Constantes.TOKEN_CARD_ENDPOINT, model: model));
        }


        /// <summary>
        /// Creacion de cliente token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<CustomerRes>> CreateTokenCustomer(CustomerTransaction model)
        {
            return await _consume.ExecuteAsync<BaseResponse<CustomerRes>>(_consume.MakePostRequest(endPoint: Constantes.TOKEN_CUSTOMER_ENDPOINT, model: model));
        }

        /// <summary>
        /// Agregar token a un cliente
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResponse<AddTokenCustomerRes>> AttachTokenToCustomer(AddTokenToCustomer model)
        {
            return await _consume.ExecuteAsync<BaseResponse<AddTokenCustomerRes>>(_consume.MakePostRequest(endPoint: Constantes.ADD_TOKEN_TO_CUSTOMER_ENDPOINT, model: model));
        }

        
    }
}

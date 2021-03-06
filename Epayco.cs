using System;
using System.Collections.Generic;
using System.Text.Json;
using EpaycoSdk.Models;
using EpaycoSdk.Models.Bank;
using EpaycoSdk.Models.Cash;
using EpaycoSdk.Models.Charge;
using EpaycoSdk.Models.Plans;
using EpaycoSdk.Models.Subscriptions;
using EpaycoSdk.Utils;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using SER.EpaycoSdk.Models.RequestModels;
using static System.Text.Json.JsonElement;

namespace EpaycoSdk
{
    public class Epayco
    {
        BodyRequest body = new BodyRequest();
        Request _request = new Request();
        RequestRest _restRequest = new RequestRest();
        Auxiliars _auxiliars = new Auxiliars();
        private readonly ILogger _logger;
        #region Constructor
        public Epayco(string publicKey, string privateKey, string lang, bool test, ILogger<Epayco> logger)
        {
            _PUBLIC_KEY = publicKey;
            _PRIVATE_KEY = privateKey;
            _LANG = lang;
            _TEST = test;
            _request.AuthService(publicKey, privateKey);
            _logger = logger;
        }
        #endregion

        #region Atributes
        private string _PUBLIC_KEY = string.Empty;
        private string _PRIVATE_KEY = string.Empty;
        private string PARAMETER = string.Empty;
        private string ENDPOINT = string.Empty;
        private string _LANG = string.Empty;
        private bool _TEST = false;
        private string IV = "0000000000000000";
        #endregion

        #region Methods

        /*
         * METODOS RELACIONADOS CON EL CUSTOMER
         */
        public TokenModel CreateToken(CreateToken model)
        {
            PARAMETER = body.ObjectToString(model);
            ENDPOINT = Constants.url_create_token;
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            // _logger.LogInformation($"----------------------------token {content} --------------------------------");
            return JsonSerializer.Deserialize<TokenModel>(content);
        }

        public AddTokenModel AddNewToken(string customerId, string tokenId)
        {
            PARAMETER = body.getBodyAddNewToken(customerId, tokenId);
            ENDPOINT = Constants.url_add_token;
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            _logger.LogInformation($"----------------------------content add new token to customer {content} --------------------------------");
            AddTokenModel token = JsonSerializer.Deserialize<AddTokenModel>(content);
            return token;
        }

        public CustomerCreateModel CustomerCreate(CreateCustomer model)
        {
            PARAMETER = body.ObjectToString(model);
            _logger.LogInformation($"----------------------------PARAMETER\n{PARAMETER}----------------");
            ENDPOINT = Constants.url_create_customer;
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            return JsonSerializer.Deserialize<CustomerCreateModel>(content);
        }

        public CustomerFindModel FindCustomer(string customerId)
        {
            ENDPOINT = body.getQueryFindCustomer(_PUBLIC_KEY, customerId);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            CustomerFindModel customer = JsonSerializer.Deserialize<CustomerFindModel>(content);
            return customer;
        }

        public CustomerListModel CustomerGetList()
        {
            ENDPOINT = body.getQueryFindAllCustomers(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            StatusConsult customer = JsonSerializer.Deserialize<StatusConsult>(content);
            CustomerListModel custom = new CustomerListModel();
            if (customer.status)
            {
                custom = JsonSerializer.Deserialize<CustomerListModel>(content);
            }
            else
            {
                custom.status = false;
                custom.message = customer.message;
            }

            return custom; ;
        }

        public CustomerEditModel CustomerUpdate(string id_customer, string name)
        {
            ENDPOINT = body.getQueryUpdateCustomer(_PUBLIC_KEY, id_customer);
            PARAMETER = body.getBodyUpdateCustomer(name);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CustomerEditModel customer = JsonSerializer.Deserialize<CustomerEditModel>(content);
            return customer;
        }

        public CustomerTokenDeleteModel CustomerDeleteToken(string franchise, string mask, string customer_id)
        {
            ENDPOINT = Constants.url_token_delete;
            PARAMETER = body.getBodyDeleteTokenCustomer(franchise, mask, customer_id);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CustomerTokenDeleteModel customer = JsonSerializer.Deserialize<CustomerTokenDeleteModel>(content);
            return customer;
        }

        /*
         * METODOS RELACIONADOS CON PLANS
         */
        public CreatePlanModel PlanCreate(string id_plan, string name, string description, decimal amount, string currency, string interval, int interval_count, int trial_days)
        {
            ENDPOINT = Constants.url_create_plan;
            PARAMETER = body.getBodyCreatePlan(id_plan, name, description, amount, currency, interval, interval_count, trial_days);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CreatePlanModel plan = JsonSerializer.Deserialize<CreatePlanModel>(content);
            return plan;
        }

        public FindPlanModel GetPlan(string id_plan)
        {
            ENDPOINT = body.getQueryGetPlan(id_plan, _PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            FindPlanModel plan = JsonSerializer.Deserialize<FindPlanModel>(content);
            return plan;
        }

        public FindAllPlansModel GetAllPlans()
        {
            FindAllPlansModel plan = new FindAllPlansModel();
            ENDPOINT = body.getQueryGetAllPlans(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            FindAllPlansSatusModel status = JsonSerializer.Deserialize<FindAllPlansSatusModel>(content);
            if (status.status)
            {
                plan = JsonSerializer.Deserialize<FindAllPlansModel>(content);
            }
            else
            {
                plan.status = false;
                plan.message = status.message;
            }
            return plan;
        }

        public RemovePlanModel RemovePlan(string id_plan)
        {
            ENDPOINT = body.getQueryRemovePlan(_PUBLIC_KEY, id_plan);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            RemovePlanModel plan = JsonSerializer.Deserialize<RemovePlanModel>(content);
            return plan;
        }

        /*
         * SUBSCRIPTIONS
         */
        public CreateSubscriptionModel SubscriptionCreate(string id_plan, string customer_id, string token_card, string doc_type, string doc_number, string url_confirmation = null, string method_confirmation = null)
        {
            ENDPOINT = Constants.url_create_subscription;
            PARAMETER = body.getBodyCreateSubscription(id_plan, customer_id, token_card, doc_type, doc_number, url_confirmation, method_confirmation);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CreateSubscriptionModel subscription = JsonSerializer.Deserialize<CreateSubscriptionModel>(content);
            return subscription;
        }

        public FindSusbscriptionModel getSubscription(string subscriptionId)
        {
            ENDPOINT = body.getQueryFindSubscription(_PUBLIC_KEY, subscriptionId);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            FindSusbscriptionModel subscription = JsonSerializer.Deserialize<FindSusbscriptionModel>(content);
            return subscription;
        }

        public AllSubscriptionModel getAllSubscription()
        {
            ENDPOINT = body.getQueryFindAllSubscription(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            SubscriptionStatus status = JsonSerializer.Deserialize<SubscriptionStatus>(content);
            AllSubscriptionModel subscription = new AllSubscriptionModel();
            if (status.status)
            {
                subscription = JsonSerializer.Deserialize<AllSubscriptionModel>(content);
            }
            else
            {
                subscription.status = false;
                subscription.message = status.message;
            }
            return subscription;
        }

        public CancelSubscriptionModel cancelSubscription(string subscriptionId)
        {
            ENDPOINT = Constants.url_cancel_subscription;
            PARAMETER = body.getBodyCancelSubscription(subscriptionId);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            CancelSubscriptionModel subscription = JsonSerializer.Deserialize<CancelSubscriptionModel>(content);
            return subscription;
        }

        public ChargeSubscriptionModel ChargeSubscription(string id_plan,
            string customer_id,
            string token_card,
            string doc_type,
            string doc_number,
            string ip,
            string address = null,
            string phone = null,
            string cell_phone = null
            )
        {
            ENDPOINT = Constants.url_chage_subscription;
            PARAMETER = body.getBodyChargeSubscription(id_plan, customer_id, token_card, doc_type, doc_number, ip, address, phone, cell_phone);
            string content = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            ChargeSubscriptionModel subscription = JsonSerializer.Deserialize<ChargeSubscriptionModel>(content);
            return subscription;
        }

        /*
         * BANK CREATE
         */
        public JsonElement BankCreate(CreatePaymentPSE model)
        {
            //_logger.LogInformation($"_PUBLIC_KEY {_PUBLIC_KEY} _PRIVATE_KEY {_PRIVATE_KEY}");
            ENDPOINT = Constants.url_pagos_debitos;
            model.ToEncrypt(_auxiliars.ConvertToBase64(IV), _TEST, _PUBLIC_KEY, _PRIVATE_KEY);
            PARAMETER = body.ObjectToString(model);
            //_logger.LogInformation($"ENDPOINT {ENDPOINT}");
            //_logger.LogInformation($"PARAMETER {PARAMETER}");
            string response = _restRequest.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            _logger.LogInformation($"-----------------------------response\n{response}");
            return ToJsonDocument(response);
            //_logger.LogInformation($"content {content}");
            //try
            //{
            //    return JsonSerializer.Deserialize<PseModel>(response);
            //}
            //catch (Exception e)
            //{
            //    _logger.LogInformation($"----------------------------ERROR\n{e.ToString()}----------------");
            //    var json = JObject.Parse(response);
            //    throw new EpaycoException(json["text_response"].ToString(), json["title_response"].ToString());
            //}
        }

        public PseModel BankCreateSplit(
            string bank,
            string invoice,
            string description,
            string value,
            string tax,
            string tax_base,
            string currency,
            string type_person,
            string doc_type,
            string doc_number,
            string name,
            string last_name,
            string email,
            string country,
            string cell_phone,
            string url_response,
            string url_confirmation,
            string method_confirmation,
            string splitpayment,
            string split_app_id,
            string split_merchant_id,
            string split_type,
            string split_primary_receiver,
            string split_primary_receiver_fee,
            List<SplitReceivers> split_receivers,
            string extra1 = "",
            string extra2 = "",
            string extra3 = "",
            string extra4 = "",
            string extra5 = "",
            string extra6 = "",
            string extra7 = "")
        {
            ENDPOINT = Constants.url_pagos_debitos;
            PARAMETER = body.getBodyBankCreateSplit(_auxiliars.ConvertToBase64(IV), _TEST, _PUBLIC_KEY, _PRIVATE_KEY, bank, invoice, description, value, tax,
                tax_base, currency, type_person, doc_type, doc_number, name, last_name, email, country,
                cell_phone, url_response, url_confirmation, method_confirmation, splitpayment, split_app_id, split_merchant_id,
                split_type, split_primary_receiver, split_primary_receiver_fee, split_receivers, extra1, extra2, extra3,
                extra4, extra5, extra6, extra7);
            string content = _restRequest.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            PseModel pse = JsonSerializer.Deserialize<PseModel>(content);
            return pse;
        }

        public JsonElement GetTransaction(string transactionId)
        {
            ENDPOINT = body.getQueryGetTransaction(_PUBLIC_KEY, transactionId);
            string response = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);

            return ToJsonDocument(response);
            //TransactionModel transaction = new TransactionModel();
            //TransactionResponse response = JsonSerializer.Deserialize<TransactionResponse>(content);
            //if (response.success)
            //{
            //    transaction = JsonSerializer.Deserialize<TransactionModel>(content);
            //}
            //else
            //{
            //    transaction.success = response.success;
            //    transaction.title_response = response.title_response;
            //    transaction.text_response = response.text_response;
            //    transaction.last_action = response.last_action;
            //}
            //return transaction;
        }

        public BanksModel GetBanks()
        {
            BanksModel bank = new BanksModel();
            ENDPOINT = body.getQueryGetBanks(_PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            BankResponse response = JsonSerializer.Deserialize<BankResponse>(content);
            if (response.success)
            {
                bank = JsonSerializer.Deserialize<BanksModel>(content);
            }
            else
            {
                bank.success = response.success;
                bank.text_response = response.text_response;
                bank.title_response = response.title_response;
                bank.last_action = response.last_action;
            }
            return bank;
        }

        /*
         * CASH
         */
        public JsonElement CashCreate(CreatePaymentCash model)
        {
            ENDPOINT = body.getQueryCash(model.Type);
            model.I = _auxiliars.ConvertToBase64(IV);
            model.Test = _TEST.ToString();
            model.PublicKey = _PUBLIC_KEY;
            model.I = _auxiliars.ConvertToBase64(IV);
            PARAMETER = body.ObjectToString(model);
            // _logger.LogInformation($"-----------------------------body\n{PARAMETER}");

            string response = _restRequest.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            _logger.LogInformation($"-----------------------------response\n{response}");
            return ToJsonDocument(response);
            //try
            //{
            //    return JsonSerializer.Deserialize<CashModel>(response);
            //}
            //catch (Exception e)
            //{
            //    _logger.LogInformation($"----------------------------ERROR\n{e.ToString()}----------------");
            //    var json = JObject.Parse(response);
            //    throw new EpaycoException(json["text_response"].ToString(), json["title_response"].ToString());
            //}
        }

        public CashTransactionModel GetCashTransaction(string ref_payco)
        {
            ENDPOINT = body.getQueryCashTransaction(ref_payco, _PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            CashTransactionModel transaction = JsonSerializer.Deserialize<CashTransactionModel>(content);
            return transaction;
        }

        /*
         * PAYMENT
         */
        public JsonElement ChargeCreate(CreatePaymentTC model)
        {
            ENDPOINT = Constants.url_charge;
            PARAMETER = body.ObjectToString(model);
            // _logger.LogInformation($"----------------------------PARAMETER\n{PARAMETER}----------------");
            string response = _request.Execute(
                ENDPOINT,
                "POST",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY),
                PARAMETER);
            _logger.LogInformation($"----------------------------response\n{response}----------------");
            return ToJsonDocument(response);
            //try
            //{
            //    return JsonSerializer.Deserialize<ChargeModel>(response);
            //}
            //catch (Exception e)
            //{
            //    _logger.LogInformation($"----------------------------ERROR\n{e.ToString()}----------------");
            //    var json = JObject.Parse(response);
            //    throw new EpaycoException(json["message"].ToString());
            //}

        }

        public ChargeTransactionModel GetChargeTransaction(string ref_payco)
        {
            ENDPOINT = body.getQueryCashTransaction(ref_payco, _PUBLIC_KEY);
            string content = _request.Execute(
                ENDPOINT,
                "GET",
                _auxiliars.ConvertToBase64(_PUBLIC_KEY));
            ChargeTransactionModel transaction = JsonSerializer.Deserialize<ChargeTransactionModel>(content);
            return transaction;
        }

        public static JsonElement ToJsonDocument(string response)
        {
            var documentOptions = new JsonDocumentOptions
            {
                CommentHandling = JsonCommentHandling.Skip
            };
            return JsonDocument.Parse(response, documentOptions).RootElement;
        }

        #endregion
    }

    public class EpaycoException : Exception
    {
        public string Title { get; set; }
        public EpaycoException(string msg, string title = null) : base(msg)
        {
            this.Title = title;
        }
    }
}
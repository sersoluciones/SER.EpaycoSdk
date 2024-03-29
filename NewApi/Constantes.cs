﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SER.EpaycoSdk.NewApi
{
    public class Constantes
    {
        //endpoints
        public const string LOGIN_ENDPOINT = "login";
        public const string STANDARD_TRANSACTION_ENDPOINT = "payment/process/standard";
        public const string CASH_TRANSACTION_ENDPOINT = "payment/process/cash";
        public const string DAVIPLATA_TRANSACTION_ENDPOINT = "payment/process/daviplata";
        public const string DAVIPLATA_CONFIRM_ENDPOINT = "payment/confirm/daviplata";
        public const string DETAIL_TRANSACTION_ENDPOINT = "transaction/detail";
        public const string PSE_TRANSACTION_ENDPOINT = "payment/process/pse";
        public const string CONFIRM_PSE_TRANSACTION_ENDPOINT = "payment/pse/transaction";
        public const string CONFIRM_STANDARD_TRANSACTION_ENDPOINT = "payment/confirm/standard";
        public const string BANKS_ENDPOINT = "payment/pse/banks";
        public const string TC_TRANSACTION_ENDPOINT = "payment/process";
        public const string TOKEN_CARD_ENDPOINT = "token/card";
        public const string TOKEN_CUSTOMER_ENDPOINT = "token/customer";
        public const string ADD_TOKEN_TO_CUSTOMER_ENDPOINT = "subscriptions/customer/add/new/token";
    }
}

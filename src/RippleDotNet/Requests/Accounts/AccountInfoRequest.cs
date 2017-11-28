﻿using Newtonsoft.Json;

namespace RippleDotNet.Requests.Accounts
{
    public class AccountInfoRequest : LedgerRequest
    {
        public AccountInfoRequest(string account)
        {
            Account = account;
            Command = "account_info";
        }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("strict")]
        public bool? Strict { get; set; }

        [JsonProperty("queue")]
        public bool? Queue { get; set; }

        [JsonProperty("signer_lists")]
        public bool? SignerLists { get; set; }
    }
}

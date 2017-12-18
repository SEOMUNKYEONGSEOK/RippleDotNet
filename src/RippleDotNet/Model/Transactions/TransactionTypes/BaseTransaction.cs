﻿using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RippleDotNet.Json.Converters;

namespace RippleDotNet.Model.Transactions.TransactionTypes
{
    [JsonConverter(typeof(TransactionConverter))]
    public class BaseTransaction
    {

        public BaseTransaction()
        {
            Fee = new Currency {Value = "10000"};
        }

        public string Account { get; set; }

        public string AccountTxnID { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public Currency Fee { get; set; }

        public uint? Flags { get; set; }

        public uint? LastLedgerSequence { get; set; }

        public List<Memo> Memos { get; set; }

        public uint? Sequence { get; set; }

        [JsonProperty("SigningPubKey")]
        public string SigningPublicKey { get; set; }

        public List<Signer> Signers { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionType TransactionType { get; set; }

        [JsonProperty("TxnSignature")]
        public string TransactionSignature { get; set; }

        [JsonConverter(typeof(RippleDateTimeConverter))]
        public DateTime? Date { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("inLedger")]
        public uint? InLedger { get; set; }

        [JsonProperty("ledger_index")]
        public uint? LedgerIndex { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("validated")]
        public bool? Validated { get; set; }

        public override string ToString()
        {
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.NullValueHandling = NullValueHandling.Ignore;
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            return JsonConvert.SerializeObject(this, serializerSettings);
        }
    }

    public class Memo
    {
        [JsonProperty("Memo")]
        public Memo2 Memo2 { get; set; }
    }

    public class Memo2
    {
        public string MemoData { get; set; }

        public string MemoFormat { get; set; }

        public string MemoType { get; set; }
    }

    public class Signer
    {
        public string Account { get; set; }

        [JsonProperty("TxnSignature")]
        public string TransactionSignature { get; set; }

        [JsonProperty("SigningPubKey")]
        public string SigningPublicKey { get; set; }
    }

    public class Meta
    {
        public List<AffectedNode> AffectedNodes { get; set; }

        public int TransactionIndex { get; set; }

        public string TransactionResult { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public Currency DeliveredAmount { get; set; }
    }

    public class FinalFields
    {
        public string Account { get; set; }

        public object Balance { get; set; }

        public int Flags { get; set; }

        public int OwnerCount { get; set; }

        public int Sequence { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public Currency HighLimit { get; set; }

        public string HighNode { get; set; }

        [JsonConverter(typeof(CurrencyConverter))]
        public Currency LowLimit { get; set; }

        public string LowNode { get; set; }
    }

    public class PreviousFields
    {
        [JsonConverter(typeof(CurrencyConverter))]
        public object Balance { get; set; }
        public int Sequence { get; set; }
    }
    

    public class AffectedNode
    {
        public NodeInfo CreatedNode { get; set; }

        public NodeInfo DeletedNode { get; set; }

        public NodeInfo ModifiedNode { get; set; }
    }

    public class NodeInfo
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public LedgerEntryType LedgerEntryType { get; set; }

        public string LedgerIndex { get; set; }

        [JsonProperty("PreviousTxnID")]
        public string PreviousTransactionId { get; set; }

        [JsonProperty("PreviousTxnLgrSeq")]
        public uint? PreviousTransactionLedgerSequence { get; set; }

        public dynamic FinalFields { get; set; }

        public dynamic NewFields { get; set; }

        public dynamic PreviousFields { get; set; }
    }
}
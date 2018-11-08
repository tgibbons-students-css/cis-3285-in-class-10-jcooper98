using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

using CurrencyTrader.Contracts;

namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly String url;
        ITradeDataProvider urlProvider;
        public AdjustTradeDataProvider(String url)
        {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            IEnumerable<string> tradeTxt = urlProvider.GetTradeData();
            // new list of trades with substitution in them
            List<string> newTradeTxt = new List<string>();
            
            foreach (string line in tradeTxt)
            {
                string newLine = line.Replace("GBP", "EUR");
                newTradeTxt.Add(newLine);
            }
            
            return newTradeTxt;
        }
    }
}

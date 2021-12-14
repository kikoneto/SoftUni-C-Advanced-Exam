using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace StockMarket
{
    public class Investor
    {
        private readonly List<Stock> Portfolio;
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            this.Portfolio = new List<Stock>();
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }
        public int Count { get => this.Portfolio.Count;}
        public void BuyStock(Stock stock)
        {
            bool isBuyable = true;
            foreach (var item in this.Portfolio)
            {
                if (item.CompanyName == stock.CompanyName)
                {
                    isBuyable = false;
                }
            }
            if (isBuyable)
            {
                var price = stock.MarketCapitalization;
                if (price > 10000 && this.MoneyToInvest >= stock.PricePerShare)
                {
                    this.MoneyToInvest -= stock.PricePerShare;
                    this.Portfolio.Add(stock);
                }
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if(!this.Portfolio.Any(x => x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if(this.Portfolio.First(x => x.CompanyName == companyName).PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                this.Portfolio.RemoveAll(x => x.CompanyName == companyName);
                this.MoneyToInvest += sellPrice;
                return $"{companyName} was sold.";
            }
        }
        public Stock FindStock(string companyName)
        {
            return this.Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            if(this.Portfolio.Count > 0)
            {
                return this.Portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");

            foreach (var item in this.Portfolio)
            {
                sb.AppendLine($"{item}");
            }

            return sb.ToString().TrimStart().TrimEnd();
        }
    }
}

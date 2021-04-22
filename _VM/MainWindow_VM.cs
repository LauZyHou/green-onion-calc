using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Goc._VM
{
    public class MainWindow_VM : ViewModelBase
    {
        private string? paymentInAdvance;
        private string? lendingRate;
        private string? interestRate;
        private string? bankingIncome;
        private string? pureRebate;
        private string? mortgageServiceCharge;
        private string? marketingExpenses;

        public string? PaymentInAdvance { get => paymentInAdvance; set => this.RaiseAndSetIfChanged(ref paymentInAdvance, value); }
        public string? LendingRate { get => lendingRate; set => this.RaiseAndSetIfChanged(ref lendingRate, value); }
        public string? InterestRate { get => interestRate; set => this.RaiseAndSetIfChanged(ref interestRate, value); }
        public string? BankingIncome { get => bankingIncome; set => this.RaiseAndSetIfChanged(ref bankingIncome, value); }
        public string? PureRebate { get => pureRebate; set => this.RaiseAndSetIfChanged(ref pureRebate, value); }
        public string? MortgageServiceCharge { get => mortgageServiceCharge; set => this.RaiseAndSetIfChanged(ref mortgageServiceCharge, value); }
        public string? MarketingExpenses { get => marketingExpenses; set => this.RaiseAndSetIfChanged(ref marketingExpenses, value); }

        private void Clear()
        {
            PureRebate = MortgageServiceCharge = MarketingExpenses = "";
            PaymentInAdvance = PaymentInAdvance?.Trim();
            LendingRate = LendingRate?.Trim();
            InterestRate = InterestRate?.Trim();
            BankingIncome = BankingIncome?.Trim();
        }

        private void OnCalculate()
        {
            //
            // Clear value
            //
            Clear();

            //
            // Parse input
            //
            double pIA, lR, iR, bI, pR, mSC, mE;

            bool succ = double.TryParse(paymentInAdvance, out pIA);
            if (!succ) return;

            succ = double.TryParse(lendingRate, out lR);
            if (!succ) return;

            succ = double.TryParse(interestRate, out iR);
            if (!succ) return;

            succ = double.TryParse(bankingIncome, out bI);
            if (!succ) return;

            //
            // Calculate answer
            //
            pR = pIA * (lR - iR) / 100d;

            mSC = (bI - pR) * 0.6;
            decimal mSC_d = new decimal(mSC / 100d);
            mSC = decimal.ToDouble(Math.Round(mSC_d, MidpointRounding.AwayFromZero)) * 100d;

            mE = pR + mSC;

            //
            // Set output
            //
            PureRebate = pR.ToString();
            MortgageServiceCharge = mSC.ToString();
            MarketingExpenses = mE.ToString();
        }
    }
}

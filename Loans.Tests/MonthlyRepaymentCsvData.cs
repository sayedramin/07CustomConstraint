using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Loans.Tests
{
    public class MonthlyRepaymentCsvData
    {
        public static IEnumerable GetTestCases(string csvFileName)
        {
            var csvLines = File.ReadAllLines(csvFileName);

            return (from line in csvLines select line.Replace(" ", "").Split(',') into values let principal = decimal.Parse(values[0]) let interestRate = decimal.Parse(values[1]) let termInYears = int.Parse(values[2]) let expectedRepayment = decimal.Parse(values[3]) select new TestCaseData(principal, interestRate, termInYears, expectedRepayment)).ToList();
        }
    }
}
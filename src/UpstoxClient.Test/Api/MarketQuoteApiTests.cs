/* 
 * OpenAPI definition
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using UpstoxClient.Client;
using UpstoxClient.Api;
using UpstoxClient.Model;

namespace UpstoxClient.Test
{
    /// <summary>
    ///  Class for testing MarketQuoteApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class MarketQuoteApiTests
    {
        private MarketQuoteApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new MarketQuoteApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of MarketQuoteApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' MarketQuoteApi
            //Assert.IsInstanceOfType(typeof(MarketQuoteApi), instance, "instance is a MarketQuoteApi");
        }

        /// <summary>
        /// Test GetFullMarketQuote
        /// </summary>
        [Test]
        public void GetFullMarketQuoteTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string symbol = null;
            //string apiVersion = null;
            //var response = instance.GetFullMarketQuote(symbol, apiVersion);
            //Assert.IsInstanceOf<GetFullMarketQuoteResponse> (response, "response is GetFullMarketQuoteResponse");
        }
        /// <summary>
        /// Test GetMarketQuoteOHLC
        /// </summary>
        [Test]
        public void GetMarketQuoteOHLCTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string symbol = null;
            //string interval = null;
            //string apiVersion = null;
            //var response = instance.GetMarketQuoteOHLC(symbol, interval, apiVersion);
            //Assert.IsInstanceOf<GetMarketQuoteOHLCResponse> (response, "response is GetMarketQuoteOHLCResponse");
        }
        /// <summary>
        /// Test Ltp
        /// </summary>
        [Test]
        public void LtpTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string symbol = null;
            //string apiVersion = null;
            //var response = instance.Ltp(symbol, apiVersion);
            //Assert.IsInstanceOf<GetMarketQuoteLastTradedPriceResponse> (response, "response is GetMarketQuoteLastTradedPriceResponse");
        }
    }

}

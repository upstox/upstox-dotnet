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
    ///  Class for testing TradeProfitAndLossApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class TradeProfitAndLossApiTests
    {
        private TradeProfitAndLossApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new TradeProfitAndLossApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of TradeProfitAndLossApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' TradeProfitAndLossApi
            //Assert.IsInstanceOfType(typeof(TradeProfitAndLossApi), instance, "instance is a TradeProfitAndLossApi");
        }

        /// <summary>
        /// Test GetProfitAndLossCharges
        /// </summary>
        [Test]
        public void GetProfitAndLossChargesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string segment = null;
            //string financialYear = null;
            //string apiVersion = null;
            //string fromDate = null;
            //string toDate = null;
            //var response = instance.GetProfitAndLossCharges(segment, financialYear, apiVersion, fromDate, toDate);
            //Assert.IsInstanceOf<GetProfitAndLossChargesResponse> (response, "response is GetProfitAndLossChargesResponse");
        }
        /// <summary>
        /// Test GetTradeWiseProfitAndLossData
        /// </summary>
        [Test]
        public void GetTradeWiseProfitAndLossDataTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string segment = null;
            //string financialYear = null;
            //int? pageNumber = null;
            //int? pageSize = null;
            //string apiVersion = null;
            //string fromDate = null;
            //string toDate = null;
            //var response = instance.GetTradeWiseProfitAndLossData(segment, financialYear, pageNumber, pageSize, apiVersion, fromDate, toDate);
            //Assert.IsInstanceOf<GetTradeWiseProfitAndLossDataResponse> (response, "response is GetTradeWiseProfitAndLossDataResponse");
        }
        /// <summary>
        /// Test GetTradeWiseProfitAndLossMetaData
        /// </summary>
        [Test]
        public void GetTradeWiseProfitAndLossMetaDataTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string segment = null;
            //string financialYear = null;
            //string apiVersion = null;
            //string fromDate = null;
            //string toDate = null;
            //var response = instance.GetTradeWiseProfitAndLossMetaData(segment, financialYear, apiVersion, fromDate, toDate);
            //Assert.IsInstanceOf<GetTradeWiseProfitAndLossMetaDataResponse> (response, "response is GetTradeWiseProfitAndLossMetaDataResponse");
        }
    }

}

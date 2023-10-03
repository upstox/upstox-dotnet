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
    ///  Class for testing UserApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class UserApiTests
    {
        private UserApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new UserApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of UserApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' UserApi
            //Assert.IsInstanceOfType(typeof(UserApi), instance, "instance is a UserApi");
        }

        /// <summary>
        /// Test GetProfile
        /// </summary>
        [Test]
        public void GetProfileTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string apiVersion = null;
            //var response = instance.GetProfile(apiVersion);
            //Assert.IsInstanceOf<GetProfileResponse> (response, "response is GetProfileResponse");
        }
        /// <summary>
        /// Test GetUserFundMargin
        /// </summary>
        [Test]
        public void GetUserFundMarginTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string apiVersion = null;
            //string segment = null;
            //var response = instance.GetUserFundMargin(apiVersion, segment);
            //Assert.IsInstanceOf<GetUserFundMarginResponse> (response, "response is GetUserFundMarginResponse");
        }
    }

}
